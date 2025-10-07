using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;


namespace SistemaCuentas.RefrehToken.Data
{
    public class AccessData(
        string connectionString
        )
    {
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public async Task<RefreshTokenModel?> GetRefreshTokenByToken(string refreshToken)
        {
            string query = $"Select * from RefreshToken rt Where rt.Token = @Token";
            RefreshTokenModel? refreshTokenModel = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Token", refreshToken);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    refreshTokenModel = new RefreshTokenModel()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Token = reader.GetString(reader.GetOrdinal("Token")),
                        UserId = reader.GetString(reader.GetOrdinal("UserId")),
                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreateAt")),
                        ExpiresAt = reader.GetDateTime(reader.GetOrdinal("ExpiresAt")),
                        IsRevoked = reader.GetBoolean(reader.GetOrdinal("IsRevoked"))
                    };
                }
            }

            return refreshTokenModel;
        }

        public async Task<string> AddRefreshTokenAsync(string userId)
        {
            string query = "INSERT INTO RefreshToken (Token, IsRevoked, UserId) VALUES (@Token,@IsRevoked,@UserId)";
            var refreshTokenString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Token", refreshTokenString);
                command.Parameters.AddWithValue("@IsRevoked", 0);
                command.Parameters.AddWithValue("@UserId", userId);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }

            return refreshTokenString;
        }

        public async Task RevokeRefreshTokenAsync(string token)
        {
            string query = "UPDATE RefreshToken SET IsRevoked = @IsRevoked WHERE Token = @Token";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IsRevoked", 1);
                command.Parameters.AddWithValue("@Token", token);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
