using System;
using System.Windows.Forms;

namespace PasswordGenerator
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            var loopContinue = true;
            while (loopContinue)
            {
                Console.Clear();
                Console.WriteLine("Password Generator");
                Console.WriteLine("(Please Note: Copies pass to clipboard.)");
                Console.Write("\nPassword Length? (Between 1 - 30 digits.): ");

                int passLength;
                while (!int.TryParse(Console.ReadLine(), out passLength) || passLength < 1 || passLength > 30)
                {
                    Console.WriteLine("Invalid input, please enter a number between 1 - 30.");
                    Console.Write("\nPlease enter pass length: ");
                }

                const int charBegin = 33;
                const int charEnd = 126;
                var buffer = new char[passLength]; 

                var random = new Random();
                for (var i = 0; i < passLength; i++) 
                    buffer[i] = (char)random.Next(charBegin, charEnd); 

                var password = new String(buffer); 

                Clipboard.SetText(password); 
                Console.WriteLine("\n" + password + "\n"); 
                Console.WriteLine("Copied to clipboard, enjoy! :D"); 

                Console.Write("Generate another? Y/N: ");
                var contInput = (Console.ReadLine());
                var lowerContInput = contInput.ToLower();

                if (lowerContInput == "y")
                {
                    loopContinue = true;
                }
                else if (lowerContInput == "n")
                {
                    loopContinue = false;
                }
                else
                {
                    loopContinue = true;
                }
            }

            Console.WriteLine("Press the any key to close...");
            Console.ReadLine(); 
        }
    }
}
