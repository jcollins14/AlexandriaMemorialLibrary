using System;
using System.IO;

namespace AlexandriaMemorialLibrary
{
    class Program
    {
        static void Main()
        {
            LibraryController alexandria = new LibraryController();
            alexandria.Load();
            alexandria.Save();
            alexandria.Run();
            while (true)
            {
                Console.WriteLine("Would you like to check out another book? y/n");
                string again = Console.ReadLine().Trim().ToLower();
                if (again == "y")
                {
                    alexandria.Run();
                    
                }
                else if (again == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("I didn't understand that. Please try again.");
                    continue;
                }

            }

        }
    }
}
