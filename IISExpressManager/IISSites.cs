namespace IISExpressManager
{
    public class IISSites
    {
        /*
            Written by lordamit
            lordamit {at] gmail [dot} com
        */
        public IISSites(string siteName, string id, string portNumber)
        {
            SiteName = siteName;
            Id = id;
            Status = "Stopped";
            ProcessId = "Not Found";
            Port = portNumber;
        }

        public string ProcessId { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string Port { get; set; }
    }
}