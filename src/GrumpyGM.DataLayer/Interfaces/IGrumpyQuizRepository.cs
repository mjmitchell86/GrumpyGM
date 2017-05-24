
using GrumpyGM.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrumpyGM.DataLayer.Interfaces
{
    public interface IGrumpyQuizRepository
    {
        void SaveCorrectResponse(CorrectResponse response);
        void SaveWrongResponse(WrongResponse response);
        void SaveWakeUpPhrase(WakeUpPhrase phrase);
        Task<List<WakeUpPhrase>> GetAllActiveWakeUpPhrases();
        Task<List<CorrectResponse>> GetAllActiveCorrectResponses();
        Task<List<WrongResponse>> GetAllActiveWrongResponses();
    }
}
