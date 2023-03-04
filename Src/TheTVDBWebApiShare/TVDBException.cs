namespace TheTVDBWebApiShare
{
    public class TVDBException : Exception
    {
        public TVDBException(HttpStatusCode statusCode, string status)
        {
            this.StatusCode = statusCode;
            this.Status = status;
        }

        public HttpStatusCode StatusCode { get; }

        public string Status { get; }
    }
}
