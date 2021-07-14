using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoiseCanvas.PRNG;

namespace DummyImageCreator
{
    public partial class ImageGenerator : Form
    {
        private readonly Pattern pattern;
        private StreamWriter sw;
        private Thread generatorThread;
        //128 megabyte chunk size seems to work well. this is the size of the generating data held in memory at any point in time, then flushed to disk
        //chunksize may be reduced if file is smaller than it
        private long chunkSize = 1024 * 1024 * 128;
        public ImageGenerator(Pattern pattern)
        {
            InitializeComponent();
            button_abort.Text = "Abort\n(remember to delete file remnants if you dont want them!)";
            this.pattern = pattern;
        }
        private void ImageGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            generatorThread?.Abort();
            sw.BaseStream.Close();
        }
        private void button_abort_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImageGenerator_Load(object sender, EventArgs e)
        {
            string fileName = DummyImageCreator.patternDirectory + (string.IsNullOrEmpty(pattern.patternFileName)
                ? pattern.generateFileName(false)
                : pattern.patternFileName);
            //Just declare an instance. im too lazy to check if its needed
            Well19937c well19937 = new Well19937c(fileName.GetHashCode() + pattern.getFileExtension().GetHashCode());

            //sort regions and perform auto-filling

            #region sortPatternsAndFillNull

            List<Region> generatorRegions = pattern.regions.ToList();
            generatorRegions = new List<Region>(generatorRegions.OrderBy(region => region.startAddress));
            List<Region> gapRegions = new List<Region>();

            long gap = generatorRegions[0].startAddress;
            //weird little conversion from lengths to indices here.
            if (gap > 1)
            {
                Region temp = new Region(0, generatorRegions[0].startAddress,
                    global::DummyImageCreator.Region.PatternType.UserDef, new[] {(byte) 0xFF}, 'h', 'h', "",
                    false, 0);
                gapRegions.Add(temp);
            }

            for (int i = 1; i < generatorRegions.Count - 1; i++)
            {
                gap = generatorRegions[i + 1].startAddress - generatorRegions[i].endAddress;
                //weird little conversion from lengths to indices here.
                if (gap > 1)
                {
                    Region temp = new Region(generatorRegions[i].endAddress + 1, generatorRegions[i + 1].startAddress,
                        global::DummyImageCreator.Region.PatternType.UserDef, new[] {(byte) 0xFF}, 'h', 'h', "",
                        false, 0);
                    gapRegions.Add(temp);
                }
            }

            generatorRegions.AddRange(gapRegions);
            generatorRegions = new List<Region>(generatorRegions.OrderBy(region => region.startAddress));

            #endregion


            long startOfFile = generatorRegions[0].startAddress;
            long endOfFile = generatorRegions[generatorRegions.Count - 1].endAddress;
            if (pattern.maxImageSize > 0)
                endOfFile = pattern.maxImageSize;

            if (File.Exists(fileName))
                File.Delete(fileName);
            generatorThread = new Thread(delegate()
            {
                //always start with binary file
                sw = File.AppendText(fileName + ".bin");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                long timeTaken = 0;
                for (int i = 0; i < generatorRegions.Count; i++)
                {
                    Region region = generatorRegions[i];
                    var startAddr = region.startAddress;
                    var endAddr = region.endAddress;
                    if (pattern.maxImageSize > 0)
                    {
                        if (startAddr > pattern.maxImageSize)
                            goto EndOfWrite;
                        if (endAddr > pattern.maxImageSize)
                            endAddr = pattern.maxImageSize;
                    }

                    long amountToWrite = endAddr - startAddr + 1;

                    if (amountToWrite < chunkSize)
                        chunkSize = amountToWrite;

                    //the following indexes keep track of things across multiple write flushes
                    //for user-defined data indexing
                    int regionInternalIndex = 0;
                    byte[] dataBytes = new byte[chunkSize];
                    //for checkerboard indexing. cant just have one index because you might have userDefined checkerboarding
                    int checkerboardIndex = 0;
                    bool checkerboarding = false;

                    byte[] staticDataBytes =
                    {
                        0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF
                    };
                    if (region.patternType == global::DummyImageCreator.Region.PatternType.UserDef ||
                        region.patternType == global::DummyImageCreator.Region.PatternType.UserDefFile)
                        staticDataBytes = region.userDefinedData;
                    while (amountToWrite > 0)
                    {
                        //NOTE*** databytes.length is our reference for how much we have to program. neither of these variables hold the final value
                        if (amountToWrite < chunkSize)
                        {
                            dataBytes = new byte[amountToWrite];
                            amountToWrite = 0;
                        }
                        else
                        {
                            amountToWrite -= chunkSize;
                            //not needed because the previous case will only ever happen at the last iteration
                            //dataBytes = new byte[chunkSize];
                        }


                        switch (region.patternType)
                        {
                            case global::DummyImageCreator.Region.PatternType.Random:
                                if (region.checkerboard)
                                {
                                    int dataBytesIndex = 0;

                                    while (dataBytesIndex < dataBytes.Length)
                                    {
                                        if (checkerboardIndex >= region.checkerboardSize)
                                        {
                                            checkerboarding = !checkerboarding;
                                            checkerboardIndex = 0;
                                        }
                                        int checkerBoardAmountToWrite = region.checkerboardSize - checkerboardIndex;
                                        if (dataBytesIndex + checkerBoardAmountToWrite >= dataBytes.Length)
                                        {
                                            checkerBoardAmountToWrite = dataBytes.Length - dataBytesIndex;
                                        }
                                        checkerboardIndex += checkerBoardAmountToWrite;

                                        if (checkerboarding)
                                        {
                                            for (int j = 0; j < checkerBoardAmountToWrite; j++)
                                            {
                                                dataBytes[dataBytesIndex + j] = 0xFF;
                                            }
                                        }
                                        else well19937.nextBytes(dataBytes, dataBytesIndex, checkerBoardAmountToWrite);

                                        dataBytesIndex += checkerBoardAmountToWrite;
                                    }
                                }
                                else well19937.nextBytes(dataBytes);

                                break;
                            //userDef and userDefFile and repeat because its all stored in the same array
                            #region userDefinedData
                            default:
                                if (region.checkerboard)
                                {
                                    int dataBytesIndex = 0;

                                    while (dataBytesIndex < dataBytes.Length)
                                    {
                                        if (checkerboardIndex >= region.checkerboardSize)
                                        {
                                            checkerboarding = !checkerboarding;
                                            checkerboardIndex = 0;
                                        }
                                        int checkerBoardAmountToWrite = region.checkerboardSize - checkerboardIndex;
                                        if (dataBytesIndex + checkerBoardAmountToWrite >= dataBytes.Length)
                                        {
                                            checkerBoardAmountToWrite = dataBytes.Length - dataBytesIndex;
                                        }
                                        checkerboardIndex += checkerBoardAmountToWrite;

                                        if (checkerboarding)
                                        {
                                            for (int j = 0; j < checkerBoardAmountToWrite; j++)
                                            {
                                                dataBytes[dataBytesIndex + j] = 0xFF;
                                            }
                                        }
                                        else
                                        {
                                            //well19937.nextBytes(dataBytes, dataBytesIndex, checkerBoardAmountToWrite);
                                            int amountWritten = 0;
                                            for (int j = 0; j < checkerBoardAmountToWrite;)
                                            {
                                                //if (checkerBoardAmountToWrite - staticDataBytes.Length >= j)
                                                {
                                                    //checks if there was carry-over from last write flush
                                                    if (regionInternalIndex > 0)
                                                    {
                                                        Buffer.BlockCopy(staticDataBytes, regionInternalIndex, dataBytes, dataBytesIndex + j, staticDataBytes.Length - regionInternalIndex);
                                                        amountWritten += staticDataBytes.Length - regionInternalIndex;
                                                        j += staticDataBytes.Length - regionInternalIndex;
                                                        regionInternalIndex = 0;
                                                        
                                                    }
                                                    else
                                                    {
                                                        Buffer.BlockCopy(staticDataBytes, 0, dataBytes, dataBytesIndex + j, staticDataBytes.Length);
                                                        amountWritten += staticDataBytes.Length;
                                                        j += staticDataBytes.Length;
                                                    }
                                                }
                                            }

                                            int remainder = checkerBoardAmountToWrite % staticDataBytes.Length;
                                            if (remainder > 0)
                                            {
                                                Buffer.BlockCopy(staticDataBytes, 0, dataBytes, amountWritten + dataBytesIndex, remainder);
                                                regionInternalIndex = remainder;
                                            }
                                        }

                                        dataBytesIndex += checkerBoardAmountToWrite;
                                    }
                                }
                                else
                                {
                                    for (int j = 0; j < dataBytes.Length; j += staticDataBytes.Length)
                                    {
                                        if (dataBytes.Length - staticDataBytes.Length >= j)
                                        {
                                            //checks if there was carry-over from last write flush
                                            if (regionInternalIndex > 0)
                                            {
                                                Buffer.BlockCopy(staticDataBytes, regionInternalIndex, dataBytes, j, staticDataBytes.Length - regionInternalIndex);
                                                regionInternalIndex = 0;
                                            }
                                            else Buffer.BlockCopy(staticDataBytes, 0, dataBytes, j, staticDataBytes.Length);
                                        }
                                    }

                                    int remainder = dataBytes.Length % staticDataBytes.Length;
                                    if (remainder > 0)
                                    {
                                        Buffer.BlockCopy(staticDataBytes, 0, dataBytes, dataBytes.Length - remainder, remainder);
                                        regionInternalIndex = staticDataBytes.Length - remainder;
                                    }
                                }
                                #endregion
                                break;
                        }

                        sw.BaseStream.Write(dataBytes, 0, dataBytes.Length);
                        if (stopwatch.ElapsedMilliseconds - timeTaken > 1000)
                        {
                            timeTaken = stopwatch.ElapsedMilliseconds;
                            try
                            {
                                var write = amountToWrite;
                                Invoke(new Action(() => { richTextBox_log.AppendText(((decimal)(100 - (write / ((double) (endOfFile - startOfFile)) * 100))).ToString("#.##") + "% complete   " + stopwatch.Elapsed.Seconds + " seconds elapsed.\n"); }));
                            }
                            catch
                            {
                                //this can happen when the form is aborted at the right time. It is ugly to do this but its short and it works.
                            }
                        }
                    }
                }

                EndOfWrite:
                sw.BaseStream.Close();

                Invoke(new Action(() =>
                {
                    richTextBox_log.AppendText("File Write Complete.");
                }));

                if (pattern.patternFileFormat != Pattern.PatternFileFormat.Binary)
                {
                    //this particular converter has no logging
                    //http://srecord.sourceforge.net/man/man1/srec_cat.html for advanced tweaking of options (especially for motorola format)

                    string args;
                    if (pattern.patternFileFormat == Pattern.PatternFileFormat.IntelHex)
                        args = "\"" + fileName + ".bin\" -binary -o \"" + fileName + ".hex\" -intel";
                    else args = "\"" + fileName + ".bin\" -binary -o \"" + fileName + "\".srec -motorola";
                    Process fileConverter = new Process
                    {
                        StartInfo = {FileName = "srec_cat.exe",Arguments = args}
                    };
                    fileConverter.Start();
                    fileConverter.WaitForExit();
                    Invoke(new Action(() =>
                    {
                        richTextBox_log.AppendText("File Conversion Complete.");
                    }));
                }
                
                Invoke(new Action(Close));

            });
            generatorThread.Start();
        }
    }
}