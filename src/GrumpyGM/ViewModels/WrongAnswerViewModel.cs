using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;

namespace GrumpyGM.ViewModels
{
    public class WrongAnswerViewModel
    {
        public List<WrongResponse> WrongResponses { get; set; }
        public WrongResponse WrongResponse { get; set; }
    }
}
