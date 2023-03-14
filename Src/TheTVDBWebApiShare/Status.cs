﻿namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Status record.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Id of the status record:
        /// </summary>
        /// <remarks>Can be null if no status exists.</remarks>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Keep updated flag of the status record.
        /// </summary>
        [JsonPropertyName("keepUpdated")]
        public bool KeepUpdated { get; set; }

        /// <summary>
        /// Name of the status record.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the status record.
        /// </summary>
        [JsonPropertyName("recordType")]
        public string RecordType { get; set; }
    }
}
