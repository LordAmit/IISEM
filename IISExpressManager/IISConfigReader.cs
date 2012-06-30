using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IISExpressManager
{
    internal class IISConfigReader
    {
        /*
            Written by lordamit
            lordamit {at] gmail [dot} com   
        */
        private static List<IISSites> _iisSites;

        internal static List<IISSites> ReadXmlFromConfig(IISExpressConfiguration iisExConfig)
        {
            _iisSites = new List<IISSites>();
            
            if (!iisExConfig.CheckIISExpressConfigExistence()) return null;

            string contents = File.ReadAllText(iisExConfig.IISExpressConfigAddress);

            var document = new XmlDocument();
            document.LoadXml(contents);
            XmlNodeList siteList = document.GetElementsByTagName("site");
            XmlNodeList bindingNodes = document.SelectNodes("/configuration/system.applicationHost/sites/site/bindings");
            int counter=0;
            foreach (object node in siteList)
            {
                var xmlElement = (XmlElement)node;
                var portNumber = FindPort(bindingNodes.Item(counter).InnerXml);
                _iisSites.Add(new IISSites(xmlElement.Attributes["name"].Value, xmlElement.Attributes["id"].Value, portNumber));
                counter++;
            }
            
            return _iisSites;
        }

        private static string FindPort(string innerXmlString)
        {
            //<binding protocol=\"http\" bindingInformation=\":8080:localhost\" />
            //<binding protocol=\"http\" bindingInformation=\"*:1038:localhost\" />

            int indexOfLastColon;
            string portNumber;
            int portIndex = innerXmlString.IndexOf("=\":");
            
            if(portIndex==-1)
            {
                portIndex = innerXmlString.IndexOf("*");
                portNumber = innerXmlString.Substring(portIndex + 2);
                indexOfLastColon= portNumber.IndexOf(":");

                portNumber = portNumber.Substring(0, indexOfLastColon);
                return portNumber;
            }
            portNumber = innerXmlString.Substring(portIndex+3);
            indexOfLastColon = portNumber.IndexOf(":");

            portNumber = portNumber.Substring(0, indexOfLastColon);
            return portNumber;

        }
    }
}