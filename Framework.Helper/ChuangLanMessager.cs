using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Framework.Helper
{
    public class ChuangLanMessager : IMessager
    {
        static JObject configJson = null;

        private string sMsgAccount = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("account").ToString();
        private string sMsgPassword = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("password").ToString();
        private string sMsgMD5key = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("MD5key").ToString();
        private string sRegisteMSG = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("Msg_Registe").ToString();
        private string sChangePWDMSG = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("Msg_ResetPassword").ToString();
        private string postUrl = configJson.GetValue("MessageInfo_Chuanglan").Value<string>("postUrl").ToString();

        static ChuangLanMessager()
        {
            using (TextReader tr = new StreamReader(Path.Combine(HttpRuntime.BinDirectory, "frame.config.json")))
            {
                string configStr = tr.ReadToEnd();
                configJson = JSONHelper.GetModel<JObject>(configStr);
            }
        }

        public string RegisteMessage
        {
            get
            {
                return sRegisteMSG;
            }
        }

        public string ChangePWDMessage
        {
            get
            {
                return sChangePWDMSG;
            }
        }

        public bool SendMessage(string mobileNumber, string MsgContent)
        {
            bool bResult = false;
            string postStrTpl = "account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true&extno=";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, sMsgAccount, sMsgPassword, mobileNumber, MsgContent));
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(postUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;
            Stream newStream = myRequest.GetRequestStream();

            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                bResult = true;
            }
            return bResult;
        }
    }
}
