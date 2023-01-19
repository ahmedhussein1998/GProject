using Gproject.UI.Models;
using Gproject.UI.Models.Dtos;

namespace Gproject.UI.Services
{
    // IDisposable Deh Goah Function Hyt3mlaha implemntation Kasa Bl Mange Un_use Reqests ELy Fi El Memmory
    public interface IBaseService : IDisposable
    {
      
        Task<T> SendAsync<T>(ApiRequest apiRequest);


    }
}
