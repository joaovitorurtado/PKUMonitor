
using System;
using System.Threading.Tasks;
using PKUMonitor;
using PKUMonitor.Entidades;
using PKUMonitor.Modelos;
using ScanCodeForms.Services;
using Xamarin.Forms;

namespace ScanCodeForms
{
    public partial class CadastroProduto : ContentPage
    {
        NovoProduto model;
        Repositorio<Produto> produtoRepositorio;
        string str = null;
        public CadastroProduto()
        {
            InitializeComponent();
            model = BindingContext as NovoProduto;
            produtoRepositorio = new Repositorio<Produto>();
        }
        private async void Button_OnClicked(object sender, EventArgs e) => await OpenScan();

        private async Task OpenScan()
        {
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();
            if (!string.IsNullOrEmpty(result))
            {
                str = result.ToString();
                await DisplayAlert("Nova Conta", str, "OK");
            }
        }


        private void BtnCriarCadastro_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(model.Produto.Nome) || float.IsNaN(model.Produto.QuantiaProteina) || string.IsNullOrEmpty(model.Produto.Tipo))
            {
                DisplayAlert("Nova Conta", "Está faltando dados", str);


            }
            else
            { 

                model.Produto.CodigoBarra = str;
                Produto p = produtoRepositorio.Create(model.Produto);
                produtoRepositorio.Update(p);
                DisplayAlert(model.Produto.CodigoBarra.ToString(), str, model.Produto.QuantiaProteina.ToString());
            }
            }
        }
    }
