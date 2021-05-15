namespace Marketplace.Domain
{
    /// <summary>
    /// first create all properties with the right access modifiers
    /// ensure that you do not expose what does not have to be exposed
    /// </summary>
    public class ClassifiedAd
    {
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
            OwnerId = ownerId;
            State = ClassifiedAdState.Inactive;
        }

        public ClassifiedAdId Id { get; private set; }

        public void SetTitle(ClassifiedAdTitle title) => Title = title;

        public void UpdatePrice(Price price) => Price = price;

        public void UpdateText(ClassifiedAdText text) => Text = text;

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }

        public ClassifiedAdState State { get; private set; }
        public ClassifiedAdText Text { get; private set; }
        public ClassifiedAdTitle Title { get; private set; }
        public Price Price { get; private set; }
        public UserId ApprovedBy { get; private set; }
        public UserId OwnerId { get; private set; }

        protected void EnsureValidState()
        {
            var valid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    ClassifiedAdState.PendingReview =>
                    Title != null &&
                    Text != null &&
                    Price?.Amount > 0,
                    ClassifiedAdState.Active =>
                    Title != null &&
                    Text != null &&
                    Price?.Amount > 0 &&
                    ApprovedBy != null,
                    _ => true
                });
            if (!valid)
            {
                throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
            }
        }

        public void RequestToPublish()
        {
            State = ClassifiedAdState.PendingReview;
            EnsureValidState();
        }
    }
}