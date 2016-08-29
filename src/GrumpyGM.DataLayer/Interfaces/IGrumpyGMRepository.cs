using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrumpyGM.DataLayer.Interfaces
{
    public interface IGrumpyGMRepository
    {
        void SaveTaunt(GrumpyGMTaunt taunt);
        Task<long> GetTauntCount();
        Task<List<GrumpyGMTaunt>> GetAllActiveTaunts();
    }
}
