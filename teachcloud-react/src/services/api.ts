import type { Teacher, Student } from "../types/user"

const API_BASE_URL = import.meta.env.VITE_API_URL || "https://localhost:7000/api"

class ApiService {
  private getAuthHeaders() {
    const token = localStorage.getItem("authToken")
    return {
      "Content-Type": "application/json",
      ...(token && { Authorization: `Bearer ${token}` }),
    }
  }

  // Teacher API calls
  async getAllTeachers(): Promise<Teacher[]> {
    const response = await fetch(`${API_BASE_URL}/teacher`, {
      headers: this.getAuthHeaders(),
    })

    if (!response.ok) {
      throw new Error("Failed to fetch teachers")
    }

    return response.json()
  }

  async getTeacherById(id: number): Promise<Teacher> {
    const response = await fetch(`${API_BASE_URL}/teacher/${id}`, {
      headers: this.getAuthHeaders(),
    })

    if (!response.ok) {
      throw new Error("Failed to fetch teacher")
    }

    return response.json()
  }

  async createTeacher(teacher: Omit<Teacher, "id">): Promise<Teacher> {
    const response = await fetch(`${API_BASE_URL}/teacher`, {
      method: "POST",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(teacher),
    })

    if (!response.ok) {
      throw new Error("Failed to create teacher")
    }

    return response.json()
  }

  // Student API calls
  async getAllStudents(): Promise<Student[]> {
    const response = await fetch(`${API_BASE_URL}/student`, {
      headers: this.getAuthHeaders(),
    })

    if (!response.ok) {
      throw new Error("Failed to fetch students")
    }

    return response.json()
  }

  async getStudentById(id: number): Promise<Student> {
    const response = await fetch(`${API_BASE_URL}/student/${id}`, {
      headers: this.getAuthHeaders(),
    })

    if (!response.ok) {
      throw new Error("Failed to fetch student")
    }

    return response.json()
  }

  async createStudent(student: Omit<Student, "id">): Promise<Student> {
    const response = await fetch(`${API_BASE_URL}/student`, {
      method: "POST",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(student),
    })

    if (!response.ok) {
      throw new Error("Failed to create student")
    }

    return response.json()
  }
}

export const apiService = new ApiService()
