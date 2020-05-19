using System;
using PKUMonitor.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PKUMonitor.Modelos;
using PKUMonitor.Vistas;
using PKUMonitor.Vistas.Admin;

namespace PKUMonitor
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Repositorio<Pessoa> repositorio;
        LoginModel model;

        public MainPage()
        {
            InitializeComponent();
            repositorio = new Repositorio<Pessoa>();
            model = BindingContext as LoginModel;
        }
        
        private void BtnIniciarSessao_Clicked(object sender, EventArgs e)
        {
            Pessoa usuario = repositorio.Query(p => p.Email == model.Email && p.Password == model.Password).SingleOrDefault();
            if(usuario != null)
            {
                DisplayAlert("PKU Monitor", "Bem vindo " + usuario.Nome, "Ok");
                if (usuario.EsAdministrador)
                {
                    Navigation.PushAsync(new MenuPRO(usuario));
                }
                else
                {

                }
            }
            else
            {
                DisplayAlert("Error", "Usuario e/ou senha errada", "Ok");
            }
        }
        private void BtnCriarConta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CriarConta());
        }
    }
}
