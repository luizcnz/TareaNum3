using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using App02SQLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace App02SQLite
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page1 : ContentPage
    {
        private int     ItemID;
        private String  ItemNombre;
        private String  ItemApellido;
        private int     ItemEdad;
        private String  ItemFecha;
        private String  ItemCorreo;
        private String  ItemDireccion;
        private String  ItemSelected;

        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            conexion.CreateTable<Personas>();
            var listapersonas = conexion.Table<Personas>().ToList();
            ListaPersonas.ItemsSource = listapersonas;
            conexion.Close();

        }

        async void btnmod_Clicked(object sender, EventArgs e)
        {

            if (ItemFecha == null)
            {
                DisplayAlert("Aviso", "" + ItemNombre + " Debes seleccionar algun elemento de la lista", "Ok");
            }
            else
            {
                var Datos = new Class1
                {
                    DatosID = ItemID,
                    DatosNombre = ItemNombre,
                    DatosApellido = ItemApellido,
                    DatosEdad = ItemEdad,
                    DatosFecha = ItemFecha,
                    DatosCorreo = ItemCorreo,
                    DatosDireccion = ItemDireccion
                };

                var mods = new Page2(); mods.BindingContext = Datos; await Navigation.PushAsync(mods);
            }

        }

     
        private void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var almacenar = e.SelectedItem as Personas;

            ItemID = almacenar.id;
            ItemNombre = almacenar.nombre;
            ItemApellido = almacenar.apellido;
            ItemEdad = almacenar.edad;
            ItemFecha = almacenar.fecha;
            ItemCorreo = almacenar.correo;
            ItemDireccion = almacenar.direccion;


            selleccion.Text = ""+ItemNombre+" "+ItemApellido+"";

            DisplayAlert("Aviso", "Has seleccionado a: " + ItemNombre + " ", "Ok");

        }

        private void btnborrar_Clicked(object sender, EventArgs e)
        {
            if(ItemFecha == null)
            {
                DisplayAlert("Aviso", "" + ItemNombre + " Debes seleccionar algun elemento de la lista", "Ok");
            }
            else
            {
                string x = Convert.ToString(ItemID);

                SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
                var borrarpersonas = conexion.Query<Personas>($"Delete FROM Personas WHERE Id = '" + x + "' ");
                conexion.Close();

                DisplayAlert("Aviso", "" + ItemNombre + " ha sido eliminado de la lista de personas", "Ok");
            }

        }
    }
}