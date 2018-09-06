using System;


namespace TodoDomain.Exceptions
{
    public class TodoNotFoundException : ApplicationException
    {
        public TodoNotFoundException(string id) : base($"Todo with id '{id}' was not found.") 
        { }
    }
}