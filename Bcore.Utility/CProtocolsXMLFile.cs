using System.IO;
using System.Xml;
using System.Web;
using System.Data;
using System;
namespace Bcore.Utility
{
    public class FlushDataProtocol
    {

        public string description = "";
        public string flatform = "";
        public string version = "";
        public string device_name = "";
        // protocol link (get settings)
        public string url_protocol = "";
        // flush data link
        public string url_sync = "";



        public FlushDataProtocol(string _desc, string _flatform, string _version, string _device_name, string _link_protocol, string _link_sync)
        {
            description = _desc;
            flatform = _flatform;
            version = _version;
            device_name = _device_name;
            url_protocol = _link_protocol;
            url_sync = _link_sync;

        }

    }

    public class CProtocolsXMLFile
    {



    //  private readonly ILog log4net = LogManager.GetLogger("ProtocolsXMLFile");

        //public variables    
        private string strDefaultProtocolUrl = "";

        public FlushDataProtocol[] arrFlushDataProtocols = new FlushDataProtocol[101];
        // private variables 
        // Private _application As System.Web.HttpApplicationState
        private string _fileName = "protocols.xml";

        private XmlDocument _xmldoc = new XmlDocument();
        //Public Sub New(ByVal app As System.Web.HttpApplicationState)

        public CProtocolsXMLFile()
        {
            //_application = app

            readFile();

        }

        public bool readFile()
        {


            try
            {
                string pathProtocolsFile = HttpContext.Current.Server.MapPath("~/") + _fileName;


                if (File.Exists(pathProtocolsFile) == false)
                {
                    // because OLD versions we put protocols.xml inside folder "protocols"
                    pathProtocolsFile = HttpContext.Current.Server.MapPath("~/protocols/") + _fileName;

                }

                // load xml file 
                _xmldoc.Load(pathProtocolsFile);

                // get default protocol
                strDefaultProtocolUrl = _xmldoc.SelectSingleNode("protocols-navigation/default-protocol").InnerText;


                XmlNodeList xmlProtocolsNodeList = _xmldoc.SelectNodes("protocols-navigation/protocols/protocol");


                if ((xmlProtocolsNodeList != null))
                {
                    int i = 0;

                    foreach (XmlNode protocolNode in xmlProtocolsNodeList)
                    {
                        //<protocol>
                        //   <description>protocol for android version 5.9</description>
                        //   <flatform>android</flatform>
                        //   <version>5.9</version>
                        //   <device-name></device-name>
                        //   <url>http://protocol-a59.secondcopy.mobi</url> 
                        //</protocol>

                        string description = protocolNode.SelectSingleNode("description").InnerText.Trim();
                        string flatform = protocolNode.SelectSingleNode("flatform").InnerText.Trim();
                        string version = protocolNode.SelectSingleNode("version").InnerText.Trim();
                        string device_name = protocolNode.SelectSingleNode("device-name").InnerText.Trim();

                        string link_protocol = "";
                        // old version we dont have node 'url-protocol'
                        if ((protocolNode.SelectSingleNode("url-protocol") != null))
                        {
                            link_protocol = protocolNode.SelectSingleNode("url-protocol").InnerText.Trim();
                        }

                        string link_sync = "";

                        // old version we use 'url' 
                        if (protocolNode.SelectSingleNode("url-sync") == null)
                        {
                            link_sync = protocolNode.SelectSingleNode("url").InnerText.Trim();
                            // new version
                        }
                        else
                        {
                            link_sync = protocolNode.SelectSingleNode("url-sync").InnerText.Trim();
                        }

                        //format: VERSION $ OS $ LINK ###
                        // for example  http://protocol-a59.secondcopy.mobi,5.9,Android 

                        //If Not String.IsNullOrEmpty(strArrProtocolLinks) AndAlso strArrProtocolLinks.Length > 0 Then
                        //    strArrProtocolLinks = strArrProtocolLinks & "###"
                        //End If

                        //strArrProtocolLinks = strArrProtocolLinks & flatform & "$" & version & "$" & device_name & "$" & link

                        FlushDataProtocol aFlushDataProtocol = new FlushDataProtocol(description, flatform, version, device_name, link_protocol, link_sync);
                        arrFlushDataProtocols[i] = aFlushDataProtocol;
                        i = i + 1;

                    }

                }
            }
            catch (Exception ex)
            {
              //  log4net.Error("[readFile] Exception: " + ex.Message);
            }

            return true;

        }

        public string getDefaultProtocol()
        {
            return strDefaultProtocolUrl;
        }


        public FlushDataProtocol[] getProtocolList()
        {
            return arrFlushDataProtocols;
        }


        public DataTable getProtocolListWithDataTable()
        {

            DataTable dt = new DataTable();

            if (arrFlushDataProtocols == null)
            {
                return dt;
            }

            try
            {
                dt.Columns.Add("DESCRIPTION", typeof(string));
                dt.Columns.Add("FLATFORM", typeof(string));
                dt.Columns.Add("VERSION", typeof(string));
                dt.Columns.Add("DEVICE-NAME", typeof(string));
                dt.Columns.Add("URL-PROTOCOL", typeof(string));
                dt.Columns.Add("URL-SYNC", typeof(string));



                foreach (FlushDataProtocol aProtocol in arrFlushDataProtocols)
                {
                    if (aProtocol == null)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }

                    DataRow row = dt.NewRow();
                    row["DESCRIPTION"] = aProtocol.description;
                    row["FLATFORM"] = aProtocol.flatform;
                    row["VERSION"] = aProtocol.version;
                    row["DEVICE-NAME"] = aProtocol.device_name;
                    row["URL-PROTOCOL"] = aProtocol.url_protocol;
                    row["URL-SYNC"] = aProtocol.url_sync;

                    dt.Rows.Add(row);

                }

            }
            catch (Exception ex)
            {
             //   log4net.Error("[getProtocolListWithDataTable] Exception: " + ex.Message);
            }

            return dt;

        }
    }

}