using System;
using System.Linq;
using System.Text;
using FileShare.Access.DTO;
using SMBLibrary;

namespace FileShare.Access
{
    public class FileShareService : IFileShareService
    {
        public string ReadFile(ReadFileDTO dto)
        {
            using (var client = new FileShareClient(dto))
            {
                object handle;
                FileStatus status;
                bool connected = client.Connect();
                if (!connected)
                {
                    Console.WriteLine("Not Connected Exiting...");
                    return null;
                }

                var share = client.Share;
                NTStatus ntStatus = share.CreateFile(out handle, out status, dto.FileName, 
                    AccessMask.GENERIC_READ, 0, ShareAccess.Read, CreateDisposition.FILE_OPEN_IF, 
                    CreateOptions.FILE_NON_DIRECTORY_FILE, null);

                if (ntStatus == NTStatus.STATUS_SUCCESS)
                {
                    byte[] data = null;
                    bool read = true;
                    int start = 0;
                    while (read)
                    {
                        Console.WriteLine("Reading...");
                        share.ReadFile(out var chuckedData, handle, start, 65536);
                        data = data == null ? chuckedData : data.Union(chuckedData).ToArray();
                        start += 65536;
                        if (chuckedData.Length < 65536) read = false;
                    }

                    return Encoding.UTF8.GetString(data);
                }
            }

            return null;
        }
    }
}