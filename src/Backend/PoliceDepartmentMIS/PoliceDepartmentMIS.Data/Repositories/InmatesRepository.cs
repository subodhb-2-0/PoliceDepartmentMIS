using MySql.Data.MySqlClient;
using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Data.Config;
using System.Data;

namespace PoliceDepartmentMIS.Data.Repositories
{
    public class InmatesRepository : IInmatesRepository
    {
        private readonly ConnectionString _connectionString;

        public InmatesRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Response<bool>> DeleteInmatesAsync(int Id, int userId)
        {
            Response<bool> response = new();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpDeleteInmate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Id", Id);
                    cmd.Parameters.AddWithValue("@p_UpdatedBy", userId);
                    var messageParam = new MySqlParameter("@p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);
                    await cmd.ExecuteNonQueryAsync();
                    response.Message = messageParam.Value.ToString();
                    if (response.Message == "Inmate successfully deleted")
                    {
                        response.IsSuccess = true;
                    }
                }
            }
            return response;
        }

        public async Task<InmateResponseDto> GetInmateByIdAsync(int Id)
        {
            InmateResponseDto inmateResponse = null;

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetInmateById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Id", Id);
                    var messageParam = new MySqlParameter("@p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);
                    await cmd.ExecuteNonQueryAsync();
                    string message = messageParam.Value.ToString();

                    if (message == "Inmate found successfully")
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                inmateResponse = new InmateResponseDto
                                {
                                    Id = reader.GetInt32("Id"),
                                    FirstName = reader.GetString("FirstName"),
                                    MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? null : reader.GetString("MiddleName"),
                                    LastName = reader.GetString("LastName"),
                                    DOB = reader.GetDateTime("DOB"),
                                    CitizenshipNumber = reader.GetString("CitizenshipNumber")
                                };
                            }
                        }
                    }
                    else
                    {
                        inmateResponse = null;
                    }
                }
            }

            return inmateResponse;
        }

        public async Task<GetAllList<InmateGetAllResponseDto>> GetInmatessAsync(FilterDto filterDto)
        {
            var inmatesList = new GetAllList<InmateGetAllResponseDto>
            {
                DataList = new List<InmateGetAllResponseDto>()
            };

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetFilteredInmates", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@p_SearchByColumn", filterDto.SearchByColumn ?? string.Empty);
                    cmd.Parameters.AddWithValue("@p_SearchValue", filterDto.SearchValue ?? string.Empty);
                    cmd.Parameters.AddWithValue("@p_OrderByColumn", filterDto.OrderByColumn ?? "Id");
                    cmd.Parameters.AddWithValue("@p_OrderBy", filterDto.OrderBy ?? "ASC");
                    cmd.Parameters.AddWithValue("@p_PageSize", filterDto.PageSize);
                    cmd.Parameters.AddWithValue("@p_PageNumber", filterDto.PageNumber);

                    // Output parameter for total count
                    var totalCountParam = new MySqlParameter("@p_TotalRecords", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(totalCountParam);

                    // Execute the stored procedure and read multiple result sets
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        // Read the paginated data (first result set)
                        while (await reader.ReadAsync())
                        {
                            inmatesList.DataList.Add(new InmateGetAllResponseDto
                            {
                                Id = reader.GetInt32("Id"),
                                InmateName = reader.IsDBNull(reader.GetOrdinal("InmateName")) ? null : reader.GetString("InmateName"),
                                DOB = reader.GetDateTime("DOB").ToString("dd, MMMM yyyy"),
                                CitizenshipNumber = reader.GetString("CitizenshipNumber")
                            });
                        }

                        // Move to the next result set (the total count of records)
                        if (await reader.NextResultAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                inmatesList.TotalCount = reader.GetInt32(0);
                            }
                        }
                    }
                    inmatesList.TotalCount = Convert.ToInt32(totalCountParam.Value);
                }
            }

            return inmatesList;
        }

        public async Task<Response<int>> InsertInmatesAsync(InmateRequestDto inmate, int userId)
        {
            Response<int> response = new();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpInsertInmate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_FirstName", inmate.FirstName);
                    cmd.Parameters.AddWithValue("@p_MiddleName", inmate.MiddleName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_LastName", inmate.LastName);
                    cmd.Parameters.AddWithValue("@p_DOB", inmate.DOB);
                    cmd.Parameters.AddWithValue("@p_CitizenshipNumber", inmate.CitizenshipNumber);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", userId);

                    var inmateIdParam = new MySqlParameter("@p_InmateId", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(inmateIdParam);

                    var messageParam = new MySqlParameter("@p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    await cmd.ExecuteNonQueryAsync();
                    response.Data = Convert.ToInt32(inmateIdParam.Value);
                    if(response.Data > 0)
                    {
                        response.IsSuccess = true;
                    }
                    response.Message = messageParam.Value.ToString();
                }
            }

            return response;
        }

        public async Task<Response<bool>> UpdateInmatesAsync(InmateRequestDto inmate, int Id, int userId)
        {
            Response<bool> response = new();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpUpdateInmate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Id", Id);
                    cmd.Parameters.AddWithValue("@p_FirstName", inmate.FirstName);
                    cmd.Parameters.AddWithValue("@p_MiddleName", inmate.MiddleName ?? (object)DBNull.Value); // Handle nullable fields
                    cmd.Parameters.AddWithValue("@p_LastName", inmate.LastName);
                    cmd.Parameters.AddWithValue("@p_DOB", inmate.DOB);
                    cmd.Parameters.AddWithValue("@p_CitizenshipNumber", inmate.CitizenshipNumber);
                    cmd.Parameters.AddWithValue("@p_UpdatedBy", userId);
                    var messageParam = new MySqlParameter("@p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    var successParam = new MySqlParameter("@p_Success", MySqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(successParam);

                    await cmd.ExecuteNonQueryAsync();
                    response.Message = messageParam.Value.ToString();
                    response.IsSuccess = Convert.ToBoolean(successParam.Value);
                    response.Data = Convert.ToBoolean(successParam.Value);
                }
            }
            return response;
        }
    }
}