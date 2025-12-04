using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using eComunidade.Models;

namespace eComunidade.Services
{
    public class ApiServices
    {
        private readonly HttpClient _http;

        public ApiServices()
        {
            string baseUrl;

#if ANDROID
    // Android emulator: usa o localhost do PC via 10.0.2.2 e HTTP (evita problemas com certificado)
    baseUrl = "https://ecomunidadeapi.azurewebsites.net";
#else
            // Windows / iOS / Mac - use HTTPS (porta do launchSettings)
            baseUrl = "https://ecomunidadeapi.azurewebsites.net";
#endif

            _http = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(20)
            };
        }



        public void SetBearerToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = null;
            }
            else
            {
                _http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        private async Task<(bool ok, string? error)> PostResultAsync<T>(string path, T obj)
        {
            var res = await _http.PostAsJsonAsync(path, obj);
            if (res.IsSuccessStatusCode) return (true, null);
            var txt = await res.Content.ReadAsStringAsync();
            return (false, txt);
        }

        private async Task<(bool ok, string? error)> PutResultAsync<T>(string path, T obj)
        {
            var res = await _http.PutAsJsonAsync(path, obj);
            if (res.IsSuccessStatusCode) return (true, null);
            var txt = await res.Content.ReadAsStringAsync();
            return (false, txt);
        }

        private async Task<(bool ok, string? error)> DeleteResultAsync(string path)
        {
            var res = await _http.DeleteAsync(path);
            if (res.IsSuccessStatusCode) return (true, null);
            var txt = await res.Content.ReadAsStringAsync();
            return (false, txt);
        }

        // DICA
        public async Task<List<Dica>?> GetDicas()
            => await _http.GetFromJsonAsync<List<Dica>>("/api/dica");

        public async Task<Dica?> GetDicaById(int id)
            => await _http.GetFromJsonAsync<Dica>($"/api/dica/{id}");

        public Task<(bool ok, string? error)> CriarDica(Dica dica) =>
            PostResultAsync("/api/dica", dica);

        public Task<(bool ok, string? error)> AtualizarDica(int id, Dica dica) =>
            PutResultAsync($"/api/dica/{id}", dica);

        public Task<(bool ok, string? error)> DeletarDica(int id) =>
            DeleteResultAsync($"/api/dica/{id}");

        //EVENTO 
        public async Task<List<Evento>?> GetEventos()
            => await _http.GetFromJsonAsync<List<Evento>>("/api/evento");

        public async Task<Evento?> GetEventoById(int id)
            => await _http.GetFromJsonAsync<Evento>($"/api/evento/{id}");

        public Task<(bool ok, string? error)> CriarEvento(Evento evento) =>
            PostResultAsync("/api/evento", evento);

        public Task<(bool ok, string? error)> AtualizarEvento(int id, Evento evento) =>
            PutResultAsync($"/api/evento/{id}", evento);

        public Task<(bool ok, string? error)> DeletarEvento(int id) =>
            DeleteResultAsync($"/api/evento/{id}");

        // OCORRENCIA 
        public async Task<List<Ocorrencia>?> GetOcorrencias()
            => await _http.GetFromJsonAsync<List<Ocorrencia>>("/api/ocorrencia");

        public async Task<Ocorrencia?> GetOcorrenciaById(int id)
            => await _http.GetFromJsonAsync<Ocorrencia>($"/api/ocorrencia/{id}");

        public Task<(bool ok, string? error)> CriarOcorrencia(Ocorrencia oc) =>
            PostResultAsync("/api/ocorrencia", oc);

        public Task<(bool ok, string? error)> AtualizarOcorrencia(int id, Ocorrencia oc) =>
            PutResultAsync($"/api/ocorrencia/{id}", oc);

        public Task<(bool ok, string? error)> DeletarOcorrencia(int id) =>
            DeleteResultAsync($"/api/ocorrencia/{id}");


        // USUARIO
        public async Task<List<Usuario>?> GetUsuarios()
            => await _http.GetFromJsonAsync<List<Usuario>>("/api/usuario");

        public async Task<Usuario?> GetUsuarioById(int id)
            => await _http.GetFromJsonAsync<Usuario>($"/api/usuario/{id}");

        public Task<(bool ok, string? error)> CriarUsuario(Usuario u) =>
            PostResultAsync("/api/usuario", u);

        public Task<(bool ok, string? error)> LogarUsuario(Usuario u) =>
            PostResultAsync("/api/usuario/login", u);

        public Task<(bool ok, string? error)> AtualizarUsuario(int id, Usuario u) =>
            PutResultAsync($"/api/usuario/{id}", u);

        public Task<(bool ok, string? error)> DeletarUsuario(int id) =>
            DeleteResultAsync($"/api/usuario/{id}");

        // Exemplo de login (retorna token string se a API retornar string)
        public async Task<(bool ok, string? tokenOrError)> Login(string email, string senha)
        {
            var payload = new { Email = email, Senha = senha };
            var res = await _http.PostAsJsonAsync(_http.BaseAddress + "api/usuario/login", payload);
            if (res.IsSuccessStatusCode)
            {
                var token = await res.Content.ReadFromJsonAsync<string?>();
                return (true, token);
            }
            else
            {
                var txt = await res.Content.ReadAsStringAsync();
                return (false, txt);
            }
        }
    }
}
