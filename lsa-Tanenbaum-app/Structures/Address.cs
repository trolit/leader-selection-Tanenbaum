namespace lsa_Tanenbaum_app.Structures
{
    public struct Address
    {
        public string IP;
        public string port;

        public Address(string IP, string port)
        {
            this.IP = IP;
            this.port = port;
        }
    }
}
