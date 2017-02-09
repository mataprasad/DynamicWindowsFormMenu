using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicWinMenu
{
    public class XMenu
    {
        public XMenu()
        {
            Childs = new List<XMenu>();
        }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Text { get; set; }
        [XmlAttribute]
        public string Key { get; set; }
        [XmlAttribute]
        public int Index { get; set; }
        public List<XMenu> Childs { get; set; }
    }
}
