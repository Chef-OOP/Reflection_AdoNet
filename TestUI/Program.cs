using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using Entity.POCO;
using DAL.AdoNet;
using Business.Concrete;

namespace TestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdoNet
            string connectionString = "Server=.;Database=Northwind;Integrated Security=True;";
            ShippersGeneric SG = new ShippersGeneric(connectionString);
            List<Shippers> s = SG.GetList();
            Console.ReadLine();
            //GenericManager<Shippers> genericManager = new GenericManager<Shippers>(connectionString);
            //List<Shippers> s =  genericManager.GetList();
            //Console.ReadLine();
            //string result = genericManager.Update(new Products { ProductID = 1, SupplierID = 2, CategoryID = 3 });
            //string result = genericManager.Update(new Shippers { ShipperID = 40, CompanyName = "Hızlı",Phone="555555555"});
            //Console.WriteLine(result);
            //genericManager.Insert(new Products 
            //{
            //     CategoryID=1, SupplierID=1, Discontinued=10, ProductName="Portakal", QuantityPerUnit="kilo", UnitsInStock=100, ReorderLevel=10, UnitPrice=5, UnitsOnOrder=150
            //});
            //Console.WriteLine(genericManager.Insert(new Shippers { CompanyName = "HızlıKargo", Phone = "1111112233" }));
            //ShippersManager manager = new ShippersManager(connectionString);

            ////Console.WriteLine(manager.Insert(new Shippers() { CompanyName = "TavşanKargo", Phone = "2223334565" }));
            ////Console.WriteLine(manager.Delete(6));
            //manager.Update(new Shippers() { ShipperID = 5, CompanyName = "EnHızlıKargo", Phone = "6549875465" });
            //Console.WriteLine("-----------------------------");
            //List<Shippers> shippers =  manager.GetList();
            //foreach (var item in shippers)
            //{
            //    Console.WriteLine(item.ShipperID+" "+item.CompanyName);
            //}




            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = con;
            //sqlCommand.CommandText = "select * from Shippers";
            //sqlCommand.ExecuteNonQuery() = > Insert Delete Update 
            //con.Open();
            //NorthwindHelper helper = new NorthwindHelper(connectionString);
            //if (helper.ExecCommand("insert into Shippers values ('ÇokHızlıKargo','1236547898')")>0)
            //{
            //    Console.WriteLine("ekeleme işlemi başarılı");
            //}
            //SqlDataReader reader = helper.GetEntity("select * from Shippers");//=> Select
            //while (reader.Read())
            //{

            //    Shippers shippers = new Shippers()
            //    {
            //        CompanyName = reader[nameof(shippers.CompanyName)].ToString(),
            //        Phone = reader[nameof(shippers.Phone)].ToString(),
            //        ShipperID = Convert.ToInt32(reader[nameof(shippers.ShipperID)])
            //    };
            //    //int id = Convert.ToInt32(reader[0]);
            //    //string Cn = reader[1].ToString();
            //    //string Ph = reader[2].ToString();
            //    Console.WriteLine(shippers.ShipperID + " " + shippers.CompanyName + " " + shippers.Phone);
            //}
            //con.Close();

            Console.ReadKey();

        }
    }
}
