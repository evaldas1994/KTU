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
            FindWay(cities);  //nelabai veikiantis


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
            int distance = ((cities[0].Location[0] - 1) - nearestFlowerShop[0]) + ((cities[0].Location[1] - 1) - nearestFlowerShop[1]);
            if(distance < 0)
            {
                return distance * (-1);
            }

            return distance;
        }

        public int GetDistanceToNewShop(List<City> cities, int i, int j)
        {
            return ((cities[0].Location[0] - 1) - i) + ((cities[0].Location[1] - 1) - j);
        }

        public int[] getDirection(List<City> cities)
        {
           
            int[] direction = new int[] { 0, 0 };
            if (cities[0].Location[0] -1 > GetNearestFlowerShop(cities)[0])
            {
                direction[0] = -1;
            }

            if (cities[0].Location[0] - 1 < GetNearestFlowerShop(cities)[0])
            {
                direction[0] = 1;
            }

            if (cities[0].Location[1] - 1 > GetNearestFlowerShop(cities)[1])
            {
                direction[1] = -1;
            }

            if (cities[0].Location[1] - 1 < GetNearestFlowerShop(cities)[1])
            {
                direction[1] = 1;
            }

            return direction;
        }

        public int FindWay(List<City> cities)
        {
            int[] location = cities[0].Location;
            int distance = GetDistanceToNearestShop(cities, GetNearestFlowerShop(cities));

            if(distance == 0)
            {
                Label1.Text = "Programa baigė darbą";
                return 0;
            }
           
                
                    System.Diagnostics.Debug.WriteLine("X ašyje dar reikia eiti");
                    if(((location[1] - 1 + getDirection(cities)[1]) < cities[0].MapSize) && ((location[1] - 1 + getDirection(cities)[1]) >=0))  //jei kairėje vis dar yra langelių
                    {
                        if((cities[0].Map[location[0]-1][location[1]-1 + getDirection(cities)[1]] == '0'))   //jei kairėje 0  ||  jei kairėje '.', o viršuje ne '0'
                        {
                            cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                            cities[0].Location = new int[] { location[0], location[1] + getDirection(cities)[1] };  //Pakeičiu klasėje naują vietą
                            System.Diagnostics.Debug.WriteLine("Paeinam į kairę. Dabartinės koordinatės: [" + (location[0] - 1) + ":" + (location[1] - 1) + "]");
                        }
                        else
                        {
                            if((cities[0].Map[location[0] - 1][location[1] - 1 + getDirection(cities)[1]] == '.') && ((cities[0].Map[location[0] - 1 + getDirection(cities)[0]][location[1] - 1] != '0')) )
                            {
                                cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                                cities[0].Location = new int[] { location[0], location[1] + (getDirection(cities)[1]*2) };  //Pakeičiu klasėje naują vietą
                                System.Diagnostics.Debug.WriteLine("Paeinam į kairę. Dabartinės koordinatės: [" + (location[0] - 1) + ":" + (location[1] - 1) + "]");
                            }
                        }
                    }
                        //System.Diagnostics.Debug.WriteLine("Dabartinės koordinatės: [" + (location[0]-1) + ":" + (location[1]-1) + "]");
                        //System.Diagnostics.Debug.WriteLine("Kairėje yra: " + cities[0].Map[location[0]-1][location[1]-1-1]);
                        //System.Diagnostics.Debug.WriteLine("Viršuje yra: " + cities[0].Map[location[0]-1-1][location[1]-1]);
                        //System.Diagnostics.Debug.WriteLine("Dešinėje yra: " + cities[0].Map[location[0]-1][location[1]]);
                        //System.Diagnostics.Debug.WriteLine("Apačioje yra: " + cities[0].Map[location[0]][location[1]-1]);
                    //}
                    
               

                
                    System.Diagnostics.Debug.WriteLine("X ašyje dar reikia eiti");
                    if (((location[0] - 1 + getDirection(cities)[0]) < cities[0].MapSize) && (location[0] - 1 + getDirection(cities)[0]) >= 0)  //jei kairėje vis dar yra langelių
                    {

                    //tryyyy
                    if (((cities[0].Map[location[0] - 1 + getDirection(cities)[0]][location[1] - 1] == '.') && (cities[0].Map[location[0] - 1 + (getDirection(cities)[0] * 2)][location[1] - 1] == 'G')))
                    {

                        //cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                        cities[0].Location = new int[] { location[0] + (getDirection(cities)[0] * 2), location[1] };  //Pakeičiu klasėje naują vietą
                        cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                        //System.Diagnostics.Debug.WriteLine("Paeinam į viršų. Dabartinės koordinatės: [" + (location[0] - 1) + ":" + (location[1] - 1) + "]");
                    }
                    ////end of try

                    if ((cities[0].Map[location[0] - 1 + getDirection(cities)[0]][location[1] - 1] == '0') && (cities[0].Map[location[0] - 1][location[1] - 1 + getDirection(cities)[1]] != '0'))   //jei viršuje '0', o kaireje ne '0'
                        {
                            cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                            cities[0].Location = new int[] { location[0] + getDirection(cities)[0], location[1] };  //Pakeičiu klasėje naują vietą
                            System.Diagnostics.Debug.WriteLine("Paeinam į viršų. Dabartinės koordinatės: [" + (location[0] - 1) + ":" + (location[1] - 1) + "]");
                        }
                        else
                        {
                            if (((cities[0].Map[location[0] - 1 + getDirection(cities)[0]][location[1] - 1] == '.') && ((cities[0].Map[location[0] - 1][location[1] - 1 + getDirection(cities)[1]] == '1'))))
                            {
                                cities[0].Map[location[0] - 1][location[1] - 1] = 'K';      //esamą vietą pažymiu 'K' keliu
                                cities[0].Location = new int[] { location[0] + (getDirection(cities)[0] * 2), location[1] };  //Pakeičiu klasėje naują vietą
                                System.Diagnostics.Debug.WriteLine("Paeinam į viršų. Dabartinės koordinatės: [" + (location[0] - 1) + ":" + (location[1] - 1) + "]");
                            }
                        }
                    }
                    //System.Diagnostics.Debug.WriteLine("Dabartinės koordinatės: [" + (location[0]-1) + ":" + (location[1]-1) + "]");
                    //System.Diagnostics.Debug.WriteLine("Kairėje yra: " + cities[0].Map[location[0]-1][location[1]-1-1]);
                    //System.Diagnostics.Debug.WriteLine("Viršuje yra: " + cities[0].Map[location[0]-1-1][location[1]-1]);
                    //System.Diagnostics.Debug.WriteLine("Dešinėje yra: " + cities[0].Map[location[0]-1][location[1]]);
                    //System.Diagnostics.Debug.WriteLine("Apačioje yra: " + cities[0].Map[location[0]][location[1]-1]);
                    //}

                

            

            string pathR = Server.MapPath("~/App_Data/Res3.txt");
            WriteFile(pathR, cities);

            FindWay(cities);

            return 0;
        }




    }
}