using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientLogger.Business.Infrastructure
{
    public class RuleViolationException : ApplicationException
    {
        public RuleViolation[] RuleViolations { get; private set; }

        public RuleViolationException(IEnumerable<RuleViolation> ruleViolations) :
            this(ruleViolations.ToArray())
        { }
        public RuleViolationException(params RuleViolation[] ruleViolations) :
            base(ruleViolations.Length > 1 ? "RuleViolationException" : ruleViolations[0].Message)
        {
            RuleViolations = ruleViolations;
        }
    }
}
