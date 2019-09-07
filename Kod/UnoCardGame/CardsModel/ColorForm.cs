using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardsModel
{
    public partial class ColorForm : Form
    {
        public int ReturnColor { get; set; }
        public ColorForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            if (radRed.Checked == true)
            {
                ReturnColor = 0;
            }
            else if (radOrange.Checked == true)
            {
                ReturnColor = 1;
            }
            else if (radGreen.Checked == true)
            {
                ReturnColor = 2;
            }
            else if (radBlue.Checked == true)
            {
                ReturnColor = 3;
            }
            else
                ReturnColor = 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}


