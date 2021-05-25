using System.Net;
using System.Net.Sockets;

namespace lsa_Tanenbaum_app.Structures
{
    public struct InitializedSocketResult
    {
        public Socket socket;
        public EndPoints endPoints;

        public InitializedSocketResult(Socket socket, EndPoints endPoints)
        {
            this.socket = socket;
            this.endPoints = endPoints;
        }
    }
}
