using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyImageCreator
{
    [Serializable]
    public class Region
    {
        public long startAddress = 0;
        public long endAddress = 0;
        public char startAddressDisplaySuffix;
        public char endAddressDisplaySuffix;
        public PatternType patternType = PatternType.Random;
        public string userDefinedFilePath = "";
        public byte[] userDefinedData = new byte[0];
        public bool checkerboard = false;
        public int checkerboardSize = 0;

        public Region(long startAddress, long endAddress, PatternType patternType, byte[] userDefinedData, char startAddressDisplaySuffix, char endAddressDisplaySuffix, string userDefinedFilePath, bool checkerboard, int checkerboardSize)
        {
            this.startAddress = startAddress;
            this.endAddress = endAddress;
            this.patternType = patternType;
            this.startAddressDisplaySuffix = startAddressDisplaySuffix;
            this.endAddressDisplaySuffix = endAddressDisplaySuffix;
            this.userDefinedFilePath = userDefinedFilePath;
            this.userDefinedData = userDefinedData;
            this.checkerboard = checkerboard;
            this.checkerboardSize = checkerboardSize;
        }

        public Region()
        {

        }

        //designed to generate chunks of data for streaming to files to prevent memory overflow
        public void generate(byte[] output, long index)
        {

        }


        public enum  PatternType
        {
            Random,
            Repeat,
            UserDef,
            UserDefFile
        }

        public override string ToString()
        {
            string s = Helper.decimalToAddrString(startAddress, startAddressDisplaySuffix) + " | " +
                       Helper.decimalToAddrString(endAddress, endAddressDisplaySuffix) + " | " + patternType.ToString();
            switch (patternType)
            {
                case PatternType.UserDefFile:
                    s += " | " + userDefinedFilePath.Split(new[] {"\\"}, StringSplitOptions.None).Last();
                    break;
                case PatternType.UserDef:
                    s += " | ";
                    int length = 4;
                    if (userDefinedData.Length <= 4)
                        s += Helper.ByteArrayToString(userDefinedData);
                    else
                    {
                        byte[] temp = new byte[4];
                        for (int i = 0; i < 4; i++)
                            temp[i] = userDefinedData[i];
                        s += Helper.ByteArrayToString(temp);
                    }
                    break;
            }

            if (checkerboard)
                s += " | Checkerboarded";
            return s;
        }

        public Region Clone()
        {
            //long startAddress, long endAddress, PatternType patternType, byte[] userDefinedData, char startAddressDisplaySuffix, char endAddressDisplaySuffix, string userDefinedFilePath
            return new Region(this.startAddress, this.endAddress, this.patternType, (userDefinedData).ToArray(), startAddressDisplaySuffix, endAddressDisplaySuffix, userDefinedFilePath, checkerboard, checkerboardSize);
        }
    }
}
