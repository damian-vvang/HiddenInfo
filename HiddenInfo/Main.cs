using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace HiddenInfo
{
	public partial class Main : Form
	{
		OpenFileDialog ofd = new OpenFileDialog();
		string selection = "";   //Selection between [TypeText] and [SelectTxtFile]

		// Windows ribbon control disable
		private const int WS_SYSMENU = 0x80000;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style &= ~WS_SYSMENU;
				return cp;
			}
		}

		public Main()
		{
			InitializeComponent();
		}

		//SelectImage - Button [Decode section]
		private void fileOpen1_button_Click(object sender, EventArgs e)
		{
			ofd.Filter = ("BMP|*.bmp");
			details.Text = null;
			txtContentLoad.Text = null;

			if (ofd.ShowDialog() == DialogResult.Cancel)
			{
				filePath1.Text = "No image selected for decode!";
				fileName1.Text = null;
				details.Text = null;
				txtContentLoad.Text = null;
			}
			else
			{
				Bitmap bmp = new Bitmap(ofd.FileName);
				readImg.Image = bmp;
				readImg.Tag = "loaded";

				filePath1.Text = ofd.FileName;
				fileName1.Text = ofd.SafeFileName;
			}
		}

		//SelectImage - Button [Encode section]
		private void fileOpen2_button_Click(object sender, EventArgs e)
		{
			ofd.Filter = ("BMP|*.bmp");
			textName2.Text = null;
			textPath2.Text = null;
			txtContentWrite.Text = null;

			if (ofd.ShowDialog() == DialogResult.Cancel)
			{
				filePath2.Text = "No image selected for encode!";
				txtContentWrite.Text = null;
				fileName2.Text = null;
				textName2.Text = null;
				textPath2.Text = null;

				if (File.Exists("temp.txt"))
						File.Delete("temp.txt");
			}
			else
			{
				Bitmap bmp = new Bitmap(ofd.FileName);
				writeImg.Image = bmp;
				writeImg.Tag = "loaded";

				filePath2.Text = ofd.FileName;
				fileName2.Text = ofd.SafeFileName;
			}
		}

		// SelectTxtFile - Button [Encode section]
		private void selectTxtFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog text_ToEncodeFile = new OpenFileDialog();
			text_ToEncodeFile.Filter = "TXT|*.txt";
			text_ToEncodeFile.ShowDialog();
			selection = "SelectTxtFile";

			if (File.Exists("temp.txt"))
					File.Delete("temp.txt");

			if (text_ToEncodeFile.FileName == "")
			{
				textPath2.Text = "No text selected for encode!";
				textName2.Text = null;
				txtContentWrite.Text = null;
			}
			else
			{
				textPath2.Text = text_ToEncodeFile.FileName;
				textName2.Text = text_ToEncodeFile.SafeFileName;
				typeText_backlight.BackColor = Color.Green;
				selectTxtFile_backlight.BackColor = Color.Red;
			}
		}

		// TypeText - Button [Encode section]
		private void typeText_button_Click(object sender, EventArgs e)
		{
			TextFileCreator text_fileCreator = new TextFileCreator();
			text_fileCreator.Show();
			selection = "TypeText";
		}

		// Reset - Button [Decode section]
		private void resetButton1_Click(object sender, EventArgs e)
		{
			selectImage1_backlight.BackColor = Color.Green;

			readImg.Image = null;
			readImg.Tag = null;
			filePath1.Text = null;
			fileName1.Text = null;
			details.Text = null;
			txtContentLoad.Text = null;
		}

		// Reset - Button [Encode section]
		private void resetButton2_Click(object sender, EventArgs e)
		{
			if (File.Exists("temp.txt"))
					File.Delete("temp.txt");

			selectImage2_backlight.BackColor = Color.Green;

			writeImg.Image = null;
			writeImg.Tag = null;
			filePath2.Text = null;
			fileName2.Text = null;
			textPath2.Text = null;
			textName2.Text = null;
			txtContentWrite.Text = null;
			selection = null;
		}

		// Exit - Button
		private void exitButton_Click(object sender, EventArgs e)
		{
			if (File.Exists("temp.txt"))
					File.Delete("temp.txt");

			this.Close();
		}

		// Minimalize - Button
		private void minimalizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		// DecodeMessage - Button [Decode section]
		private void decodeButton_Click(object sender, EventArgs e)
		{
			//Loading the content of the image.
			byte[] fileBytes = System.IO.File.ReadAllBytes(filePath1.Text);

			//Initial data for further transformations.
			byte[] initialData = new[] { fileBytes[10], fileBytes[11], fileBytes[12], fileBytes[13] };

			//Offset value.
			int offset = BitConverter.ToInt32(initialData, 0);

			byte[] initialDataOri = new[] { fileBytes[6], fileBytes[7], fileBytes[8], fileBytes[9] };

			//Original offset value.
			int offsetOri = BitConverter.ToInt32(initialDataOri, 0);

			//Overlaying the offset value.
			byte[] newFileTxt = new byte[offset - offsetOri - 1 + 1];

			//Copying the content of an array [An array of values with an offset].
			Array.Copy(fileBytes, offsetOri, newFileTxt, 0, offset - offsetOri);

			DialogResult dialogResult = MessageBox.Show("Save the decoded message to a file?", "Decoded message.", MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Text file|*.txt";
				saveFileDialog1.Title = "Save As: ";
				saveFileDialog1.ShowDialog();

				if (saveFileDialog1.FileName == "")
				{
					details.Text = "No path to save the decoded content!";
				}
				else
				{
					System.IO.File.WriteAllBytes(saveFileDialog1.FileName, newFileTxt);
					details.Text = ("The decoded message has been saved in: " + saveFileDialog1.FileName);

					string path;
					path = saveFileDialog1.FileName;
					txtContentLoad.Text = Convert.ToString(File.ReadAllText(path));

					if ((txtContentLoad.Text).StartsWith("BMv~"))
					{
						txtContentLoad.Text = null;
						txtContentLoad.Text = "No content";
						System.IO.File.Delete(saveFileDialog1.FileName);
					}
					else
					{
						txtContentLoad.Text = null;
						txtContentLoad.Text = ("Encoded content: " + "'" + Convert.ToString(File.ReadAllText(path)) + "'");
					}
				}
			}
			else if (dialogResult == DialogResult.No)
			{
				txtContentLoad.Text = System.Text.Encoding.UTF8.GetString(newFileTxt);
				details.Text = ("The image has been decoded.");
				details.Text += Environment.NewLine + "The file has not been saved. Save path not specified!";

				if ((txtContentLoad.Text).StartsWith("BMv~"))
				{
					txtContentLoad.Text = null;
					txtContentLoad.Text = "*No content*";
				}
				else
				{
					txtContentLoad.Text = null;
					txtContentLoad.Text = ("Encoded content: " + "'" + System.Text.Encoding.UTF8.GetString(newFileTxt) + "'");
				}
			}
		}

		// EncodeMessage - Button [Encode section]
		private void encodeButton_Click(object sender, EventArgs e)
		{
			txtContentWrite.Text = "Encoded message: " + Convert.ToString(File.ReadAllText(textPath2.Text));

			//Loading the content of the image.
			byte[] fileBytes = System.IO.File.ReadAllBytes(ofd.FileName);

			//Initial data for further transformations.
			byte[] initialData = new[] { fileBytes[10], fileBytes[11], fileBytes[12], fileBytes[13] };

			//Original offset value.
			int offsetOri = BitConverter.ToInt32(initialData, 0);

			//Offset value for further transformations.
			int offset = 0;

			//Loading the content of the message
			byte[] text_ToEncode = System.IO.File.ReadAllBytes(textPath2.Text);

			//Overlaying the offset value.
			offset = offsetOri + text_ToEncode.Count();
			byte[] modification = BitConverter.GetBytes(offset);

			byte[] initial = new byte[10];
			Array.Copy(fileBytes, initial, 6);

			//Creating an encoded file.
			byte[] newFile = new byte[initial.Length + modification.Length - 1 + 1];

			//Filling the array with initial values
			Array.Copy(initial, newFile, initial.Length);
			Array.Copy(initialData, 0, newFile, initial.Length - 4, initialData.Length);

			//Filling the array with modified values
			Array.Copy(modification, 0, newFile, initial.Length, modification.Length);
			Array.Resize(ref newFile, offsetOri);

			Array.Copy(fileBytes, 14, newFile, 14, offsetOri - 14);
			int initialData1 = newFile.Length;

			//Resizing the array [additional space for message to be encoded]
			Array.Resize(ref newFile, newFile.Length + text_ToEncode.Length);

			Array.Copy(text_ToEncode, 0, newFile, initialData1, text_ToEncode.Length);

			//Filling the array with modified values [including offset value]
			initialData1 = newFile.Length;
			Array.Resize(ref newFile, newFile.Length + (fileBytes.Length - (newFile.Length - text_ToEncode.Length)));

			Array.Copy(fileBytes, offsetOri, newFile, initialData1, fileBytes.Length - offsetOri);

			// Save as
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "Bitmap Image|*.bmp";
			saveFileDialog1.Title = "Select a location for the bitmap with the encoded message:";

			if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
				txtContentWrite.Text += Environment.NewLine + "The file has not been saved. Save path not specified!";

			else
			{
				System.IO.File.WriteAllBytes(saveFileDialog1.FileName, newFile);
				txtContentWrite.Text += Environment.NewLine + "The file has been saved in: " + saveFileDialog1.FileName;
			}
		}

		// Timer1 - Conditional statements for buttons & Backlight control
		private void timer1_Tick(object sender, EventArgs e)
		{
			if ((string)readImg.Tag == "loaded")
				selectImage1_backlight.BackColor = Color.Red;

			if ((string)writeImg.Tag == "loaded")
				selectImage2_backlight.BackColor = Color.Red;

			if (selection == "TypeText")
			{
				if (File.Exists("temp.txt"))
				{
					string path = Path.Combine(Environment.CurrentDirectory, "temp.txt");
					textName2.Text = "TypeText option selected! Press button to start.";
					textPath2.Text = path;
					typeText_backlight.BackColor = Color.Red;
					selectTxtFile_backlight.BackColor = Color.Green;
				}
				else
					textName2.Text = "TypeText option selected! No content!";
			}

			// Decode - button - backlight [Decode section]

			if (filePath1.Text != "" && fileName1.Text != "")
			{
				decodeButton_backlight.BackColor = Color.Green;
				decodeButton.Enabled = true;
			}
			else
			{
				decodeButton_backlight.BackColor = Color.Red;
				decodeButton.Enabled = false;
			}

			// Encode - button - backlight [Encode section]

			if (filePath2.Text != "" && fileName2.Text != "" && textPath2.Text != "" && textName2.Text != "")
			{
				encodeButton_backlight.BackColor = Color.Green;
				encodeButton.Enabled = true;
			}
			else
			{
				encodeButton_backlight.BackColor = Color.Red;
				encodeButton.Enabled = false;
			}

			// TypeText + SelectTxtFile - buttons - backlight [Encode section]

			if (filePath2.Text != "" && fileName2.Text != "")
			{
				selectTxtFile_backlight.BackColor = Color.Green;
				typeText_backlight.BackColor = Color.Green;
				selectTxtFile.Enabled = true;
				typeText_button.Enabled = true;

				if (selection == "SelectTxtFile")
                {
					selectTxtFile_backlight.BackColor = Color.Red;
					typeText_backlight.BackColor = Color.Green;
				}

				else if (selection == "TypeText")
                {
					typeText_backlight.BackColor = Color.Red;
					selectTxtFile_backlight.BackColor = Color.Green;
				}
			}
			else
			{
				selectTxtFile_backlight.BackColor = Color.Red;
				typeText_backlight.BackColor = Color.Red;
				selectTxtFile.Enabled = false;
				typeText_button.Enabled = false;
			}
		}
	}
}
