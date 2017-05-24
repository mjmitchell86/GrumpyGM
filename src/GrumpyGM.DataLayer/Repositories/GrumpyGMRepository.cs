using Amazon.DynamoDBv2.DataModel;
using GrumpyGM.DataLayer.Interfaces;
using GrumpyGM.DataLayer.Models;
using Amazon.DynamoDBv2;
using Amazon;
using Amazon.Runtime;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Linq;

namespace GrumpyGM.DataLayer.Repositories
{
    public class GrumpyGMRepository : IGrumpyGMRepository
    {
        private readonly DynamoDBContext _dbContext;
        private readonly DynamoDBOperationConfig _ddboc;
        private readonly AmazonDynamoDBClient _client;

        public GrumpyGMRepository()
        {
            //TODO - Move the AWS Credentials to User Secrets or some 
            AmazonDynamoDBConfig dbConfig = new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.USEast1 };
            AWSCredentials cred = new BasicAWSCredentials("000", "000");

            AmazonDynamoDBClient client = new AmazonDynamoDBClient(cred, dbConfig);

            _dbContext = new DynamoDBContext(client);
            _ddboc = new DynamoDBOperationConfig();

            //Set Strongly Consistent Reads to only retrieve the most up-to-date data.
            _ddboc.ConsistentRead = false;
        }

        public async Task<long> GetTauntCount()
        {
            var res = await _client.DescribeTableAsync(new DescribeTableRequest
            {
                TableName = "GrumpyGMTaunt"
            });

            return res.Table.ItemCount;
        }

        public async void SaveTaunt(GrumpyGMTaunt taunt)
        {
            await _dbContext.SaveAsync(taunt);
        }

        public async Task<List<GrumpyGMTaunt>> GetAllActiveTaunts()
        {
            try
            {
                _ddboc.IndexName = "IsActive_IDX";
                var taunts = new List<GrumpyGMTaunt>();
                var results = _dbContext.QueryAsync<GrumpyGMTaunt>(true, _ddboc);

                do
                {
                    var set = await results.GetNextSetAsync();

                    if (set == null || !set.Any())
                    {
                        return null;
                    }

                    taunts.AddRange(set.ToArray());
                } while (!results.IsDone);

                return taunts;
            } catch(AmazonDynamoDBException ex)
            {
                throw new AmazonDynamoDBException(ex.Message);
            }
  
        }
    }
}
