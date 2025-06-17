import type React from "react"
import { Navigate } from "react-router-dom"
import { authService } from "../services/auth"

interface ProtectedRouteProps {
  children: React.ReactNode
}

export default function ProtectedRoute({ children }: ProtectedRouteProps) {
  const isAuthenticated = authService.isAuthenticated()

  if (!isAuthenticated) {
    // אם המשתמש לא מחובר, הפנה אותו למסך התחברות
    return <Navigate to="/login" replace />
  }

  return <>{children}</>
}
