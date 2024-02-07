namespace Enigma_Simulator
{
    public partial class Rotor : UserControl
    {
        /* public rotor map used over the years
         * taken from https://en.wikipedia.org/wiki/Enigma_rotor_details
         * 
        Rotor #	ABCDEFGHIJKLMNOPQRSTUVWXYZ	Date Introduced	Model Name & Number
        IC	DMTWSILRUYQNKFEJCAZBPGXOHV	1924	Commercial Enigma A, B
        IIC	HQZGPJTMOBLNCIFDYAWVEUSRKX	1924	Commercial Enigma A, B
        IIIC	UQNTLSZFMREHDPXKIBVYGJCWOA	1924	Commercial Enigma A, B
        Rotor #	ABCDEFGHIJKLMNOPQRSTUVWXYZ	Date Introduced	Model Name & Number
        I	JGDQOXUSCAMIFRVTPNEWKBLZYH	7 February 1941	German Railway (Rocket)
        II	NTZPSFBOKMWRCJDIVLAEYUXHGQ	7 February 1941	German Railway (Rocket)
        III	JVIUBHTCDYAKEQZPOSGXNRMWFL	7 February 1941	German Railway (Rocket)
        UKW	QYHOGNECVPUZTFDJAXWMKISRBL	7 February 1941	German Railway (Rocket)
        ETW	QWERTZUIOASDFGHJKPYXCVBNML	7 February 1941	German Railway (Rocket)
        Rotor #	ABCDEFGHIJKLMNOPQRSTUVWXYZ	Date Introduced	Model Name & Number
        I-K	PEZUOHXSCVFMTBGLRINQJWAYDK	February 1939	Swiss K
        II-K	ZOUESYDKFWPCIQXHMVBLGNJRAT	February 1939	Swiss K
        III-K	EHRVXGAOBQUSIMZFLYNWKTPDJC	February 1939	Swiss K
        UKW-K	IMETCGFRAYSQBZXWLHKDVUPOJN	February 1939	Swiss K
        ETW-K	QWERTZUIOASDFGHJKPYXCVBNML	February 1939	Swiss K
        Rotor #	ABCDEFGHIJKLMNOPQRSTUVWXYZ	Date Introduced	Model Name & Number
        I	EKMFLGDQVZNTOWYHXUSPAIBRCJ	1930	Enigma I
        II	AJDKSIRUXBLHWTMCQGZNPYFVOE	1930	Enigma I
        III	BDFHJLCPRTXVZNYEIWGAKMUSQO	1930	Enigma I
        IV	ESOVPZJAYQUIRHXLNFTGKDCMWB	December 1938	M3 Army
        V	VZBRGITYUPSDNHLXAWMJQOFECK	December 1938	M3 Army
        VI	JPGVOUMFYQBENHZRDKASXLICTW	1939	M3 & M4 Naval (FEB 1942)
        VII	NZJHGRCXMYSWBOUFAIVLPEKQDT	1939	M3 & M4 Naval (FEB 1942)
        VIII	FKQHTLXOCBJSPDZRAMEWNIUYGV	1939	M3 & M4 Naval (FEB 1942)
        Rotor #	ABCDEFGHIJKLMNOPQRSTUVWXYZ	Date Introduced	Model Name & Number
        Beta	LEYJVCNIXWPBQMDRTAKZGFUHOS	Spring 1941	M4 R2
        Gamma	FSOKANUERHMBTIYCWLQPZXVGJD	Spring 1942	M4 R2
        Reflector A	EJMZALYXVBWFCRQUONTSPIKHGD		
        Reflector B	YRUHQSLDPXNGOKMIEBFZCWVJAT		
        Reflector C	FVPJIAOYEDRZXWGCTKUQSBNMHL		
        Reflector B Thin	ENKQAUYWJICOPBLMDXZVFTHRGS	1940	M4 R1 (M3 + Thin)
        Reflector C Thin	RDOBJNTKVEHMLFCWZAXGYIPSUQ	1940	M4 R1 (M3 + Thin)
        ETW	ABCDEFGHIJKLMNOPQRSTUVWXYZ		Enigma I

        Rotor	Notch	Effect
I	Q	If rotor steps from Q to R, the next rotor is advanced
II	E	If rotor steps from E to F, the next rotor is advanced
III	V	If rotor steps from V to W, the next rotor is advanced
IV	J	If rotor steps from J to K, the next rotor is advanced
V	Z	If rotor steps from Z to A, the next rotor is advanced
VI, VII, VIII	Z+M	If rotor steps from Z to A, or from M to N the next rotor is advanced
         */
        static char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public int pos = 0, notch; //the current position of the rolling rotor
        public int position
        {
            get { return pos; }

            set
            {

                int turns = Math.Abs(value - pos);
                pos = value;
                if (pos == 26) pos = 0;
                while (turns != 0)
                {
                    turns--;
                    Rotate();
                }
            }
        }
        public bool turnNextRotor => pos == notch - 1;
        public int getTranslatedRotor(int pos) //position of the wire from IN to OUT
        {
            for (int i = 0; i < IN.Length; i++)
            {
                IN[i].ForeColor = Color.Silver;
                OUT[i].ForeColor = Color.Silver;
            }
            this.Refresh();
            Pen pen = new Pen(Color.Yellow, 1);
            Point first = new Point(IN[pos].Location.X - 2, IN[pos].Location.Y + IN[pos].Size.Height / 2);
            Point second = new Point(OUT[(((int)IN[pos].Tag + this.pos) % 26)].Location.X + OUT[(((int)IN[pos].Tag + this.pos) % 26)].Size.Width + 2, OUT[(((int)IN[pos].Tag + this.pos) % 26)].Location.Y + IN[pos].Size.Height / 2);
            Graphics s = Graphics.FromHwnd(this.Handle);
            s.DrawLine(pen, first.X, first.Y, second.X, second.Y);
            s.Dispose();
            label1.Text = $"{OUT[(((int)IN[pos].Tag + this.pos) % 26)].Text} <= {IN[pos].Text}";
            label1.ForeColor = Color.Yellow;
            IN[pos].ForeColor = Color.Yellow;
            OUT[(((int)IN[pos].Tag + this.pos) % 26)].ForeColor = Color.Yellow;

            return (((int)IN[pos].Tag + this.pos) % 26);
        }
        public int getCharacterReverse(int pos) //position of the wire from OUT to IN
        {
            for (int i = 0; i < OUT.Length; i++)
            {
                OUT[i].ForeColor = Color.Silver;
                IN[i].ForeColor = Color.Silver;
            }
            Pen pen = new Pen(Color.Green, 1);
            Point first = new Point(OUT[pos].Location.X + OUT[pos].Size.Width + 2, OUT[pos].Location.Y + OUT[pos].Size.Height / 2);
            Point second = new Point(IN[(((int)OUT[pos].Tag + this.pos) % 26)].Location.X - 2, IN[(((int)OUT[pos].Tag + this.pos) % 26)].Location.Y + OUT[pos].Size.Height / 2);
            Graphics s = Graphics.FromHwnd(this.Handle);
            s.DrawLine(pen, first.X, first.Y, second.X, second.Y);
            s.Dispose();
            label2.Text = $"{OUT[pos].Text} => {IN[(((int)OUT[pos].Tag + this.pos) % 26)].Text}";
            label2.ForeColor = Color.Green;
            OUT[pos].ForeColor = Color.Green;
            IN[(((int)OUT[pos].Tag + this.pos) % 26)].ForeColor = Color.Green;

            return (((int)OUT[pos].Tag + this.pos) % 26);
        }
        public void swap(Label a, Label b)
        {
            Label temp = new Label();
            temp.Text = a.Text;
            temp.Tag = a.Tag;
            a.Text = b.Text;
            a.Tag = b.Tag;
            b.Text = temp.Text;
            b.Tag = temp.Tag;
        }
        public void Rotate()
        {
            for (int i = IN.Length - 1; i > 0; i--)
            {
                swap(IN[i - 1], IN[i]);
                swap(OUT[i - 1], OUT[i]);
            }
            Rotor_SizeChanged(null, null);
            this.Refresh();
        }
        public void setRotorWiring(string Sequence)
        {
            if (Sequence.Length != 26)
            {
                MessageBox.Show("Invalid wiring format");

            }
            for (int i = 0; i < 26; i++)
            {
                int num = Sequence[i] - 65;
                IN[i].Tag = num;
                OUT[num].Tag = i;

            }
        }
        public void renderWiring(object sender, PaintEventArgs e)
        {
            Graphics s = e.Graphics;
            s.Clear(this.BackColor);
            for (int i = 0; i < 26; i++)
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
                Point first = new Point(IN[i].Location.X - 2, IN[i].Location.Y + IN[i].Size.Height / 2);
                Point second = new Point(OUT[(((int)IN[i].Tag + pos) % 26)].Location.X + OUT[(((int)IN[i].Tag + pos) % 26)].Size.Width + 2, OUT[(((int)IN[i].Tag + pos) % 26)].Location.Y + IN[i].Size.Height / 2);
                s.DrawLine(pen, first.X, first.Y, second.X, second.Y);
            }
            s.Dispose();
        }
        public Rotor()
        {
            InitializeComponent();
            for (int i = 0; i < IN.Length; i++)
            {
                IN[i] = new Label();
                IN[i].ForeColor = Color.Silver;
                IN[i].Font = new Font("Courier New", 14f, FontStyle.Regular);
                IN[i].AutoSize = true;
                IN[i].Text = (i + 1).ToString();
                this.Controls.Add(IN[i]);

                OUT[i] = new Label();
                OUT[i].ForeColor = Color.Silver;
                OUT[i].Font = new Font("Courier New", 14f, FontStyle.Regular);
                OUT[i].AutoSize = true;
                OUT[i].Text = (i + 1).ToString();
                this.Controls.Add(OUT[i]);
            }
            setRotorWiring("ABCDEFGHIJKLMNOPQRSTUVWXYZ");//Unscrambled rotor
            Rotor_SizeChanged(null, null);
            this.Paint += renderWiring;
        }
        Label[] IN = new Label[26];
        Label[] OUT = new Label[26];
        private void Rotor_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Size.Width / 2) - (label1.Size.Width / 2), 2);
            for (int i = 0; i < IN.Length; i++)
            {
                IN[i].Location = new Point(this.Size.Width - IN[i].Size.Width - 2, (i + 1) * IN[i].Height + 2);
                OUT[i].Location = new Point(2, (i + 1) * OUT[i].Height + 2);
            }
            label2.Location = new Point((this.Size.Width / 2) - (label2.Size.Width / 2), (27) * IN[0].Height + 50);
        }
    }
}
