using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace POKEDEX.ViewModel
{
    class VMPatron:BaseViewModel
    {
        string _Texto;
        #region CONSTRUCTOR
        public VMPatron(INavigation navigation)
        {
            Navigation = navigation;
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
        public void ProcesoSimple()
        {

        }
        #endregion
        #endregion
        #region COMANDO
        public ICommand ProcesoAsyncronocommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimCommand => new Command(ProcesoSimple);
        #endregion
    }
}
