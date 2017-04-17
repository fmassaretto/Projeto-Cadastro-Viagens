using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens
{
    public class ClientApi
    {
        HttpClient client;

        public ClientApi()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApiBase"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<T> Get<T>(string metodo)
        {
            try
            {
                HttpResponseMessage response =  client.GetAsync(metodo).Result;

                if (!response.IsSuccessStatusCode)
                    this.TratarExcecao(response);

                return response.Content.ReadAsAsync<List<T>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Get<T>(string metodo, int id)
        {
            try
            {
                string assinaturaMetodo = string.Format(metodo + "/{0}", id);
                HttpResponseMessage response = client.GetAsync(assinaturaMetodo).Result;

                if (!response.IsSuccessStatusCode)
                    this.TratarExcecao(response);

                return response.Content.ReadAsAsync<T>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Post(string metodo, string parametros)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync(metodo, new StringContent(parametros, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                    this.TratarExcecao(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Put(string metodo, string parametros)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync(metodo, new StringContent(parametros, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                    this.TratarExcecao(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(string metodo, int id)
        {
            try
            {
                string assinaturaMetodo = string.Format(metodo + "/{0}", id);
                HttpResponseMessage response = client.DeleteAsync(assinaturaMetodo).Result;

                if (!response.IsSuccessStatusCode)
                    this.TratarExcecao(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void TratarExcecao(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var mensagem = "401 - Usuário não autorizado";
                throw new Exception(mensagem);
            }
            else
            {
                var mensagem = JsonConvert.DeserializeObject<MensagemException>(response.Content.ReadAsStringAsync().Result);

                if (mensagem.message.ToUpper().Contains("ERROR") || mensagem.message.Contains("Internal"))
                    throw new Exception(mensagem.exceptionMessage);
                else
                    throw new Exception(mensagem.message);
            }
        }
    }
}
