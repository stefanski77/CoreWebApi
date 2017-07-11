using Npgsql;

namespace CoreWebApi
{
    public class PostgresAdapter
    {
        private readonly NpgsqlConnectionStringBuilder connectionStringBuilder;

        public PostgresAdapter()
        {
            connectionStringBuilder = new NpgsqlConnectionStringBuilder()
            {
                Host = "PostgreSQL 9.6",
                Database = "Stefan"
            };
        }
    }
}
