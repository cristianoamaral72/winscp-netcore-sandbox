using System;
using WinSCP;

namespace WinScpNetCore
{
    public class WinScpUtil
    {
        public bool Upload()
        {
            var sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "ftp.hostname.com",
                PortNumber = 21,
                UserName = "ABC",
                Password = "123456"
            };
            try
            {
                using (var session = new Session())
                {
                    session.Open(sessionOptions);

                    var transferOptions = new TransferOptions
                    {
                        TransferMode = TransferMode.Binary
                    };

                    var transferResult = session.PutFiles(@"C:\test\*.jpg", "/test-destination/*",
                        false, transferOptions);

                    transferResult.Check();

                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Uploaded file: " + transfer.FileName);
                    }
                }

                
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }

}
