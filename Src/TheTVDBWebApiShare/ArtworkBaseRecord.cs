namespace TheTVDBWebApi
{
    /// <summary>
    /// Base artwork record.
    /// </summary>
    public class ArtworkBaseRecord
    {
        internal ArtworkBaseRecord(ArtworkBaseRecordModel model)
        {
            Id = model.Id;
            Image = model.Image;
            Thumbnail = model.Thumbnail;
            Language = model.Language;
            Type = model.Type;
            Score = model.Score;
            Width = model.Width;
            Height = model.Height;
            IncludesText = model.IncludesText;
        }

        public long Id { get; }

        public string? Image { get; }

        public string? Thumbnail { get; }

        public Languages Language { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>The artwork type corresponds to the ids from the /artwork/types endpoint.</remarks>
        public long Type { get; }

        public double Score { get; }

        public long Width { get; }

        public long Height { get; }

        public bool IncludesText { get; }
    }
}
