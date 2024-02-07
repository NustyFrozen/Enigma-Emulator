namespace Enigma_Simulator
{

    public partial class Keyboard : UserControl
    {
        public Keyboard()
        {
            InitializeComponent();

        }
        Dictionary<Keys, Button> keyValuePairs = new Dictionary<Keys, Button>();
        public void RegisterKeyCapture()
        {
            GlobalKeyboardHook gkh = new GlobalKeyboardHook();
            foreach (Control x in Controls)
            {
                if (x is Button)
                {
                    Keys key = (Keys)x.Text[0];
                    keyValuePairs.Add(key, (Button)x);

                }
            }
            gkh.KeyboardPressed += gkh_KeyDown;
        }
        GlobalKeyboardHookEventArgs keyevent = null;
        bool pressed = false;
        void gkh_KeyDown(object sender, GlobalKeyboardHookEventArgs e)
        {

            if (keyevent is not null && pressed)
                if (e.KeyboardData.VirtualCode != keyevent.KeyboardData.VirtualCode) return;
                else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                {
                    return;
                }
                else
                {
                    pressed = false;
                }

            KeyValuePair<Keys, Button> found = keyValuePairs.FirstOrDefault(x => (int)x.Key == e.KeyboardData.VirtualCode);
            if (!(found.Key is Keys.None)) //is this even in the enigma keyboard layout?
            {

                if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                {
                    found.Value.BackColor = Color.Yellow;
                    Enigma.processKey((char)found.Key);
                    keyevent = e;
                    pressed = true;
                }
                else
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(100);
                        found.Value.BackColor = this.BackColor;
                    }).Start(); //letting it sleep a bit cuz if you release the key instantly you wont even see the yellow keypress

                }
            }

        }
    }
}
