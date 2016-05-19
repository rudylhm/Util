using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
namespace Util.Serialization
{

    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SimpleSerialization
    {

        #region Json
        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            if (obj == null) return string.Empty;

            return JsonConvert.SerializeObject(obj);
        }

        public static string ObjectToJsonNullIgnore(object obj)
        {
            if (obj == null) return string.Empty;
            var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, jSetting);
        }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(string str)
        {
            return JsonConvert.DeserializeObject(str);
        }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static List<T> JsonToObjectList<T>(string str)
        {
            return JsonConvert.DeserializeObject<List<T>>(str);
        }

        #endregion

        #region Xml
        /// <summary>
        /// 对象序列化到XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToXml(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Encoding = Encoding.UTF8;
            setting.Indent = true;


            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(obj.GetType());

            MemoryStream stream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(stream, setting))
            {
                ser.Serialize(writer, obj);
            }

            stream.Position = 0;
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// XML反序列化回对象
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object XmlToObject(string xml, Type t)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(t);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }




        /// <summary>
        /// XML反序列化回对象
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            T obj = default(T);
            if (xml == null)
            {
                return obj;
            }

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(xml);
            using (System.Xml.XmlNodeReader reader = new System.Xml.XmlNodeReader(xdoc.DocumentElement))
            {
                obj = (T)ser.Deserialize(reader);
            }

            return obj;
        }
        #endregion

        #region Binary
        // Methods
        public static byte[] ToBytes(object value)
        {
            if (value == null)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, value);
                return stream.ToArray();
            }
        }

        public static object ToObject(byte[] serializedObject)
        {
            if (serializedObject == null)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(serializedObject))
            {
                return new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream);
            }
        }
        #endregion
    }
}
