using System;
using System.Windows.Forms;
using System.IO;

namespace HiddenInfo
{
    public partial class TextFileCreator : Form
    {
        string path = Path.Combine(Environment.CurrentDirectory, "temp.txt");

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

        public TextFileCreator()
        {
            InitializeComponent();
        }

        // Save & Exit - Button
        private void save_exitButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path, lcd.Text);
            this.Close();
        }

        // Discard & Exit - Button
        private void discard_exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
