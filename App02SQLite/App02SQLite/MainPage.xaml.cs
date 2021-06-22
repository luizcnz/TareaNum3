using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using App02SQLite.Models;

namespace App02SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnsalvar_Clicked(object sender, EventArgs e)
        {

            if (nombre.Text == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar un Nombre!", "Ok");
            }
            else if (apellido.Text == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar un Apellido!", "Ok");
            }
            else if (edad.Text == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar una Edad!", "Ok");
            }
            else if (fecha.Date == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar una Fecha!", "Ok");
            }
            else if (correo.Text == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar un Correo!", "Ok");
            }
            else if (direccion.Text == null)
            {
                DisplayAlert("Aviso", "Debes Ingresar una Direccion!", "Ok");
            }
            else
            {
                Int32 resultado = 0;
                Int32 years = Convert.ToInt32(edad.Text);
                String date = Convert.ToString(fecha.Date);

                var persona = new Personas
                {
                    nombre = nombre.Text,
                    apellido = apellido.Text,
                    edad = years,
                    fecha = date,
                    correo = correo.Text,
                    direccion = direccion.Text
                };

                using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
                {
                    conexion.CreateTable<Personas>();
                    resultado = conexion.Insert(persona);

                    if (resultado > 0)
                        DisplayAlert("Aviso", "Adicionado", "Ok");
                    else
                        DisplayAlert("Aviso", "Error", "Ok");
                }
            }


        }


        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
    }
}
