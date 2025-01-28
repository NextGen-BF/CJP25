import { apiURL, request } from "./shared";
import { AuthToken } from "../models/user";

export async function Login(email: string, password: string): Promise<AuthToken> {
    return await request<AuthToken>(`${apiURL}/account/login`, {
        method: "POST",
        body: JSON.stringify({email, password})
    });
}