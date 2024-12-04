using Microsip_Rentas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Microsip_Rentas.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public ViewModelBase CurrentChildView 
        { 
            get
            {
                return _currentChildView;
            }
            set 
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        // Comandos para cambiar de vista
        public ICommand ShowAssetViewCommand { get; set; }
        public ICommand ShowAssetTypeViewCommand { get; set; }
        public ICommand ShowRentalContractViewCommand { get; set; }
        public ICommand ShowPreinvoicesViewCommand { get; set; }
        public ICommand ShowGenerationPreinvoiceViewCommand { get; set; }

        //comandos para pantallas de editar o crear
        public ICommand ShowCreateEditAssetViewCommand { get; set; }
        public ICommand ShowCreateEditTypeAssetViewCommand { get; set; }
        public ICommand ShowCreateEditRentalContractViewCommand { get; set; }
        public ICommand ShowCreateEditPreinvoiceViewCommand { get; set; }

        public MainViewModel()
        {
            ShowAssetViewCommand = new ViewModelCommand(ExecuteShowAssetViewCommand);
            ShowAssetTypeViewCommand = new ViewModelCommand(ExecuteShowAssetTypeViewCommand);
            ShowRentalContractViewCommand = new ViewModelCommand(ExecuteShowRentalContractViewCommand);
            ShowPreinvoicesViewCommand = new ViewModelCommand(ExecuteShowPreinvoicesViewCommand);
            ShowGenerationPreinvoiceViewCommand = new ViewModelCommand(ExecuteShowGenerationPreinvoiceViewCommand);

            ShowCreateEditAssetViewCommand = new ViewModelCommand(ExecuteShowCreateEditAssetViewCommand);
            ShowCreateEditTypeAssetViewCommand = new ViewModelCommand(ExecuteShowCreateEditTypeAssetViewCommand);
            ShowCreateEditRentalContractViewCommand = new ViewModelCommand(ExecuteShowCreateEditRentalContractViewCommand);
            ShowCreateEditPreinvoiceViewCommand = new ViewModelCommand(ExecuteShowCreateEditPreinvoiceViewCommand);

            ExecuteShowAssetViewCommand(null);
        }

        private void ExecuteShowCreateEditPreinvoiceViewCommand(object obj)
        {
            CurrentChildView = new CreateEditPreinvoiceVM();
        }

        private void ExecuteShowCreateEditRentalContractViewCommand(object obj)
        {
            CurrentChildView = new CreateEditRentalContractVM();
        }

        private void ExecuteShowCreateEditTypeAssetViewCommand(object obj)
        {
            if (obj is int assetId)
            {
                // Pasa el ID al ViewModel de edición/creación
                CurrentChildView = new CreateEditTypeAssetVM(assetId);
            }
            else
            {
                // Si no se pasa un ID, lo crea en modo "nuevo registro"
                CurrentChildView = new CreateEditTypeAssetVM();
            }
        }

        private void ExecuteShowCreateEditAssetViewCommand(object obj)
        {
            CurrentChildView = new CreateEditAssetVM();
        }

        private void ExecuteShowGenerationPreinvoiceViewCommand(object obj)
        {
            CurrentChildView = new GenerationPreinvoiceVM();
        }

        private void ExecuteShowPreinvoicesViewCommand(object obj)
        {
            CurrentChildView = new PreinvoiceVM();
        }

        private void ExecuteShowRentalContractViewCommand(object obj)
        {
            CurrentChildView = new RentalContractVM();
        }

        private void ExecuteShowAssetViewCommand(object obj)
        {
            CurrentChildView = new AssetsVM();
        }

        private void ExecuteShowAssetTypeViewCommand(object obj)
        {
            CurrentChildView = new AssetTypesVM();
        }        
    }
}
