using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A290BUFFPT2
{
    public partial class FrmCollections : Form
    {
        public FrmCollections()
        {
            InitializeComponent();
        }

        private void BtnShowNames_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < Controls.Count; index++)
            {
                MessageBox.Show("Control # " + index.ToString() +
                    " has the name " + Controls[index].Name);
            }
        }
        // TODO: create 5+ sample buttons for this function to loop through.
        // TODO: redo the Homework Project 1 such that it is formated correctly
    }

}
