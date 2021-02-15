using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 14; i <= 25; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            } 

            if((List<ProfileClass>)Session["List"] != null)
            {
                List<ProfileClass> savedProfiles = (List<ProfileClass>)Session["List"];

                foreach(ProfileClass P in savedProfiles)
                {
                    displayResult(P);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] checkedLanguages = this.getChecked();
            
            ProfileClass P = new ProfileClass();
            P.Name = TextBox1.Text;
            P.School = TextBox2.Text;
            P.Age = Int32.Parse(DropDownList1.SelectedItem.Text);
            P.ProgrammingLanguages = getChecked();


            if ((List<ProfileClass>)Session["List"] == null)
            {
                List<ProfileClass> savedProfiles = new List<ProfileClass>();
                savedProfiles.Add(P);
                Session["List"] = savedProfiles;

                Table1.Rows.Clear();
                displayResult(P);
            } else
            {
                List<ProfileClass> savedProfiles = (List<ProfileClass>)Session["List"];
                savedProfiles.Add(P);
                Session["List"] = savedProfiles;

                Table1.Rows.Clear();
                foreach (ProfileClass PP in savedProfiles)
                {
                    displayResult(PP);
                }
            }
                
            //displayResult(P);

        }

        private string[] getChecked()
        {
            string[] strArray = { };
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)// getting selected value from CheckBox List  
                {
                    strArray = arrayPush(strArray, i);
                }
            }
            return strArray;
        }

        private string[] arrayPush(string[] strArray, int i)
        {
            Array.Resize(ref strArray, strArray.Length + 1);
            strArray[strArray.GetUpperBound(0)] = CheckBoxList1.Items[i].Text;
            return strArray;
        }
    
        private void displayResult(ProfileClass P)
        {
            TableRow row = new TableRow();

            TableCell name = new TableCell();
            name.Text = P.Name;

            TableCell school = new TableCell();
            school.Text = P.School;

            TableCell age = new TableCell();
            age.Text = P.Age.ToString();

            TableCell programingLanguages = new TableCell();
            programingLanguages.Text = string.Join(", ", P.ProgrammingLanguages);

            row.Cells.Add(name);
            row.Cells.Add(school);
            row.Cells.Add(age);
            row.Cells.Add(programingLanguages);

            Table1.Rows.Add(row);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }


}