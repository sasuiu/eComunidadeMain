using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

            await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro realizado! Faça login para continuar.", "OK");

            await Shell.Current.GoToAsync($"//{nameof(TelaLogin)}");
        }

        [RelayCommand]
        private async Task ContinuarSemCadastro()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }
    }
}