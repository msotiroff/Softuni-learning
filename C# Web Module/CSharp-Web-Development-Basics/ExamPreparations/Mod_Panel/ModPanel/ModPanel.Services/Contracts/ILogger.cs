namespace ModPanel.Services.Contracts
{
    using ModPanel.Models.Common;
    using ModPanel.Services.Models.Log;
    using System.Collections.Generic;

    public interface ILogger
    {
        IEnumerable<LogServiceModel> All();

        void Create(int adminId, string activity, LogType logType);
    }
}
