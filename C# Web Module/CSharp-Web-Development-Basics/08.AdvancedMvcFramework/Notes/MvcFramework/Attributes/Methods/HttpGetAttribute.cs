namespace MvcFramework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        private const string CorrectMethodType = "get";

        public override bool IsValid(string requestMethod)
            => string.Compare(CorrectMethodType, requestMethod, true) == 0 ? true : false;
    }
}
