using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;

namespace GrumpyGM.ViewModels
{
    public class GMTauntAddShow
    {
        public List<string> Taunts { get; set; }
        public GrumpyGMTaunt NewTaunt { get; set; }
    }
}
