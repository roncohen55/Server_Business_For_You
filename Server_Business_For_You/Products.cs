using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Products:Category
    {
        private string _Makat;

        private int _Quantity;

        private int _Type;

        private float _Price;

        private float _PriceForTheBusiness;

        public Products() { }

        public Products(int id , string makat , string name , int quantity , int type , float price , float priceforthebusiness) : base(id, name)
        {
            _Makat = makat;

            _Quantity = quantity;

            _Type = type;

            _Price = price;

            _PriceForTheBusiness = priceforthebusiness;
        }

        public string getMakat() => _Makat;

        public int getQuantity() => _Quantity;

        public int getType() => _Type;

        public float getPrice() => _Price;

        public float getPriceForBusiness() => _PriceForTheBusiness;

      

        public override List<string> allItems()
        {


            List<string> tmp = new List<string>();
            tmp.Clear();
            string str = "";

            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Products ;";
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

        public List<string> allItemsForCategory(string st)
        {
            int types = int.Parse(st);

            List<string> tmp = new List<string>();
            tmp.Clear();
            string str = "";

            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Products where type='" + types + "';";
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
            mySqlCommand.CommandText = "Select * from Products ;";
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

        private Products giveMeObject(string str)
        {

            int cObject = 0;
            Products p1;
            string name = "", id = "", makat = "", quantity = "", type = "", price = "", priceforthebusiness = "";
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '~')
                {
                    cObject++;


                }

                else if (cObject == 0 && str[i] >= '0' && str[i] <= '9')
                    id += str[i];
                else if (cObject == 1)
                    makat += str[i];
                else if (cObject == 2)
                    name += str[i];
                else if (cObject == 3)
                    quantity += str[i];
                else if (cObject == 4)
                    type += str[i];
                else if (cObject == 5)
                    price += str[i];
                else if (cObject == 6)
                    priceforthebusiness += str[i];




            }

            p1 = new Products(int.Parse(id.Trim()), makat.Trim(), name.Trim(), int.Parse(quantity.Trim()), int.Parse(type.Trim()), float.Parse(price.Trim()), float.Parse(priceforthebusiness.Trim()));

            return p1;

        }

        public override string Update(string str)
        {
            Products tmp;
            tmp = giveMeObject(str);
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Products SET makat='" + tmp.getMakat() + "', name='" + tmp.getName() + "', quantity='" + tmp.getQuantity() + "', type='" + tmp.getType() + "', Price='" + tmp.getPrice() + "', Price_for_the_business='" + tmp.getPriceForBusiness() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();

            return "true";


        }

        public override string Insert(string str)
        {
            Products tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Products values('" + id + "','" + tmp.getMakat() + "','" + tmp.getName() + "','" + tmp.getQuantity() + "','" + tmp.getType() + "','" + tmp.getPrice() + "','" + tmp.getPriceForBusiness() + "');";
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
            mySqlCommand.CommandText = "delete from Products where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }


    }
}
