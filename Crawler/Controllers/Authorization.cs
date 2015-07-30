using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Text.RegularExpressions;

using Crawler.Controllers;


namespace Crawler
{
    class AuthorizationVK : IAuthorization
    {
        public string authorize(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                string accessToken = "";
                string userId = "";
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    {
                        userId = m.Groups["value"].Value;
                    }
                }
                MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", accessToken, userId));

                return "success";
            }
            return "failed";
        }
    }
}
