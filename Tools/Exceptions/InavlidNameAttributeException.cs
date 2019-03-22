using System;

namespace CSharpPractice4.Tools.Exceptions
{
    internal class InvalidNameAttributeException : Exception
    {
        public InvalidNameAttributeException(string nameAttribute) : base($"Invalid characters in {nameAttribute}")
        {

        }
    }
}
