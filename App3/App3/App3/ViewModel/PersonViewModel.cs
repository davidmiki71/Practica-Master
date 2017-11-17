using App3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        #region Instances

        private string _NuevoIngreso = String.Empty;
        private ObservableCollection<PersonModel> _listPersonList = new ObservableCollection<PersonModel>();

        private string _NuevoFiltro = String.Empty;

        private List<PersonModel> listaOriginal = new List<PersonModel>();


        public ObservableCollection<PersonModel> listPersonList
        {
            get { return _listPersonList; }
            set { _listPersonList = value; OnPropertyChanged("listPersonList"); }
        }


        public string NuevoIngreso {
            get { return _NuevoIngreso; }
            set { _NuevoIngreso = value; OnPropertyChanged("NuevoIngreso"); }
        }

        public string NuevoFiltro {
            get { return _NuevoFiltro; }
            set {

                _NuevoFiltro = value;
                OnPropertyChanged("NuevoFiltro");
                FiltrarPersona(_NuevoFiltro);
            }
        }

        public ICommand EliminarPersonaCommand { get; set; }

        public ICommand AgregarPersonaCommand { get; set; }

        public ICommand FiltroCommand { get; set; }
        #endregion 

        public PersonViewModel()
        {
            InitClass();
            InitCommands();

        }

        public void InitClass() {
            listPersonList = PersonModel.ObtenerPersonas();
            listaOriginal = listPersonList.ToList();
        }

        public void InitCommands() {
            AgregarPersonaCommand = new Command(AgregarPersona);
            EliminarPersonaCommand = new Command<int>(EliminarPersona);
        }

        private void AgregarPersona() {  //método de agregar persona
            listPersonList.Add(new PersonModel() { Nombre = NuevoIngreso, Apellido = "Apellido", Descripcion = "Generica" });
        }

        private void EliminarPersona(int id) {
            listaOriginal.RemoveAll(x => x.Id == id);
            listPersonList = new ObservableCollection<PersonModel>(listaOriginal as List<PersonModel>);
        }

        //private void Filtrar() { //método filtrar
        //    ObservableCollection<PersonModel> listaPersonasAux = listPersonList;

        //    if (NuevoFiltro.Equals("") || NuevoFiltro == null)
        //    {
        //        tieneFiltro = false;
        //        noTieneFiltro = true;
        //    }
        //    else {
        //        tieneFiltro = true;
        //        noTieneFiltro = false;
        //        var listaFiltrada = (from a in listPersonList where a.Nombre == NuevoFiltro select a).ToList();
        //        listPersonListFiltro = new ObservableCollection<PersonModel>(listaFiltrada as List<PersonModel>);
        //    }
        //}


        public void FiltrarPersona(string textoBuscar) {
            listPersonList.Clear();
            listaOriginal.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x=> listPersonList.Add(x));
        }

        #region Notified Region
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName) {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));           
            }
        }

        #endregion


    }
}
