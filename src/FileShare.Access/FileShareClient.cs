using System;
using System.Net;
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
        private NTStatus _status;
        private bool _connected;
        
        
        public FileShareClient(string domainName, string username, string password, string ipAddress)
        {
            _domainName = domainName;
            _username = username;
            _password = password;
            _ipAddress = ipAddress;
        }
        
        public void Connect()
        {
            _connected = base.Connect(IPAddress.Parse(_ipAddress), SMBTransportType.DirectTCPTransport);
            
            if (_connected)
                _status = Login(_domainName, _username, _password);
        }

        public void Disconnect()
        {
            if (_status == NTStatus.STATUS_SUCCESS)
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