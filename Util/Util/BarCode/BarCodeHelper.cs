using System;
using System.Drawing;
using com.google.zxing;
using com.google.zxing.common;
using ByteMatrix = com.google.zxing.common.ByteMatrix;
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

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="qrCode">二维码的Bitmap</param>
        /// <returns></returns>
        public static string DecodeQRCode(Bitmap qrCode)
        {
            LuminanceSource source = new RGBLuminanceSource(qrCode, qrCode.Width, qrCode.Height);
            var bBitmap = new BinaryBitmap(new HybridBinarizer(source));
            var result = new MultiFormatReader().decode(bBitmap);
            return result.Text;
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
