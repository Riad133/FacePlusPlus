using System;

namespace FacePlusPlus.Web.Contracts.Response
{
    public class Envelope<T>
    {
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal Envelope(T body, string errorMessage)
        {
            Body = body;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = errorMessage == null;
        }

        public T Body { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }
        public bool IsSuccess { get; }
    }

    public class Envelope : Envelope<string>
    {
        private Envelope(string errorMessage)
            : base(errorMessage == null? null : "success", errorMessage)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }

        public static Envelope<T> Error<T>(T error, string errorMessage)
        {
            return new Envelope<T>(error, errorMessage);
        }
    }
}