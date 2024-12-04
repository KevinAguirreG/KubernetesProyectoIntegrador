using Microsip_Rentas.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace Microsip_Rentas.DataAccess
{
    class AssetTypeRepository:DbContext
    {
        //Conect to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = " +App.databaseName);
        }

        //Define the table into the database
        public DbSet<AssetType> AssetTypes { get; set; }

        //Get en donde le pasas el id como parametro
        public AssetType Get(int id)
        {
            //Trace.WriteLine("En el get: " + id);
            //Regresa el objeto de la base de datos
            return this.AssetTypes.Find(id); 
        }

        //Obtiene todos los objetos de la tabla
        public List<AssetType> GetAll()
        {
            return this.AssetTypes.ToList();
        }

        //Creación de nuevo registro
        public void Create(AssetType assetType)
        {
            //Si assetType existe
            if (assetType != null)
            {
                //Agregas el registro
                this.AssetTypes.Add(assetType);
                //Guardamos los cambios de la tabla
                this.SaveChanges();
            }
        }

        //Editas un registro
        public void Update(AssetType assetType)
        {
            //Obtenemos el assetType en base al id
            var assetTypeFind = this.Get(assetType.Id);
            //SI es diferente a null
            if (assetTypeFind != null)
            {
                //Cambuas los atributos del objeto encontrado por los atributos del objeto parametyro
                assetTypeFind.Name = assetType.Name;
                assetTypeFind.AbreviationName = assetType.AbreviationName;
                assetTypeFind.Price = assetType.Price;
                assetTypeFind.Description = assetType.Description;
                //Guardamos los cambios de la tabla
                this.SaveChanges();
            }
        }

        //Eliminar registro de la tabla
        public void Delete(int id)
        {
            //Buscamos el objeto
            var assetTypeObj = this.AssetTypes.Find(id);
            //Trace.WriteLine("Eliminar: " + id);
            //Si se encontró un objeto
            if (assetTypeObj != null)
            {
                //Eliminamos de la tabla
                this.AssetTypes.Remove(assetTypeObj);
                //Guardamos los cambios de la tabla
                this.SaveChanges();
            }
        }



        ////Execute query
        //public void ExecuteWrite(string query, Dictionary<string, object> args)
        //{
        //    using (var con = new SqliteConnection("Data Source=" + App.databaseName))
        //    {
        //        con.Open();
        //        var command = con.CreateCommand(); 
        //        command.CommandText = query;
        //        foreach (var item in args)
        //        {
        //            command.Parameters.AddWithValue(item.Key, item.Value);
        //        }
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public DataTable Execute(string query, Dictionary<string, object> args)
        //{
        //    //Delete all the white spaces, if is null return null
        //    if (string.IsNullOrEmpty(query.Trim()))
        //        return null;

        //    //Make the database connection
        //    using (var con = new SqliteConnection("Data Source="+App.databaseName))
        //    {

        //        //Open connection 
        //        con.Open();

        //        var dt = new DataTable();

        //        using (var command = new SqliteCommand(query, con) )
        //        {
        //            foreach (KeyValuePair<string, object> item in args)
        //            {
        //                command.Parameters.AddWithValue(item.Key, item.Value);
        //            }
        //            using (SqliteDataReader dr = command.ExecuteReader())
        //            {
        //                do
        //                {
        //                    dt.BeginLoadData();
        //                    dt.BeginLoadData();
        //                    dt.Load(dr);
        //                    dt.EndLoadData();
        //                } while (!dr.IsClosed && dr.NextResult());
        //            }

        //            return dt;
        //        }
        //    }
        //}

        //public void Create(AssetType assetType)
        //{
        //    const string query = "INSERT INTO AssetTypes" +
        //        "(Name, AbreviationName, Description, Price) " +
        //        "VALUES (@Name, @AbreviationName, @Description, @Price) ";

        //    var args = new Dictionary<string, object>() 
        //    {
        //        {"@Name", assetType.Name },
        //        {"@AbreviationName", assetType.AbreviationName },
        //        {"@Description", assetType.Description },
        //        {"@Price", assetType.Price }
        //    };

        //    ExecuteWrite(query, args);
        //}

        //public AssetType Get(int id )
        //{
        //    var assetType = new AssetType();
        //    string query = "SELECT * FROM AssetTypes " +
        //        "WHERE Id = @id";

        //    var args = new Dictionary<string, object>()
        //    {
        //        {"@id", assetType.Id }
        //    };

        //    DataTable dt = Execute(query, args);

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return null;
        //    }

        //    assetType = new AssetType
        //    {
        //        Id = Convert.ToInt32(dt.Rows[0]["id"]),
        //        Name = Convert.ToString(dt.Rows[0]["name"]),
        //        AbreviationName = Convert.ToString(dt.Rows[0]["abreviation_name"]),
        //        Description = Convert.ToString(dt.Rows[0]["description"]),
        //        Price = Convert.ToDecimal(dt.Rows[0]["price"])
        //    };


        //    return assetType;
        //}

        //public List<AssetType> GetAll() 
        //{
        //    List<AssetType> assetTypes = new List<AssetType>();
        //    var assetType = new AssetType(); 
        //    string query = "SELECT * FROM AssetTypes ";

        //    var args = new Dictionary<string, object>()
        //    {
        //        {"@id", assetType.Id }
        //    };

        //    DataTable dt = Execute(query, args);

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return null;
        //    }

        //        assetType = new AssetType
        //        {
        //            Id = Convert.ToInt32(dt.Rows[0]["Id"]),
        //            Name = Convert.ToString(dt.Rows[0]["Name"]),
        //            AbreviationName = Convert.ToString(dt.Rows[0]["AbreviationName"]),
        //            Description = Convert.ToString(dt.Rows[0]["Description"]),
        //            Price = Convert.ToDecimal(dt.Rows[0]["Price"])
        //        };

        //        assetTypes.Add(assetType);


        //    return assetTypes;
        //}
        //public void Update(AssetType assetType)
        //{
        //    const string query = "UPDATE AssetTypes " +
        //        "SET name = @name, abreviation_name = @abreviation_name, description = @description, price = @price" +
        //        "WHERE id = @id ";

        //    var args = new Dictionary<string, object>()
        //    {
        //        {"@name", assetType.Name },
        //        {"@abreviation_name", assetType.AbreviationName },
        //        {"@description", assetType.Description },
        //        {"@price", assetType.Price }
        //    };

        //    ExecuteWrite(query, args);
        //}

        //public void Delete(AssetType assetType)
        //{
        //    const string query = "DELETE FROM AssetTypes " +
        //        "WHERE id = @id ";

        //    var args = new Dictionary<string, object>()
        //    {
        //        {"@id", assetType.Id }
        //    };

        //    ExecuteWrite(query, args);
        //}
    }
}
