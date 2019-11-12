using System;
using FileShare.Access;

namespace FileShare.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Displaying File Contents In the Share");
            using (var client = new FileShareClient("", "rebel", "***REMOVED***", "127.0.0.1"))
            {
                client.Connect();
                var fileStore = client.Share;
                Console.WriteLine("Connected to Share");
            }
        }
    }
}