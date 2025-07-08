export type Course = {
    id: number
    name: string
    description?: string
    teacherId: number
    teacherName: string | null
    studyGroups: any[]
  }
  
  export type CreateCoursePayload = {
    name: string
    studyGroups: { name: string }[]
  }