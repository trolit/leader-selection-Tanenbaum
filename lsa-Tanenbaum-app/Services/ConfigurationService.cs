using lsa_Tanenbaum_app.Models;
using System;
using System.Net;
using System.Net.Sockets;
using static lsa_Tanenbaum_app.Headers;

namespace lsa_Tanenbaum_app.Services
{
    public class ConfigurationService
    {
        public void InitializeSocket(Process process, int bufferSize, AsyncCallback OnDataReceived)
        {
            process.SynchronizationContainer = Configuration;

            process.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            process.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // initialize source EndPoint
            process.SourceEndPoint = new IPEndPoint(IPAddress.Parse(process.SourceAddress.IP), Convert.ToInt32(process.SourceAddress.port));

            // bind socket
            process.Socket.Bind(process.SourceEndPoint);

            // initialize target EndPoint
            process.TargetEndPoint = new IPEndPoint(IPAddress.Parse(process.TargetAddress.IP), Convert.ToInt32(process.TargetAddress.port));

            process.IsInitialized = true;

            // start listening
            byte[] buffer = new byte[bufferSize];
            process.Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), buffer);
        }

        public void StopSocket(Process process)
        {
            process.IsInitialized = false;
            process.Socket.Shutdown(SocketShutdown.Both);
            process.Socket.Close();
        }
    }
}
