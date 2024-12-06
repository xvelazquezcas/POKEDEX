using POKEDEX.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POKEDEX
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListarPokemon();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
