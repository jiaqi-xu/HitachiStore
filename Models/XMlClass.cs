using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using System.Data;
using System.Xml;
using System.Web;
using System.Web.UI;





namespace Models
{
   public  class XMlClass:XmlTextReader,IXmlLineInfo
    {
       public void SelectData( string Pstr)
       {
           string sqlstr = "select FirstClassDm.FirstClassDmName, SecondClassDm.SecondClassDmName ,ThirdClassDmName from ThirdClassDm left join SecondClassDm on ThirdClassDm.SecondClassDmID=SecondClassDm.SecondClassDmID left join FirstClassDm on FirstClassDm.FirstClassDmID=SecondClassDm.FirstClassDmID for xml auto,xmldata";
           SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connString"]);
           SqlCommand cmd = new SqlCommand(sqlstr, conn);
           conn.Open();
           XmlReader objXmlReader = cmd.ExecuteXmlReader();
           DataSet ds = new DataSet();
           ds.DataSetName = "GoodClass";
           ds.ReadXml(objXmlReader, XmlReadMode.Fragment);
           ds.WriteXml(Pstr );
           
           conn.Close();


       }
       
        
    }
}
