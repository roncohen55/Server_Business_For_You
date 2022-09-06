using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class OrdersSuppliers:Category
    {
        private string _NameSalesmen;

        private string _Info;

        private string _Date;

        private float _Price;

        public OrdersSuppliers(int id , string name ,string nameSalesmen, string info , float price , string date) : base(id, name)
        {
            _NameSalesmen = nameSalesmen;
            _Info = info;
            _Price = price;
            _Date = date;
        }

        public OrdersSuppliers() { }

        public string getNameSalesmen() => _NameSalesmen;

        public string getDetails() => _Info;

        public string getDate() => _Date;

        public float getPrice() => _Price;

        public override List<string> allItems()
        {


            List<string> tmp = new List<string>();
            tmp.Clear();
            string str = "";

            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from OrdersSuppliers ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {

                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString();
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
            mySqlCommand.CommandText = "Select * from OrdersSuppliers ;";
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

        private OrdersSuppliers giveMeObject(string str)
        {

            int cObject = 0;
            OrdersSuppliers s1;
            string name = "", id = "", nameSalsmen = "", details = "", date = "", price = "";
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
                    nameSalsmen += str[i];
                else if (cObject == 3)
                    details += str[i];
                else if (cObject == 4)
                    price += str[i];
                else if (cObject == 5)
                    date += str[i];
               

            }

            s1 = new OrdersSuppliers(int.Parse(id.Trim()), name.Trim(), nameSalsmen.Trim(), details.Trim(), float.Parse( price.Trim()), date.Trim());

            return s1;

        }

        public override string Insert(string str)
        {
            OrdersSuppliers tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            DateTime myDate = DateTime.Now;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into OrdersSuppliers values('" + id + "','" + tmp.getName() + "','" + tmp.getNameSalesmen() + "','" + tmp.getDetails() + "','" + tmp.getPrice() + "','" + myDate.ToString("dd/MM/yyyy") + "');";
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
            mySqlCommand.CommandText = "delete from OrdersSuppliers where id=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }
    }
}
