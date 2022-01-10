using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;

namespace WriteIT.Interfaces
{
    public interface ISeries
    {
        public Task<List<SeriesViewModel>> Get();
        public Task<SeriesViewModel> Get(int id);
        public Task<List<SeriesViewModel>> GetByIds(int[] ids);
        public Task Create(SeriesViewModel model);
        public Task Update([FromRoute] int id, SeriesViewModel model);
        public Task Delete(int[] ids);
    }
}
