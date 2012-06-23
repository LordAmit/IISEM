namespace IISExpressManager
{
    public class IISSites
    {
        /*
            Written by lordamit
            lordamit {at] gmail [dot} com
        */
        public IISSites(string siteName, string id)
        {
            SiteName = siteName;
            Id = id;
            Status = "Stopped";
            ProcessId = "Not Found";
        }

        public string ProcessId { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string SiteName { get; set; }
    }
}