using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Users:Category
    {

        private string _Password;

        private int _Chack;

        public Users() { }

        public Users(int id , string name , string password , int chack):base(id,name)
        {

            _Password = password;

            _Chack = chack;

        }

        public string getPassword() => _Password;

        public int getChack() => _Chack;

       

        public override List<string> allItems()
        {


            List<string> tmp = new List<string>();
            tmp.Clear();
            string str = "";

            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Users ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {

                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString();
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
            mySqlCommand.CommandText = "Select * from Users ;";
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

        private Users giveMeObject(string str)
        {

            int cObject = 0;
            Users u1;
            string name = "", id = "" , password="" , chack="";
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
                    password += str[i];
                else if (cObject == 3)
                    chack += str[i];





            }

            u1 = new Users(int.Parse(id.Trim()), name.Trim(),password.Trim(),int.Parse(chack.Trim()));

            return u1;

        }

        public override string Update(string str)
        {
            Users tmp;
            tmp = giveMeObject(str);
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Users SET UserName='" + tmp.getName() + "', Password='" + tmp.getPassword() + "', chack='" + tmp.getChack() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();

            return "true";


        }

        public override string Insert(string str)
        {
            Users tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Users values('" + id + "','" + tmp.getName() + "','" + tmp.getPassword() + "','" + tmp.getChack() + "');";
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
            mySqlCommand.CommandText = "delete from Users where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }
    }
}
