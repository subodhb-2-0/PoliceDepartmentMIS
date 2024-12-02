using MySql.Data.MySqlClient;
using PoliceDepartmentMIS.Core.Dtos.Booking;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Data.Config;
using System.Data;

namespace PoliceDepartmentMIS.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ConnectionString _connectionString;

        public BookingRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Response<bool>> DeleteBookingAsync(int Id, int userId)
        {
            var response = new Response<bool>();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpDeleteBooking", connection))
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
                    if (response.Message == "Booking successfully deleted")
                    {
                        response.IsSuccess = true;
                    }
                }
            }

            return response;
        }

        public async Task<GetAllList<BookingGetAllResponseDto>> GetBookingByEmployeeId(int EmployeeId)
        {
            var bookingsList = new GetAllList<BookingGetAllResponseDto>
            {
                DataList = new List<BookingGetAllResponseDto>()
            };

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetBookingByEmployeeId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the input parameter
                    cmd.Parameters.AddWithValue("@p_EmployeeId", EmployeeId);

                    // Add the output parameter
                    var totalCountParam = new MySqlParameter("@p_TotalRecords", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(totalCountParam);

                    // Execute the command
                    await cmd.ExecuteNonQueryAsync();

                    // After executing the stored procedure, get the output parameter value
                    bookingsList.TotalCount = Convert.ToInt32(totalCountParam.Value);

                    // Retrieve data if needed using ExecuteReader or other methods
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            bookingsList.DataList.Add(new BookingGetAllResponseDto
                            {
                                Id = reader.GetInt32("Id"),
                                InmateId = reader.GetInt32("InmateId"),
                                InmateName = reader.GetString("InmateName"),
                                BookingLocation = reader.GetString("BookingLocation"),
                                FacilityName = reader.GetString("FacilityName"),
                                BookedDate = reader.GetDateTime("BookedDate").ToString("dd, MMMM yyyy"),
                                ReleasedDate = reader.IsDBNull(reader.GetOrdinal("ReleasedDate")) ? null : reader.GetDateTime("ReleasedDate").ToString("dd, MMMM yyyy"),
                                Charges = reader.GetString("Charges"),
                                ReleasedInformation = reader.IsDBNull(reader.GetOrdinal("ReleasedInformation")) ? null : reader.GetString("ReleasedInformation")
                            });
                        }
                    }
                }
            }

            return bookingsList;
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int Id)
        {
            BookingResponseDto bookingResponse = null;

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetBookingById", connection))
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

                    if (message == "Booking found successfully")
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                bookingResponse = new BookingResponseDto
                                {
                                    Id = reader.GetInt32("Id"),
                                    InmateId = reader.GetInt32("InmateId"),
                                    InmateName = reader.GetString("InmateName"),
                                    BookingLocation = reader.GetString("BookingLocation"),
                                    FacilityName = reader.GetString("FacilityName"),
                                    BookedDate = reader.GetDateTime("BookedDate"),
                                    ReleasedDate = reader.IsDBNull(reader.GetOrdinal("ReleasedDate")) ? null : reader.GetDateTime("ReleasedDate"),
                                    Charges = reader.GetString("Charges"),
                                    ReleasedInformation = reader.IsDBNull(reader.GetOrdinal("ReleasedInformation")) ? null : reader.GetString("ReleasedInformation")
                                };
                            }
                        }
                    }
                }
            }

            return bookingResponse;
        }


        public async Task<GetAllList<BookingGetAllResponseDto>> GetBookingsAsync(FilterDto filterDto)
        {
            var bookingsList = new GetAllList<BookingGetAllResponseDto>
            {
                DataList = new List<BookingGetAllResponseDto>()
            };

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpGetFilteredBookings", connection))
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

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            bookingsList.DataList.Add(new BookingGetAllResponseDto
                            {
                                Id = reader.GetInt32("Id"),
                                InmateId = reader.GetInt32("InmateId"),
                                InmateName = reader.GetString("InmateName"),
                                BookingLocation = reader.GetString("BookingLocation"),
                                FacilityName = reader.GetString("FacilityName"),
                                BookedDate = reader.GetDateTime("BookedDate").ToString("dd, MMMM yyyy"),
                                ReleasedDate = reader.IsDBNull(reader.GetOrdinal("ReleasedDate")) ? null : reader.GetDateTime("ReleasedDate").ToString("dd, MMMM yyyy"),
                                Charges = reader.GetString("Charges"),
                                ReleasedInformation = reader.IsDBNull(reader.GetOrdinal("ReleasedInformation")) ? null : reader.GetString("ReleasedInformation")
                            });
                        }

                        // Get total count of records
                        if (await reader.NextResultAsync() && await reader.ReadAsync())
                        {
                            bookingsList.TotalCount = reader.GetInt32(0);
                        }
                    }

                    bookingsList.TotalCount = Convert.ToInt32(totalCountParam.Value);
                }
            }

            return bookingsList;
        }


        public async Task<Response<int>> InsertBookingAsync(BookingRequestDto booking, int userId)
        {
            var response = new Response<int>();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpInsertBooking", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_InmateId", booking.InmateId);
                    cmd.Parameters.AddWithValue("@p_BookingLocation", booking.BookingLocation);
                    cmd.Parameters.AddWithValue("@p_FacilityName", booking.FacilityName);
                    cmd.Parameters.AddWithValue("@p_BookedDate", booking.BookedDate);
                    cmd.Parameters.AddWithValue("@p_ReleasedDate", booking.ReleasedDate);
                    cmd.Parameters.AddWithValue("@p_Charges", booking.Charges);
                    cmd.Parameters.AddWithValue("@p_ReleasedInformation", booking.ReleasedInformation);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", userId);

                    var bookingIdParam = new MySqlParameter("@p_BookingId", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(bookingIdParam);

                    var messageParam = new MySqlParameter("@p_Message", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    await cmd.ExecuteNonQueryAsync();

                    response.Data = Convert.ToInt32(bookingIdParam.Value);
                    if (response.Data > 0)
                    {
                        response.IsSuccess = true;
                    }
                    response.Message = messageParam.Value.ToString();
                }
            }

            return response;
        }


        public async Task<Response<bool>> UpdateBookingAsync(BookingRequestDto booking, int Id, int userId)
        {
            var response = new Response<bool>();

            using (var connection = new MySqlConnection(_connectionString.MySqlConnectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand("SpUpdateBooking", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_Id", Id);
                    cmd.Parameters.AddWithValue("@p_InmateId", booking.InmateId);
                    cmd.Parameters.AddWithValue("@p_BookingLocation", booking.BookingLocation);
                    cmd.Parameters.AddWithValue("@p_FacilityName", booking.FacilityName);
                    cmd.Parameters.AddWithValue("@p_BookedDate", booking.BookedDate);
                    cmd.Parameters.AddWithValue("@p_ReleasedDate", booking.ReleasedDate);
                    cmd.Parameters.AddWithValue("@p_Charges", booking.Charges);
                    cmd.Parameters.AddWithValue("@p_ReleasedInformation", booking.ReleasedInformation);
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