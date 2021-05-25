namespace lsa_Tanenbaum_app.Structures
{
    public struct RawAddress
    {
        public string IP;
        public string port;

        public RawAddress(string IP, string port)
        {
            this.IP = IP;
            this.port = port;
        }
    }
}
