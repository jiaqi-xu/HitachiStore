using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    public  class SingleGoodHtmlEdit
    {
        private int goodID;
        public int GoodID
        {
            set { goodID = value; }
            get { return goodID; }
        }
        private string editText;
        public string EditText
        {
            set {  editText=value ; }
            get { return editText; }
        }
        private string editImg;
        public string EditImg
        {
            set { editImg = value; }
            get { return editImg; }
        }
        public static List<SingleGoodHtmlEdit> getSingleGoodHtmlEditInfo(int goodid)
        {
            List<SingleGoodHtmlEdit> singGoodHtmlList = new List<SingleGoodHtmlEdit>();
            string lSqlstring = "select * from SingleGoodHtmlEdit where GoodID='" + goodid + "'";
            SqlHelper.ReadDateReadBegin(lSqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                SingleGoodHtmlEdit singleGoodHtml = new SingleGoodHtmlEdit();
                singleGoodHtml.EditImg = SqlHelper.SqlReader["EditImg"].ToString();
                singleGoodHtml.EditText = SqlHelper.SqlReader["EditText"].ToString();
                singGoodHtmlList.Add(singleGoodHtml);
            }
            SqlHelper.ReadDateReadEnd();
            return singGoodHtmlList;
        }
        public bool DeleteGoodHtml()
        {
            string lString = "delete from SingleGoodHtmlEdit where EditImg='" + this.EditImg + "'";
            if (SqlHelper.ExecuteNonQuery(lString)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AlterGoodHtml()
        {
            string lString = "update SingleGoodHtmlEdit set EditText='" + this.EditText + "',EditImg='"+this.EditImg+"'";
            if (SqlHelper.ExecuteNonQuery(lString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
