using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using UsersAPI.Infra.Messages.Models;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Services
{
    public class EmailMessageService
    {
        private readonly EmailMessageSettings? _emailMessageSettings;

        public EmailMessageService(IOptions<EmailMessageSettings>? emailMessageSettings)
        {
            _emailMessageSettings = emailMessageSettings?.Value;
        }

        public async Task SendMessage(MessagesRequestModel messagesRequestModel)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    /*
                    
                    //Autenticando na Api de envio de emails
                    var authResponseModel = await ExecuteAuth();

                    //Criando um parâmetro de cabeçalho com o token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponseModel.Token);
                    */

                    var messagesRequestContent = new StringContent(JsonConvert.SerializeObject(messagesRequestModel),
                        Encoding.UTF8, "application/json");
                    
                    await httpClient.PostAsync($"{_emailMessageSettings?.BaseUrl}/sendemail",messagesRequestContent);
                }
                catch (Exception e) 
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        /*
        private async Task<AuthResponseModel> ExecuteAuth()
        {
            using (var httpClient = new HttpClient())
            {
                var authRequestModel = new AuthRequestModel
                {
                    Key = _emailMessageSettings.User,
                    Pass = _emailMessageSettings.Pass
                };

                var authRequestContent = new StringContent(JsonConvert.SerializeObject(authRequestModel),
                    Encoding.UTF8, "application/json");

                var authResponse = await httpClient.PostAsync($"{_emailMessageSettings?.BaseUrl}/auth", authRequestContent);

                return ReadResponse<AuthResponseModel>(authResponse);
            }
        }
        */

        private T ReadResponse<T>(HttpResponseMessage response)
        {
            var builder = new StringBuilder();
            using (var item = response.Content)
            {
                var task = item.ReadAsStringAsync();
                builder.Append(task.Result);
            }

            return JsonConvert.DeserializeObject<T>(builder.ToString());
        }

    }
}
