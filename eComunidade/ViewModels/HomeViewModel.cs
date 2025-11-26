using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eComunidade.Views;
using Microsoft.Maui.Controls;

namespace eComunidade.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? nomeUsuario;

        public HomeViewModel()
        {
            NomeUsuario = "Olá, Usuário!";
        }

        [RelayCommand]
        private void ToggleMenu()
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

        // comandos de navegação
        [RelayCommand]
        private async Task NavigateToProfile()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaLogin)}");
        }

        [RelayCommand]
        private async Task NavigateToEvents()
        {
          
            await Shell.Current.GoToAsync($"{nameof(TelaEventos)}");
        }

        [RelayCommand]
        private async Task NavigateToOccurrences()
        {
            
            await Shell.Current.GoToAsync($"{nameof(TelaOcorrencias)}");
        }

        [RelayCommand]
        private async Task NavigateToRanking()
        {
           
            await Shell.Current.GoToAsync($"{nameof(TelaRanking)}");
        }

        [RelayCommand]
        private async Task NavigateToDicas()
        {
            await Shell.Current.GoToAsync($"{nameof(TelaDicas)}");
        }

        [RelayCommand]
        private async Task NavigateToHome()
        {
            
            await Shell.Current.GoToAsync($"{nameof(TelaHome)}");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            
            await Shell.Current.GoToAsync($"{nameof(TelaAdicionar)}");
        }
    }
}