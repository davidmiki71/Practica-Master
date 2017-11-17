using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App3.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion { get; set; }
        public PersonModel() { }

        public static ObservableCollection<PersonModel> ObtenerPersonas() {
            ObservableCollection<PersonModel> lst = new ObservableCollection<PersonModel>();

            lst.Add(new PersonModel { Id=1, Nombre="David", Apellido="Rodríguez", Descripcion="Generica" });
            lst.Add(new PersonModel { Id = 2, Nombre = "Juan", Apellido = "Alpizar", Descripcion = "Generica" });
            lst.Add(new PersonModel { Id = 3, Nombre = "Maria", Apellido = "Alve", Descripcion = "Generica" });
            lst.Add(new PersonModel { Id = 3, Nombre = "Pedro", Apellido = "Sanchez", Descripcion = "Generica" });
            lst.Add(new PersonModel { Id = 4, Nombre = "Lupe", Apellido = "Ramirez", Descripcion = "Generica" });

            return lst;
        }

     }
}
