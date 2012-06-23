using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace IISExpressManager
{
    internal class IISConfigReader
    {
        private static List<IISSites> _iisSites;

        internal static List<IISSites> ReadXmlFromConfig(IISExpressConfiguration iisExConfig)
        {
            _iisSites = new List<IISSites>();
            var output = new StringBuilder();

            if (!iisExConfig.CheckIISExpressConfigExistence()) return null;

            string contents = File.ReadAllText(iisExConfig.IISExpressConfigAddress);

            var document = new XmlDocument();
            document.LoadXml(contents);
            XmlNodeList siteList = document.GetElementsByTagName("site");
            foreach (object node in siteList)
            {
                var xmlElement = (XmlElement) node;
                _iisSites.Add(new IISSites(xmlElement.Attributes["name"].Value, xmlElement.Attributes["id"].Value));
            }
            return _iisSites;
        }
    }
}