using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DummyImageCreator
{
    [Serializable]
    public class Pattern
    {
        public List<Region> regions;
        public long maxImageSize;
        public char maxImageSizeSuffix;
        public string patternFileName;
        public PatternFileFormat patternFileFormat;
        public Pattern(List<Region> regions, long maxImageSize, char maxImageSizeSuffix, string patternFileName, PatternFileFormat patternFileFormat)
        {
            this.regions = regions;
            this.maxImageSize = maxImageSize;
            this.maxImageSizeSuffix = maxImageSizeSuffix;
            this.patternFileName = patternFileName;
            this.patternFileFormat = patternFileFormat;
        }

        public Pattern(List<Region> regions)
        {
            this.regions = regions;
        }

        public enum PatternFileFormat
        {
            Binary,
            IntelHex,
            MotorolaHex
        }

        /// <summary>
        /// saves the pattern to a file so it can be loaded later. does not generate the actual image
        /// </summary>
        public int savePattern()
        {
            string fullFilePath = DummyImageCreator.patternDirectory;

            if (!Directory.Exists(fullFilePath))
                Directory.CreateDirectory(fullFilePath);

            if (string.IsNullOrEmpty(patternFileName))
                fullFilePath += generateFileName(true);
            else
                fullFilePath += patternFileName;

            fullFilePath += ".ptn";

            if (File.Exists(fullFilePath))
                return -1;

            Helper.WriteToBinaryFile(fullFilePath, this, false);
            return 0;
        }

        public string getFileExtension()
        {
            switch (patternFileFormat)
            {
                case PatternFileFormat.Binary:
                    return ".bin";
                case PatternFileFormat.IntelHex:
                    return ".hex";
                case PatternFileFormat.MotorolaHex:
                    return ".srec";
                default:
                    return "";
            }
        }

        /// <summary>
        /// auto-generates a filename for the current pattern based off its attributes
        /// </summary>
        public string generateFileName(bool trueIfPatternFile)
        {


            StringBuilder sb = new StringBuilder();

            // switch (patternFileFormat)
            // {
            //     case PatternFileFormat.Binary:
            //         sb.Append("BIN");
            //         break;
            //     case PatternFileFormat.IntelHex:
            //         sb.Append("IHEX");
            //         break;
            //     case PatternFileFormat.MotorolaHex:
            //         sb.Append("MHEX");
            //         break;
            // }

            //sb.Append(trueIfPatternFile ? "VICPTN " : "VICIMG ");
            sb.Append("VIC ");

            if (regions.Count == 0)
            {
                return "empty" + getFileExtension();
            }
            long startOfFile = regions[0].startAddress;
            long endOfFile = regions[regions.Count - 1].endAddress;

            sb.Append(Helper.decimalToAddrString(startOfFile, regions[0].startAddressDisplaySuffix) + "-" +
                      Helper.decimalToAddrString(endOfFile, regions[regions.Count - 1].endAddressDisplaySuffix));
            sb.Append(" ");

            bool allSameRegionPattern = true;
            Region.PatternType regionPattern = regions[0].patternType;
            for (int i = 0; i < regions.Count; i++)
            {
                if (regions[i].patternType != regionPattern)
                {
                    allSameRegionPattern = false;
                    break;
                }
            }

            if (allSameRegionPattern)
            {
                sb.Append(regionPattern.ToString()).Append("");
            }
            else
            {
                int maxIndex = 4;
                if (regions.Count < 4)
                    maxIndex = regions.Count;
                for (int i = 0; i < maxIndex; i++)
                {
                    sb.Append(regions[i].patternType.ToString()).Append("-");
                }
            }

            return sb.ToString();
        }
    }
}
