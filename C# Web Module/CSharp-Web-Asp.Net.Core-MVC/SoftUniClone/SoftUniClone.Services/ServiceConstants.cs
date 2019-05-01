namespace SoftUniClone.Services
{
    public static class ServiceConstants
    {
        public const string PdfCertificateFormat = @"
            <h1 style=""text-align: center;"">Certificate</h1>
            <h2 style=""text-align: center;"">{0} Course</h2>
            <h3 style=""text-align: center;"">{3} - Grade: {4}</h3>
            <br />
            <h4 style=""text-align: center;""><em>From {1} - To {2}</em><h4>
            <h4 style=""text-align: center;""><em>Lecturer: {5}<em></h4>
            <h4 style=""text-align: center;"">{6}</h4>";
    }
}