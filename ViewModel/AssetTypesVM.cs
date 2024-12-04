using FirebirdSql.Data.FirebirdClient;
using Microsip_Rentas.DataAccess;
using Microsip_Rentas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Microsip_Rentas.ViewModel
{
    public class AssetTypesVM: ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _deleteCommand;
        private AssetTypeRepository _repository;
        private AssetType? _assetTypeEntity = null;
        public AssetTypeRecord AssetTypeRecord { get; set; }
 
       //Se encarga de manejar la eliminacion de registros
        public ICommand DeleteCommand
        {
            get
            {
                //Trace.WriteLine("Entró al command");
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => Delete((int)param), null);
                }

                return _deleteCommand;
            }
        }
        public AssetTypesVM()
        {
            _assetTypeEntity = new AssetType();
            _repository = new AssetTypeRepository();
            AssetTypeRecord = new AssetTypeRecord();

            GetAll();
        }

       
        //Manejo de eliminar
        public void Delete(int id)
        {
            //Trace.WriteLine("Entró al delete");
            //ABrir un modal para esperar respuesta de usuario, el usuario ingresa true o false
            if (MessageBox.Show("¿Desea elimiar este tipo de activo?", "AssetType", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    //Llamamos al delete del repositorio
                    _repository.Delete(id);
                    //Feedback al usuario
                    MessageBox.Show("Tipo de activo eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    //Feedback al usuario
                    MessageBox.Show("Ocurrió un error durante el proceso. " + ex.InnerException);
                }
                finally
                {
                    //Actualizar los registros de tu tabla
                    GetAll();
                }
            }
        }

        
        //Obtenemos todos los registros de nuestra tabla
        public void GetAll()
        {
            AssetTypeRecord.AssetTypeRecords = new System.Collections.ObjectModel.ObservableCollection<AssetTypeRecord>();
            //Obtienes todos los registros de la tabla, conectandote al repositorio
            //Foreach de cada registro de mi tabla
            //Agregamos un nuevo objeto al records cada vez que recorremos el foreach
            _repository.GetAll().ForEach(data => AssetTypeRecord.AssetTypeRecords.Add(new AssetTypeRecord()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                AbreviationName = data.AbreviationName,
                Price = data.Price,
            }));
        }

    }
}
