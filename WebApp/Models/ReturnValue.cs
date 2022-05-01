namespace WebApplication3.Models
{
    public class ReturnValue
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ReturnValue<T> : ReturnValue where T : class
    {
        public T Data { get; set; } 
    }

}
