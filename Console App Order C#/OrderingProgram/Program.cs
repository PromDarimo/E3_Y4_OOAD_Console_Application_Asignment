using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] code = new string[20] {"N1","N2","N3","N4","N5", "N6", "N7", "N8", "N9", "N10", "N11", "N12", "N13", "N14", "N15", "N16", "N17", "N18", "N19","F6" };
            string[] menu = new string[20] {"Laptop ROG G17",
                                           "Laptop ROG G713",
                                           "Laptop Dell 3550",
                                           "Desktop Dell 5550",
                                           "DesktopAcer a16",
                                           " Laptop Rog Scar g17",
                                           "Laptop Rog Zflow13 ",
                                           "Desktop Dell Vostro 3550",
                                           " Desktop Dell Vostro 5570 ",
                                           "Laptop Acer a13",
                                           "Tabblet Lenovo Yoga 7I",
                                           "Tabblet Lenovo Yoga 9I Book",
                                           "Desk Clone All Brand ",
                                           "Desktop DEll Clone ",
                                           "laptop asus Vivibook ",
                                           "Tablet Lenovo 15 Inch ",
                                           "Tablet Lenovo 13 Inch ",
                                           "DesktopAcer h23",
                                           "DesktopAcer h23",
                                           "Check out payment"};
            decimal[] price = new decimal[20] { 975.00m, 735.00m, 550.00m, 430.00m, 450.00m, 550.00m, 670.00m, 355.00m, 800.00m, 660.00m, 399.00m, 450.00m, 599.00m, 689.00m, 2440.00m, 450.00m, 450.00m, 450.00m, 450.00m, 0 };
            string strprice = "";

            string transact = "N";
            do
            {

                Console.Clear();
                //display menu
                Console.WriteLine("Code".PadRight(10) + "Menu".PadRight(30) + "Price");
                for (int i = 0; i < menu.Length; i++)
                {
                    if (price[i] > 0) { strprice = price[i].ToString(); } else { strprice = ""; }
                    Console.WriteLine(code[i].PadRight(10) + menu[i].PadRight(30) + strprice);
                }

                string[] order_list = new string[1];
                int qty;
                string strQty;
                decimal subtotal = 0;
                string order;
                int code_index;
                int current_order_index = 0;
                decimal grand_total = 0;
                Console.WriteLine();
                do
                {
                    //take orders
                    Console.Write("Enter menu code: ");
                    order = Console.ReadLine().ToUpper();
                    code_index = Array.IndexOf(code, order);
                    if (code_index < 0)
                    {
                        Console.WriteLine("Invalid code!!!!");
                    }
                    else
                    {
                        if (order != "F6")
                        {
                            do
                            {
                                Console.Write("Enter Qty: ");
                                strQty = Console.ReadLine();
                                if (int.TryParse(strQty, out qty) == false)
                                {
                                    Console.WriteLine("Invalid quantity value!!!");
                                }
                            }
                            while (int.TryParse(strQty, out qty) == false);

                            subtotal = price[code_index] * qty;
                            grand_total = grand_total + subtotal;
                            order_list[current_order_index] = order.PadRight(10) + menu[code_index].PadRight(30) +
                                price[code_index].ToString().PadRight(10) +  qty.ToString().PadRight(10) + subtotal.ToString().PadLeft(10);

                            Array.Resize(ref order_list, order_list.Length + 1);
                            current_order_index++;
                        }
                        else
                        {
                            if (grand_total == 0)
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                } while (order != "F6");

                

                decimal amount_tendered = 0;
                decimal change = 0;
                string str_amount;


                if (grand_total > 0)
                {
                    //display orders
                    Console.WriteLine("\nCode".PadRight(11) + "Menu".PadRight(30) + "Price".PadRight(10) + "Qty".PadRight(10) + "Sub Total".PadLeft(10));
                    for (int i = 0; i < order_list.Length; i++)
                    {
                        Console.WriteLine(order_list[i]);
                    }

                    string str_total = "Total Amount: " + grand_total.ToString("#,0.00");
                    Console.WriteLine(str_total.PadLeft(70));

                    //accept payment and compute change
                    do
                    {
                        do
                        {
                            Console.Write("\nEnter amount tendered: ");
                            str_amount = Console.ReadLine();
                        } while (decimal.TryParse(str_amount, out amount_tendered) == false);

                        if (Convert.ToDecimal(str_amount) < grand_total)
                        {
                            Console.WriteLine("Amount tendered must be greater than the total amount...");
                        }


                    } while (Convert.ToDecimal(str_amount) < grand_total);

                    change = amount_tendered - grand_total;
                    Console.WriteLine("Change: ".PadRight(23) + change.ToString("#,0.00"));
                }
                


                do
                {
                    Console.Write("\nAnother trasaction:(Y/N): ");
                    transact = Console.ReadLine().ToUpper();
                } while (transact != "Y" && transact !="N");

                

            } while (transact != "N");
            Console.WriteLine("Press any key to exit.....");


            Console.ReadKey();
        }
    }
}
