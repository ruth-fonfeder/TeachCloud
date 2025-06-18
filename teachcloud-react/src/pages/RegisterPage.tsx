"use client"

import type React from "react"

import { useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import { Button } from "../components/ui/button"
import { Input } from "../components/ui/input"
import { Label } from "../components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "../components/ui/card"
import { Alert, AlertDescription } from "../components/ui/alert"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "../components/ui/select"
import { Loader2 } from "lucide-react"
import type { UserType } from "../types/user"
import { authService } from "../services/auth"

export default function RegisterPage() {
  const [formData, setFormData] = useState({
    fullName: "",
    email: "",
    password: "",
    confirmPassword: "",
    userType: "" as UserType | "",
  })
  const [isLoading, setIsLoading] = useState(false)
  const [error, setError] = useState("")
  const navigate = useNavigate()

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setIsLoading(true)
    setError("")

    // בדיקות ולידציה
    if (formData.password !== formData.confirmPassword) {
      setError("הסיסמאות אינן תואמות")
      setIsLoading(false)
      return
    }

    if (!formData.userType) {
      setError("יש לבחור סוג משתמש")
      setIsLoading(false)
      return
    }

    try {
      await authService.register({
        fullName: formData.fullName,
        email: formData.email,
        password: formData.password,
        userType: formData.userType as UserType,
      })

      // לאחר הרשמה מצליחה, נווט למסך התחברות
      navigate("/login?message=registration-success")
    } catch (err) {
      setError("שגיאה בהרשמה. אנא נסה שוב.")
    } finally {
      setIsLoading(false)
    }
  }

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }))
  }

  const handleUserTypeChange = (value: UserType) => {
    setFormData((prev) => ({
      ...prev,
      userType: value,
    }))
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100 flex items-center justify-center p-4">
      <Card className="w-full max-w-md">
        <CardHeader className="text-center">
          <CardTitle className="text-2xl font-bold text-gray-900">הרשמה</CardTitle>
          <CardDescription className="text-gray-600">צור חשבון חדש במערכת</CardDescription>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="space-y-2">
              <Label htmlFor="fullName">שם מלא</Label>
              <Input
                id="fullName"
                name="fullName"
                type="text"
                value={formData.fullName}
                onChange={handleChange}
                required
                disabled={isLoading}
                className="text-right"
                dir="rtl"
              />
            </div>

            {/* <div className="space-y-2">
              <Label htmlFor="username">שם משתמש</Label>
              <Input
                id="username"
                name="username"
                type="text"
                value={formData.username}
                onChange={handleChange}
                required
                disabled={isLoading}
                className="text-right"
                dir="rtl"
              />
            </div> */}

            <div className="space-y-2">
              <Label htmlFor="email">אימייל</Label>
              <Input
                id="email"
                name="email"
                type="email"
                value={formData.email}
                onChange={handleChange}
                required
                disabled={isLoading}
                className="text-right"
                dir="rtl"
                // autoComplete="email"
                autoComplete="off"

              />
            </div>


            <div className="space-y-2">
              <Label htmlFor="password">סיסמה</Label>
              <Input
                id="password"
                name="password"
                type="password"
                value={formData.password}
                onChange={handleChange}
                required
                disabled={isLoading}
                className="text-right"
                dir="rtl"
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="confirmPassword">אימות סיסמה</Label>
              <Input
                id="confirmPassword"
                name="confirmPassword"
                type="password"
                value={formData.confirmPassword}
                onChange={handleChange}
                required
                disabled={isLoading}
                className="text-right"
                dir="rtl"
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="userType">סוג משתמש</Label>
              <Select onValueChange={handleUserTypeChange} disabled={isLoading}>
                <SelectTrigger className="text-right" dir="rtl">
                  <SelectValue placeholder="בחר סוג משתמש" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="teacher">מורה</SelectItem>
                  <SelectItem value="student">תלמידה</SelectItem>
                </SelectContent>
              </Select>
            </div>

            {error && (
              <Alert variant="destructive">
                <AlertDescription>{error}</AlertDescription>
              </Alert>
            )}

            <Button type="submit" className="w-full" disabled={isLoading}>
              {isLoading ? (
                <>
                  <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                  נרשם...
                </>
              ) : (
                "הירשם"
              )}
            </Button>
          </form>

          <div className="mt-6 text-center">
            <p className="text-sm text-gray-600">
              כבר יש לך חשבון?{" "}
              <Link to="/login" className="text-blue-600 hover:underline">
                התחבר כאן
              </Link>
            </p>
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
