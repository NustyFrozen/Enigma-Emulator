using System.Diagnostics;

namespace Enigma_Simulator
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://en.wikipedia.org/wiki/Enigma_machine") { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] wires = new string[] { textBox1.Text, textBox2.Text, textBox3.Text };
            decimal[] pos = new decimal[] { numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown6.Value, numericUpDown5.Value, numericUpDown4.Value };
            Rotor[] rotors = new Rotor[3];
            for (int i = 0; i < rotors.Length; i++)
            {
                rotors[i] = new Rotor();
                rotors[i].setRotorWiring(wires[i]);//not scramble here since its entry disk
                rotors[i].notch = 0;
                int position = Convert.ToInt16(pos[i]);

                while (rotors[i].pos != position)//not optimal but it needs to behave like a rotor...
                    rotors[i].pos++;

                rotors[i].notch = (int)pos[3 + i];
            }
            this.Visible = false;
            new Enigma(rotors, textBox4.Text, textBox5.Text).Show();
        }
    }
}
