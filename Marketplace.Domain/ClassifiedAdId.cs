using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    /// <summary>
    /// Enforce constraints at the Value Object level
    /// This helps make code more explicit
    /// </summary>
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        private readonly Guid _value;
        public ClassifiedAdId(Guid value) => _value = value;
    }
}
