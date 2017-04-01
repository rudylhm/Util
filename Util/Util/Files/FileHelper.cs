using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Files
{
    public class FileHelper
    {
        /// <summary>
        /// 通过文件名获取后缀名
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string GetFileExt(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1, (fileName.Length - fileName.LastIndexOf(".") - 1));
        }


        public static bool IsExistFile(string fileFullPath)
        {
            string directoryPath = GetFileDirectory(fileFullPath);
            if (Directory.Exists(directoryPath))
            {
                if (File.Exists(fileFullPath))
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// 从文件路径获取其所在目录
        /// </summary>
        ///<param name="path">文件路径</param>
        /// <returns>目录路径</returns>
        public static string GetFileDirectory(string path)
        {
            if (path.EndsWith("\\"))
            {
                return path;
            }
            return path.Substring(0, path.LastIndexOf("\\"));
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="content">要写入的byte数组</param>
        /// <returns>是否成功</returns>
        public static bool WriteFile(string filePath, string fileName, byte[] content)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                using (FileStream fsWrite = new FileStream(CombineFilePathAndName(filePath, fileName), FileMode.Append))
                {
                    fsWrite.Write(content, 0, content.Length);
                };
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="stream">要写入的流</param>
        /// <returns>是否成功</returns>
        public static bool WriteFile(string filePath, string fileName, Stream stream)
        {
            try
            {
                byte[] content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return WriteFile(filePath, fileName, content);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteFile(string fileFullPath)
        {
            try
            {
                if (!File.Exists(fileFullPath))
                {
                    return true;
                }
                File.Delete(fileFullPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 检查文件后缀名是否在列表中
        /// </summary>
        /// <param name="extList">后缀列表</param>
        /// <param name="fileName">文件名</param>
        /// <returns>返回是否</returns>
        public static bool CheckFileExt(List<string> extList, string fileName)
        {
            string fileExt = GetFileExt(fileName);
            if (extList.Contains(fileExt))
            {
                return true;
            }
            return false;
        }

        private static string CombineFilePathAndName(string filePath, string fileName)
        {
            if (!filePath.EndsWith("\\"))
            {
                filePath += "\\";
            }
            return filePath + fileName;
        }
    }
}
