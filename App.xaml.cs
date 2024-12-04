using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using Microsip_Rentas.DataAccess;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsip_Rentas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Nombre de mi base de datos
        public static string databaseName = "MicrosipRents.db";

        //Obtenemos el path de donde vamos a guardar la información
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //Creación de un path para la base de datos
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);

        //Code that runs everytime that the application starts
        protected override void OnStartup(StartupEventArgs e)
        {
            //Create the db file 
            //Check if the database exists
            DatabaseFacade facade = new DatabaseFacade(new AssetTypeRepository());
            facade.EnsureCreated(); //If ture, nothing happens / if false, creates all the tables of the schema
            Trace.WriteLine(facade.EnsureCreated());
            Trace.WriteLine(databasePath);
        }

    }

}
