using Amazon.DynamoDBv2.DataModel;

namespace GrumpyGM.DataLayer.Models
{
    [DynamoDBTable("WakeUpPhrase")]
    public class WakeUpPhrase
    {
        [DynamoDBHashKey]
        public string WakeUpPhraseId { get; set; }
        [DynamoDBProperty]
        public string Phrase { get; set; }
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
