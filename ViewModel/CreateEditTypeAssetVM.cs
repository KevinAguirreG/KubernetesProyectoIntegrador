using FirebirdSql.Data.FirebirdClient;
using Microsip_Rentas.DataAccess;
using Microsip_Rentas.Model;
using Microsip_Rentas.View;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Microsip_Rentas.ViewModel
{
    public class CreateEditTypeAssetVM: ViewModelBase
    {
        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private AssetTypeRepository _repository;
        private AssetType? _assetTypeEntity = null;
        public AssetTypeRecord AssetTypeRecord { get; set; }
        public int AssetTypeId { get; private set; }

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new RelayCommand(param => ResetData(), null);
                }

                return _resetCommand;
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => SaveData((object)param), null);
                }

                return _saveCommand;
            }
        }
        public ICommand EditCommand
        {
            get
            {
                if(_editCommand == null)
                {
                    _editCommand = new RelayCommand(param => EditData((int)param), null);
                }
                return _editCommand;    
            }
        }
 
        public CreateEditTypeAssetVM(int assetId)
        {
            AssetTypeId = assetId;
            _assetTypeEntity = new AssetType();
            _repository = new AssetTypeRepository();
            AssetTypeRecord = new AssetTypeRecord();

            EditData(assetId);
            
            
           
            //GetAll();
        }

        public CreateEditTypeAssetVM()
        {
            
            _assetTypeEntity = new AssetType();
            _repository = new AssetTypeRepository();
            AssetTypeRecord = new AssetTypeRecord();

            //GetAll();
        }

       

        public void ResetData()
        {
            AssetTypeRecord.Id = 0;
            AssetTypeRecord.Name = string.Empty;
            AssetTypeRecord.AbreviationName = string.Empty;
            AssetTypeRecord.Description = string.Empty;
            AssetTypeRecord.Price = 0; 
        }
        

        public void SaveData(Object? param)
        {
            //Trace.WriteLine("AssetType: " + AssetTypeRecord.Id + " " + AssetTypeRecord.Name);
            
            if (AssetTypeRecord != null)
            {
                
                _assetTypeEntity.Name = AssetTypeRecord.Name;
                _assetTypeEntity.AbreviationName = AssetTypeRecord.AbreviationName;
                _assetTypeEntity.Description = AssetTypeRecord.Description;
                _assetTypeEntity.Price = AssetTypeRecord.Price;

                try
                {
                    if (AssetTypeRecord.Id <= 0)
                    {
                        //_repository.Create(_assetTypeEntity);
                        //Trace.WriteLine("AssetType: " +  _assetTypeEntity.Name + " " + _assetTypeEntity.Description);
                        _repository.Add(_assetTypeEntity);
                        _repository.SaveChanges();

                        MessageBox.Show("Nuevo tipo de activo creado correctamente.");
                    }
                    else
                    {
                        _assetTypeEntity.Id = AssetTypeRecord.Id;  
                        _repository.Update(_assetTypeEntity);
                        MessageBox.Show("Tipo de activo editado correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    MessageBox.Show("Ocurrió un error durante la creación. " + ex.InnerException);
                }
                finally
                {
                    //GetAll();
                    if(param != null && param.Equals("SaveAndNew"))
                    {
                        var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


                        if (mainViewModel.ShowCreateEditTypeAssetViewCommand.CanExecute(null))
                        {
                            mainViewModel.ShowCreateEditTypeAssetViewCommand.Execute(null);
                        }
                    }
                    ResetData();
                }

            }
        }

        public void EditData(int id)
        {
            var model = _repository.Get(id);
            //Trace.WriteLine(model.Name);

            AssetTypeRecord.Id = model.Id;
            AssetTypeRecord.Name = model.Name;
            AssetTypeRecord.Description = model.Description;
            AssetTypeRecord.AbreviationName = model.AbreviationName;
            AssetTypeRecord.Price = model.Price;
            //Trace.WriteLine("El assetRecord es: " +  AssetTypeRecord.Name);

        }

        public List<ArticleAsset> getArticles2()
        {
            List<ArticleAsset> result = new List<ArticleAsset>();
            FbConnection connection = new FbConnection();

            try
            {
                connection = MicrosipConnection.getInstance().CreateConnection();
                connection.Open();

                string query = "SELECT ARTICULO_ID, NOMBRE FROM ARTICULOS";

                using (FbCommand command = new FbCommand(query, connection))
                using (FbDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                            
                        ArticleAsset article = new ArticleAsset { Id = reader.GetInt32(0), ArticleName = reader.GetString(1) };
                        result.Add(article);
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();

            }
            return result;
        }
    }

}
