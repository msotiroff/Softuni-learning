namespace BashSoft.App.SimpleJudge
{
    public interface IContentComparer
    {
        void CompareContent(string userOutputPath, string expectedOutputPath);
    }
}
