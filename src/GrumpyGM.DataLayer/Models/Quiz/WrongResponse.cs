using Amazon.DynamoDBv2.DataModel;

namespace GrumpyGM.DataLayer.Models
{
    [DynamoDBTable("WrongResponse")]
    public class WrongResponse
    {
        [DynamoDBHashKey]
        public string WrongResponseId { get; set; }
        [DynamoDBProperty]
        public string Response { get; set; }
        [DynamoDBProperty]
        [DynamoDBGlobalSecondaryIndexHashKey]
        public bool LastQuestionRespose { get; set; }
        [DynamoDBProperty]
        public string CreatedDate { get; set; }
        [DynamoDBProperty]
        [DynamoDBGlobalSecondaryIndexHashKey]
        public bool IsActive { get; set; }
        [DynamoDBProperty]
        [DynamoDBGlobalSecondaryIndexRangeKey]
        public bool IsPending { get; set; }
    }
}
