using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyImageCreator
{
    public partial class RegionMaker : Form
    {
        private readonly List<Region> _definedRegions;
        private readonly int _thisIndex;
        public static string validSuffixes = "hdkmg";

        public Region ReturnRegion { get; set; }

        public RegionMaker(List<Region> definedRegions, int thisIndex)
        {
            InitializeComponent();
            toolTip_regionMaker.SetToolTip(checkBox_checkerboard, "\"Checkerboarding\" will cause the entire region to alternate\n" + 
                                                                  " from its programmed data to blank data, and back again.\n" +
                                                                  " The size of these chunks is determined by the corresponding numeric up-down box");
            toolTip_regionMaker.SetToolTip(checkBox_startAtClosestBoundary, "closest boundary means: start at the number which is equal to\n" + 
                                                                                  "(largest region address so far) + 1");
            this._definedRegions = definedRegions;
            this._thisIndex = thisIndex;

            //force the checkedChange method to fire so we get something to fill in the textbox initially
            checkBox_startAtClosestBoundary.Checked = true;
            numericUpDown_checkerboardSize.Enabled = checkBox_checkerboard.Checked;
        }

        public RegionMaker(Region oldRegion, List<Region> definedRegions, int thisIndex)
        {
            InitializeComponent();

            this._definedRegions = definedRegions;
            this._thisIndex = thisIndex;

            textBox_startAddress.Text = Helper.decimalToAddrString(oldRegion.startAddress, oldRegion.startAddressDisplaySuffix);
            textBox_endAddress.Text = Helper.decimalToAddrString(oldRegion.endAddress, oldRegion.endAddressDisplaySuffix);
            richTextBox_userDefinedData.Text = Helper.ByteArrayToString(oldRegion.userDefinedData);
            textBox_userDefinedFileLocation.Text = oldRegion.userDefinedFilePath;
            switch (oldRegion.patternType)
            {
                case global::DummyImageCreator.Region.PatternType.Random:
                    radioButton_patternTypeRandom.Checked = true;
                    break;
                case global::DummyImageCreator.Region.PatternType.Repeat:
                    radioButton_patternTypeRepeat.Checked = true;
                    break;
                case global::DummyImageCreator.Region.PatternType.UserDef:
                    radioButton_patternTypeUserDefined.Checked = true;
                    break;
                case global::DummyImageCreator.Region.PatternType.UserDefFile:
                    radioButton_patternTypeUserDefinedFile.Checked = true;
                    break;
            }

            if (oldRegion.checkerboard)
            {
                checkBox_checkerboard.Checked = true;
                numericUpDown_checkerboardSize.Value = oldRegion.checkerboardSize;
            }
            else numericUpDown_checkerboardSize.Enabled = false;
            updateLengthTextBox();
        }


        private void button_save_Click(object sender, EventArgs e)
        {
            Region region = new Region();
            /*
             * list of checks
             * invalid start-end range (invalid length)
             * overlapping existing data regions
             * user-defined data parsing problems
             * invalid file location / file access
             * 
             */

            long startAddress = Helper.addrStringToDecimal(textBox_startAddress.Text);
            long endAddress = Helper.addrStringToDecimal(textBox_endAddress.Text);
            if (startAddress == -1)
            {
                MessageBox.Show(@"ERROR: Start Address is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endAddress == -1)
            {
                MessageBox.Show(@"ERROR: End Address is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startAddress == -2)
            {
                MessageBox.Show(@"ERROR: Start Address does not have a valid suffix.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (endAddress == -2)
            {
                MessageBox.Show(@"ERROR: End Address does not have a valid suffix.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (startAddress == -3)
            {
                MessageBox.Show(@"ERROR: Start Address contains illegal characters.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (endAddress == -3)
            {
                MessageBox.Show(@"ERROR: End Address contains illegal characters.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (endAddress - startAddress < 0)
            {
                MessageBox.Show(@"ERROR: Start Address -> End Address is less than 0, so it is an empty region.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            region.startAddress = startAddress;
            region.endAddress = endAddress;
            region.startAddressDisplaySuffix = textBox_startAddress.Text.Last();
            region.endAddressDisplaySuffix = textBox_endAddress.Text.Last();

            Region.PatternType patternType;
            if (radioButton_patternTypeRandom.Checked)
                patternType = global::DummyImageCreator.Region.PatternType.Random;
            else if (radioButton_patternTypeRepeat.Checked)
                patternType = global::DummyImageCreator.Region.PatternType.Repeat;
            else if (radioButton_patternTypeUserDefined.Checked)
                patternType = global::DummyImageCreator.Region.PatternType.UserDef;
            else
                patternType = global::DummyImageCreator.Region.PatternType.UserDefFile;
            region.patternType = patternType;

            if (checkBox_checkerboard.Checked)
            {
                if (numericUpDown_checkerboardSize.Value > endAddress - startAddress)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        @"WARN: Checkerboard size is greater than memory region. This will effectively disable checkerboarding. Are you sure you want to do this?",
                        "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Cancel)
                        return;
                }
                region.checkerboard = true;
                region.checkerboardSize = (int) numericUpDown_checkerboardSize.Value;
            }


            if (patternType == global::DummyImageCreator.Region.PatternType.UserDef)
            {
                string userDef = richTextBox_userDefinedData.Text.Replace(" ", "").Replace("\n", "").ToUpper();
                if (userDef.Length % 2 != 0)
                {
                    MessageBox.Show(@"ERROR: User-defined data is missing a complete pair (odd-length detected)", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < userDef.Length; i++)
                {
                    if (!"0123456789ABCDEF".Contains(userDef[i]))
                    {
                        MessageBox.Show("@ERROR: User-Defined Data contains characters that are not part of a valid hex string (exclusing space and enter)", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                byte[] userDefBytes = new byte[userDef.Length / 2];
                for (int i = 0; i < userDef.Length; i += 2)
                {

                    int a;
                    if (userDef[i] < 'A')
                        a = userDef[i] - '0';
                    else a = userDef[i] - 55;//A - 10
                    int b;
                    if (userDef[i] < 'A')
                        b = userDef[i + 1] - '0';
                    else b = userDef[i + 1] - 55;//A - 10
                    userDefBytes[i / 2] = (byte) ((a << 4) + b);
                }

                region.userDefinedData = userDefBytes;
            }

            if (patternType == global::DummyImageCreator.Region.PatternType.UserDefFile)
            {
                if (!File.Exists(textBox_userDefinedFileLocation.Text))
                {
                    MessageBox.Show(@"ERROR: File does not exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                region.userDefinedFilePath = textBox_userDefinedFileLocation.Text;
            }

            //do this check close to last because it may require user input
            for (int i = 0; i < _definedRegions.Count; i++)
            {
                if ((startAddress <= _definedRegions[i].endAddress && endAddress >= _definedRegions[i].startAddress))
                {
                    DialogResult diagResult = MessageBox.Show("WARN: current region will overlap existing data.\n" +
                                                              "The region with a lower starting address (i.e. starts sooner) will take precedence.\n" +
                                                              "Hit OK to continue or Cancel to stop.", "",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (diagResult == DialogResult.Cancel)
                        return;
                    break;
                }
            }


            //end
            ReturnRegion = region;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_browseForUserDefinedFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {Filter = @"All Files (*.*)|*.*"};
            DialogResult diagResult = openFileDialog.ShowDialog();
            if (diagResult != DialogResult.OK)
                return;
            textBox_userDefinedFileLocation.Text = openFileDialog.FileName;
            radioButton_patternTypeUserDefinedFile.Checked = true;
        }

        private void richTextBox_userDefinedData_TextChanged(object sender, EventArgs e)
        {
            radioButton_patternTypeUserDefined.Checked = true;
            int selectionStart = richTextBox_userDefinedData.SelectionStart;
            int selectionLength = richTextBox_userDefinedData.SelectionLength;
            richTextBox_userDefinedData.Text = richTextBox_userDefinedData.Text.ToUpper();
            richTextBox_userDefinedData.SelectionStart = selectionStart;
            richTextBox_userDefinedData.SelectionLength = selectionLength;
        }

        private void textBox_userDefinedFileLocation_TextChanged(object sender, EventArgs e)
        {
            radioButton_patternTypeUserDefinedFile.Checked = true;
        }

        private void checkBox_startAtClosestBoundary_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_startAtClosestBoundary.Checked)
            {
                textBox_startAddress.ReadOnly = false;
                return;
            }

            textBox_startAddress.ReadOnly = true;
            //if we start at 0 there is nothing before us, account for that.
            long lastBoundary = 0;
            if (_definedRegions.Count > 0)
                lastBoundary = _definedRegions[_thisIndex].endAddress + 1;
            //figure out if the user already has a start address entered. then check the format they gave, then match it.
            if (textBox_startAddress.Text.Length > 0)
            {
                char suffix = textBox_startAddress.Text.Last();
                if (validSuffixes.Contains(suffix))
                {
                    //this is all we need to do because the save function reads data from the textbox
                    textBox_startAddress.Text = Helper.decimalToAddrString(lastBoundary, suffix);
                    //WATCH OUT for the return here
                    return;
                }
            }

            //default to hex
            textBox_startAddress.Text = Helper.decimalToAddrString(lastBoundary, 'h');
        }

        /// <summary>
        /// update the length textbox with the new value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_endAddress_KeyUp(object sender, KeyEventArgs e)
        {
            updateLengthTextBox();
        }

        /// <summary>
        /// update the endAddress textbox with the new value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_length_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox_length.Text.Length <= 0) return;
            long lengthValue = Helper.addrStringToDecimal(textBox_length.Text);
            long startAddrValue = Helper.addrStringToDecimal(textBox_startAddress.Text);
            if (lengthValue < 0 || startAddrValue < 0)
                return;
            //at this point we know that the textbox contains a valid addr-type string
            char suffix = textBox_length.Text.Last();
            long newval = lengthValue + startAddrValue - 1;
            textBox_endAddress.Text = Helper.decimalToAddrString(newval, 'h');
        }

        private void updateLengthTextBox()
        {
            if (textBox_endAddress.Text.Length <= 0) return;
            long endAddrValue = Helper.addrStringToDecimal(textBox_endAddress.Text);
            long startAddrValue = Helper.addrStringToDecimal(textBox_startAddress.Text);
            if (endAddrValue < 0 || startAddrValue < 0)
                return;
            //at this point we know that the textbox contains a valid addr-type string
            char suffix = textBox_endAddress.Text.Last();
            long newval = endAddrValue - startAddrValue + 1;
            if (newval < 0)
                newval = 0;
            textBox_length.Text = Helper.decimalToAddrString(newval, 'h');
        }

        private void checkBox_checkerboard_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_checkerboardSize.Enabled = checkBox_checkerboard.Checked;
        }

        private void textBox_startAddress_KeyUp(object sender, KeyEventArgs e)
        {
            updateLengthTextBox();
        }
    }
}