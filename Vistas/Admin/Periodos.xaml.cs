using PKUMonitor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PKUMonitor.Vistas.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Periodos : ContentPage
    {
        string idConjunto;
        public Periodos(string idConjunto)
        {
            InitializeComponent();
            this.idConjunto = idConjunto;
            BindingContext = new PeriodoModel(idConjunto);
        }

        private void BtnAgregarPeriodo_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}