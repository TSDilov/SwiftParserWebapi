using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftparserData.Models
{
    public class SwiftMessage
    {
        public SwiftMessage(string senderCode, string messageType, string textBlock, string authenticationCode)
        {
            SenderCode = senderCode;
            MessageType = messageType;
            TextBlock = textBlock;
            AuthenticationCode = authenticationCode;
        }

        public string SenderCode { get; private set; }

        public string MessageType { get; private set; } 
        
        public string TextBlock { get; private set; }

        public string AuthenticationCode { get; private set; }
    }
}
