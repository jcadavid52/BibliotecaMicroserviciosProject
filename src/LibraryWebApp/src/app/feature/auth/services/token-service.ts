import { Injectable } from "@angular/core";
import { jwtDecode } from "jwt-decode";
import { JwtPayload } from "../models/decode-rol-token-model";

@Injectable(
    {
        providedIn: 'root'
    }
)
export class TokenService {

    private accessToken: string | null = null;
    private refreshToken: string | null = null;

    public setAuthToken(token: string) {
        this.accessToken = token;
        localStorage.setItem('auth_token', token);
    }

    public setRefreshToken(token: string) {
        this.refreshToken = token;
        localStorage.setItem('refresh_token', token);
    }

    public decodeRoleToken(): string[] {
        let token = this.accessToken ?? localStorage.getItem('auth_token') ?? '';
        try {
            const decoded = jwtDecode<JwtPayload & { [key: string]: any }>(token);
            const roles = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null;
            if (!roles) return [];
            if (Array.isArray(roles)) return roles;
            return [roles];
        } catch (error) {

            console.error("Error decodificando token:", error);
            return [];
        }
    }

    public getAuthToken(): string {
    return this.accessToken ?? localStorage.getItem('auth_token') ?? '';
  }

    public isAuthenticated(): boolean {
        const token = this.getAuthToken();
        return !!token;
    }
}