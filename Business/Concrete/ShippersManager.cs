using Business.Abstract;
using DAL.AdoNet;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public interface IShippersManager : IGenericServis<Shippers> { }
    public class ShippersManager : IShippersManager
    {
        NorthwindHelper helper;
        public ShippersManager(string conStr)
        {
            helper = new NorthwindHelper(conStr);
        }
        public Shippers Get(int id)
        {
            SqlDataReader reader = helper.GetEntity($"Select * From Shippers Where ShipperID={id}");
            Shippers shippers = new Shippers();
            while (reader.Read())
            {
                shippers.ShipperID = Convert.ToInt32(reader[nameof(shippers.ShipperID)]);
                shippers.CompanyName = reader[nameof(shippers.CompanyName)].ToString();
                shippers.Phone = reader[nameof(shippers.Phone)].ToString();
            }
            return shippers;
        }
        public List<Shippers> GetList()
        {
            SqlDataReader reader = helper.GetEntity($"Select * From Shippers");
            List<Shippers> shippers = new List<Shippers>();
            while (reader.Read())
            {
                Shippers shipper = new Shippers();
                shipper.ShipperID = Convert.ToInt32(reader[nameof(shipper.ShipperID)]);
                shipper.CompanyName = reader[nameof(shipper.CompanyName)].ToString();
                shipper.Phone = reader[nameof(shipper.Phone)].ToString();
                shippers.Add(shipper);
            }
            return shippers;
        }
        public string Delete(int id)
        {
            if (helper.ExecCommand($"Delete from Shippers where ShipperID={id}") > 0)
            {
                return "Silme İşlemi Başarılı";
            }
            return "Silme işlemi Başarısız!!!";
        }
        public string Insert(Shippers entity)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@ComName",$"{entity.CompanyName}"),
                new SqlParameter("@Ph",$"{entity.Phone}"),
            };
            if (helper.ExecCommand("insert into Shippers values (@ComName,@Ph)", sqlParameters) > 0)
            {
                return "Ekleme işlemi Başarılı";
            }
            return "Ekleme işlemi Başarısız";
        }
        public string Update(Shippers entity)
        {
            if (helper.ExecCommand($"Update Shippers set CompanyName='{entity.CompanyName}',Phone='{entity.Phone}' where ShipperID={entity.ShipperID}") > 0)
            {
                return "Güncelleme Başarılı";
            }
            return "Güncelleme Başarısız";
        }
    }
}
