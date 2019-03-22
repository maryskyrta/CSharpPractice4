using System;

namespace CSharpPractice4.Tools.Exceptions
{
    internal class PersonNotBornException : Exception
    {
        public PersonNotBornException(DateTime date) : base($"Entered date of birth {date.ToShortDateString()} is in the future.")
        {

        }
    }
}
