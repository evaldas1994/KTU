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
            List<City> cities = new List<City>();
            ReadFile(path, cities);

        }

        public void ReadFile(string path, List<City> cities)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string[].
                    string[] readedandsplitted = sr.ReadLine().Split(' ');

                    int mapSize = Int32.Parse(readedandsplitted[0]);
                    int locationY = Int32.Parse(readedandsplitted[1]);
                    int locationX = Int32.Parse(readedandsplitted[2]);

                    char[] streetPlan;
                    char[][] cityPlan = new char[mapSize][]; ;
                    for (int i = 0; i < mapSize; i++)
                    {
                        streetPlan = sr.ReadLine().ToCharArray();
                        cityPlan[i] = streetPlan;
                    }

                    // Set data to cities list
                    SetDataToList(mapSize, locationY, locationX, cityPlan, cities);
                }
            }

            catch (IOException ee)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ee.Message);
            }
        }

        public void SetDataToList(int mapSize, int locationY, int locationX, char[][] cityPlan, List<City> cities)
        {
            City city = new City();

            city.MapSize = mapSize;
            city.Location = new int[] { locationY, locationX };
            city.Map = cityPlan;

            cities.Add(city);
        }
    }
}