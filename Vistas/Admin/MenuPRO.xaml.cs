using PKUMonitor.Entidades;
using PKUMonitor.Modelos;
using PKUMonitor.Vistas;
using ScanCodeForms;
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
    public partial class MenuPRO : ContentPage
    {
        Pessoa admin, pessoa2;
        Repositorio<Pessoa> repositorioPessoa;
        public MenuPRO(Pessoa admin)
        {
            InitializeComponent();
            this.admin = admin;
            BindingContext = new MenuAdminModel(admin);
            repositorioPessoa = new Repositorio<Pessoa>();
            pessoa2 = new Pessoa();
            MainProgressBar.Progress = (admin.ProteinaBar);
            MainLabel.Text = admin.Proteina.ToString();
            if(admin.ProteinaBar <= 0.5F && admin.ProteinaBar>= 0.29F){
                MainProgressBar.ProgressColor = Color.Orange;
            }
            else if (admin.ProteinaBar <=0.29F)
            {
                MainProgressBar.ProgressColor = Color.Red;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Periodos((BindingContext as MenuAdminModel).admin.IdConjunto));
        }

        private void BtnVecinos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroProduto());
        }

        private void BtnAportaciones_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnGastos_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnBalance_Clicked(object sender, EventArgs e)
        {
            pessoa2.ProteinaTotal = 250F;
            pessoa2.Proteina = 250F;
            admin.Proteina = pessoa2.Proteina;
            admin.ProteinaBar = 1F;
            repositorioPessoa.Update(admin);

        }

        private void BtnConsumirProduto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsumirProduto(admin));
        }
    }
}