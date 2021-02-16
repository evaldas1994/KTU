using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/App_Data/Duom3.txt");

            ReadFile(path);

        }

        public void ReadFile(string path)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string[].
                    string[] readedandsplitted = sr.ReadLine().Split(' ');

                    int matrix = Int32.Parse(readedandsplitted[0]);
                    int locationY = Int32.Parse(readedandsplitted[1]);
                    int locationX = Int32.Parse(readedandsplitted[2]);

                    char[] streetPlan;
                    char[][] cityPlan = new char[matrix][]; ;
                    for (int i = 0; i < matrix; i++)
                    {
                        streetPlan = sr.ReadLine().ToCharArray();
                        cityPlan[i] = streetPlan;                       
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ee.Message);
            }
        }
    }
}