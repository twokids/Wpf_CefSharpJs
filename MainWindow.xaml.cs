using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CefSharpJs
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebView();


        }

        /// <summary>
        /// 初始化浏览器控件
        /// </summary>
        private void InitializeWebView()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            webView.RegisterAsyncJsObject("dotNetMessage", new DotNetMessage(this));
            //bin 目录中
            string path = AppDomain.CurrentDomain.BaseDirectory + @"templates\index.html";
            webView.Address = path;
            webView.FrameLoadEnd += OnBrowserFrameLoadEnd;        
        }

        private void OnBrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            if (args.Frame.IsMain)
            {
                webView.ExecuteScriptAsync("indexJs.jsMethod('你好')");
            }
        }

    }
}
