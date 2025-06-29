// src/api/courseApi.ts

export const getTeacherCourses = async (token: string) => {
    const res = await fetch("http://localhost:7166/api/teachers/my/courses", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
  
    if (!res.ok) {
      throw new Error("Failed to fetch teacher courses");
    }
  
    return await res.json();
  };
  