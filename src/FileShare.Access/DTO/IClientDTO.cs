namespace FileShare.Access.DTO
{
    public interface IClientDTO
    {
        string IPAddress { get; set;  }
        string DomainName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string ShareName { get; set; }
    }
}