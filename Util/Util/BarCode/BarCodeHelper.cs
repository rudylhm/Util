using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using com.google.zxing;
using ByteMatrix = com.google.zxing.common.ByteMatrix;
using EAN13Writer = com.google.zxing.oned.EAN13Writer;
using EAN8Writer = com.google.zxing.oned.EAN8Writer;
using MultiFormatWriter = com.google.zxing.MultiFormatWriter;

namespace Util.BarCode
{
    public class BarCodeHelper
    {
        /// <summary>
        /// 生成条码(EAN_8 编码)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽</param>
        /// <param name="height">长</param>
        /// <returns></returns>
        public static Bitmap CreateBarCode_EAN8(string content, int width = 32, int height = 16)
        {
            // 生成一维码  
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.EAN_8, width, height);
            try
            {
                return toBitmap(byteMatrix);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 生成条码(EAN_16 编码)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽</param>
        /// <param name="height">长</param>
        /// <returns></returns>
        public static Bitmap CreateBarCode_EAN13(string content, int width = 32, int height = 16)
        {
            // 生成一维码  
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.EAN_13, width, height);
            try
            {
                return toBitmap(byteMatrix);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽</param>
        /// <param name="height">长</param>
        /// <returns></returns>
        public static Bitmap CreateQRCode(string content, int width = 64, int height = 64)
        {
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, width, height);
            return toBitmap(byteMatrix);
        }

        private static Bitmap toBitmap(ByteMatrix matrix)
        {
            // 定义位图的款和高  
            int width = matrix.Width;
            int height = matrix.Height;

            Bitmap bmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            return bmap;
        }


    }
}
