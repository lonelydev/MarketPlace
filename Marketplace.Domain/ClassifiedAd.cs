using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
/// <summary>
/// first create all properties with the right access modifiers
/// ensure that you do not expose what does not have to be exposed
/// </summary>
    public class ClassifiedAd
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// must supply id when creating a Classified Ad
        /// </summary>
        /// <param name="id"></param>
        public ClassifiedAd(Guid id, Guid ownerId)
        {
            if(id == default)
            {
                throw new ArgumentException("Identity must be specified", nameof(id));
            }

            if (ownerId == default)
            {
                throw new ArgumentException("Owner id must be specified", nameof(ownerId));
            }

            Id = id;
            _ownerId = ownerId;
        }

        private Guid _ownerId;
        private string _title;
        private string _text;
        private decimal _price;

        public void SetTitle(string title) => _title = title;
        public void UpdateText(string text) => _text = text;
        public void UpdatePrice(decimal price) => _price = price;

    }
}
