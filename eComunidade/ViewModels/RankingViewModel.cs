using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eComunidade.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace eComunidade.ViewModels
{
    public partial class RankItem : ObservableObject
    {
        public int Posicao { get; set; }
        public string NomeUsuario { get; set; }
        public int Pontos { get; set; }
        public string CorDestaque { get; set; }
        public string AvatarUrl { get; set; } = "profile.png";
    }

    public partial class RankingViewModel : ObservableObject
    {
        public ObservableCollection<RankItem> TopRanking { get; set; } = new ObservableCollection<RankItem>();

        [ObservableProperty]
        private RankItem _posicaoUsuario;

        public RankingViewModel()
        {
            CarregarDadosRanking();
        }

        private void CarregarDadosRanking()
        {
            string corOuro = "#FADF7C"; 
            string corPrata = "#D4D4D4"; 
            string corBronze = "#D2B48C"; 

            TopRanking.Add(new RankItem { Posicao = 1, NomeUsuario = "Ana Silva", Pontos = 1500, CorDestaque = corOuro });
            TopRanking.Add(new RankItem { Posicao = 2, NomeUsuario = "Bruno Costa", Pontos = 1250, CorDestaque = corPrata });
            TopRanking.Add(new RankItem { Posicao = 3, NomeUsuario = "Carla Souza", Pontos = 1100, CorDestaque = corBronze });


            TopRanking.Add(new RankItem { Posicao = 4, NomeUsuario = "David Mendes", Pontos = 980 });
            TopRanking.Add(new RankItem { Posicao = 5, NomeUsuario = "Erika Santos", Pontos = 850 });
            TopRanking.Add(new RankItem { Posicao = 6, NomeUsuario = "Fernando Lima", Pontos = 730 });
            TopRanking.Add(new RankItem { Posicao = 7, NomeUsuario = "Giovanna Alves", Pontos = 650 });
            TopRanking.Add(new RankItem { Posicao = 8, NomeUsuario = "Hugo Reis", Pontos = 510 });
            TopRanking.Add(new RankItem { Posicao = 9, NomeUsuario = "Isabela Neves", Pontos = 450 });
            TopRanking.Add(new RankItem { Posicao = 10, NomeUsuario = "João Pereira", Pontos = 390 });


            PosicaoUsuario = new RankItem
            {
                Posicao = 202,
                NomeUsuario = "Você",
                Pontos = 250
            };
        }



        [RelayCommand]
        private Task NavigateToProfile()
        {

            return Task.CompletedTask;
        }

        [RelayCommand]
        private void OpenMenu()
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaAdicionar)}");
        }

        [RelayCommand]
        private async Task NavigateToRanking()
        {

            await Shell.Current.GoToAsync($"//{nameof(TelaRanking)}");
        }
    }
}
