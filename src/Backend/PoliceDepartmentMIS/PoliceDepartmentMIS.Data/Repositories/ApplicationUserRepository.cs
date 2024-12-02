using MySql.Data.MySqlClient;
using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Data.Config;
using System.Data;

namespace PoliceDepartmentMIS.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ConnectionString _connectionString;

        public ApplicationUserRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<bool> DeleteApplicationUserAsync(int applicationuserId, int updatedBy)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ApplicationUser>> GetApplicationUserByIdAsync(int applicationuserId)
        {
            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetApplicationUserById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_Id", applicationuserId);
                    var messageParam = new MySqlParameter("p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    // Execute the stored procedure
                    var reader = await cmd.ExecuteReaderAsync();

                    ApplicationUser user = null;

                    // Read the result set returned by the procedure
                    if (await reader.ReadAsync())
                    {
                        user = new ApplicationUser
                        {
                            Id = reader.GetInt32("Id"),
                            FirstName = reader.GetString("FirstName"),
                            MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? null : reader.GetString("MiddleName"),
                            LastName = reader.GetString("LastName"),
                            UserName = reader.GetString("UserName"),
                            Email = reader.GetString("Email"),
                            Phone = reader.GetString("Phone")
                        };
                    }

                    // Close the reader
                    await reader.CloseAsync();

                    // Retrieve the message
                    var message = messageParam.Value.ToString();

                    if (string.IsNullOrEmpty(message) || message.Contains("No such user"))
                    {
                        // Handle the case where no user was found or user is deleted
                        return null;  // Or throw an exception if needed
                    }
                    Response<ApplicationUser> response = new();
                    response.Message = message;
                    response.IsSuccess = true;
                    response.Data = user;
                    return response;
                }
            }
        }

        public Task<List<ApplicationUser>> GetApplicationUsersAsync(FilterDto filterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertApplicationUserAsync(UserRegisterDto dto)
        {
            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpInsertApplicationUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_FirstName", dto.FirstName);
                    cmd.Parameters.AddWithValue("p_MiddleName", dto.MiddleName);
                    cmd.Parameters.AddWithValue("p_LastName", dto.LastName);
                    cmd.Parameters.AddWithValue("p_UserName", dto.UserName);
                    cmd.Parameters.AddWithValue("p_Email", dto.Email);
                    cmd.Parameters.AddWithValue("p_Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("p_Password", dto.Password);

                    var newIdParam = new MySqlParameter("p_NewId", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newIdParam);

                    await cmd.ExecuteNonQueryAsync();
                    var newUserId = Convert.ToInt32(newIdParam.Value);
                    return newUserId;
                }
            }
        }

        public Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationuser)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> ValidateUserAsync(UserLoginDto dto)
        {
            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpValidateUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_UserName", dto.UserName);

                    var validatedParam = new MySqlParameter("p_Validated", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(validatedParam);

                    var storedPassword = new MySqlParameter("p_StoredPassword", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(storedPassword);

                    await cmd.ExecuteNonQueryAsync();

                    var validated = Convert.ToInt32(validatedParam.Value);
                    var PassHash = storedPassword.Value.ToString();

                    Response<int> response = new Response<int>();
                    response.Message = PassHash;
                    response.IsSuccess = validated > 0;
                    response.Data = validated;

                    return response;
                }
            }
        }
    }
}