using eComunidade.Views;
using System;
using Microsoft.Maui.Controls;

namespace eComunidade
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.TelaLogin), typeof(Views.TelaLogin));
            Routing.RegisterRoute(nameof(Views.TelaHome), typeof(Views.TelaHome));
            Routing.RegisterRoute(nameof(Views.TelaEventos), typeof(Views.TelaEventos));
            Routing.RegisterRoute(nameof(Views.TelaRanking), typeof(Views.TelaRanking));
            Routing.RegisterRoute(nameof(Views.TelaDicas), typeof(Views.TelaDicas));

            Routing.RegisterRoute(nameof(Views.TelaOcorrencias), typeof(Views.TelaOcorrencias));
            Routing.RegisterRoute(nameof(Views.TelaAdicionar), typeof(Views.TelaAdicionar));

            Routing.RegisterRoute(nameof(Views.TelaCadastro), typeof(Views.TelaCadastro));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
           
            await Shell.Current.GoToAsync($"//{nameof(Views.TelaLogin)}");
        }
    }
}