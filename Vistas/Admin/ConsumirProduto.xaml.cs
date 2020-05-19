using PKUMonitor.Entidades;
using PKUMonitor.Modelos;
using PKUMonitor.Vistas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScanCodeForms.Services;

namespace PKUMonitor.Vistas.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumirProduto : ContentPage
    {
        Repositorio<Produto> repositorioProduto;
        Repositorio<Pessoa> repositorioPessoa;
        MenuPRO menupro;
        Pessoa pessoa;
        NovoProduto model;
        string str = null;
        //função inicializadora das classes;
        public ConsumirProduto(Pessoa pessoa)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            model = BindingContext as NovoProduto;
            repositorioProduto = new Repositorio<Produto>();
            repositorioPessoa = new Repositorio<Pessoa>();
        }


        private async void Button_OnClicked(object sender, EventArgs e) => await OpenScan();
        //Função que lê o código de barra e transforma em string;
        private async Task OpenScan()
        {
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();
            if (!string.IsNullOrEmpty(result))
            {
                str = result.ToString();
            }
        }

        //função principal da consumação do produto onde se pega o código de barra e utiliza os dados do banco 
        //de dados para a consumação do usuário;
        private void BtnConfirmarProduto_Clicked(object sender, EventArgs e)
        {
            if(str!= null)
            {
               Produto codigobarra = repositorioProduto.Query(p => p.CodigoBarra == str).SingleOrDefault();
                DisplayAlert(codigobarra.QuantiaProteina.ToString(), codigobarra.CodigoBarra, "aaa");

                float proteina = ((codigobarra.QuantiaProteina) / (pessoa.ProteinaTotal));
                pessoa.Proteina -= codigobarra.QuantiaProteina;
                pessoa.ProteinaBar -= proteina;
                DisplayAlert("Sucesso", "O produto foi consumido e possuia " + codigobarra.QuantiaProteina.ToString() + "proteínas", "lul");
                repositorioPessoa.Update(pessoa);
                Navigation.PopAsync();
                Navigation.PopAsync();
                Navigation.PushAsync(new MenuPRO(pessoa));
            }
            else if (model.ProdutoSelecionado != null)
            {
                string str1 = model.ProdutoSelecionado.QuantiaProteina.ToString();
                float proteina = ((model.ProdutoSelecionado.QuantiaProteina)/(pessoa.ProteinaTotal));
                pessoa.Proteina -= model.ProdutoSelecionado.QuantiaProteina;
                pessoa.ProteinaBar -= proteina;
                DisplayAlert("Sucesso", "O produto foi consumido e possuia " + str1  + "proteínas", "lul");
                repositorioPessoa.Update(pessoa);
                Navigation.PopAsync();
                Navigation.PopAsync();
                Navigation.PushAsync(new MenuPRO(pessoa));
            }
            else
            {
                DisplayAlert("errorNull", "Não existe produto selecionado", "error");
            }

        }
    }
}