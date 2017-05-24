using Amazon.DynamoDBv2.DataModel;
using GrumpyGM.DataLayer.Interfaces;
using GrumpyGM.DataLayer.Models;
using Amazon.DynamoDBv2;
using Amazon;
using Amazon.Runtime;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GrumpyGM.DataLayer.Repositories
{
    public class GrumpyQuizRepository : IGrumpyQuizRepository
    {
        private readonly DynamoDBContext _dbContext;
        private readonly DynamoDBOperationConfig _ddboc;
        private readonly AmazonDynamoDBClient _client;

        public GrumpyQuizRepository()
        {
            AmazonDynamoDBConfig dbConfig = new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.USEast1 };
            AWSCredentials cred = new BasicAWSCredentials("000", "000");

            AmazonDynamoDBClient client = new AmazonDynamoDBClient(cred, dbConfig);

            _dbContext = new DynamoDBContext(client);
            _ddboc = new DynamoDBOperationConfig();

            //Set Strongly Consistent Reads to only retrieve the most up-to-date data.
            _ddboc.ConsistentRead = false;
        }

        public async void SaveCorrectResponse(CorrectResponse response)
        {
            await _dbContext.SaveAsync(response);
        }

        public async void SaveWrongResponse(WrongResponse response)
        {
            await _dbContext.SaveAsync(response);
        }

        public async void SaveWakeUpPhrase(WakeUpPhrase phrase)
        {
            await _dbContext.SaveAsync(phrase);
        }

        public async Task<List<WakeUpPhrase>> GetAllActiveWakeUpPhrases()
        {
            try
            {
                _ddboc.IndexName = "IsActive-IsPending-index";
                var phrases = new List<WakeUpPhrase>();
                var results = _dbContext.QueryAsync<WakeUpPhrase>(true, _ddboc);
                
                {
                    var set = await results.GetNextSetAsync();

                    if (set == null || !set.Any())
                    {
                        return null;
                    }

                    phrases.AddRange(set.ToArray());
                } while (!results.IsDone);

                return phrases;
            }
            catch (AmazonDynamoDBException ex)
            {
                throw new AmazonDynamoDBException(ex.Message);
            }

        }

        public async Task<List<CorrectResponse>> GetAllActiveCorrectResponses()
        {
            try
            {
                _ddboc.IndexName = "IsActive-IsPending-index";
                var responses = new List<CorrectResponse>();
                var results = _dbContext.QueryAsync<CorrectResponse>(true, _ddboc);

                {
                    var set = await results.GetNextSetAsync();

                    if (set == null || !set.Any())
                    {
                        return null;
                    }

                    responses.AddRange(set.ToArray());
                } while (!results.IsDone) ;

                return responses;
            }
            catch (AmazonDynamoDBException ex)
            {
                throw new AmazonDynamoDBException(ex.Message);
            }
        }

        public async Task<List<WrongResponse>> GetAllActiveWrongResponses()
        {
            try
            {
                _ddboc.IndexName = "IsActive-IsPending-index";
                var responses = new List<WrongResponse>();
                var results = _dbContext.QueryAsync<WrongResponse>(true, _ddboc);

                {
                    var set = await results.GetNextSetAsync();

                    if (set == null || !set.Any())
                    {
                        return null;
                    }

                    responses.AddRange(set.ToArray());
                } while (!results.IsDone) ;

                return responses;
            }
            catch (AmazonDynamoDBException ex)
            {
                throw new AmazonDynamoDBException(ex.Message);
            }
        }
    }
}
