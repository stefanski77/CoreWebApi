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
                Host = "localhost",
                Database = "stefan"
            };
        }

        public Value ReadValue(
            int id)
        {
            using (var connection = CreateOpenConnection())
            {
				var command = new NpgsqlCommand(
				"select * from value v where v.id = :id",
				connection);
				command.Parameters.AddWithValue("id", id);
				var reader = command.ExecuteReader();

				if (!reader.HasRows)
					return null;

                reader.Read();

				return new Value
				{
					Id = reader.GetInt16(0),
					Name = reader.GetString(1)
                };
            }
        }

        private NpgsqlConnection CreateOpenConnection()
        {
            var connection = new NpgsqlConnection(connectionStringBuilder.ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
