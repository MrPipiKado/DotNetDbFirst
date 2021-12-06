using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Order model = new Order();
            using (EFDBEntities db = new EFDBEntities())
            {
                while (true)
                {
                    Console.WriteLine("Select action: 1 - Add, 2 - Update, 3 - Delete, 4 - Select");
                    int action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            model.Name = "name1";
                            model.TotalPrice = 1000;
                            model.DecorationCount = 2;
                            db.Orders.Add(model);
                            db.SaveChanges();
                            Console.WriteLine("New entity was successfully added");
                            break;
                        case 2:
                            model = db.Orders.Where(x => x.ID == 1).FirstOrDefault();
                            model.Name = "newName";
                            db.Orders.Add(model);
                            db.SaveChanges();
                            Console.WriteLine("Entity was successfully updated");
                            break;
                        case 3:
                            db.Orders.Remove(model);
                            db.SaveChanges();
                            Console.WriteLine("Entity was successfully deleted");
                            break;
                        case 4:
                            var orderList = db.Orders.ToList<Order>();
                            foreach (var order in orderList)
                            {
                                Console.WriteLine(order.ID + " " + order.Name + " " + order.DecorationCount + " " + order.TotalPrice);
                            }
                            Console.WriteLine("Entity was successfully loaded");
                            break;
                    }
                }
                
            }
            Console.ReadLine();
        }
    }
}
