using System;

namespace Marketplace.Domain
{
    /// <summary>
    /// Enforce constraints at the Value Object level
    /// This helps make code more explicit
    /// </summary>
    public class UserId
    {
        private readonly Guid _value;

        public UserId(Guid value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");
            }
            _value = value;
        }
    }
}
