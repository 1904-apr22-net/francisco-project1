using System;
using System.Text.RegularExpressions;

namespace HardwareStore.Library
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        /*private string _address;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;*/
        public int DefaultStoreId { get; set; }
        private DateTime _timeLastOrderPlaced;
        //private int lastStoreOrderedFrom;//TODO: implement/change type later?

        /// <summary>
        /// The customer's ID.
        /// </summary>
        public int CustId { get; set; }

        /// <summary>
        /// The customer's first name. Cannot be empty.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name cannot be empty.", nameof(value));
                }
                _firstName = value;
            }
        }

        /// <summary>
        /// The customer's last name. Cannot be empty.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last name cannot be empty.", nameof(value));
                }
                _lastName = value;
            }
        }

        /// <summary>
        /// The customer's phone number. Cannot be empty or non-US phone number.
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Phone number cannot be empty.", nameof(value));
                }
                if (!IsPhoneNumber(value))
                {
                    throw new ArgumentException("Not a proper phone number format.", nameof(value));
                }
                _phoneNumber = value;
            }
        }
       
        /*
        /// <summary>
        /// The customer's address. Cannot be empty.
        /// </summary>
        public string Address
        {
            get => _address;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Address cannot be empty.", nameof(value));

                }
                _address = value;
            }
        }

        /// <summary>
        /// The customer's city. Cannot be empty.
        /// </summary>
        public string City
        {
            get => _city;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("City cannot be empty.", nameof(value));

                }
                _city = value;
            }
        }

        /// <summary>
        /// The customer's state. Cannot be empty.
        /// </summary>
        public string State
        {
            get => _state;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("State cannot be empty.", nameof(value));

                }
                _state = value;
            }
        }

        /// <summary>
        /// The customer's zip code. Cannot be empty.
        /// </summary>
        public string ZipCode
        {
            get => _zipCode;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Zip code cannot be empty.", nameof(value));

                }
                _zipCode = value;
            }
        }

        /// <summary>
        /// The customer's country. Cannot be empty.
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Country cannot be empty.", nameof(value));

                }
                _country = value;
            }
        }*/

        /// <summary>
        /// The time customer placed last order. Cannot be empty.
        /// </summary>
        //TODO: maybe change this later?
        public DateTime TimeLastOrderPlaced
        {
            get => _timeLastOrderPlaced;
            set => _timeLastOrderPlaced = value;
        }

        /// <summary>
        /// The customer's default store. Allowed to be empty.
        /// </summary>
        /*public int DefaultStoreId
        {
            get => _defaultStoreId;
            set
            {                
                if(value.Length==0);
                {
                    throw new ArgumentException("Default store Id cannot be empty.");
                }
                _defaultStoreId = value;
            }
        }*/

        //public int LastStoreOrderedFrom { get; set; }

        /// <summary>
        /// Checks to see if number input is a valid US phone number WITH area code.
        /// It is written to all users to enter whatever delimiters they want
        /// or no delimiters at all (i.e. 111-222-3333, or 111.222.3333,
        /// or (111) 222-3333, or 1112223333, etc...).
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool IsPhoneNumber(string phone)
        {
            return Regex.Match(phone, @"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$").Success;
        }
    }
}
