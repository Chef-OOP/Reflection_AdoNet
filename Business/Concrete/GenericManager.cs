using Business.Abstract;
using DAL.AdoNet;
using Entity;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericServis<T>
        where T : class, IDatabaseTable, new()
    {
        NorthwindHelper db;
        public GenericManager(string ConnectionString)
        {
            db = new NorthwindHelper(ConnectionString);
        }
        public string Delete(int id)
        {
            Type type = typeof(T);
            string typeID = type.GetProperties()[0].Name;
            string DeleteType = $"delete from {type.Name} where {typeID}={id}";
            int result = db.ExecCommand(DeleteType);
            if (result > 0)
            {
                return "Silme işlemi Başarılı";
            }
            return "Silme işlemi Başarısız";
        }
        public T Get(int id)
        {
            Type type = typeof(T);
            string GetEntity = $"select * from {type.Name} where {type.GetProperties()[0].Name}={id}";
            SqlDataReader reader = db.GetEntity(GetEntity);
            //T entity = new T();
            T typeCreate = (T)Activator.CreateInstance(type);
            while (reader.Read())
            {
                foreach (var item in type.GetProperties())
                {
                    item.SetValue(typeCreate, reader[item.Name]);
                }
            }
            return typeCreate;
        }
        public List<T> GetList()
        {
            try
            {
                Type type = typeof(T);
                string GetEntity = $"select * from {type.Name}";
                SqlDataReader reader = db.GetEntity(GetEntity);
                List<T> typeList = (List<T>)Activator.CreateInstance(typeof(List<T>));
                while (reader.Read())
                {
                    T typeCreate = (T)Activator.CreateInstance(type);
                    foreach (PropertyInfo item in type.GetProperties())
                    {
                        if (reader[item.Name].GetType() != typeof(DBNull))
                            item.SetValue(typeCreate, reader[item.Name]);

                    }
                    typeList.Add(typeCreate);
                }
                return typeList;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Insert(T entity)
        {
            Type type = typeof(T);
            string propertyName = "";
            var propertyType = type.GetProperties();
            List<SqlParameter> parameters = new List<SqlParameter>();
            for (int i = 0; i < propertyType.Count(); i++)
            {
                if (propertyType[i].GetValue(entity) != null && i != 0)
                {
                    propertyName += propertyType[i].Name + ",";
                    parameters.Add(new SqlParameter($"@{propertyType[i].Name }", propertyType[i].GetValue(entity)));
                }
            }
            string parametreName = "";
            foreach (var item in parameters)
                parametreName += item.ParameterName + ",";

            propertyName = propertyName.Substring(0, propertyName.Length - 1);
            parametreName = parametreName.Substring(0, parametreName.Length - 1);

            string InsertType = $"insert into {type.Name} ({propertyName}) values ({parametreName})";
            int result = db.ExecCommand(InsertType, parameters);
            if (result > 0)
                return "Ekeleme Başarılı";
            return "Ekleme Başarısız";
        }
        public string Update(T entity)
        {
            Type type = typeof(T);
            string property = "";
            var propertyType = type.GetProperties();
            List<SqlParameter> parameters = new List<SqlParameter>();
            for (int i = 0; i < propertyType.Count(); i++)
            {
                if (propertyType[i].GetValue(entity) != null && i != 0)
                {
                    parameters.Add(new SqlParameter($"@{propertyType[i].Name }", propertyType[i].GetValue(entity)));
                    property += propertyType[i].Name + "=" + $"@{propertyType[i].Name }" + ",";
                }
            }
            property = property.Substring(0, property.Length - 1);
            string InsertType = $"Update {type.Name} set {property} where {propertyType[0].Name}={propertyType[0].GetValue(entity)}";
            int result = db.ExecCommand(InsertType, parameters);
            if (result > 0)
                return "Güncelleme Başarılı";
            return "Güncelleme Başarısız";
        }
    }

    public class ShippersGeneric : GenericManager<Shippers>
    {
        public ShippersGeneric(string ConnectionString):base(ConnectionString)
        {

        }
    }

    public class ProductGenreic : GenericManager<Products>
    {
        public ProductGenreic(string ConnectionString) :base(ConnectionString)
        {

        }
    }
}
