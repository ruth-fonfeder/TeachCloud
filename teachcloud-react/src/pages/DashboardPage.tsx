"use client"

import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "../components/ui/card"
import { Button } from "../components/ui/button"
import { LogOut, BookOpen, Users } from "lucide-react"
import { authService } from "../services/auth"

export default function DashboardPage() {
  const [user, setUser] = useState<{ name: string; type: string } | null>(null)
  const navigate = useNavigate()

  useEffect(() => {
    // טעינת פרטי המשתמש מה-localStorage
    const currentUser = authService.getCurrentUser()
    if (currentUser) {
      setUser({
        name: currentUser.fullName,
        type: currentUser.userType,
      })
    }
  }, [])

  const handleLogout = () => {
    authService.logout()
    navigate("/")
  }

  if (!user) {
    return <div>טוען...</div>
  }

  return (
    <div className="min-h-screen bg-gray-50 p-4">
      <div className="max-w-6xl mx-auto">
        <header className="flex justify-between items-center mb-8">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">כיתה חכמה</h1>
            <p className="text-gray-600">שלום {user.name}</p>
          </div>
          <Button variant="outline" onClick={handleLogout}>
            <LogOut className="mr-2 h-4 w-4" />
            התנתק
          </Button>
        </header>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          <Card>
            <CardHeader>
              <CardTitle className="flex items-center">
                <BookOpen className="mr-2 h-5 w-5" />
                הקורסים שלי
              </CardTitle>
              <CardDescription>נהל את הקורסים והשיעורים שלך</CardDescription>
            </CardHeader>
            <CardContent>
              <Button className="w-full">צפה בקורסים</Button>
            </CardContent>
          </Card>

          {user.type === "teacher" && (
            <Card>
              <CardHeader>
                <CardTitle className="flex items-center">
                  <Users className="mr-2 h-5 w-5" />
                  ניהול תלמידות
                </CardTitle>
                <CardDescription>נהל את התלמידות והקבוצות</CardDescription>
              </CardHeader>
              <CardContent>
                <Button className="w-full">צפה בתלמידות</Button>
              </CardContent>
            </Card>
          )}

          <Card>
            <CardHeader>
              <CardTitle>הגדרות</CardTitle>
              <CardDescription>נהל את הגדרות החשבון שלך</CardDescription>
            </CardHeader>
            <CardContent>
              <Button variant="outline" className="w-full">
                הגדרות חשבון
              </Button>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}
