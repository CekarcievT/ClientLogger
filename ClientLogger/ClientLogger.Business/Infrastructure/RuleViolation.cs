using System;

namespace ClientLogger.Business.Infrastructure
{
    public class RuleViolation
    {
        public string Message { get; private set; }
        public RuleViolation(Exception ex)
        {
            Message = ex.Message;
        }

        public RuleViolation(string message)
        {
            Message = message;
        }
    }
}
