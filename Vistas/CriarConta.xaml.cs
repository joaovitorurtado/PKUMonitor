using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PKUMonitor.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarConta : ContentPage
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        private void BtnContaNoob_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaContaNOOB());
        }

        private void BtnContaPRO_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaContaPRO());
        }

        private void BtnTermos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Termino());
        }
    }
}