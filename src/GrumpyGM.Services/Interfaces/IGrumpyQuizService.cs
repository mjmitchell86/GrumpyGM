using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;

namespace GrumpyGM.Services.Interfaces
{
    public interface IGrumpyQuizService
    {
        void SaveWakeUpPhrase(string phrase);
        void saveCorrectResponse(string response, bool lastQuestion);
        void saveWrongResponse(string response, bool lastQuestion);
        List<WakeUpPhrase> GetWakeUpPhrases();
        List<CorrectResponse> GetCorrectResponses();
        List<WrongResponse> GetWrongResponses();
    }
}
