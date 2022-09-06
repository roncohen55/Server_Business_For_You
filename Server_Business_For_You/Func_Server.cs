using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Business_For_You
{
    class Func_Server
    {
        private List<string> arr = new List<string>();

        public Func_Server() { }

        public string FuncSwich(char pac , string str)
        {         
            arr.Clear();
            string result = "";
            Bids b2 = new Bids();
            Category c1 = new Category();
            Users u1 = new Users();
            Suppliers s1 = new Suppliers();
            Products p1 = new Products();
            Sales sale1 = new Sales();
            Insights ins1 = new Insights();
            OrdersSuppliers o1 = new OrdersSuppliers();
            

            switch (pac)
            {
                case 'a':  
                    arr = b2.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'b':
                    result = b2.Update(str);
                    break;

                case 'c':
                    result = b2.Delete(str);
                    break;

                case 'd':
                    result = b2.Insert(str);
                    break;

                case 'e':
                    arr = b2.allItemsForSalesman(str);
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'f':
                    arr = c1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'g':
                    result = c1.Update(str);
                    break;

                case 'h':
                    result = c1.Delete(str);
                    break;

                case 'i':
                    result = c1.Insert(str);
                    break;

                case 'j':
                    arr = u1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'k':
                    result = u1.Update(str);
                    break;

                case 'l':
                    result = u1.Delete(str);
                    break;

                case 'm':
                    result = u1.Insert(str);
                    break;

                case 'n':
                    arr = s1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'o':
                    result = s1.Update(str);
                    break;

                case 'p':
                    result = s1.Delete(str);
                    break;

                case 'q':
                    result = s1.Insert(str);
                    break;

                case 'r':
                    arr = p1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 's':
                    result = p1.Update(str);
                    break;

                case 't':
                    result = p1.Delete(str);
                    break;

                case 'u':
                    result = p1.Insert(str);
                    break;

                case 'v':
                    arr = sale1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'w':
                    result = sale1.Update(str);
                    break;

                case 'x':
                    result = sale1.Delete(str);
                    break;

                case 'y':
                    result = sale1.Insert(str);
                    break;

                case 'z':
                    arr = sale1.allItemsForSalesman(str);
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'A':
                    arr = ins1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'B':
                    result = ins1.Update(str);
                    break;

                case 'C':
                    result = ins1.Delete(str);
                    break;

                case 'D':
                    result = ins1.Insert(str);
                    break;

                case 'E':
                    arr = ins1.allItemsForSalesman(str);
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'F' :
                    arr = p1.allItemsForCategory(str);
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'G':
                    string[] st = str.Split('~');
                    result = sale1.deletecamotFromProduct(st[0],int.Parse( st[1]));
                    break;

                case 'H':
                    arr = o1.allItems();
                    for (int i = 0; i < arr.Count; i++)
                        result += arr[i].ToString() + "*";
                    break;

                case 'J':
                    result = o1.Insert(str);
                    break;

                case 'K':
                    result = o1.Delete(str);
                    break;

            }

            return result;
        }


    }
}

 /*

רשימת פונקציות 

a-e =>הצעות מחיר(Bids)

f-i => קטגוריות(Category)

j-m  => משתמשים(Users)

n-q  => ספקים(Suppliers)

r-u , F => מוצרים (Product)

v-z => מכירות(Sales)

A-E => תובנות(Insights)

 */
