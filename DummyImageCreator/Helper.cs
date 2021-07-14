using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyImageCreator
{
    static class Helper
    {
        /// <summary>
        /// converts an address-type string to decimal
        /// return codes:
        /// -1 empty string
        /// -2 invalid suffix
        /// -3 illegal char present
        /// </summary>
        /// <param name="addrString">The address-type string to enter (d h k m g)</param>
        /// <returns></returns>
        public static long addrStringToDecimal(string addrString)
        {
            if (addrString.Length < 1)
            {
                return -1;
            }

            char suffix = addrString.Last();
            string valueString = addrString.Substring(0, addrString.Length - 1).ToUpper();
            for (int i = 0; i < valueString.Length; i++)
            {
                if (!"0123456789".Contains(valueString[i]))
                {
                    if (suffix != 'h')
                        return -3;
                    if (!"ABCDEF".Contains(valueString[i]))
                        return -3;
                }
            }
            switch (suffix)
            {
                case 'd':
                    return Convert.ToInt64(valueString);
                case 'h':
                    return long.Parse(valueString, System.Globalization.NumberStyles.HexNumber);
                case 'k':
                    return Convert.ToInt64(valueString) * 1024;
                case 'm':
                    return Convert.ToInt64(valueString) * 1024 * 1024;
                case 'g':
                    return Convert.ToInt64(valueString) * 1024 * 1024 * 1024;
                default:
                    return -2;
            }
        }

        /// <summary>
        /// converts a decimal-base value to an address-type string
        /// return codes:
        /// null, suffix was not valid
        /// </summary>
        /// <param name="num"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string decimalToAddrString(long num, char suffix)
        {
            switch (suffix)
            {
                case 'd':
                    return num + "d";
                case 'h':
                    return num.ToString("X") + "h";
                case 'k':
                    return (num / 1024) + "k";
                case 'm':
                    return (num / 1024 / 1024) + "m";
                case 'g':
                    return (num / 1024 / 1024 / 1024) + "g";
                default:
                    return null;
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-","");
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the binary file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the binary file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the binary file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return (T)binaryFormatter.Deserialize(stream);
                }
            }
            catch
            {
                MessageBox.Show(@"ERROR: Cannot read filetype. are you sure this is a valid saved pattern?", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (T)(object)new Pattern(null);
        }
    }
}
