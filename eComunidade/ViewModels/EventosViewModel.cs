using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eComunidade.Models;
using System;
using System.Collections.ObjectModel;
using eComunidade.Views;

namespace eComunidade.ViewModels
{
    public partial class EventosViewModel : ObservableObject
    {
        public ObservableCollection<Evento> Eventos { get; set; } = new ObservableCollection<Evento>();

        public EventosViewModel()
        {
            // exemplos pra nao deixar tudo vazio
            Eventos.Add(new Evento
            {
                Id = 1,
                Titulo = "Reunião de Moradores",
                Descricao = "Discussão sobre a segurança do bairro.",
                Local = "Salão de Festas",
                Data = new DateTime(2025, 9, 14, 19, 0, 0),
                QtdeVoluntarios = 15,
                QtdeVagas = 30,
                Duracao = TimeSpan.FromHours(2),
                PontuacaoVoluntario = 5
            });

            Eventos.Add(new Evento
            {
                Id = 2,
                Titulo = "Feira de Troca",
                Descricao = "Traga objetos, livros e roupas que você não usa mais para trocar com outros moradores.",
                Local = "Parque Central",
                Data = new DateTime(2025, 9, 15, 14, 0, 0),
                QtdeVoluntarios = 8,
                QtdeVagas = 20,
                Duracao = TimeSpan.FromHours(4),
                PontuacaoVoluntario = 10
            });
        }

       
        [RelayCommand]
        private async Task NavigateToHome()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task NavigateToAdd()
        {
            await Shell.Current.GoToAsync($"{nameof(TelaAdicionar)}");
        }
    }
}