using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Timers;

namespace DAE
{
    class Program
    {
        private String path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Log.txt";

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);


        [DllImport("user32.dll", EntryPoint = "BlockInput")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        static void Main(string[] args)
        {
            new Program().start();
        }

        private void start()
        {
            Console.WriteLine("================================\r\n   ______   _______  _______ \r\n  |      | |   _   ||       |\r\n  |  _    ||  |_|  ||    ___|\r\n  | | |   ||       ||   |___ \r\n  | |_|   ||       ||    ___|\r\n  |       ||   _   ||   |___ \r\n  |______| |__| |__||_______|\r\n\r\n================================\r\nEmulator for the Deltion Arcade.\r\nMade by Nick Schakelaar\r\n================================");
            bool isBlockingInput = true;

            while (true)
            {
                if (handl)

                Console.WriteLine($"isBlockingInput: {isBlockingInput}");
                //R becomes W
                if (GetAsyncKeyState(82) == 32768)
                {
                    BlockRealInput(true);
                    isBlockingInput = true;
                    Console.WriteLine("Simulating W keypress");
                }
                //D becomes A
                else if (GetAsyncKeyState(68) == 32768)
                {
                    BlockRealInput(true);
                    isBlockingInput = true;
                    Console.WriteLine("Simulating A keypress");
                }
                else if (isBlockingInput)
                {
                    BlockInput(false);
                    isBlockingInput = false;
                }
            }
        }

        public void BlockRealInput(bool isTrue)
        {
            Program.BlockInput(isTrue);
        }
    }
}
