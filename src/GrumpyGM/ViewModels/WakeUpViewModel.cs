using System.Collections.Generic;
using GrumpyGM.DataLayer.Models;

namespace GrumpyGM.ViewModels
{
    public class WakeUpViewModel
    {
        public List<WakeUpPhrase> WakeUpPhrases { get; set; }
        public WakeUpPhrase WakeUpPhrase { get; set; }
    }
}
