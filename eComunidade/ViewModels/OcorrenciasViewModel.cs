using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using eComunidade.Models;
using eComunidade.Models.Enum;
using eComunidade.Views;

namespace eComunidade.ViewModels
{
    public partial class OcorrenciasViewModel : ObservableObject
    {
        public ObservableCollection<Ocorrencia> Destaques { get; set; } = new ObservableCollection<Ocorrencia>();
        public ObservableCollection<Ocorrencia> Recentes { get; set; } = new ObservableCollection<Ocorrencia>();

        public OcorrenciasViewModel()
        {
            // exmplos de dados pra nao ficar vazio
            Destaques.Add(new Ocorrencia
            {
                Id = 1, 
                Descricao = "Rua com buracos próximo ao parque, causando acidentes.",
                Data = DateTime.Now.AddDays(-2),
                Tipo = TipoOcorrencia.EmSolucao
            });
            Destaques.Add(new Ocorrencia
            {
                Id = 2,
                Descricao = "Falta de iluminação na rua da biblioteca. Perigoso à noite.",
                Data = DateTime.Now.AddDays(-5),
                Tipo = TipoOcorrencia.Solucionada
            });
            Destaques.Add(new Ocorrencia
            {
                Id = 3,
                Descricao = "Lixo acumulado no final da rua, atraindo roedores. Necessário fiscalização.",
                Data = DateTime.Now.AddDays(-10),
                Tipo = TipoOcorrencia.NaoSolucionada
            });

            //exemplo pra nao ficar vazio
            Recentes.Add(new Ocorrencia
            {
                Id = 4,
                Descricao = "Barulho excessivo vindo da obra na Rua das Flores. Passou do horário permitido.",
                Data = DateTime.Now,
                Tipo = TipoOcorrencia.EmSolucao
            });
            Recentes.Add(new Ocorrencia
            {
                Id = 5,
                Descricao = "Poda de árvore irregular na frente do supermercado. Galhos caídos na calçada.",
                Data = DateTime.Now.AddHours(-3),
                Tipo = TipoOcorrencia.Solucionada
            });
            Recentes.Add(new Ocorrencia
            {
                Id = 6,
                Descricao = "Cães abandonados no pátio do prédio 3. Precisam de resgate.",
                Data = DateTime.Now.AddHours(-1),
                Tipo = TipoOcorrencia.NaoSolucionada
            });
        }

        //barra de botoes

        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelaHome)}");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            await Shell.Current.GoToAsync($"{nameof(TelaAdicionar)}");
        }


        // Comando para o botão "Comentar"
        [RelayCommand]
        private async Task ComentarOcorrencia(Ocorrencia ocorrencia)
        {
            if (ocorrencia != null)
            {
                // Por enquanto, vamos apenas exibir um alerta. Em seguida, pode-se navegar para uma tela de comentários.
                await Shell.Current.DisplayAlert("Comentar Ocorrência", $"Você clicou em comentar na ocorrência: '{ocorrencia.Descricao}'.\nID: {ocorrencia.Id}", "OK");
                // Exemplo de navegação futura:
                // await Shell.Current.GoToAsync($"{nameof(TelaDetalheOcorrencia)}?Id={ocorrencia.Id}");
            }
        }
    }
}