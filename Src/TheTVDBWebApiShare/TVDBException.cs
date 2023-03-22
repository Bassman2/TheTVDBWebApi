namespace TheTVDBWebApi
{
    public class TVDBException : Exception
    {
        public TVDBException(HttpStatusCode statusCode, string status, string message)
        {
            this.StatusCode = statusCode;
            this.Status = status;
            this.Message = message;
        }

        public HttpStatusCode StatusCode { get; }

        public string Status { get; }

        public override string Message { get; }
    }
}
