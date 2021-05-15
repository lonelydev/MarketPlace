using Marketplace.Framework;
using System;
using System.Text.RegularExpressions;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        private readonly string _value;

        private ClassifiedAdTitle(string value)
        {
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Title cannot be longer than 100 characters", nameof(value));
            }
            _value = value;
        }

        /// <summary>
        /// Demonstrating how factories can be used to add transformations around
        /// object creation
        /// </summary>
        /// <param name="htmlTitle"></param>
        /// <returns></returns>
        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportedTags = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "**")
                .Replace("</b>", "**");
            return new ClassifiedAdTitle(Regex.Replace(
                supportedTags, "<.*?>", string.Empty));
        }

        public static ClassifiedAdTitle FromString(string title) => new ClassifiedAdTitle(title);
    }
}