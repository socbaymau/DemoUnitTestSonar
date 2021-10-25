using Data.Models;
using Demo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public class VideoService:IVideoService
    {
        private readonly IRepository<Videos> _repository;
        public VideoService(IRepository<Videos> repository)
        {
            _repository = repository;
        }

        public async Task<Videos> GetPathById(int id)
        {
            var data = await _repository.TableNoTracking.FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }
        public List<Videos> GetAll()
        {
            var data = _repository.TableNoTracking.ToList();
            return data;
        }
        public async Task<List<Videos>> GetAllAsync()
        {
            var data = await _repository.TableNoTracking.ToListAsync();
            return data;
        }
        public void Add(Videos video)
        {
            _repository.Add(video);
        }
    }
}
