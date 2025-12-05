using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eComunidade.Models;
using eComunidade.Services;
using eComunidade.Views; 

namespace eComunidade.ViewModels
{
    public partial class CadastroViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nome;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string telefone;

        [ObservableProperty]
        private string cep;

        [ObservableProperty]
        private string senha;

        [ObservableProperty]
        private string data_nascimento;

        public CadastroViewModel()
        {
            // Construtor
        }

        [RelayCommand]
        private async Task Cadastrar()
        {

            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                await Application.Current.MainPage.DisplayAlert("Erro de Cadastro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }
            ApiServices api = new ApiServices();
            Usuario usu = new Usuario();
            usu.Email = Email;
            usu.Senha = Senha;
            usu.Cep = Cep;
            usu.Celular = Telefone;
            usu.Nome = Nome;
            usu.Login = Email;//TODO: Criar um campo de Login no front
            usu.Data_Nascimento = Convert.ToDateTime("01/01/2000");//TODO Criar campo com a data de nascimento no front end

            var retorno = await api.CriarUsuario(usu);

            if (retorno.ok)
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro realizado! Faça login para continuar.", "OK");
                await Shell.Current.GoToAsync($"//{nameof(TelaLogin)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", retorno.error ?? "Erro desconhecido", "OK");
            }

        }

        [RelayCommand]
        private async Task ContinuarSemCadastro()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }
    }
}