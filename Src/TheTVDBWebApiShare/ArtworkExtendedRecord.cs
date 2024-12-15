namespace TheTVDBWebApi
{
    /// <summary>
    /// Extended artwork record.
    /// </summary>
    public class ArtworkExtendedRecord : ArtworkBaseRecord
    {
        internal ArtworkExtendedRecord(ArtworkExtendedRecordModel model) : base(model) 
        {
            ThumbnailWidth = model.ThumbnailWidth;
            ThumbnailHeight = model.ThumbnailHeight;
            UpdatedAt = model.UpdatedAt;
            MovieId = model.MovieId;
            SeriesId = model.SeriesId;
            EpisodeId = model.EpisodeId;
            NetworkId = model.NetworkId;
            PeopleId = model.PeopleId;
            SeasonId = model.SeasonId;
            SeriesPeopleId = model.SeriesPeopleId;
            Status = model.Status;
            TagOptions = model.TagOptions.CastModel<TagOption>();
        }

        public long ThumbnailWidth { get; }

        public long ThumbnailHeight { get; }

        public long UpdatedAt { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Artwork for a movie only.</remarks>
        public long MovieId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Artwork for a series only.</remarks>
        public long SeriesId { get; }

        public long EpisodeId { get; }

        public long NetworkId { get; }

        public long PeopleId { get; }

        public long SeasonId { get; }

        public long SeriesPeopleId { get; }

        public ArtworkStatus? Status { get; }

        public IEnumerable<TagOption>? TagOptions { get; }
    }
}
