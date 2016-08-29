using Amazon.Util;
using System;

namespace GrumpyGM.DataLayer.Helpers
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a datetime object to the preferred DynamoDB string format
        /// </summary>
        /// <param name="source">Source datetime</param>
        /// <returns>Null if source is null, ISO8601 formatted string if source has value</returns>
        public static string GoDynamo(this DateTime? source)
        {
            return source?.ToString(AWSSDKUtils.ISO8601DateFormat);
        }
        /// <summary>
        /// Converts a datetime object to the preferred DynamoDB string format
        /// </summary>
        /// <param name="source">Source datetime</param>
        /// <returns>Non-Nullable version of DateTime converter, ISO8601 formatted string if source has value</returns>
        public static string GoDynamo(this DateTime source)
        {
            return source.ToString(AWSSDKUtils.ISO8601DateFormat);
        }
    }
}


