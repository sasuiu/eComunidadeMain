using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eComunidade.Views;
using System.Collections.Generic;

namespace eComunidade.ViewModels
{
    public partial class AdicionarViewModel : ObservableObject
    {
        // 1. PROPRIEDADES DE BINDING PARA O POST

        // Lista de categorias para o Picker
        public List<string> Categorias { get; } = new List<string> { "Dica", "Ocorrência", "Evento" };

        // Propriedade para vincular ao Picker (qual categoria foi escolhida)
        [ObservableProperty]
        private string categoriaSelecionada;

        // Propriedade para vincular ao Editor (o conteúdo digitado)
        [ObservableProperty]
        private string conteudoPost;

        public AdicionarViewModel()
        {
            // Inicialização da ViewModel
            CategoriaSelecionada = Categorias[0]; // Seleciona "Dica" como padrão
        }

        // 2. COMANDOS DE AÇÃO DA TELA

        [RelayCommand]
        private Task SalvarRascunho()
        {
            // Lógica para salvar o post atual como rascunho.
            // Aqui você chamaria a API ou o serviço local.

            // Exemplo de como acessar os dados:
            string rascunho = $"Rascunho salvo: Categoria: {CategoriaSelecionada}, Conteúdo: {ConteudoPost}";

            // Em um app real, você faria:
            // if (await _dataService.SaveDraft(CategoriaSelecionada, ConteudoPost))
            // {
            //     await Shell.Current.DisplayAlert("Sucesso", "Rascunho salvo com sucesso!", "OK");
            // }

            // Apenas para demonstração:
            Shell.Current.DisplayAlert("Rascunho", rascunho, "OK");

            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task PublicarPost()
        {
            // Lógica para publicar o post
            // Aqui você faria validações e chamaria a API.

            if (string.IsNullOrWhiteSpace(ConteudoPost))
            {
                Shell.Current.DisplayAlert("Erro", "O conteúdo do post não pode estar vazio.", "OK");
                return Task.CompletedTask;
            }

            // Exemplo de como acessar os dados:
            string post = $"Publicando: Categoria: {CategoriaSelecionada}, Conteúdo: {ConteudoPost}";

            // Em um app real, você faria a chamada à API e a navegação:
            // if (await _dataService.PublishPost(CategoriaSelecionada, ConteudoPost))
            // {
            //     await Shell.Current.DisplayAlert("Sucesso", "Post publicado!", "OK");
            //     await Shell.Current.GoToAsync($"//{nameof(Views.TelaHome)}");
            // }

            // Apenas para demonstração:
            Shell.Current.DisplayAlert("Publicar", post, "OK");

            // Limpa o formulário após a "publicação" simulada
            ConteudoPost = string.Empty;

            return Task.CompletedTask;
        }


        // 3. COMANDOS DE NAVEGAÇÃO

        // Comandos do Cabeçalho
        [RelayCommand]
        private Task NavigateToProfile()
        {
            // Deixado como inativo, conforme as instruções anteriores
            return Task.CompletedTask;
        }

        [RelayCommand]
        private void OpenMenu()
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

        // Comandos da Barra Inferior
        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            // Já estamos na tela de Adicionar. Apenas retorna.
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task NavigateToDicas()
        {
            // Mapeia o ícone de coração para a tela de Dicas, como em TelaDicas
            await Shell.Current.GoToAsync($"//{nameof(TelaDicas)}");
        }
    }
}