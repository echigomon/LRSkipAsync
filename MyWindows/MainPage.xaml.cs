using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LRSkipAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_LskipAsync lskip;
        private CS_RskipAsync rskip;
        private CS_LRskipAsync lrskip;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            lskip = new CS_LskipAsync();
            rskip = new CS_RskipAsync();
            lrskip = new CS_LRskipAsync();

            TextBox01.Text = "";

            // 初期表示をクリアする
            ClearResultTextBox();
        }

        #region ［ＬＳｋｉｐ］ボタン押下
        private async void button1_Click(object sender, RoutedEventArgs e)
        {   // [LSkip]ボタン押下
            //            WriteLineResult(@"[LSkip]");

            String KeyWord = TextBox01.Text;

            lskip.Wbuf = KeyWord;
            await lskip.ExecAsync();

            WriteLineResult("\nResult : [{0}]", lskip.Wbuf);
        }
        #endregion

        #region ［ＲＳｋｉｐ］ボタン押下
        private async void button2_Click(object sender, RoutedEventArgs e)
        {   // [RSkip]ボタン押下
            //            WriteLineResult(@"[RSkip]");

            String KeyWord = TextBox01.Text;

            rskip.Wbuf = KeyWord;
            await rskip.ExecAsync();

            WriteLineResult("\nResult : [{0}]", rskip.Wbuf);

        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private void button3_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();			// 初期表示をクリアする

            TextBox01.Text = "";
        }
        #endregion

        #region ［ＬＲＳｋｉｐ］ボタン押下
        private async void button4_Click(object sender, RoutedEventArgs e)
        {   // [LRSkip]ボタン押下
            // WriteLineResult(@"[LRSkip]");
            String KeyWord = TextBox01.Text;

            lrskip.Wbuf = KeyWord;
            await lrskip.ExecAsync();

            WriteLineResult("\nResult : [{0}]", lrskip.Wbuf);
        }
        #endregion
    }
}
