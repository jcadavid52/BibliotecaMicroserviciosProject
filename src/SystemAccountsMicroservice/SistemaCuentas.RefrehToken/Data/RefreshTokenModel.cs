﻿namespace SistemaCuentas.RefrehToken.Data
{
    public class RefreshTokenModel
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public bool IsRevoked { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
