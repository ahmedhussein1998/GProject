using Gproject.UI.Models;
using Gproject.UI.Models.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace Gproject.UI.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;
        public ResponseDto responseModel { get ; set ; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            _httpClient = httpClient;
        }


        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                // hna 2wl 7aga hbd2 A  create El objedt El Kas BL_Client ELy mn klalah hghaz EL reqest
                var client = _httpClient.CreateClient("GprojectAPI"); // hna mmkn adelh logec name Ex:GprojectAPI
                var message = new HttpRequestMessage();
                // hna 3mlt el massage ely hb3tha w h3rfh any mmkn ab3t json formate 
                message.Headers.Add("Accept","application/json");
                // b3d kda h3rf el reqest uri ely 3leh end point ely 3ayzen ntsl behaa 
                message.RequestUri = new Uri(apiRequest.Url); 
                //  hna h2olo lw el httpClient feh headers 2ftradya ams7ha
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data)
                        , Encoding.UTF8, "application/json");
                }
                    switch (apiRequest.ApiType)
                    {
                        case SD.ApiType.GET: 
                            message.Method = HttpMethod.Get;
                            break;
                        case SD.ApiType.POST:
                            message.Method = HttpMethod.Post;

                            break;
                        case SD.ApiType.PUT:
                            message.Method = HttpMethod.Put;

                            break;
                        case SD.ApiType.DELETE:
                            message.Method = HttpMethod.Delete;

                            break;
                        default:
                            break;
                    }
        

                    HttpResponseMessage apiResponse = await client.SendAsync(message);

                  
                    // dlw2ty 3wzen nkr2 el content dah wn 7welo L String .. wb3d kda n7wl El string dah l Api contonent DTO Opject

                    var apiContent = await apiResponse.Content.ReadAsStringAsync();

                    var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                    return apiResponseDto;
                
            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error occurs",
                    ErrorMessages = new() { Convert.ToString(e.Message) }
                };

                var res = JsonConvert.SerializeObject(dto);  // hna h7wlo string
                var apiResponseDto=  JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
        public void Dispose()
        {
           GC.SuppressFinalize(true);
        }
    }
}
