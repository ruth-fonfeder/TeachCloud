export const getTeacherCourses = async (token: string) => {
  const res = await fetch(`${import.meta.env.VITE_API_URL}/api/teacher/my/courses`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

  if (!res.ok) {
    throw new Error("Failed to fetch teacher courses");
  }

  return await res.json();
};

export const deleteCourse = async (id: number, token: string) => {
  const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${id}`, {
    method: "DELETE",
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

  if (!res.ok) {
    throw new Error("Failed to delete course");
  }
};