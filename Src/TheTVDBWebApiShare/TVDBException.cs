namespace TheTVDBWebApi
{
    public class TVDBException : Exception
    {
        public TVDBException(string message)
        {
            this.Message = message;
        }

        public TVDBException(HttpStatusCode statusCode, string? status, string message)
        {
            this.StatusCode = statusCode;
            this.Status = status;
            this.Message = message;
        }

        public TVDBException(HttpResponseMessage res)
        {
            this.StatusCode = res.StatusCode;
            this.Status = res.ToString();
            this.Message = res.Content.ReadAsStringAsync().Result;
        }

        public HttpStatusCode StatusCode { get; }

        public string? Status { get; }

        public override string Message { get; }
    }
}
