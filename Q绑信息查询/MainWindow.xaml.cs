using Newtonsoft.Json;
using Q绑信息查询.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Q绑信息查询
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string qqApi= "http://api.qb-api.com/qb-api.php?mod=cha&qq=";

        string numApi = "http://api.qb-api.com/bq-api.php?mobile=";

        string lolApi = "http://qb-api.com/lol-api.php?mod=cha&qq=";

        string idApi = "http://qb-api.com/lolfc-api.php?name=";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnQQSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput1.Text == null || txtInput1.Text == string.Empty)
            {
                lbTips.Text = "请输入需要查询的QQ号码!";
            }
            else
            {
                lbTips.Text = "查询中，请稍等...";
                string url = qqApi + txtInput1.Text.Trim();
                try
                {
                    Task.Run(()=> 
                    {
                        string str = HttpApi(url);
                        QQSearch search = JsonConvert.DeserializeObject<QQSearch>(str);
                        if (search.Code == 200 && search.Msg == "ok")
                        {
                            Data data = search.Data;
                            Place place = search.Place;
                            Dispatcher.BeginInvoke(new Action(()=> 
                            {
                                lbTips.Text = "查询成功!";
                                txtReturn1.Text = $"QQ:{data.QQ}\r\n手机号:{data.Mobile}\r\n归属地:{place.Province} {place.City}\r\n邮编:{place.Postcode}\r\n运营商:{place.SP}";
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                txtReturn1.Clear();
                                lbTips.Text = "数据库没有此内容...";
                            }));
                        }
                    });
                }
                catch
                {
                    lbTips.Text = "网络状况不佳,查询出现异常,请稍后重试!";
                }
            }
        }

        private void BtnMobileSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput1.Text == null || txtInput1.Text == string.Empty)
            {
                lbTips.Text = "请输入需要查询的手机号码!";
            }
            else
            {
                string url = numApi+ txtInput1.Text.Trim();
                lbTips.Text = "查询中，请稍等...";
                try
                {
                    Task.Run(()=> 
                    {
                        string str = HttpApi(url);
                        NumSearch num = JsonConvert.DeserializeObject<NumSearch>(str);
                        if (num.Code == 200 && num.Msg == "ok")
                        {
                            Data data = num.Data;
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                lbTips.Text = "查询成功!";
                                txtReturn1.Text = $"QQ:{data.QQ}\r\n手机号:{data.Mobile}";
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                txtReturn1.Clear();
                                lbTips.Text = "数据库没有此内容...";
                            }));
                        }
                    });
                }
                catch
                {
                    lbTips.Text = "网络状况不佳,查询出现异常,请稍后重试!";
                }
            }
        }

        private void BtnQQSearchLOL_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput2.Text == null || txtInput2.Text == string.Empty)
            {
                lbTips.Text = "请输入需要查询的QQ号码!";
            }
            else
            {
                string url = lolApi + txtInput2.Text.Trim();
                lbTips.Text = "查询中，请稍等...";
                try
                {
                    Task.Run(() =>
                    {
                        string str = HttpApi(url);
                        LOLSearch lol = JsonConvert.DeserializeObject<LOLSearch>(str);
                        if (lol.Code == 200 && lol.Msg == "ok")
                        {
                            LOLData data = lol.Data;
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                lbTips.Text = "查询成功!";
                                txtReturn2.Text = $"游戏ID:{data.QQ}\r\n区服:{data.Server}";
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                txtReturn2.Clear();
                                lbTips.Text = "数据库没有此内容...";
                            }));
                        }
                    });
                }
                catch
                {
                    lbTips.Text = "网络状况不佳,查询出现异常,请稍后重试!";
                }
            }
        }

        private void BtnIDSearchLOL_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput2.Text == null || txtInput2.Text == string.Empty)
            {
                lbTips.Text = "请输入需要查询的ID!";
            }
            else
            {
                string url = idApi + txtInput2.Text.Trim();
                lbTips.Text = "查询中，请稍等...";
                try
                {
                    Task.Run(()=> 
                    {
                        string str = HttpApi(url);
                        LOLSearch lol = JsonConvert.DeserializeObject<LOLSearch>(str);
                        if (lol.Code == 200 && lol.Msg == "ok")
                        {
                            LOLData data = lol.Data;
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                lbTips.Text = "查询成功!";
                                txtReturn2.Text = $"QQ:{data.QQ}\r\n区服:{data.Server}";
                            }));
                        }
                        else
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                txtReturn2.Clear();
                                lbTips.Text = "数据库没有此内容...";
                            }));
                        }
                    });
                }
                catch
                {
                    lbTips.Text = "网络状况不佳,查询出现异常,请稍后重试!";
                }
            }
        }        
        
        /// <summary>
        /// 调用API返回Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string HttpApi(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.Accept = "text/html,application/xhtml/xml,*/*";
            request.ContentType = "application/json";
            byte[] buffer = new byte[1024];
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void SystemBtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SystemBtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
