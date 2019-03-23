using System;
using System.Text.RegularExpressions;
using System.Windows;
using CSharpPractice4.Tools.Exceptions;
using CSharpPractice4.Tools.Managers;

namespace CSharpPractice4.Models
{
    [Serializable]
    internal class Person
    {
        private static readonly string[] WesternSigns = { "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private static readonly string[] ChineseSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };


        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private readonly DateTime _birthday;
        private readonly string _isBirthdayToday;
        private readonly string _isAdult;
        private readonly string _westernSign;
        private readonly string _chineseSign; 

        #endregion

        #region Properties

        public string Name
        {
            set
            {
                try
                {
                    ValidateNameAttribute(value);
                }
                catch(InvalidNameAttributeException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                _name = value;
                StationManager.DataStorage.SaveChanges();
            }
            get { return _name; }
        }

        public string Surname
        {
            set
            {
                try
                {
                    ValidateNameAttribute(value);
                }
                catch(InvalidNameAttributeException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                _surname = value;
                StationManager.DataStorage.SaveChanges();
            }
            get { return _surname; }
        }

        public string Email
        {
            set
            {
                try
                {
                    ValidateEmail(value);
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                _email = value;
                StationManager.DataStorage.SaveChanges();
            }
            get { return _email; }
        }

        public string Birthday
        {
            get { return _birthday.ToShortDateString(); }
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
            Name = name;
            Surname = surname;
            Email = email;
            ValidateDate(birthday);
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

        #region Validation

       

        private static void ValidateNameAttribute(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new InvalidNameAttributeException(name);

        }

        private static void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase))
                throw new InvalidEmailException(email);
        }

        private static void ValidateDate(DateTime birthday)
        {
            if (birthday > DateTime.Today)
                throw new PersonNotBornException(birthday);
            if (birthday.Year < (DateTime.Today.Year - 135))
                throw new PersonTooOldException(birthday);
        }

        #endregion
    }
}
