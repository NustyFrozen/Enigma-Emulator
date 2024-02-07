namespace Enigma_Simulator
{
    public partial class Enigma : Form
    {
        static Enigma reference;
        static NumericUpDown[] hog = new NumericUpDown[3];
        static Lamp_board lamp_Board = new Lamp_board();
        static Rotor[] rotors = new Rotor[4];
        static Reflector reflector = new Reflector();
        static Plugboard plugboard = new Plugboard();


        public Enigma(Rotor[] rot, string reflector, string plugboard)
        {

            InitializeComponent();

            rotors[0] = new Rotor();
            rotors[0].setRotorWiring("ABCDEFGHIJKLMNOPQRSTUVWXYZ");//no scramble here since its entry disk
            rotors[0].notch = 0;

            for (int i = 0; i < 3; i++)
                Enigma.rotors[i + 1] = rot[i];

            Enigma.reflector.setReflectorWiring(reflector);
            Enigma.plugboard.setReflectorWiring(plugboard);

            int calculatecenter = (rotors[1].Width * rotors.Length + Enigma.reflector.Size.Width);

            for (int i = 0; i < rotors.Length; i++)
            {
                this.Controls.Add(rotors[i]);
                Label x = new Label();
                x.Font = new Font("Courier New", 16f, FontStyle.Regular);
                x.AutoSize = true;
                this.Controls.Add(x);
                rotors[i].Location = new Point(this.Size.Width / 2 + calculatecenter / 2 - rotors[i].Width * i, 120);

                if (i == 0)
                    x.Text = "Entry Disk";
                else
                {
                    hog[i - 1] = new NumericUpDown();
                    this.Controls.Add(hog[i - 1]);
                    hog[i - 1].Minimum = 0;
                    hog[i - 1].Maximum = 25;
                    hog[i - 1].Value = 0;
                    hog[i - 1].BackColor = this.BackColor;
                    hog[i - 1].AutoSize = true;
                    hog[i - 1].ForeColor = Color.White;
                    hog[i - 1].Font = new Font("Courier New", 16f, FontStyle.Regular); ;
                    hog[i - 1].Location = new Point(rotors[i].Location.X + rotors[i].Width / 2 - hog[i - 1].Size.Width / 2, rotors[i].Location.Y + rotors[i].Height + 2);
                    hog[i - 1].Tag = rotors[i];
                    hog[i - 1].ValueChanged += (object? sender, EventArgs e) =>
                    {

                        //((Rotor)((Control)sender).Tag).position = (int)((NumericUpDown)sender).Value; //HAHA POLYMORPHISM GO BRRRRRRR
                    };
                    hog[i - 1].Enabled = false;

                    x.Text = $"Rotor {(i)}";
                }
                x.Location = new Point(rotors[i].Location.X + (rotors[i].Size.Width / 2) - (x.Size.Width / 2), rotors[i].Location.Y - x.Size.Height);
                x.ForeColor = Color.White;
            }


            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.keyboard1.Location = new System.Drawing.Point(150, this.Size.Height - keyboard1.Size.Height - 150);
            lamp_Board.Location = new Point(keyboard1.Location.X + keyboard1.Size.Width + 150, keyboard1.Location.Y);
            this.Controls.Add(lamp_Board);
            this.keyboard1.RegisterKeyCapture();



            this.Controls.Add(Enigma.reflector);
            this.Controls.Add(Enigma.plugboard);


            button1.Location = new Point(this.Size.Width - button1.Size.Width, 0);
            Enigma.reflector.Location = new Point(rotors[rotors.Length - 1].Location.X - Enigma.reflector.Width - 20, 120);
            Enigma.plugboard.Location = new Point(rotors[0].Location.X + rotors[0].Size.Width + 2, rotors[0].Location.Y);
            textBox1.Location = new Point(2, this.Size.Height - textBox1.Size.Height - 2);
            textBox2.Location = new Point(textBox1.Size.Width + 4, this.Size.Height - textBox1.Size.Height - 2);


            keyboardLBL.Location = new Point(keyboard1.Location.X + keyboard1.Size.Width / 2 - keyboardLBL.Size.Width / 2, keyboard1.Location.Y);
            keyboardLBL.BringToFront();
            PlugBoardLBL.Location = new Point(Enigma.plugboard.Location.X + Enigma.plugboard.Size.Width / 2 - PlugBoardLBL.Size.Width / 2, Enigma.plugboard.Location.Y);
            LampBoardLBL.Location = new Point(lamp_Board.Location.X + lamp_Board.Size.Width / 2 - LampBoardLBL.Size.Width / 2, lamp_Board.Location.Y);
            LampBoardLBL.BringToFront();
            ReflectorLBL.Location = new Point(Enigma.reflector.Location.X + Enigma.reflector.Size.Width / 2 - ReflectorLBL.Size.Width / 2, Enigma.reflector.Location.Y - ReflectorLBL.Size.Height);
            ReflectorLBL.BringToFront();

            reference = this;
        }

        public static void processKey(char A)
        {
            int ParsedRotorPosition = ((int)A) - 65;
            ParsedRotorPosition = plugboard.findPair(ParsedRotorPosition, true);
            reference.textBox1.Text += A;
            rotors[1].position++;
            if (rotors[1].turnNextRotor)
                rotors[2].position += 1;
            if (rotors[2].turnNextRotor)
                rotors[3].position += 1;

            hog[0].Value = rotors[1].position;
            hog[1].Value = rotors[2].position;
            hog[2].Value = rotors[3].position;
            for (int i = 0; i < 4; i++)
                ParsedRotorPosition = rotors[i].getTranslatedRotor(ParsedRotorPosition);

            ParsedRotorPosition = reflector.findPair(ParsedRotorPosition, true);
            for (int i = 3; i > -1; i--)
                ParsedRotorPosition = rotors[i].getCharacterReverse(ParsedRotorPosition);

            ParsedRotorPosition = plugboard.findPair(ParsedRotorPosition, false);
            lamp_Board.lightUp((char)(ParsedRotorPosition + 65));
            reference.textBox2.Text += (char)(ParsedRotorPosition + 65);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}