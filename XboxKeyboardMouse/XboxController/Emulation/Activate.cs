using SimWinInput;
using System;
using System.Threading;
using System.Windows.Forms;
using XboxKeyboardMouse.Libs;

namespace XboxKeyboardMouse {
    class Activate {
        public static Thread tXboxStream, tKMInput;
        private static SimGamePad simPad;
        private static SimulatedGamePadState state;
        private static bool shuttingDown = false;
        private static bool Working = false;
        private static bool DoneOnce = false;

        private static void Init()
        {
            simPad = SimGamePad.Instance;
            try
            {
                simPad.Initialize();
                simPad.PlugIn();
                state = simPad.State[0];
            }
            catch
            {
                ShutDown();
                MessageBox.Show("Could not initialize SimGamePad / ScpBus. Shutting down.");
                Application.Exit();
            }
            
            TranslateMouse.InitMouse();
        }

        private static void KeyboardMouseInput() {
            while (!shuttingDown) {

                /*TranslateMouse.MouseButtonsInput(state);*/
                TranslateKeyboard.KeyboardInput(state);

                if (Program.MainForm.StatusSyncCheck() == true && Working == false)
                {
                    if (Program.MainForm.AutoCheck() == true)
                    {

                        Working = true;

                        Thread.Sleep(5000);

                        if (DoneOnce == false)
                        {

                            /*----Begin Alchemy---*/

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(100);

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(100);

                            state.Buttons = GamePadControl.None;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(5000);

                            /*----Look at and open book----*/

                            state.RightStickX = 32767;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(600);

                            state.RightStickX = 0;
                            SimGamePad.Instance.Update();

                            state.RightStickY = -32767;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(100);

                            state.RightStickY = 0;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(1000);

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(10);

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(100);

                            state.Buttons = GamePadControl.None;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(5000);

                            /*----Turn page----*/

                            state.Buttons = GamePadControl.RightShoulder;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(10);

                            state.Buttons = GamePadControl.None;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(3000);

                            /*----End----*/

                        }
                        else
                        {
                            /*----Go to book from end and open----*/

                            state.RightStickX = 32767;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(600);

                            state.RightStickX = 0;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(1500);

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(10);

                            state.Buttons = GamePadControl.A;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(100);

                            state.Buttons = GamePadControl.None;
                            SimGamePad.Instance.Update();
                            Thread.Sleep(4000);

                            /*----End----*/

                        }

                        /*----Prepare cockeral potion----*/

                        state.Buttons |= GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(2000);

                        state.Buttons &= ~GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(3000);

                        /*----Grab spirits----*/

                        state.RightStickX = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(150);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(100);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(7500);

                        /*---Grab Mint----*/

                        state.RightStickX = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(450);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(4000);

                        /*----Place Mint into morter----*/

                        state.RightStickY = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(400);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        PressA();

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(6000);

                        Thread.Sleep(10000);

                        /*----Grind Mint with pestle----*/

                        state.RightStickX = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(150);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(2000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(17000);

                        /*----Put Ground Mint into cauldren----*/

                        state.RightStickY = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(400);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(7000);

                        /*----Grab 2nd Mint---*/

                        state.RightStickX = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(200);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.RightStickY = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(400);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(5000);

                        /*----Place mint into morter----*/

                        state.RightStickY = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(400);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(3500);

                        /*----Grab pestle----*/

                        state.RightStickX = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(200);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(11000);

                        /*----Move morter to pot and drop in----*/

                        state.RightStickY = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(400);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(8500);

                        /*----Sandglass and Bellows----*/

                        state.RightTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.RightTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(3500);

                        state.LeftTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.LeftTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(8500);

                        /*----Grab Valeran----*/

                        state.RightStickX = 32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(350);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(4000);

                        /*----Place Valeran into cauldren----*/

                        state.RightStickX = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(450);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(4500);


                        /*----Sandglass and Bellows x1----*/

                        state.RightTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.RightTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(3500);

                        state.LeftTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.LeftTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(12000);

                        /*----Sandglass and Bellows x2----*/

                        state.RightTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.RightTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(3500);

                        state.LeftTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.LeftTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(8000);

                        /*----Grab phail---*/

                        state.RightStickX = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(600);

                        state.RightStickX = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.RightStickY = -32767;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(175);

                        state.RightStickY = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(600);

                        state.Buttons = GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.Buttons = GamePadControl.None;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(2500);

                        /*----Use Still----*/

                        state.Buttons |= GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(2000);

                        state.Buttons &= ~GamePadControl.A;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(10);

                        Thread.Sleep(6000);

                        /*----Final Bellows x2----*/

                        state.LeftTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.LeftTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1500);

                        state.LeftTrigger = 255;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1000);

                        state.LeftTrigger = 0;
                        SimGamePad.Instance.Update();
                        Thread.Sleep(7500);

                        /*----End----*/

                        Working = false;

                        DoneOnce = true;

                    }
                    else
                    {
                        SimGamePad.Instance.Update();
                        Thread.Sleep(1);
                    }

                }

                SimGamePad.Instance.Update();

                // Poll aggressively, but avoid completely pegging the CPU to 100%.
                Thread.Sleep(1);
            }
        }

        public static void ActivateKeyboardAndMouse(bool ActivateStreamThread = true, bool ActivateInputThread = true) {
            Init();

            // Cursor Toggle thread
            if (ActivateStreamThread) {
                tXboxStream = new Thread(XboxStream.XboxAppDetector);
                tXboxStream.SetApartmentState(ApartmentState.STA);
                tXboxStream.IsBackground = true;
                tXboxStream.Start();

                #if (DEBUG)
                    Logger.appendLogLine("Threads", "Starting: tXboxStream thread", Logger.Type.Info);
                #endif
            }

            // Keyboard and Mouse input thread
            if (ActivateInputThread) {
                tKMInput = new Thread(Activate.KeyboardMouseInput);
                tKMInput.SetApartmentState(ApartmentState.STA);
                tKMInput.IsBackground = true;
                tKMInput.Start();

                #if (DEBUG)
                    Logger.appendLogLine("Threads", "Starting: tKMInput thread", Logger.Type.Info);
                #endif
            }

            // Set our status to waiting
            Program.MainForm.StatusWaiting();
        }

        public static void ShutDown()
        {
            shuttingDown = true;
            simPad.ShutDown();
        }
        
        public static void SendGuide(bool buttonDown) {
            if (buttonDown)
                 state.Buttons |= GamePadControl.Guide;
            else state.Buttons &= ~GamePadControl.Guide;
            simPad.Update();
        }
        
        public static void ResetController() {
            state.RightStickX = 0;
            state.RightStickY = 0;
            state.LeftStickX = 0;
            state.LeftStickY = 0;

            state.LeftTrigger = 0;
            state.RightTrigger = 0;

            state.Buttons = GamePadControl.None;
        }

        public static void ChangeWorking()
        {

            Working = false;

        }

        private static void PressA()
        {
            state.Buttons = GamePadControl.A;
            SimGamePad.Instance.Update();
            Thread.Sleep(1000);
        }
    }
}
