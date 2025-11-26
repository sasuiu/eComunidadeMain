using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace eComunidade.ViewModels
{
    public partial class CadastroViewModel : ObservableObject
    {
        // Propriedades para os campos do formulário
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
            // Lógica para validar e registrar o usuário
            // await Shell.Current.GoToAsync($"//{nameof(Views.TelaHome)}");
        }

        [RelayCommand]
        private async Task ContinuarSemCadastro()
        {
        
            await Shell.Current.GoToAsync($"//{nameof(Views.TelaHome)}");
        }
    }
}