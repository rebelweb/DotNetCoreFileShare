using System;
using FileShare.Access;
using FileShare.Access.DTO;

namespace FileShare.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFileDTO dto = new ReadFileDTO()
            {
                IPAddress = args[0],
                Username = args[1],
                Password = args[2],
                DomainName = "",
                FileName = args[3],
                ShareName = "Temp"
            };
            
            Console.WriteLine("Displaying File Contents In the Share");
            FileShareService service = new FileShareService();
            string contents = service.ReadFile(dto);
            Console.WriteLine(contents);
        }
    }
}