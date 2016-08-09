using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public class RecevierAddress
    {
        /// <summary>
        /// 客户ID
        /// </summary>		
        private string _sclientid;
        public string sClientID
        {
            get { return _sclientid; }
            set { _sclientid = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>		
        private string _susername;
        public string sUserName
        {
            get { return _susername; }
            set { _susername = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _sphone;
        public string sPhone
        {
            get { return _sphone; }
            set { _sphone = value; }
        }
        /// <summary>
        /// 省
        /// </summary>		
        private string _sprovince;
        public string sProvince
        {
            get { return _sprovince; }
            set { _sprovince = value; }
        }
        /// <summary>
        /// 市
        /// </summary>		
        private string _scity;
        public string sCity
        {
            get { return _scity; }
            set { _scity = value; }
        }
        /// <summary>
        /// 区县
        /// </summary>		
        private string _scounty;
        public string sCounty
        {
            get { return _scounty; }
            set { _scounty = value; }
        }
        /// <summary>
        /// 具体地址
        /// </summary>		
        private string _saddress;
        public string sAddress
        {
            get { return _saddress; }
            set { _saddress = value; }
        }
    }
}
