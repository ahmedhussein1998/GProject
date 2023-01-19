//using Gproject.UI.Models;
//using Gproject.UI.Models.Dtos;

//namespace Gproject.UI.Services
//{
//    public class MenuService : BaseService, IMenuService
//    {
//        public MenuService(IHttpClientFactory httpClient) : base(httpClient)
//        {
//        }

//        public async Task<T> CreateMenu<T>(MenuDto menuDto, string token)
//        {
//            return await SendAsync<T>(new ApiRequest()
//            {
//                ApiType = SD.ApiType.POST,
//                Data = menuDto,
//                Url = SD.MenusAPIUrl + "/api/menus",
//                AccessToken = token
//            });
//        }

//        public async Task<T> DeleteMenu<T>(int id, string token)
//        {
//            return await SendAsync<T>(new ApiRequest()
//            {
//                ApiType = SD.ApiType.DELETE,
//                Url = SD.MenusAPIUrl + $"/api/menus/{id}",
//                AccessToken = token
//            });
//        }

//        public async Task<T> GetAllMenus<T>(string token)
//        {
//            return await SendAsync<T>(new ApiRequest()
//            {
//                ApiType = SD.ApiType.GET,
//                Url = SD.MenusAPIUrl + $"/api/menus",
//                AccessToken = token
//            });
//        }

//        public async Task<T> GetMenu<T>(int id, string token)
//        {
//            return await SendAsync<T>(new ApiRequest()
//            {
//                ApiType = SD.ApiType.GET,
//                Url = SD.MenusAPIUrl + $"/api/menus/{id}",
//                AccessToken = token
//            });
//        }

//        public async Task<T> UpdateMenu<T>(MenuDto menuDto, string token)
//        {
//            return await SendAsync<T>(new ApiRequest()
//            {
//                ApiType = SD.ApiType.PUT,
//                Data = menuDto,
//                Url = SD.MenusAPIUrl + "/api/menus",
//                AccessToken = token
//            });
//        }
//    }
//}
