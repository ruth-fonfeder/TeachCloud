import type { RegisterRequest, LoginRequest, AuthResponse, User } from "../types/user"

const API_BASE_URL = import.meta.env.VITE_API_URL || "https://localhost:7166/api"

class AuthService {
  async register(data: RegisterRequest): Promise<AuthResponse> {
    try {
      // בהתאם לסוג המשתמש, שלח לendpoint המתאים
      const endpoint = data.userType === "teacher" ? "teacher" : "student"

      const response = await fetch(`${API_BASE_URL}/${endpoint}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          fullName: data.fullName,
          username: data.username,
          password: data.password,
        }),
      })

      if (!response.ok) {
        throw new Error("Registration failed")
      }

      const result = await response.json()
      return result
    } catch (error) {
      console.error("Registration error:", error)
      throw error
    }
  }

  async login(data: LoginRequest): Promise<AuthResponse> {
    try {
      // כאן תוכל להוסיף את endpoint ההתחברות שלך
      const response = await fetch(`${API_BASE_URL}/auth/login`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })

      if (!response.ok) {
        throw new Error("Login failed")
      }

      const result = await response.json()

      // שמור את הטוקן ב-localStorage
      if (result.token) {
        localStorage.setItem("authToken", result.token)
        localStorage.setItem("user", JSON.stringify(result.user))
      }

      return result
    } catch (error) {
      console.error("Login error:", error)
      throw error
    }
  }

  logout(): void {
    localStorage.removeItem("authToken")
    localStorage.removeItem("user")
  }

  getCurrentUser(): User | null {
    const userStr = localStorage.getItem("user")
    return userStr ? JSON.parse(userStr) : null
  }

  getToken(): string | null {
    return localStorage.getItem("authToken")
  }

  isAuthenticated(): boolean {
    return !!this.getToken()
  }
}

export const authService = new AuthService()
