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
            string pathD = Server.MapPath("~/App_Data/Duom3.txt");
            string pathR = Server.MapPath("~/App_Data/Res3.txt");
            List<City> cities = new List<City>();
            ReadFile(pathD, cities);

            int[] nearestShop = GetNearestFlowerShop(cities);

            WriteFile(pathR, cities);
        }

        public void ReadFile(string path, List<City> cities)
        {
            try
            {
                // Open the text file using a streamReader.
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

        public void WriteFile( string path, List<City> cities)
        {
            try
            {
                // Open the text file using a streamReader.
                using (StreamWriter sw = new StreamWriter(path))
                {
                    // Write file using StreamWriter  

                    foreach(City city in cities)
                    {
                        sw.Write(city.MapSize + " " + city.Location[0] + " " + city.Location[1]);
                        for(int i=0; i<city.Map.Length; i++)
                        {
                            sw.WriteLine();
                            for(int j=0; j<city.Map.Length; j++)
                            {
                                sw.Write(city.Map[i][j]);
                            }                          
                        }
                    }
                }
            }

            catch (IOException ee)
            {
                Console.WriteLine("The file could not be wrote");
                Console.WriteLine(ee.Message);
            }
        }

        public int[] GetNearestFlowerShop(List<City> cities)
        {
            int[] nearestFlowerShop = new int[] { -1, -1 };
            for (int i=0;i<cities[0].Map.Length; i++)
            {
                for(int j=0; j < cities[0].Map.Length; j++)
                {
                    if(cities[0].Map[i][j] == 'G')
                    {
                        if(nearestFlowerShop[0] < 0)
                        {
                            nearestFlowerShop[0] = i;
                            nearestFlowerShop[1] = j;
                        }
                        else
                        {
                            if (GetDistanceToNearestShop(cities, nearestFlowerShop) > GetDistanceToNewShop(cities, i, j))
                            {
                                nearestFlowerShop[0] = i;
                                nearestFlowerShop[1] = j;
                            }
                        }
                    }
                }
            }

            return nearestFlowerShop;
        }

        public int GetDistanceToNearestShop(List<City> cities, int[] nearestFlowerShop)
        {
            return ((cities[0].Location[0] - 1) - nearestFlowerShop[0]) + ((cities[0].Location[1] - 1) - nearestFlowerShop[1]);
        }

        public int GetDistanceToNewShop(List<City> cities, int i, int j)
        {
            return ((cities[0].Location[0] - 1) - i) + ((cities[0].Location[1] - 1) - j);
        }
    }
}