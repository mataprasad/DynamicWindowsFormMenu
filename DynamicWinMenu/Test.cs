using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            Test.GenerateSampleMenuXmlFile("menu_x1.xml");
            menuStrip1.PopulateFromMenuXmlFile("menu_x1.xml", (o, e) =>
            {
                var obj = o as ToolStripMenuItem;
                if (obj != null)
                {
                    Console.WriteLine(Convert.ToString(obj.Tag));
                }
            });
        }

        public static bool GenerateSampleMenuXmlFile(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "DynamicWinMenu.menu.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    File.WriteAllText(path, reader.ReadToEnd());
                }
            }

            return true;
        }
    }
}
