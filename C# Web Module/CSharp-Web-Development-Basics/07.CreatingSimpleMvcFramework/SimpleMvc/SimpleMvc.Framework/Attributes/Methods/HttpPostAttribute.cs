namespace SimpleMvc.Framework.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private const string CorrectMethodType = "post";

        public override bool IsValid(string requestMethod)
            => string.Compare(CorrectMethodType, requestMethod, true) == 0 ? true : false;
    }
}
