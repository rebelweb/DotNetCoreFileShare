namespace FileShare.Access.DTO
{
    public class ReadFileDTO : IClientDTO
    {
        public string IPAddress { get; set;  }
        public string DomainName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ShareName { get; set; }
        public string FileName { get; set; }
    }
}