// src/api/authApi.js

// const API_BASE = "https://localhost:7166/api"; // שים כאן את כתובת ה־API האמיתית שלך

// export async function register(userData) {
//   const res = await fetch(`${API_BASE}/auth/register`, {
//     method: "POST",
//     headers: { "Content-Type": "application/json" },
//     body: JSON.stringify(userData),
//   });
//   if (!res.ok) throw new Error("Registration failed");
//   return res.json();
// }

// export async function login(credentials) {
//     const res = await fetch(`${API_BASE}/auth/login`, {
//       method: "POST",
//       headers: { "Content-Type": "application/json" },
//       body: JSON.stringify(credentials),
//     });
//     if (!res.ok) throw new Error("Login failed");
//     return res.json();
//   }
  
import { RegisterDto, LoginDto } from "../types/auth";

const API_BASE = "https://localhost:7166/api";

export async function register(userData: RegisterDto) {
  const res = await fetch(`${API_BASE}/auth/register`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(userData),
  });
  if (!res.ok) throw new Error("Registration failed");
  return res.json();
}

export async function login(credentials: LoginDto) {
  const res = await fetch(`${API_BASE}/auth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(credentials),
  });
  if (!res.ok) throw new Error("Login failed");
  return res.json();
}
