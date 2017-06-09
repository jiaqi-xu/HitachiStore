using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;


namespace Models
{
    public class XmlTextReader : XmlReader, IXmlLineInfo
    {

        public void SelectData()
        {

            string sqlstring = "select FirstClassDm.FirstClassDmName, SecondClassDm.SecondClassDmName ,ThirdClassDmName from ThirdClassDm left join SecondClassDm on ThirdClassDm.SecondClassDmID=SecondClassDm.SecondClassDmID left join FirstClassDm on FirstClassDm.FirstClassDmID=SecondClassDm.FirstClassDmID for xml auto,xmldata";
            //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connString"]);
            SqlConnection conn = new SqlConnection("server=192.168.99.132;uid=sa;pwd=sa;database=HitachiStore;");
            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            conn.Open();
            XmlTextReader objXmlReader = (XmlTextReader)cmd.ExecuteXmlReader();
            DataSet ds = new DataSet();
            ds.DataSetName = "GoodClass";
            ds.ReadXml(objXmlReader, XmlReadMode.Fragment);
            ds.WriteXml("App_Data\\GoodClass.xml", XmlWriteMode.WriteSchema);
            conn.Close();



        }


    }
}
