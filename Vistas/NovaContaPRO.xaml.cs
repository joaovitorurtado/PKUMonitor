using PKUMonitor.Entidades;
using PKUMonitor.Modelos;
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
    public partial class NovaContaPRO : ContentPage
    {
        NovaContaAdminModel model;
        Repositorio<Pessoa> pessoaRepositorio;
        Repositorio<Conjunto> conjuntoRepositorio;
        public NovaContaPRO()
        {
            InitializeComponent();
            model = BindingContext as NovaContaAdminModel;
            pessoaRepositorio = new Repositorio<Pessoa>();
            conjuntoRepositorio = new Repositorio<Conjunto>();
        }

        private void BtnCriarConta_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(model.Password2))
            {
                DisplayAlert("Nova conta", "A senha não pode estar vazia","Ok");
            }
            if (model.Password2 == model.Pessoa.Password)
            {
                if (string.IsNullOrEmpty(model.Pessoa.Email) || (model.Pessoa.Proteina == 0) || string.IsNullOrEmpty(model.Pessoa.Nome) || string.IsNullOrEmpty(model.Pessoa.Sobrenome))
                {
                    DisplayAlert("Nova Conta", "Está faltando dados", "OK");
                }
                else
                {
                    model.Pessoa.EsAdministrador = true;
                    
                    Pessoa p = pessoaRepositorio.Create(model.Pessoa);

                    if(p != null)
                    {
                        DisplayAlert("Concluido", "Sua conta foi criada", "OK");
                        Navigation.PushAsync(new MainPage());
                        model.Pessoa.ProteinaTotal = Convert.ToUInt32(model.Pessoa.Proteina);
                        pessoaRepositorio.Update(p);   
                    }
                    else
                    {
                        DisplayAlert("Error", pessoaRepositorio.Error, "OK");
                    }
                }
                
            }
            else
            {
                  DisplayAlert("Nova conta", "A senha não é igual", "Ok");
            }
        }
    }
}