using POKEDEX.Model;
using POKEDEX.ViewModel.VMPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POKEDEX.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesPokemon : ContentPage
	{
		public DetallesPokemon (PokemonModel parametros)
		{
			InitializeComponent ();
            BindingContext = new VMDetalles(Navigation, parametros);
        }
        //Button editarButton = new Button
        //{
        //    Text = "Editar"
        //    //Command = new Command(EditarCommand)
        //};

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{

        //}
    }
}