using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Suppliers:Category
    {
        private string _Company;

        private string _Details;

        private string _Phone;

        private string _Email;

        private int _Rating; 

        public Suppliers() { }


        public Suppliers(int id , string name , string company , string details , string phone , string email , int rating):base(id,name)
        {
            _Company = company;

            _Details = details;

            _Phone = phone;

            _Email = email;

            _Rating = rating;
        }

        public string getCompany() => _Company;

        public string getDetails() => _Details;

        public string getPhone() => _Phone;

        public string getEmail() => _Email;

        public int getRating() => _Rating;

       

        public override List<string> allItems()
        {


            List<string> tmp = new List<string>();
            tmp.Clear();
            string str = "";

            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Suppliers ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {

                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString() + " ~ " + mySqlDataReader[6].ToString();
                tmp.Add(str);


            }


            mySqlDataReader.Close();
            mySqlConnection.Close();

            return tmp;


        }



        public override int givemeID()
        {

            int id = 0;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Suppliers ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {


                id = int.Parse(mySqlDataReader[0].ToString());



            }


            mySqlDataReader.Close();
            mySqlConnection.Close();

            return id;

        }

        private Suppliers giveMeObject(string str)
        {

            int cObject = 0;
            Suppliers s1;
            string name = "", id = "", company = "", details = "" , phone="" , email="" , rating="";
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '~')
                {
                    cObject++;


                }

                else if (cObject == 0 && str[i] >= '0' && str[i] <= '9')
                    id += str[i];
                else if (cObject == 1)
                    name += str[i];
                else if (cObject == 2)
                    company += str[i];
                else if (cObject == 3)
                    details += str[i];
                else if (cObject == 4)
                    phone += str[i];
                else if (cObject == 5)
                    email += str[i];
                else if (cObject == 6)
                    rating += str[i];




            }

            s1 = new Suppliers(int.Parse(id.Trim()), name.Trim(), company.Trim(),details.Trim(),phone.Trim(),email.Trim() ,int.Parse(rating.Trim()));

            return s1;

        }

        public override string Update(string str)
        {
            Suppliers tmp;
            tmp = giveMeObject(str);
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Suppliers SET Name='" + tmp.getName() + "', Company='" + tmp.getCompany() + "', Details='" + tmp.getDetails() + "', Phone='" + tmp.getPhone() + "', email='" + tmp.getEmail() + "', Rating='" + tmp.getRating() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();

            return "true";


        }

        public override string Insert(string str)
        {
            Suppliers tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Suppliers values('" + id + "','" + tmp.getName() + "','" + tmp.getCompany() + "','" + tmp.getDetails() + "','" + tmp.getPhone() + "','" + tmp.getEmail() + "','" + tmp.getRating() + "');";
            num = mySqlCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            return "true";
        }

        public override string Delete(string str)
        {
            int num, id;
            id = int.Parse(str);
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "delete from Suppliers where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }

    }
}
