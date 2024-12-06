﻿using POKEDEX.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using POKEDEX.Data;
using POKEDEX.Model;

namespace POKEDEX.ViewModel.VMPokemon
{
    public class VMRegistroPokemon:BaseViewModel
    {
        #region VARIABLES
        string _Txtcolorfondo;
        string _Txtcolorpoder;
        string _Txtnombre;
        string _Txtnro;
        string _Txtpoder;
        string _Txticono;
        #endregion

        #region CONTRUCTOR

        #endregion

        #region OBJETOS
        public string Txtcolorfondo
        {
            get { return _Txtcolorfondo; }
            set { SetValue(ref _Txtcolorfondo, value); }
        }
        public string Txtcolorpoder
        {
            get { return _Txtcolorpoder; }
            set { SetValue(ref _Txtcolorpoder, value); }
        }
        public string Txtnombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }
        public string Txtnro
        {
            get { return _Txtnro; }
            set { SetValue(ref _Txtnro, value); }
        }
        public string Txtpoder
        {
            get { return _Txtpoder; }
            set { SetValue(ref _Txtpoder, value); }
        }
        public string Txticono
        {
            get { return _Txticono; }
            set { SetValue(ref _Txticono, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var function = new PokemonData();
            var parametros = new PokemonModel();    
            parametros.BackgronColor = _Txtcolorfondo;
            parametros.PowerColor = _Txtcolorpoder;
            parametros.Icon = _Txticono;
            parametros.Name = _Txtnombre;
            parametros.NmOrder = _Txtnro;
            parametros.Power = _Txtpoder;
            await function.InsertarPokemon(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopModalAsync();
        }

        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion

        #region CONTRUCTOR
        public VMRegistroPokemon(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
    }
}
