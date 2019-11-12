using System;
using FileShare.Access;

namespace FileShare.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string domainName = args[0];
            string username = args[1];
            string password = args[2];
            string shareName = args[3];
            string fileName = args[4];
            
            Console.WriteLine("Displaying File Contents In the Share");
        }
    }
}