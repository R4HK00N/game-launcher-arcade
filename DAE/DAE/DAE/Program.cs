using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Timers;

namespace KeyLogger
{
    class Program
    {
        private String path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Log.txt";

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            new Program().start();
        }

        private void start()
        {
            Console.WriteLine("================================\r\n   ______   _______  _______ \r\n  |      | |   _   ||       |\r\n  |  _    ||  |_|  ||    ___|\r\n  | | |   ||       ||   |___ \r\n  | |_|   ||       ||    ___|\r\n  |       ||   _   ||   |___ \r\n  |______| |__| |__||_______|\r\n\r\n================================\r\nEmulator for the Deltion Arcade.\r\nMade by Nick Schakelaar\r\n================================");

            while (true)
            {
                //R becomes W
                if (GetAsyncKeyState(82) == 32768)
                {
                    Console.WriteLine("Simulating W press");
                }
                //D becomes A
                else if (GetAsyncKeyState(68) == 32768)
                {
                    Console.WriteLine("Simulating A press");
                }
            }
        }
    }
}
