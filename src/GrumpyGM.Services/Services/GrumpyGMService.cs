using System;
using GrumpyGM.DataLayer.Interfaces;
using GrumpyGM.DataLayer.Models;
using GrumpyGM.Services.Interfaces;
using GrumpyGM.DataLayer.Helpers;
using System.Collections.Generic;

namespace GrumpyGM.Services.Services
{
    public class GrumpyGMService : IGrumpyGMService
    {
        private readonly IGrumpyGMRepository _grumpyRepo;

        public GrumpyGMService(IGrumpyGMRepository grumpyRepo)
        {
            _grumpyRepo = grumpyRepo;
        }

        public List<string> GetTauntsContent()
        {
            var taunts = _grumpyRepo.GetAllActiveTaunts().Result;
            var xuList = new List<string>();
            if(taunts != null)
            {
                foreach (var x in taunts)
                {
                    xuList.Add(x.TauntContent);
                }
            }
        
            return xuList;
        }

        public void SaveTaunt(GrumpyGMTaunt taunt)
        {
            taunt.TauntId = Guid.NewGuid().ToString();
            taunt.CreatedDate = DateTime.Now.GoDynamo();
            taunt.IsActive = true;
            taunt.TauntNumber = 1;
            
            //taunt.TauntNumber = ((int)_grumpyRepo.GetTauntCount().Result + 1);
            
            _grumpyRepo.SaveTaunt(taunt);
        }
    }
}
