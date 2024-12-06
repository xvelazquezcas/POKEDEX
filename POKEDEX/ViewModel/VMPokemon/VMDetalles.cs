using Firebase.Database;
using Newtonsoft.Json;
using POKEDEX.Data;
using POKEDEX.Model;
using POKEDEX.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;


namespace POKEDEX.ViewModel.VMPokemon
{
    public class VMDetalles:BaseViewModel
    {
        PokemonModel pokemonModel;
        //esto me lo paso el chat xd
        public ICommand EliminarCommand { get; set; }
        string _Texto;
        public PokemonModel ParametrosRecibe { get; set; } 
        #region CONSTRUCTOR
        public VMDetalles(INavigation navigation, PokemonModel ParametrosTrae)
        {
            Navigation = navigation;
            ParametrosRecibe = ParametrosTrae;
            EliminarCommand = new Command<string>(async (id) => await Eliminar(id));
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Volver()
        {
            await Navigation.PopModalAsync();
        }
        public void ProcesoSimple()
        {
        }
        public async Task Eliminar(string idElemento)
        {
            //await PokemonData.Eliminar(idElemento);
            //ActualizarListaDePokemones();
            var funcion = new PokemonData();
            await funcion.EliminarPokemon(ParametrosRecibe);
            await Volver(); 
            DisplayAlert("Alerta", "Se Eliminara el Pokemon seleccionado", "Salir");
        }
        private void ActualizarListaDePokemones()
        {
            // Lógica para recargar la lista después de la eliminación
            // ...
        }
        public async Task Editar(PokemonModel parametros)
        {
            //var funcion = new PokemonData();
            //await funcion.EditarPokemon(ParametrosRecibe);
            //await Volver(); 
            ////await FirebaseClient.Child(nameof(PokemonModel)+"/"+parametros.NmOrder).PutAsync(JsonConvert.SerializeObject(parametros));
            //DisplayAlert("Alerta", "Se Editara el Pokemon seleccionado", "Salir");
            //    await Navigation.PushModalAsync(new EditarPokemon(parametros));
            await Navigation.PushModalAsync(new EditarPokemon(parametros));
        }
        public async Task DetallesPokemon(PokemonModel parametros)
        {
            //await Navigation.PushModalAsync(new EditarPokemon(parametros));   //  Aquie esta la forma en la que le pasa los datos de la lista a la pagina de detalles
        }
        #endregion
        #endregion
        #region COMANDO
        public ICommand ProcesoAsyncronocommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Volvercommand => new Command(async () => await Volver());
        //public ICommand EliminarPokemonCommand => new Command(async () => await Eliminar());
        //public ICommand EditarCommand => new Command<PokemonModel>(async (p) => await Editar(p));
        //public ICommand EditarPokemonCommand => new Command<PokemonModel>(async (p) => await Editar(p));
        public ICommand ProcesoSimCommand => new Command(ProcesoSimple);
        
        #endregion
    }
}
