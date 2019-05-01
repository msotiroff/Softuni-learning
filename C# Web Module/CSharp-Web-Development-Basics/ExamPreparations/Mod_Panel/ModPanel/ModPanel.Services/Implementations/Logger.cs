namespace ModPanel.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using ModPanel.Data;
    using ModPanel.Models;
    using ModPanel.Models.Common;
    using ModPanel.Services.Models.Log;
    using System.Collections.Generic;
    using System.Linq;

    public class Logger : DataAccessService, ILogger
    {
        public Logger(ModPanelDbContext db) 
            : base(db)
        {
        }

        public IEnumerable<LogServiceModel> All()
        {
            return this.db
                .AdminLogs
                .OrderByDescending(l => l.Id)
                .ProjectTo<LogServiceModel>()
                .ToArray();
        }

        public void Create(int adminId, string activity, LogType logType)
        {
            var log = new AdminLog
            {
                AdminId = adminId,
                Activity = activity,
                LogType = logType
            };

            if (this.ValidateModelState(log))
            {
                this.db.AdminLogs.Add(log);
                this.db.SaveChanges();
            }
        }
    }
}
