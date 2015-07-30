using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Crawler
{
    public partial class frmBrowserWindow : Form
    {
        public frmBrowserWindow()
        {
            InitializeComponent();
        }

        private void frmBrowserWindow_Load(object sender, EventArgs e)
        {
            LoginVK loginController = new LoginVK();

            AuthorizationVK authrorizationController = new AuthorizationVK();
            int applicationId = 5002040;
            int scope = 1;

            //authrorizationController.authorize();
            webBrowser.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token", applicationId, scope));
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //LoginVK loginController = new LoginVK();

            //loginController.login();

            AuthorizationVK authorizationVK = new AuthorizationVK();

            if (authorizationVK.authorize(sender, e) == "failed")
            {
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.Document.GetElementById("email").InnerText = "";
                webBrowser.Document.GetElementById("pass").InnerText = "";
                webBrowser.Document.GetElementById("install_allow").InvokeMember("click");
            }


                //Login
            

            
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }
    }
}
