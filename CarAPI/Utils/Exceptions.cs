namespace CarAPI.Utils
{
    public abstract class Exceptions : Exception
    {
        protected Exceptions(string message) : base(message) 
        { 
        
        }
    }
    public class BadRequstException : Exception 
    {
        public BadRequstException() : base("Bad request")
        {
        }
    }
    public class EmptyFuelException : Exception
    {
        public EmptyFuelException() : base("Fuel cannot be empty")
        {
        }
    }
    public class EmptyBrandException : Exception
    {
        public EmptyBrandException() : base("Brand cannot be empty")
        {
        }
    }
    public class EmptyModelException : Exception
    {
        public EmptyModelException() : base("Model cannot be empty")
        {
        }
    }
}
