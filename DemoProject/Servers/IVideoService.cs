using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public interface IVideoService
    {
        Task<Videos> GetPathById(int id);
        List<Videos> GetAll();
        void Add(Videos video);
        Task<List<Videos>> GetAllAsync();
    }
}
