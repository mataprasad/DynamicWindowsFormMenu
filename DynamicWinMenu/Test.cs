using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicWinMenu
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            menuStrip1.PopulateFromMenuXmlFile("menu.xml", (o, e) =>
            {
                var obj = o as ToolStripMenuItem;
                if (obj != null)
                {
                    Console.WriteLine(Convert.ToString(obj.Tag));
                }
            });
        }
    }
}
