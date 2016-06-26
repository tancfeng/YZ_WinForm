using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SirdRoom.ManageSystem.ClientApplication
{
    class KKEntity
    {
        public Socket ClientSocket { get; set; }

        public byte[] receiveBytes { get; set; }
    }
}
