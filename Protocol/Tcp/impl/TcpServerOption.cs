using ProtocolForge.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ProtocolForge.Interface;

namespace ProtocolForge.Protocol.Tcp.impl
{
    internal class TcpServerOption
    {
        public string Ip { get; }
        public string Port { get; }

        public TcpServerOption(string ip, string port)
        {
            Ip = ip;
            Port = port;
        }
    }
}
