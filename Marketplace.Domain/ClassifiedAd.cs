namespace Marketplace.Domain
{
    /// <summary>
    /// first create all properties with the right access modifiers
    /// ensure that you do not expose what does not have to be exposed
    /// </summary>
    public class ClassifiedAd
    {
        private UserId _ownerId;
        private decimal _price;
        private string _text;
        private string _title;

        /// <summary>
        /// Must supply ClassifiedAdId and UserId for creating an Ad
        /// Using Value Objects as params, clarifies at what position each argument is
        /// It also helps abstract validations.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerId"></param>
        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            _ownerId = ownerId;
        }

        public ClassifiedAdId Id { get; private set; }

        public void SetTitle(string title) => _title = title;

        public void UpdatePrice(decimal price) => _price = price;

        public void UpdateText(string text) => _text = text;
    }
}