using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    /// <summary>
    /// Enforce constraints at the Value Object level
    /// This helps make code more explicit
    /// </summary>
    public class UserId : Value<UserId>
    {
        private readonly Guid _value;

        public UserId(Guid value) => _value = value;
    }
}