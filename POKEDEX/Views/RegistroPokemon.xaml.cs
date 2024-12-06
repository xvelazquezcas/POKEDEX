using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POKEDEX.ViewModel;
using POKEDEX.ViewModel.VMPokemon;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POKEDEX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPokemon : ContentPage
    {
        public RegistroPokemon()
        {
            InitializeComponent();
            BindingContext = new VMRegistroPokemon(Navigation);
        }
    }
}