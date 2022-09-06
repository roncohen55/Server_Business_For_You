using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Sales:Bids
    {
        private float _PriceForTheBusiness;

        public Sales() { }

        public Sales(int id, string info, string quantity, float price, string salesman, string name, string note, string phone, string address, string date, string email, float priceforthebusiness) : base( id,  info,  quantity,  price,  name,  phone,  address,  note,  date,  email,  salesman)
        {
            _PriceForTheBusiness = priceforthebusiness;
        }

        public float getPriceForBusiness() => _PriceForTheBusiness;

      

        public override List<string> allItems()
        {
            List<string> tmp = new List<string>();
            tmp.Clear();

            string str = "";
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Sales2 ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {


                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString() + " ~ " + mySqlDataReader[6].ToString() + " ~ " + mySqlDataReader[7].ToString() + " ~ " + mySqlDataReader[8].ToString() + " ~ " + mySqlDataReader[9].ToString() + " ~ " + mySqlDataReader[10].ToString() + " ~ " + mySqlDataReader[11].ToString();
                tmp.Add(str);


            }


            mySqlDataReader.Close();
            mySqlConnection.Close();

            return tmp;


        }

        public override List<string> allItemsForSalesman(string nameUs)
        {
            List<string> tmp = new List<string>();
            tmp.Clear();

            string str = "";
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Sales2 where Salesman='" + nameUs + "';";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {


                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString() + " ~ " + mySqlDataReader[6].ToString() + " ~ " + mySqlDataReader[7].ToString() + " ~ " + mySqlDataReader[8].ToString() + " ~ " + mySqlDataReader[9].ToString() + " ~ " + mySqlDataReader[10].ToString() + " ~ " + mySqlDataReader[11].ToString();
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
            mySqlCommand.CommandText = "Select * from Sales2 ;";
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

        private Sales giveMeObject(string str)
        {

            int cObject = 0;
            Sales s1;
            string info = "", quantity = "", name = "", phone = "", address = "", note = "", date = "", email = "", salesman = "", id = "", price = "",priceforthebusiness="";
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '~')
                {
                    cObject++;


                }

                else if (cObject == 0 && str[i] >= '0' && str[i] <= '9')
                    id += str[i];
                else if (cObject == 1)
                    info += str[i];
                else if (cObject == 2)
                    quantity += str[i];
                else if (cObject == 3)
                    price += str[i];
                else if (cObject == 4)
                    salesman += str[i];
                else if (cObject == 5)
                    name += str[i];
                else if (cObject == 6)
                    note += str[i];
                else if (cObject == 7)
                    phone += str[i];
                else if (cObject == 8)
                    address += str[i];
               /* else if (cObject == 9)
                    date += str[i];*/
                else if (cObject == 9)
                    email += str[i];
                else if (cObject == 10)
                    priceforthebusiness += str[i];




            }

            s1 = new Sales(int.Parse(id.Trim()), info.Trim(), quantity.Trim(), float.Parse(price.ToString().Trim()), salesman.Trim(), name.Trim(), note.Trim(), phone.Trim(), address.Trim(), date.Trim(), email.Trim(), float.Parse(priceforthebusiness.ToString().Trim()));

            return s1;

        }

        public override string Update(string str)
        {
            Sales tmp;
            tmp = giveMeObject(str);
            int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Sales2 SET info='" + tmp.getInfo() + "', Price='" + tmp.getPrice() + "', buyer='" + tmp.getName() + "',Phone='" + tmp.getPhone() + "',Address='" + tmp.getAddress() + "', Remarks='" + tmp.getNote() + "',email='" + tmp.getEmail() + "',Price_for_the_business='" + tmp.getPriceForBusiness() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();

            return "true";


        }

        public override string Insert(string str)
        {
            Sales tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            DateTime myDate = DateTime.Now;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Sales2 values('" + id + "','" + tmp.getInfo() + "','" + tmp.getQuantityInfo() + "','" + tmp.getPrice() + "','" + tmp.getSalesman() + "','" + tmp.getName() + "','" + tmp.getNote() + "','" + tmp.getPhone() + "','" + tmp.getAddress() + "','" + myDate.ToString("dd/MM/yyyy") + "','" + tmp.getEmail() + "','" + tmp.getPriceForBusiness() + "');";
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
            mySqlCommand.CommandText = "delete from Sales2 where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }

        //func to delete camot from prodect 

       public string deletecamotFromProduct(string makat, int camot)
        {
            
            
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = "update Products set quantity='" + camot + "' where makat='" + makat + "';";
                int n = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();




            return "true";


        }

    }
}
