﻿namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Extended award category record.
/// </summary>
public class AwardCategoryExtendedRecord : AwardCategoryBaseRecord
{
    [JsonPropertyName("nominees")]
    public List<AwardNomineeBaseRecord>? Nominees { get; set; }
}
