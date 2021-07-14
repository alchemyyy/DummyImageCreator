using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NoiseCanvas.PRNG;

/*
 *
 * Create by Isaac Jones
 * Please don't judge this code its really hacky
 *
 */
namespace WELLDummyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string fileSizeString;
                bool fileSizeStringReadCorrectly = false;
                double fileSizeBase = 0;
                long multiplier = 1;
                string multiplierString = "";
                do
                {
                    Console.WriteLine(
                        "Please specify size: # or #kb or #mb or #gb (# is an integer). or specify 0xXXXXXetc to give a hex number in bytes leave blank to exit");
                    fileSizeString = Console.ReadLine();
                    if (fileSizeString == null)
                        return;

                    //parse multiplier suffix correctly. no default case in switch because it is already handled at declaration

                    //only do the parsing if we know we have to.
                    if (fileSizeString.EndsWith("b"))
                    {
                        multiplierString = fileSizeString.Substring(fileSizeString.Length - 2);
                        switch (multiplierString)
                        {
                            case "kb":
                                multiplier = 1024;
                                break;
                            case "mb":
                                multiplier = 1024 * 1024;
                                break;
                            case "gb":
                                multiplier = 1024 * 1024 * 1024;
                                break;
                        }

                        fileSizeStringReadCorrectly = double.TryParse(
                            fileSizeString.Substring(0, fileSizeString.Length - 2),
                            out fileSizeBase);
                    }
                    else
                    {
                        if (fileSizeString.StartsWith("0x"))
                        {
                            fileSizeStringReadCorrectly = ulong.TryParse(fileSizeString.Substring(2), NumberStyles.HexNumber,
                                CultureInfo.CurrentCulture, out ulong temp);
                            if (!fileSizeStringReadCorrectly) continue;
                            fileSizeBase = Convert.ToDouble(temp);
                            multiplierString = "hex";
                        } 
                        else fileSizeStringReadCorrectly = double.TryParse(fileSizeString,
                            out fileSizeBase);
                    }
                } while (!fileSizeStringReadCorrectly);

                //get a file name and check to see if it already exists
                Console.WriteLine("please specify file name: (leave blank to use default filename scheme)");
                string fileName = Console.ReadLine();
                if (multiplierString == "")
                    multiplierString = "byte";
                if (fileName == "")
                {
                    if (multiplierString != "hex")
                        fileName = "randomdata_" + multiplierString + "_" + fileSizeBase + "_v";
                    else fileName = "randomdata_" + fileSizeString + "_v";
                }

                int fileCounter = 0;
                while (Directory
                    .EnumerateFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories)
                    .Select(Path.GetFileName).Contains(fileName + fileCounter + ".bin"))
                {
                    fileCounter++;
                }

                fileName += fileCounter;


                Console.WriteLine("Specify seed (string): (leave blank to use random string)");
                string seedString = Console.ReadLine();
                if (seedString == "")
                    seedString = new Random().NextDouble().ToString(CultureInfo.CurrentCulture);

                long amount = (long)Math.Round((fileSizeBase * multiplier));
                Well19937c well = new Well19937c(seedString.GetHashCode());
                long chunk = 1024 * 1024 * 64;
                byte[] dataBytes = new byte[chunk];
                StreamWriter sw = File.AppendText(fileName + ".bin");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                long timeTaken = 0;
                long originalAmount = amount;
                while (amount > 0)
                {
                    //when we hti the end and it doesn't end on a chunk we need to deal with that
                    if (amount < chunk)
                    {
                        dataBytes = new byte[amount];
                        amount = 0;
                    }
                    else amount -= chunk;

                    well.nextBytes(dataBytes);
                    sw.BaseStream.Write(dataBytes, 0, dataBytes.Length);
                    if (stopwatch.ElapsedMilliseconds - timeTaken > 1000)
                    {
                        timeTaken = stopwatch.ElapsedMilliseconds;
                        Console.WriteLine(100 - (amount / ((double)originalAmount) * 100) + "% complete" );
                    }
                }
                sw.BaseStream.Close();
                Console.WriteLine("FILE COMPLETED");
                Console.WriteLine("\n");
            }
        }
    }
}
