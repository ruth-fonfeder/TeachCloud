import React, { useEffect, useState } from "react";
import { getTeacherCourses } from "../../api/courseApi";
import CourseCard from "../../components/CourseCard";
import { useAuth } from "../../hooks/useAuth";

// --- קומפוננטת יצירת קורס ---

function CreateCourseForm({ onCourseCreated }: { onCourseCreated: () => void }) {
  const { token } = useAuth();
  const [courseName, setCourseName] = useState("");
  const [groups, setGroups] = useState([{ name: "" }]);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleGroupNameChange = (index: number, value: string) => {
    const newGroups = [...groups];
    newGroups[index].name = value;
    setGroups(newGroups);
  };

  const addGroup = () => setGroups([...groups, { name: "" }]);
  const removeGroup = (index: number) =>
    setGroups(groups.filter((_, i) => i !== index));

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!token) {
      alert("אין הרשאה, אנא התחבר/י");
      return;
    }

    const payload = {
      name: courseName,
      studyGroups: groups.filter(g => g.name.trim() !== ""),
    };

    setIsSubmitting(true);

    try {
      const res = await fetch("/api/Course/my", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(payload),
      });

      if (!res.ok) throw new Error("שגיאה ביצירת הקורס");

      alert("קורס נוצר בהצלחה!");
      setCourseName("");
      setGroups([{ name: "" }]);
      onCourseCreated(); // טען מחדש את רשימת הקורסים
    } catch (error) {
      alert("אירעה שגיאה");
      console.error(error);
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="mb-6 p-4 border rounded">
      <h3 className="mb-2 font-bold">הוסף קורס חדש</h3>
      <div>
        <label>שם הקורס:</label>
        <input
          type="text"
          value={courseName}
          onChange={e => setCourseName(e.target.value)}
          required
          className="border p-1 rounded w-full mb-2"
        />
      </div>
      <div>
        <label>קבוצות לימוד:</label>
        {groups.map((group, idx) => (
          <div key={idx} className="flex items-center gap-2 mb-1">
            <input
              type="text"
              value={group.name}
              onChange={e => handleGroupNameChange(idx, e.target.value)}
              required
              className="border p-1 rounded flex-grow"
            />
            {groups.length > 1 && (
              <button
                type="button"
                onClick={() => removeGroup(idx)}
                className="text-red-600"
              >
                מחק
              </button>
            )}
          </div>
        ))}
        <button
          type="button"
          onClick={addGroup}
          className="text-blue-600 underline mb-2"
        >
          הוסף קבוצה
        </button>
        <div style={{ height: "10px" }}></div>
      </div>
      <button
        type="submit"
        disabled={isSubmitting}
        className="bg-blue-500 text-white px-4 py-2 rounded"
      >
        {isSubmitting ? "שולח..." : "צור קורס"}
      </button>
    </form>
  );
}

// --- הקומפוננטה הראשית ---

type Course = {
  id: number;
  name: string;
  teacherId: number;
  teacherName: string | null;
  studyGroups: any[];
};

const TeacherCoursesPage = () => {
  const { token } = useAuth();
  const [courses, setCourses] = useState<Course[]>([]);

  const fetchCourses = async () => {
    if (!token) return;
    try {
      const res = await getTeacherCourses(token);
      setCourses(res);
    } catch (error) {
      console.error("שגיאה בטעינת הקורסים", error);
    }
  };

  useEffect(() => {
    fetchCourses();
  }, [token]);

  return (
    <div className="container">
      <div className="p-4">
        <h2 className="text-xl font-bold mb-4 text-center">הקורסים שלי</h2>

        <CreateCourseForm onCourseCreated={fetchCourses} />

        {courses.length === 0 ? (
          <p className="text-center text-gray-500">לא נמצאו קורסים</p>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            {courses.map((course) => (
              <CourseCard key={course.id} course={course} />
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default TeacherCoursesPage;

