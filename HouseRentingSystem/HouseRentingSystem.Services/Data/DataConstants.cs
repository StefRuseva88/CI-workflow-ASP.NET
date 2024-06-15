namespace HouseRentingSystem.Services.Data
{
    public class DataConstants
    {
        public class House
        {
            //Title
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;
            //Address
            public const int AddressMaxLength = 150;
            public const int AddressMinLength = 30;
            //Description
            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 50;
            //Price
            public const int MaxPricePerMonth = 20000;

        }

        public class Category
        {
            //Name
            public const int NameMaxLength = 50;
        }

        public class Agent
        {
            //Phone number
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;
        }

        public class User
        {
            //First name
            public const int UserFirstNameMaxLength = 12;
            public const int UserFirstNameMinLength = 1;

            //Last name
            public const int UserLastNameMaxLength = 15;
            public const int UserLastNameMinLength = 3;
        }
    }
}