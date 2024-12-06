using POKEDEX.Data;
using POKEDEX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using POKEDEX.Model;

namespace POKEDEX.ViewModel.VMPokemon
{
    public class VMPokemonList:BaseViewModel
    {
        #region Variables
        string _Text;
        ObservableCollection<PokemonModel> _ListaPokemon;
        //ObservableCollection<PokemonModel> _Lista;
        #endregion
        #region Objeto
        public ObservableCollection<PokemonModel> ListaPokemon
        {
            get { return _ListaPokemon; }
            set { SetValue(ref _ListaPokemon, value);
                OnPropertyChanged();
            }
        }
        #endregion
        #region Procesos
        public async Task Registrar()
        {
            await Navigation.PushModalAsync(new RegistroPokemon());
        }
        public async Task DetallesPokemon(PokemonModel parametros)
        {
            await Navigation.PushModalAsync(new DetallesPokemon(parametros));   //  Aquie esta la forma en la que le pasa los datos de la lista a la pagina de detalles
        }
        public async Task EditarPokemonn(PokemonModel parametrosEditar)
        {
            await Navigation.PushAsync(new EditarPokemon(parametrosEditar));
        }
        public async Task MostrarPokemon()
        {
            var function = new PokemonData();
            ListaPokemon = await function.MostrarPokemon();
        }
        #endregion
        #region Command
        public ICommand Registrarcommand => new Command(async () => await Registrar());
        public ICommand Detallescommand => new Command<PokemonModel>(async (p) => await DetallesPokemon(p));    //  Aqui este como se hace el comando utilizando el modelo
        public ICommand EditarCommand => new Command<PokemonModel>(async (p) => await EditarPokemonn(p));
        #endregion
        #region Constructor
        public VMPokemonList(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPokemon();
        }
        #endregion
    }
}