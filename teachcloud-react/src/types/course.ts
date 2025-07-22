// export type Course = {
//     id: number
//     name: string
//     description?: string
//     teacherId: number
//     teacherName: string | null
//     studyGroups: any[]
//   }
  
export type Course = {
  id: number;
  name: string;
  description?: string;
  teacherId: number;
  teacherName: string | null;
  groups: { id: number; name: string }[]; // ✅ נכון לפי ה־DTO שמגיע מהשרת
};

  export type CreateCoursePayload = {
    name: string
    studyGroups: { name: string }[]
  }