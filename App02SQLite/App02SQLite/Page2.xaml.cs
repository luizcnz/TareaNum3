using SQLite;
using App02SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]



    public partial class Page2 : ContentPage
    {

        public Page2()
        {
            InitializeComponent();
        }

        private void btnmodificar_Clicked(object sender, EventArgs e)
        {

            int         Page2ID;
            String      Page2Nombre;
            String      Page2Apellido;
            int         Page2Edad;
            String      Page2Fecha;
            String      Page2Correo;
            String      Page2Direccion;


            Page2ID =           Convert.ToInt32(item.Text);
            Page2Nombre =       nombre2.Text;
            Page2Apellido =     apellido2.Text;
            Page2Edad =         Convert.ToInt32(edad2.Text);
            Page2Fecha =        Convert.ToString(fecha2.Date);
            Page2Correo =       correo2.Text;
            Page2Direccion =    direccion2.Text;

            string x = Convert.ToString(Page2ID);

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                var modpersonas = conexion.Query<Personas>
                ($"UPDATE Personas set nombre = '" + Page2Nombre + "', apellido = '" + Page2Apellido + "', edad = '" + Page2Edad + "', fecha ='" + Page2Fecha + "', correo = '" + Page2Correo + "', direccion = '" + Page2Direccion + "' WHERE Id = '" + x + "' ");
            }

            DisplayAlert("", "Se ha modificado a " + Page2Nombre + " " +Page2Apellido +" ", "Aceptar");

        }
    }
}