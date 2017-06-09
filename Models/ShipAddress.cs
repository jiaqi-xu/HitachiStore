/*
 * 1 功能描述: 送货地址实体类
 * 
 * 2 作者：徐嘉琪
 * 
 * 3 创建时间：2012-08-07-15-30
 * 
 * 4 完成时间
 * 
 * 5 修改记录:
 * 暂无（修改时间、内容、人）；
 * 修改人 郭正肖 修改时间 20212-08-16-22-03； 修改内容：修改类名
 * 添加字段；
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ShipAddress
    {
        /// <summary>
        /// addressID
        /// </summary>
        private int addressID;
        public int AddressID
        {
            set { addressID = value; }
            get { return addressID; }
        }

        /// <summary>
        ///  address
        /// </summary>
        private string address;
        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        /// <summary> 
        ///  是否默认送货地址 
        /// </summary>
        private char isDefault;
        public char IsDefault
        {
            set { isDefault = value; }
            get { return isDefault; }
        }
        /// <summary>
        /// UserID
        /// </summary>
        private int userID;
        public int UserID
        {
            set { userID = value; }
            get { return userID; }
        }

    }
}
