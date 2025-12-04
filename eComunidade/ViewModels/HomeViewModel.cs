using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eComunidade.Views;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace eComunidade.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? nomeUsuario;

        // propriedade para o Carrossel 
        private ObservableCollection<string> bannerImages;
        public ObservableCollection<string> BannerImages
        {
            get => bannerImages;
            set => SetProperty(ref bannerImages, value);
        }

        public HomeViewModel()
        {
            NomeUsuario = "Olá!";

            bannerImages = new ObservableCollection<string>
            {
                "banner_image_01.png",
                "banner_image_02.jpg",
                "banner_image_03.png",
                "banner_image_04.png",
                "banner_image_05.png"
            };

        }

        [RelayCommand]
        private void ToggleMenu()
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

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