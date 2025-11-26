using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eComunidade.Views;

namespace eComunidade.ViewModels
{
    public class Dica
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
    }

    public partial class DicasViewModel : ObservableObject
    {
        public ObservableCollection<Dica> DicasDestaque { get; } = new ObservableCollection<Dica>();
        public ObservableCollection<Dica> DicasRecentes { get; } = new ObservableCollection<Dica>();

        public DicasViewModel()
        {
            LoadDicasData();
        }

        private void LoadDicasData()
        {
            //exemplos de dicas (api aqui dps

            DicasDestaque.Clear();
            DicasRecentes.Clear();

            DicasDestaque.Add(new Dica { Id = 1, Titulo = "Segurança em Casa", Descricao = "Dicas essenciais para melhorar a segurança do seu lar contra invasões e acidentes.", Categoria = "Segurança" });
            DicasDestaque.Add(new Dica { Id = 2, Titulo = "Economia de Água", Descricao = "Maneiras simples e eficazes de reduzir o consumo de água e economizar na conta.", Categoria = "Sustentabilidade" });

            DicasRecentes.Add(new Dica { Id = 3, Titulo = "Reciclagem Inteligente", Descricao = "Saiba onde e como descartar materiais recicláveis corretamente na sua comunidade.", Categoria = "Sustentabilidade" });
            DicasRecentes.Add(new Dica { Id = 4, Titulo = "Primeiros Socorros na Rua", Descricao = "Dicas rápidas sobre o que fazer em casos de emergência médica na vizinhança.", Categoria = "Saúde" });
            DicasRecentes.Add(new Dica { Id = 5, Titulo = "Cuidado com Pets", Descricao = "Como ajudar animais de rua e garantir o bem-estar dos seus bichinhos.", Categoria = "Comunidade" });
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
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            await Shell.Current.GoToAsync(nameof(TelaAdicionar));
        }

        [RelayCommand]
        private async Task NavigateToDicas()
        {
            
            await Shell.Current.GoToAsync($"//{nameof(TelaDicas)}");
        }
    }
}