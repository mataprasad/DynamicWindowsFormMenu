using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicWinMenu
{
    public static class MenuStripExtentions
    {
        public static void PopulateFromMenuXmlFile(this MenuStrip menuStrip, string menu_xml_file_path, EventHandler eventHnadler)
        {
            PopulateMenu(ref menuStrip, Helper.DeserializeFromXML<List<XMenu>>(File.ReadAllText(menu_xml_file_path)), eventHnadler);
        }

        public static void Populate(this MenuStrip menuStrip, string menu_xml_text, EventHandler eventHnadler)
        {
            PopulateMenu(ref menuStrip, Helper.DeserializeFromXML<List<XMenu>>(menu_xml_text), eventHnadler);
        }

        public static void Populate(this MenuStrip menuStrip, List<XMenu> menus, EventHandler eventHnadler)
        {
            PopulateMenu(ref menuStrip, menus, eventHnadler);
        }

        public static void PopulateMenu(ref MenuStrip menuStrip, List<XMenu> menus, EventHandler eventHnadler)
        {
            foreach (var item in menus.OrderBy(P => P.Index))
            {
                ToolStripMenuItem menu_ = new ToolStripMenuItem();
                menu_.Text = item.Text;
                menu_.Name = item.Name;
                menu_.Tag = item.Key;
                if (eventHnadler != null)
                {
                    menu_.Click += eventHnadler;
                }
                PopulateChilds(ref menu_, item, eventHnadler);
                menuStrip.Items.Add(menu_);
            }
        }

        private static void PopulateChilds(ref ToolStripMenuItem menu, XMenu data, EventHandler eventHnadler)
        {
            if (data.Childs.Count == 0)
            {
                return;
            }
            foreach (var item in data.Childs.OrderBy(P => P.Index))
            {
                ToolStripMenuItem menu_ = new ToolStripMenuItem();
                menu_.Text = item.Text;
                menu_.Name = item.Name;
                menu_.Tag = item.Key;
                if (eventHnadler != null)
                {
                    menu_.Click += eventHnadler;
                }
                menu.DropDownItems.Add(menu_);
                PopulateChilds(ref menu_, item, eventHnadler);
            }
        }
    }
}
