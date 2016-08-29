using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;

namespace GrumpyGM.Services.Interfaces
{
    public interface IGrumpyGMService
    {
        void SaveTaunt(GrumpyGMTaunt taunt);
        List<string> GetTauntsContent();
    }
}
