using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma_Simulator
{
    public partial class Lamp_board : Keyboard
    {
        public Lamp_board()
        {
            InitializeComponent();
            for (int i = 0; i < base.Controls.Count; i++)
                if (base.Controls[i] is Button)
                    base.Controls[i].Enabled = false;
        }
        public void lightUp(char a)
        {
            for (int i = 0; i < base.Controls.Count; i++)
                if (base.Controls[i] is Button)
                    if (base.Controls[i].Text[0] == a)
                        base.Controls[i].BackColor = Color.Green;
                    else base.Controls[i].BackColor = this.BackColor;
        }
    }
}
