using lsa_Tanenbaum_app.Structures;

namespace System.Net.Sockets
{
    public static class SocketExtensions
    {
        public static InitializedSocketResult Initialize(this Socket socket, EndPoints endPoints, 
            RawAddress processAddress, RawAddress targetAddress)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // init process EndPoint
            endPoints.epProcess = new IPEndPoint(IPAddress.Parse(processAddress.IP), Convert.ToInt32(processAddress.port));

            // bind socket
            socket.Bind(endPoints.epProcess);

            // init target EndPoint
            endPoints.epTarget = new IPEndPoint(IPAddress.Parse(targetAddress.IP), Convert.ToInt32(targetAddress.port));

            return new InitializedSocketResult(socket, new EndPoints(endPoints.epProcess, endPoints.epTarget));
        }

        public static void Stop(this Socket socket, ref bool isSocketInitialized)
        {
            isSocketInitialized = false;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

    }
}
