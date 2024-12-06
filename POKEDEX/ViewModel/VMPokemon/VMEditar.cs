using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using POKEDEX.Model;

namespace POKEDEX.ViewModel.VMPokemon
{
    public class VMEditar : BaseViewModel
    {
        PokemonModel pokemonModel;
        public PokemonModel ParametrosRecibe { get; set; }
        public VMEditar(INavigation navigation, PokemonModel ParametrosTrae)
        {
            Navigation = navigation;
            ParametrosRecibe = ParametrosTrae;
        }
        public async Task Volver()
        {
            await Navigation.PopModalAsync();
        }
        public ICommand Volvercommand => new Command(async () => await Volver());

    }
}
