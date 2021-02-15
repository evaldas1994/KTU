using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD0
{
    public class ProfileClass
    {
        private string name;
        private string school;
        private int age;
        private string[] programmingLanguages;

        //public ProfileClass(string name, string school, int age, string[] programmingLanguage)
        public ProfileClass()
        {
            //this.name = name;
            //this.school = school;
            //this.age = age;
            //this.programmingLanguages = programmingLanguage;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string School
        {
            get { return school; }
            set { school = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string[] ProgrammingLanguages
        {
            get { return programmingLanguages; }
            set { programmingLanguages = value; }
        }

        public ProfileClass Profile { get; internal set; }
    }
}