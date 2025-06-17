import Link from "next/link"
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"

export default function HomePage() {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100 flex items-center justify-center p-4">
      <Card className="w-full max-w-md">
        <CardHeader className="text-center">
          <CardTitle className="text-2xl font-bold text-gray-900">כיתה חכמה</CardTitle>
          <CardDescription className="text-gray-600">ניהול קורסים ושיעורים</CardDescription>
        </CardHeader>
        <CardContent className="space-y-4">
          <Link href="/login" className="block">
            <Button className="w-full" size="lg">
              התחברות
            </Button>
          </Link>
          <Link href="/register" className="block">
            <Button variant="outline" className="w-full" size="lg">
              הרשמה
            </Button>
          </Link>
        </CardContent>
      </Card>
    </div>
  )
}
