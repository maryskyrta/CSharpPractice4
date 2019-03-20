using System;

namespace CSharpPractice4.Models
{
    internal class Person
    {
        private static readonly string[] WesternSigns = { "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private static readonly string[] ChineseSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };


        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private readonly string _isBirthdayToday;
        private readonly string _isAdult;
        private readonly string _westernSign;
        private readonly string _chineseSign; 

        #endregion

        #region Properties

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Surname
        {
            set { _surname = value;}
            get { return _surname; }
        }

        public string Email
        {
            set { _email = value;}
            get { return _email; }
        }

        public DateTime Birthday
        {
            set { _birthday = value;}
            get { return _birthday; }
        }

        public string IsAdult
        {

            get
            {
                return _isAdult;
            }
        }

        public string IsBirthdayToday
        {
            get
            {
                return _isBirthdayToday;
            }
        }

        public string WesternSign
        {
            get
            {
                return _westernSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }





        #endregion

        #region Constructors

        internal Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
            _isAdult = SetIsAdult();
            _isBirthdayToday = SetIsBirthday();
            _chineseSign = SetChineseSign();
            _westernSign = SetWesternSign();
        }


        #endregion


        #region Helping setters
       

        private string SetWesternSign()
        {
        int day = _birthday.Day;
        int month = _birthday.Month;
            if (month == 1)
        return day< 20 ? WesternSigns[WesternSigns.Length - 1] : WesternSigns[month - 1];
        if (month == 2)
        return day< 19 ? WesternSigns[month - 2] : WesternSigns[month - 1];
        if (month > 2 && month< 7)
        return day< 21 ? WesternSigns[month - 2] : WesternSigns[month - 1];
        if(month>6&&month<11)
        return day< 23 ? WesternSigns[month - 2] : WesternSigns[month - 1];
        return day< 22 ? WesternSigns[month - 2] : WesternSigns[month - 1];
        }

        private string SetChineseSign()
        {
            return ChineseSigns[_birthday.Year % 12];
        }

        private string SetIsAdult()
        {
            if (((DateTime.Today.Year - _birthday.Year) > 18) ||
                (((DateTime.Today.Year - _birthday.Year) == 18) && (DateTime.Today.DayOfYear >= _birthday.DayOfYear)))
                return "Adult";
            return "Not adult";
        }

        private string SetIsBirthday()
        {
            if (DateTime.Today.Month == _birthday.Month && DateTime.Today.Day == _birthday.Day)
                return "Today";
            return "Not today";
        }

        #endregion
    }
}
