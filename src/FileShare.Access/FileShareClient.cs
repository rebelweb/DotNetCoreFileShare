using System;
using System.Net;
using FileShare.Access.DTO;
using SMBLibrary;
using SMBLibrary.Client;

namespace FileShare.Access
{
    public class FileShareClient : SMB2Client, IDisposable
    {
        private readonly string _domainName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _ipAddress;
        private readonly string _shareName;
        private SMB2FileStore _fileStore;
        private NTStatus _status;
        private bool _connected;
        
        
        public FileShareClient(IClientDTO dto)
        {
            _domainName = dto.DomainName;
            _username = dto.Username;
            _password = dto.Password;
            _ipAddress = dto.IPAddress;
            _shareName = dto.ShareName;
        }

        public SMB2FileStore Share => _fileStore;
        
        public bool Connect()
        {
            _connected = base.Connect(IPAddress.Parse(_ipAddress), SMBTransportType.DirectTCPTransport);

            if (_connected)
            {
                _status = Login(_domainName, _username, _password);
                if (_status == NTStatus.STATUS_SUCCESS)
                {
                    _fileStore = TreeConnect(_shareName, out _status) as SMB2FileStore;
                    return true;
                }
            }

            return false;
        }

        public void Disconnect()
        {
            if (_connected && _status == NTStatus.STATUS_SUCCESS)
                Logoff();
            
            if (_connected)
                base.Disconnect();
        }
        
        public void Dispose()
        {
            Disconnect();
        }
    }
}