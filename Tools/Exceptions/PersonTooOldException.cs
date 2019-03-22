using System;

namespace CSharpPractice4.Tools.Exceptions
{
    internal class PersonTooOldException : Exception
    {
        public PersonTooOldException(DateTime date) : base($"Entered date of birth {date.ToShortDateString()} was too long ago.")
        {

        }
    }
}
