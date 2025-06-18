export type UserType = "teacher" | "student"

export interface User {
  id: number
  fullName: string
  username: string
  userType: UserType
}

export interface Teacher {
  id: number
  fullName: string
  courses: CourseSimple[]
}

export interface Student {
  id: number
  fullName: string
  studyGroups: GroupSimple[]
}

export interface CourseSimple {
  id: number
  name: string
}

export interface GroupSimple {
  id: number
  name: string
}

export interface RegisterRequest {
  fullName: string
  email: string
  password: string
  userType: UserType
}

export interface LoginRequest {
  username: string
  password: string
}

export interface AuthResponse {
  user: User
  token: string
}
