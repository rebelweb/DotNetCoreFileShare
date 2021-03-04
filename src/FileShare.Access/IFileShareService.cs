using FileShare.Access.DTO;

namespace FileShare.Access
{
    public interface IFileShareService
    {
        public string ReadFile(ReadFileDTO dto);

        public bool WriteFile(WriteFileDto dto);
    }
}