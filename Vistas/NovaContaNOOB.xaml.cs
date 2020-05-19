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
    public partial class NovaContaNOOB : ContentPage
    {
        Repositorio<Pessoa> repositorioPessoa;
        NovaContaNOOBModel model;

        public NovaContaNOOB()
        {
          
            InitializeComponent();
            model = BindingContext as NovaContaNOOBModel;
            repositorioPessoa = new Repositorio<Pessoa>();
        }


        private void BtnCriarConta_Clicked(object sender, EventArgs e)
        {
            if(model.ConjuntoSelecionado!= null)
            {
                if (string.IsNullOrEmpty(model.Pessoa.Sobrenome) || string.IsNullOrEmpty(model.Pessoa.Email) || string.IsNullOrEmpty(model.Pessoa.Nome) || string.IsNullOrEmpty(model.Pessoa.NumCasa) || string.IsNullOrEmpty(model.Pessoa.Password) || string.IsNullOrEmpty(model.Password2))
                {
                    DisplayAlert("Nova Conta", "Dados faltando", "Ok");
                }
                else
                {
                    if (model.Password2 == model.Pessoa.Password)
                    {
                        model.Pessoa.IdConjunto = model.ConjuntoSelecionado.Id;
                        model.Pessoa.EsAdministrador = false;
                        if (repositorioPessoa.Create(model.Pessoa) != null)
                        {
                            DisplayAlert("Concluido", "Conta criada com sucesso", "OK");
                            Navigation.PushAsync(new MainPage());
                        }
                        else
                        {
                            DisplayAlert("Error", repositorioPessoa.Error, "Ok");
                        }
                    }
                    else
                    {
                        DisplayAlert("Nova conta", "As senahs não coincidem", "Ok");
                    }

                }
                   
            }
            else
            {
                DisplayAlert("Nova Conta", "Selecione um conjunto", "Ok");
            }
        }
    }
}