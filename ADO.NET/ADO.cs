    public class ADORepository<T> where T : BaseEntity
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public async Task Create(T entity)
        {
        string sqlExpression;
            var type = typeof(T);
            var name = type.GetProperty("Name");
            var password = type.GetProperty("Password");
            sqlExpression = $"insert into Users (Name, Password) values ('{name.GetValue(entity)}', '{password.GetValue(entity)}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              await connection.OpenAsync();
              SqlCommand command = new SqlCommand(sqlExpression, connection);
              command.ExecuteNonQuery();
            }
        }

        public async Task Delete(int id)
        {
            string sqlExpression = $"delete from Users where Id = {id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public async Task<T> Read(int id)
        {
            int userId = 0;
            string sqlExpression = $"select * from Users where id = {id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                       userId = (int)reader.GetValue(0);
                    }
                }
                else
                    return null;
                reader.Close();
            }

            User user = new User { Id = userId };
            return user as T;
        }


        public async Task Update(T entity)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            string commandText = "";
            foreach(var property in properties)
            {
                try
                {
                    var i = property.GetValue(entity);
                    if (i == null)
                        continue;
                    commandText += property.Name + " = " + property.GetValue(entity) + ", ";
                }catch(Exception e)
                {

                }
            }
            string sqlExpression = $"update Users set {commandText} where Id = {entity.Id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}