namespace Enigma_Simulator
{
    public partial class Reflector : UserControl
    {
        //reflector is very similar to a rotor in its sense,unlike rotor its not a rolling key, So its like a simple Caesar cipher
        static char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public void setReflectorWiring(string Sequence)
        {
            Stack<Color> colorPairs = new Stack<Color>();
            colorPairs.Push(Color.Lime);
            colorPairs.Push(Color.Yellow);
            colorPairs.Push(Color.Red);
            colorPairs.Push(Color.Purple);
            colorPairs.Push(Color.White);
            colorPairs.Push(Color.Blue);
            colorPairs.Push(Color.FromArgb(40, 0, 74));
            colorPairs.Push(Color.Pink);
            colorPairs.Push(Color.DodgerBlue);
            colorPairs.Push(Color.Cyan);
            colorPairs.Push(Color.Gold);
            colorPairs.Push(Color.DimGray);
            colorPairs.Push(Color.Black); //26 characters 13 pairs...

            if (Sequence.Length != 26)
            {
                MessageBox.Show("Invalid wiring format");

            }
            for (int i = 0; i < 26; i++)
            {
                if ((Convert.ToInt16(Sequence[i]) - 65 - 1) < i)
                {
                    pad[i].ForeColor = pad[Convert.ToInt16(Sequence[i]) - 65].ForeColor;
                }
                else
                {
                    pad[i].ForeColor = colorPairs.Pop();
                    //if failed, it means the paring format is incorrect
                }
                pad[i].Text = $"{((char)(i + 65))} -> {Sequence[i]}";
                pad[i].Tag = Sequence[i] - 65;
            }
        }
        public virtual int findPair(int a, bool resetColors)
        {
            if (resetColors)
                for (int i = 0; i < pad.Length; i++)
                    pad[i].BackColor = this.BackColor;

            pad[a].BackColor = Color.Silver;
            return (int)pad[a].Tag;
        }
        public Reflector()
        {
            InitializeComponent();

            for (int i = 0; i < pad.Length; i++)
            {
                pad[i] = new Label();
                pad[i].ForeColor = Color.Silver;
                pad[i].Font = new Font("Courier New", 9.75f, FontStyle.Regular);
                pad[i].AutoSize = true;
                pad[i].Text = ((char)(i + 65)).ToString();
                this.Controls.Add(pad[i]);
            }
            Reflector_SizeChanged(null, null);
        }
        Label[] pad = new Label[26];
        private void Reflector_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < pad.Length; i++)
            {
                pad[i].Location = new Point((this.Size.Width / 2) - (pad[i].Size.Width / 2), i * pad[i].Height + 2);
            }
        }
    }
}
