﻿namespace SistemaCuentas.Application.Dtos
{
    public record RefreshTokenDto(
        string Token,
        string UserId,
        DateTime ExpiresAt
        );
}
