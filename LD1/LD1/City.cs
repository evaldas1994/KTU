using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD1
{
    public class City
    {
        private int mapSize;
        private int[] location;
        private char[][] map;

        public City()
        {

        }

        public int MapSize
            {
            get; set;
            }

        public int[] Location
        {
            get; set;
        }

        public char[][] Map
        {
            get; set;
        }

    }
}