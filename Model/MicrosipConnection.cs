using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsip_Rentas.Model
{
    public class MicrosipConnection
    {
        private string server; 
        private string username;
        private string password;
        private string port;
        private string database; 
        private static MicrosipConnection con = null;


        public MicrosipConnection()
        {
            this.server = "Localhost";
            this.username = "SYSDBA";
            this.password = "masterkey";
            this.port = "3050";  
            this.database = "C:\\Microsip datos\\AD2000.FDB";
        }

        public FbConnection CreateConnection()
        {
            FbConnection connection = new FbConnection();
            try
            {
                connection.ConnectionString = "User=" + this.username +
                                                ";Password=" + this.password +
                                                ";Database=" + this.database +
                                                ";Datasource=" + this.server+
                                                ";Port="+this.port+
                                                ";Dialect=3;"+
                                                ";Charset=UTF8;";
            }
            catch (Exception ex)
            {
                connection = null; 
                throw ex;
            }
            return connection;
        }

        public static MicrosipConnection getInstance()
        {
            if(con == null)
            {
                con = new MicrosipConnection();
            }
            return con; 
        }

        //public List<ArticleAsset> GetArticulos()
        //{
        //    var articulos = new List<ArticleAsset>();

        //    using (FbConnection connection = new FbConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT ID, NOMBRE FROM ARTICULOS";

        //        using (FbCommand command = new FbCommand(query, connection))
        //        using (FbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                articulos.Add(new ArticleAsset
        //                {
        //                    Id = reader.GetInt32(0),
        //                    Name = reader.GetString(1)
        //                });
        //            }
        //        }
        //    }

        //    return articulos;
        //}


    }
}
