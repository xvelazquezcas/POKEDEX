using System;
using System.Collections.Generic;
using System.Text;
using POKEDEX.Model;
using POKEDEX.Connectionn;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace POKEDEX.Data
{
    public class PokemonData
    {

        public async Task InsertarPokemon(PokemonModel parametros)
        {
            await Connection.firebase.Child("Pokemon").PostAsync(new PokemonModel()
            {
                 Name = parametros.Name,
                 BackgronColor = parametros.BackgronColor,
                 Power = parametros.Power,
                 Icon = parametros.Icon,
                 NmOrder = parametros.NmOrder,
                 PowerColor = parametros.PowerColor,
                 IdPokemon = parametros.IdPokemon
            });
        }
        //public async Task<List<PokemonModel>> MostrarPokemon()
        public async Task<ObservableCollection<PokemonModel>> MostrarPokemon()
        {
            var data = await Task.Run(() => Connection.firebase.Child("Pokemon").AsObservable<PokemonModel>().AsObservableCollection());
            return data;
        }
        public async Task EditarPokemon(PokemonModel parametrosRecibe)
        {
            await Connection.firebase.Child("Pokemon").PutAsync(new PokemonModel()
            {
                Name = parametrosRecibe.Name,
                BackgronColor = parametrosRecibe.BackgronColor,
                Power = parametrosRecibe.Power,
                Icon = parametrosRecibe.Icon,
                NmOrder = parametrosRecibe.NmOrder,
                PowerColor = parametrosRecibe.PowerColor,
                IdPokemon = parametrosRecibe.IdPokemon
            });
        }
        public async Task EliminarPokemon(PokemonModel nmrOrden)
        {
            if (nmrOrden != null && !string.IsNullOrEmpty(nmrOrden.NmOrder))
            {
                var eliminar = (await Connection.firebase.Child("Pokemon").OnceAsync<PokemonModel>()).Where(a => a.Object.NmOrder == nmrOrden.NmOrder).FirstOrDefault();
                await Connection.firebase.Child("Pokemon").Child(eliminar.Key).DeleteAsync();
                //await Connection.firebase.Child("Pokemon").Child(eliminar.Key).DeleteAsync();
            }
        }
        //esto nose de donde lo saque la neta jaja
        //public async Task EditarPokemon(PokemonModel parametros)
        //{
        //    await Connection.firebase
        //        .Child("Pokemon")
        //        .Child(parametros.IdPokemon)
        //        .PutAsync(new PokemonModel()
        //        {
        //            Name = parametros.Name,
        //            BackgronColor = parametros.BackgronColor,
        //            Power = parametros.Power,
        //            Icon = parametros.Icon,
        //            NmOrder = parametros.NmOrder,
        //            PowerColor = parametros.PowerColor,
        //            IdPokemon = parametros.IdPokemon
        //        });
        //}
        //public static async Task Eliminar(string idElemento)
        //{
        //    try
        //    {
        //        //var firebase = new FirebaseClient("https://mvvm-2c13a-default-rtdb.firebaseio.com/");

        //        // Obtiene el elemento que deseas eliminar
        //        var elementoAEliminar = await Connection.firebase
        //            .Child("Pokmeon") // Corregido el nombre del nodo
        //            .Child(idElemento) // Utiliza el ID específico del elemento a eliminar
        //            .OnceSingleAsync<PokemonModel>();

        //        if (elementoAEliminar != null)
        //        {
        //            // Elimina el elemento usando su ID
        //            await Connection.firebase.Child("Pokmeon").Child(idElemento).DeleteAsync();
        //        }
        //        else
        //        {
        //            // El elemento no fue encontrado
        //            Console.WriteLine("El elemento no existe o no se puede eliminar.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción, por ejemplo, registrar o mostrar un mensaje de error
        //        Console.WriteLine($"Error al eliminar: {ex.Message}");
        //    }
        //}
        //public async Task EditarPokemon(PokemonModel parametros)
        //{
        //    await Connection.firebase.Child("Pokemon").PutAsync(new PokemonModel()
        //    {
        //        Name = parametros.Name,
        //        BackgronColor = parametros.BackgronColor,
        //        Power = parametros.Power,
        //        Icon = parametros.Icon,
        //        NmOrder = parametros.NmOrder,
        //        PowerColor = parametros.PowerColor,
        //        IdPokemon = parametros.IdPokemon
        //    });
        //}
    }
}

            //return (await Connection.firebase.Child("Pokemon").OnceAsync<PokemonModel>()).Select(item => new PokemonModel
            //{
            //    IdPokemon = item.Key,
            //    Name = item.Object.Name,
            //    BackgronColor = item.Object.BackgronColor,
            //    Power = item.Object.Power,
            //    Icon = item.Object.Icon,
            //    NmOrder = item.Object.NmOrder,
            //    PowerColor = item.Object.PowerColor
            //}).ToList();
        //private INavigation navigation1;
        //private object navigation2;

        //public PokemonData(INavigation navigation1, object navigation2)
        //{
        //    this.navigation1 = navigation1;
        //    this.navigation2 = navigation2;
        //}