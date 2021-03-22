using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD1
{
    class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        private int[] Credits { get; set; }
        public int CreditsCount { get; set; }

        public Student(string Surname, string Name, string Group, int[] Credits, int CreditsCount)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Group = Group;
            this.Credits = Credits;
            this.CreditsCount = CreditsCount;
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < CreditsCount; i++)
            {
                line += Credits[i] + " ";
            }
            return String.Format("| {0,15} | {1,15} | {2,15} | {3,15) | ",
                this.Surname, this.Name, this.Group, this.Credits, line );
        }
    } 
}
