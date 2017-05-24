using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;

namespace GrumpyGM.ViewModels
{
    public class CorrectAnswerViewModel
    {
        public List<CorrectResponse> CorrectResponses { get; set; }
        public CorrectResponse CorrectResponse { get; set; }
    }
}
