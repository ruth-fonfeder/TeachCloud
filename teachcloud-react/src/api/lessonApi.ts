const API_URL = import.meta.env.VITE_API_URL;

export const getLessonsByCourse = async (courseId: number, token: string) => {
  const res = await fetch(`${API_URL}/api/lesson/${courseId}/lessons`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

  if (!res.ok) {
    throw new Error("Failed to fetch lessons");
  }

  return await res.json();
};

export const createLesson = async (
  lessonData: { title: string; studyGroupId: number },
  token: string
) => {
  const res = await fetch(`${API_URL}/api/lesson`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(lessonData),
  });

  if (!res.ok) {
    const errorText = await res.text();
    throw new Error("Failed to create lesson: " + errorText);
  }

  return await res.json();
};
