using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server_Business_For_You
{
    class Bids:Category
    {
    

        private string _info;

        private string _quantityInfo;

        private float _price;

        private string _NameBayer;

        private string _phone;

        private string _address;

        private string _Note;

        private string _date;

        private string _email;

        private string _salesman;

       

        public Bids() { }

        public Bids(int id, string info, string quantity, float price, string name, string phone, string address, string note, string date, string email, string salesman):base(id,name)
        {
          
            _info = info;
            _quantityInfo = quantity;
            _price = price;
            _NameBayer = name;
            _phone = phone;
            _address = address;
            _Note = note;
            _date = date;
            _email = email;
            _salesman = salesman;

       
            
        }

        

        public string getPhone() => _phone;

        public string getAddress() => _address;

        public string getNote() => _Note;

        public string getDate() => _date;

        public string getEmail() => _email;

        public string getSalesman() => _salesman;

        public string getInfo() => _info;

        public string getQuantityInfo() => _quantityInfo;

        public float getPrice() => _price;

        public override List<string> allItems()
        {
            List<string> tmp = new List<string>();
           tmp.Clear();

            string str = "";
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Bids1 ;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {


                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString() +  " ~ " + mySqlDataReader[6].ToString() + " ~ " + mySqlDataReader[7].ToString() + " ~ " + mySqlDataReader[8].ToString() + " ~ " + mySqlDataReader[9].ToString()+ " ~ " + mySqlDataReader[10].ToString() ;
                tmp.Add(str);


            }


            mySqlDataReader.Close();
            mySqlConnection.Close();

            return tmp;


        }

        public virtual List<string> allItemsForSalesman( string nameUs )
        {
            List<string> tmp = new List<string>();
            tmp.Clear();

            string str = "";
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from Bids1 where salesman='" + nameUs + "';";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();





            while (mySqlDataReader.Read())
            {


                str = mySqlDataReader[0].ToString() + " ~ " + mySqlDataReader[1].ToString() + " ~ " + mySqlDataReader[2].ToString() + " ~ " + mySqlDataReader[3].ToString() + " ~ " + mySqlDataReader[4].ToString() + " ~ " + mySqlDataReader[5].ToString() + " ~ " + mySqlDataReader[6].ToString() + " ~ " + mySqlDataReader[7].ToString() + " ~ " + mySqlDataReader[8].ToString() + " ~ " + mySqlDataReader[9].ToString() + " ~ " + mySqlDataReader[10].ToString();
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
                mySqlCommand.CommandText = "Select * from Bids1 ;";
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

        private Bids giveMeObject(string str)
        {
           
            int cObject = 0;
            Bids b1;
            string info = "", quantity = "", name = "", phone = "", address = "", note = "", date = "", email = "", salesman = "", id = "", price = "";
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
                    name += str[i];
                else if (cObject == 5)
                    phone += str[i];
                else if (cObject == 6)
                    address += str[i];
                else if (cObject == 7)
                    note += str[i];
                else if (cObject == 8)
                    email += str[i];
                 else if (cObject == 9)
                    salesman += str[i];




            }

            b1 = new Bids(int.Parse(id.Trim()), info.Trim(), quantity.Trim(), float.Parse(price.ToString().Trim()), name.Trim(), phone.Trim(), address.Trim(), note.Trim(), date, email.Trim(), salesman.Trim());
           
            return b1;
            
        }

        public override string Update(string str)
        {
            Bids tmp ;
            tmp = giveMeObject(str);
             int num;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "UPDATE Bids1 SET info='" + tmp.getInfo() + "', price='" + tmp.getPrice() + "', NameBayer='" +tmp.getName() + "',phone='" + tmp.getPhone() + "',Address='" + tmp.getAddress() + "', Note='" + tmp.getNote() + "',email='" + tmp.getEmail() + "' WHERE id='" + tmp.getId().ToString() + "';";

            num = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine(num);
            mySqlConnection.Close();
          
            return "true";

     
        }

        public override string Insert(string str)
        {
            Bids tmp;
            tmp = giveMeObject(str);
            int id = givemeID();
            id += 1;
            int num;
            DateTime myDate = DateTime.Now;
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-6LP02KT\\SQLEXPRESS;database=Business_For_You;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "insert into Bids1 values('" + id + "','" + tmp.getInfo() + "','" + tmp.getQuantityInfo() + "','" + tmp.getPrice() + "','" + tmp.getSalesman() + "','" + tmp.getName() + "','" + tmp.getPhone() + "','" + tmp.getAddress() + "','" + tmp.getNote() + "','" + myDate.ToString("dd/MM/yyyy") + "','" + tmp.getEmail() + "');";
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
            mySqlCommand.CommandText = "delete from Bids1 where ID=" + id + ";";
            num = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return "true";
        }




    }
}
