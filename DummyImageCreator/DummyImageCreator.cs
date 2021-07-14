using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyImageCreator
{
    public partial class DummyImageCreator : Form
    {
        public static string patternDirectory;
        public DummyImageCreator()
        {
            InitializeComponent();
            patternDirectory = Directory.GetCurrentDirectory() + "\\DummyImageCreatorPatterns\\";
            toolTip_imageCreator.SetToolTip(button_SaveImagePattern, "This will save the current settings you have entered, which can then\n" +
                                                                           "be used to regenerate the image later. This uses the same file name as the generated image\n" + 
                                                                           "but with a different file extension");
        }

        private Pattern imagePattern = new Pattern(new List<Region>());
        private void button_ifcMoveUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void button_ifcMoveDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (listBox_imageFileContents.SelectedItem == null || listBox_imageFileContents.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox_imageFileContents.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox_imageFileContents.Items.Count)
                return; // Index out of range - nothing to do


            // Removing removable element
            Region tempRegion = imagePattern.regions[listBox_imageFileContents.SelectedIndex];
            string tempString = listBox_imageFileContents.Items[listBox_imageFileContents.SelectedIndex] as string;
            imagePattern.regions.RemoveAt(listBox_imageFileContents.SelectedIndex);
            listBox_imageFileContents.Items.RemoveAt(listBox_imageFileContents.SelectedIndex);
            // Insert it in new position
            imagePattern.regions.Insert(newIndex, tempRegion);
            listBox_imageFileContents.Items.Insert(newIndex, tempString ?? string.Empty);

            // Restore selection
            listBox_imageFileContents.SetSelected(newIndex, true);
        }

        private void button_ifcClone_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox_imageFileContents.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show(@"ERROR: Please select a region to clone.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Region newRegion = imagePattern.regions[selectedIndex].Clone();
            imagePattern.regions.Insert(selectedIndex, newRegion);
            listBox_imageFileContents.Items.Insert(selectedIndex, newRegion.ToString());
        }

        private void button_ifcEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox_imageFileContents.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show(@"ERROR: Please select a region to edit.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Region tempRegion = imagePattern.regions[selectedIndex];
            imagePattern.regions.RemoveAt(selectedIndex);
            RegionMaker regionMaker = new RegionMaker(tempRegion, imagePattern.regions, selectedIndex);
            DialogResult dialogResult = regionMaker.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                imagePattern.regions.Insert(selectedIndex, tempRegion);
                return;
            }

            imagePattern.regions.Insert(selectedIndex, regionMaker.ReturnRegion);
            listBox_imageFileContents.Items.RemoveAt(selectedIndex);
            listBox_imageFileContents.Items.Insert(selectedIndex, imagePattern.regions[selectedIndex]);
        }

        private void button_ifcDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox_imageFileContents.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show(@"ERROR: Please select a region to delete.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            imagePattern.regions.RemoveAt(selectedIndex);
            listBox_imageFileContents.Items.RemoveAt(selectedIndex);
            if (selectedIndex > 0)
                listBox_imageFileContents.SelectedIndex = selectedIndex - 1;
            else if (listBox_imageFileContents.Items.Count > 0)
                listBox_imageFileContents.SelectedIndex = 0;
        }

        private void button_ifcInsert_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox_imageFileContents.SelectedIndex;
            if (selectedIndex < 0)
                selectedIndex = listBox_imageFileContents.Items.Count - 1;
            if (selectedIndex < 0)
                selectedIndex = 0;
            RegionMaker regionMaker = new RegionMaker(imagePattern.regions, selectedIndex);
            DialogResult diagResult = regionMaker.ShowDialog();
            if (diagResult != DialogResult.OK)
                return;

            if (selectedIndex < imagePattern.regions.Count)
            {
                imagePattern.regions.Insert(selectedIndex + 1, regionMaker.ReturnRegion);
                listBox_imageFileContents.Items.Insert(selectedIndex + 1, regionMaker.ReturnRegion.ToString());
                listBox_imageFileContents.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                imagePattern.regions.Add(regionMaker.ReturnRegion);
                listBox_imageFileContents.Items.Add(regionMaker.ReturnRegion.ToString());
                listBox_imageFileContents.SelectedIndex = selectedIndex;
            }
        }

        private void button_SaveImagePattern_Click(object sender, EventArgs e)
        {
            int result = imagePattern.savePattern();
            if (result == -1)
            {
                MessageBox.Show(@"ERROR: File already exists. Please delete it or change this file name", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button_ifcLoadSavedImage_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(patternDirectory))
                Directory.CreateDirectory(patternDirectory);
            OpenFileDialog ofd = new OpenFileDialog {InitialDirectory = patternDirectory};
            DialogResult dialogResult = ofd.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            Pattern tempPattern = Helper.ReadFromBinaryFile<Pattern>(ofd.FileName);
            if (tempPattern.regions == null)
            {
                return;
            }

            imagePattern = tempPattern;


            textBox_maxImageSize.Text =
                Helper.decimalToAddrString(imagePattern.maxImageSize, imagePattern.maxImageSizeSuffix);
            textBox_imageSaveName.Text = imagePattern.patternFileName;

            listBox_imageFileContents.Items.Clear();
            for (int i = 0; i < imagePattern.regions.Count; i++)
            {
                listBox_imageFileContents.Items.Add(imagePattern.regions[i]);
            }

            switch (imagePattern.patternFileFormat)
            {
                case Pattern.PatternFileFormat.Binary:
                    radioButton_fileFormatBinary.Checked = true;
                    break;
                case Pattern.PatternFileFormat.IntelHex:
                    radioButton_fileFormatIntelHex.Checked = true;
                    break;
                case Pattern.PatternFileFormat.MotorolaHex:
                    radioButton_FileFormatMotorolaHex.Checked = true;
                    break;
            }


        }

        private void radioButton_fileFormatBinary_CheckedChanged(object sender, EventArgs e)
        {
            imagePattern.patternFileFormat = Pattern.PatternFileFormat.Binary;
        }

        private void radioButton_FileFormatMotorolaHex_CheckedChanged(object sender, EventArgs e)
        {
            imagePattern.patternFileFormat = Pattern.PatternFileFormat.MotorolaHex;
        }

        private void radioButton_fileFormatIntelHex_CheckedChanged(object sender, EventArgs e)
        {
            imagePattern.patternFileFormat = Pattern.PatternFileFormat.IntelHex;
        }

        private void textBox_imageSaveName_TextChanged(object sender, EventArgs e)
        {
            imagePattern.patternFileName = textBox_imageSaveName.Text;
        }

        private void textBox_maxImageSize_TextChanged(object sender, EventArgs e)
        {
            long temp = Helper.addrStringToDecimal(textBox_maxImageSize.Text);
            if (temp >= 0)
            {
                imagePattern.maxImageSize = temp;
                imagePattern.maxImageSizeSuffix = textBox_maxImageSize.Text.Last();
            }
        }

        private void button_GenerateImage_Click(object sender, EventArgs e)
        {
            if (imagePattern.regions.Count < 1)
            {
                MessageBox.Show("Cannot generate image, no patterns exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new ImageGenerator(imagePattern).Show();
        }

        private void button_openAppFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(patternDirectory))
                Directory.CreateDirectory(patternDirectory);
            Process.Start(patternDirectory);
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            imagePattern = new Pattern(new List<Region>(), 0, 'h', "", Pattern.PatternFileFormat.Binary);
            textBox_maxImageSize.Text = "";
            textBox_imageSaveName.Text = "";
            listBox_imageFileContents.Items.Clear();
            radioButton_fileFormatBinary.Checked = true;
        }
    }
}
