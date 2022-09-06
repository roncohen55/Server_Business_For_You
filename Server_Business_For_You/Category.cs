using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Category
    {
        private int _id;

        private string _Name;

        public Category() { }

        public Category (int id , string name)
        {
            _id = id;
            _Name = name;
        }

        public int getId() => _id;

        public string getName() => _Name;

        public virtual List<string> allItems()
        {

           
                List<string> tmp = new List<string>();
                tmp.Clear();
                string str = "";

                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "Select * from Category ;";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





                while (mySqlDataReader.Read())
                {

                    str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString();
                    tmp.Add(str);


                }


                mySqlDataReader.Close();
                mySqlConnection.Close();

                return tmp;

            
        }

       

        public virtual int givemeID()
        {

            int id = 0;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Category ;";
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

        private Category giveMeObject(string str)
        {

            int cObject = 0;
            Category c1;
            string name = "", id = "";
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
               




            }

            c1 = new Category(int.Parse(id.Trim()), name.Trim());

            return c1;

        }

        public virtual string Update(string str)
        {
            Category tmp;
            tmp = giveMeObject(str);
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Category SET NameCategory='" + tmp.getName() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();

            return "true";


        }

        public virtual string Insert(string str)
        {
            Category tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Category values('" + id + "','" + tmp.getName() + "');";
            num = mySqlCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            return "true";
        }

        public virtual string Delete(string str)
        {
            int num, id;
            id = int.Parse(str);
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "delete from Category where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }

    }
}
