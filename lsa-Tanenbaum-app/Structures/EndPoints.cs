using System.Net;

namespace lsa_Tanenbaum_app.Structures
{
    public struct EndPoints
    {
        public EndPoint epProcess;
        public EndPoint epTarget;

        public EndPoints(EndPoint epProcess, EndPoint epTarget)
        {
            this.epProcess = epProcess;
            this.epTarget = epTarget;
        }
    }
}
