namespace FileShare.Access.DTO
{
    public abstract class FileShareDto : IClientDTO
    {
        public string IPAddress { get; set; }
        public string DomainName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ShareName { get; set; }
    }
}