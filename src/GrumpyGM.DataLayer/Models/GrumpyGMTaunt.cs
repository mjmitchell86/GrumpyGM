using Amazon.DynamoDBv2.DataModel;

namespace GrumpyGM.DataLayer.Models
{
    [DynamoDBTable("GrumpyGMTaunt")]
    public class GrumpyGMTaunt
    {
        [DynamoDBHashKey]
        public string TauntId { get; set; }
        [DynamoDBProperty]
        public string TauntContent { get; set; }
        [DynamoDBProperty]
        [DynamoDBGlobalSecondaryIndexHashKey]
        public int TauntNumber { get; set; }
        [DynamoDBProperty]
        public string CreatedDate { get; set; }
        [DynamoDBProperty]
        [DynamoDBGlobalSecondaryIndexHashKey]
        public bool IsActive { get; set; }
    }
}
