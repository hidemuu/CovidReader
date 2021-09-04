using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace CovidReader.Repository
{
    public class XmlFileHelper
    {

        private string _path;
        //private XElement _xml;

        public XmlFileHelper(string path)
        {
            _path = path;
            //_xml = XElement.Load(path);
        }

        public T Read<T>()
        {
            using (var stream = new StreamReader(_path, new UTF8Encoding(false)))
            {
                var serializer = new XmlSerializer(typeof(T));
                //if (stream != null)
                //{
                //    return (T)se.Deserialize(stream);
                //}
                return (T)serializer.Deserialize(stream);
            }

        }

        public void Write<T>(T obj)
        {
            XmlSerializer se = new XmlSerializer(typeof(T));
            StreamWriter sw = new StreamWriter(_path, false, new UTF8Encoding(false));
            se.Serialize(sw, obj);
            sw.Close();
            
        }

    }
}
