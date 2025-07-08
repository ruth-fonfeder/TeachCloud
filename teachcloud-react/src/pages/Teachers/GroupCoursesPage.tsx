// pages/GroupCoursesPage.tsx
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { Course } from "../../types/course";
import CourseCard from "../../components/CourseCard";
const GroupCoursesPage = () => {
  const { token } = useAuth();
  const { groupId } = useParams();
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    if (!token || !groupId) return;

    const fetchCourses = async () => {
      const res = await fetch(`${import.meta.env.VITE_API_URL}/api/groups/${groupId}/courses`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const data = await res.json();
      setCourses(data);
    };

    fetchCourses();
  }, [token, groupId]);

  return (
    <div className="p-6">
      <h2 className="text-xl font-bold mb-4 text-right">הקורסים של הקבוצה</h2>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        {courses.map((course) => (
          <CourseCard key={course.id} course={course} onDelete={() => {}} />
        ))}
      </div>
    </div>
  );
};

export default GroupCoursesPage;
