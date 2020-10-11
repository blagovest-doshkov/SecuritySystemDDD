namespace SecuritySystem.Domain.Common.Models
{
    using Common;
    using Exceptions;
    using static ModelConstants.Contact;

    public class Contact : ValueObject
    {
        internal Contact(string name, string phoneNumber)
        {
            ValidateName(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        //EF workaround ...
        internal Contact(string name)
        {
            ValidateName(name);

            this.Name = name;
            this.PhoneNumber = default!;
        }

        public string Name { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        private void ValidateName(string name)
        {
            Validator.StringLength<InvalidContactException>(name, MinNameLength, MaxNameLength, nameof(this.Name));
        }
    }
}
