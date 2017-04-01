using Pechkin;
using Pechkin.Synchronized;
using System.Drawing.Printing;

namespace Util.Files
{
    public class PDFHelper
    {
        public static byte[] ConvertHtmlToPDF(string htmlText, string url)
        {
            //Pechkin.SimplePechkin sc = new SimplePechkin(new GlobalConfig()
            SynchronizedPechkin sc = new SynchronizedPechkin(new GlobalConfig()

            .SetMargins(new Margins() { Left = 0, Right = 0, Top = 0, Bottom = 0 }) //设置边距
                    .SetPaperOrientation(false) //设置纸张方向为横向
                    .SetPaperSize(550, 1000)); //设置纸张大小(使用者可以根据自己的需求设置。这里的50代表长，100代表宽)

            ObjectConfig oc = new ObjectConfig();

            oc.SetPrintBackground(true).SetLoadImages(true).Header.SetHtmlContent(url);

            //以上设置十分重要:

            //SetPrintBackground(true)是显示样式所必须的(例如令设置有颜色的<div>能在PDF中显示出来)。

            //SetLoadImages(true)令PDF可以加载图片。由于Pechkin是封装wkhtmltopdf。wkhtmltopdf是不能识别相对路径的图片文件的。所以HTML内的所有图片路径都不能使用相对路径！必须使用绝对路径！

            //.Header.SetHtmlContent(WebPageUri)是使用一个网页内容来设置PDF的页眉。

            var byteResult = sc.Convert(oc, htmlText);

            return byteResult;
        }
    }
}
