using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using TrackYourWorkout.Configurations;

namespace TrackYourWorkout.Context
{
    public class DapperContext
    {
        private readonly DBSettingsConfiguration _dbSettings;

        public DapperContext(IOptions<DBSettingsConfiguration> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_dbSettings.devConnection);
        }
    }
}
