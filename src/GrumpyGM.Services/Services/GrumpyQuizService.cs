using System;
using GrumpyGM.Services.Interfaces;
using GrumpyGM.DataLayer.Models;
using GrumpyGM.DataLayer.Helpers;
using GrumpyGM.DataLayer.Interfaces;
using System.Collections.Generic;

namespace GrumpyGM.Services.Services
{
    public class GrumpyQuizService : IGrumpyQuizService
    {
        private readonly IGrumpyQuizRepository _grumpyQuizRepo;

        public GrumpyQuizService(IGrumpyQuizRepository grumpyQuizRepo)
        {
            _grumpyQuizRepo = grumpyQuizRepo;
        }

        public void saveCorrectResponse(string response, bool lastQuestion)
        {
            var xuResponse = new CorrectResponse()
            {
                CorrectResponseId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now.GoDynamo(),
                IsPending = true,
                IsActive = true,
                LastQuestionRespose = lastQuestion,
                Response = response
            };

            _grumpyQuizRepo.SaveCorrectResponse(xuResponse);
        }

        public void SaveWakeUpPhrase(string phrase)
        {
            var xuPhrase = new WakeUpPhrase()
            {
                WakeUpPhraseId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now.GoDynamo(),
                IsPending = true,
                IsActive = true,
                Phrase = phrase
            };

            _grumpyQuizRepo.SaveWakeUpPhrase(xuPhrase);            
        }

        public void saveWrongResponse(string response, bool lastQuestion)
        {
            var xuResponse = new WrongResponse()
            {
                WrongResponseId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now.GoDynamo(),
                IsPending = true,
                IsActive = true,
                LastQuestionRespose = lastQuestion,
                Response = response
            };

            _grumpyQuizRepo.SaveWrongResponse(xuResponse);
        }

        public List<WakeUpPhrase> GetWakeUpPhrases()
        {
            return _grumpyQuizRepo.GetAllActiveWakeUpPhrases().Result;           
        }

        public List<CorrectResponse> GetCorrectResponses()
        {
            return _grumpyQuizRepo.GetAllActiveCorrectResponses().Result;
        }

        public List<WrongResponse> GetWrongResponses()
        {
            return _grumpyQuizRepo.GetAllActiveWrongResponses().Result;
        }
    }
}
