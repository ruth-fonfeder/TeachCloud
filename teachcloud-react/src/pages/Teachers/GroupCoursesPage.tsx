import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { Course } from "../../types/course";
import CourseCard from "../../components/CourseCard";
import { Group } from "../../types/groupTypes";

const GroupCoursesPage = () => {
  const { token } = useAuth();
  const { groupId } = useParams();
  const [courses, setCourses] = useState<Course[]>([]);
  const [group, setGroup] = useState<Group | null>(null);
  const [newCourseName, setNewCourseName] = useState("");
  const [showCreateForm, setShowCreateForm] = useState(false);

  useEffect(() => {
    if (!token || !groupId) return;

   

    const fetchGroup = async () => {
      try {
        const res = await fetch(`${import.meta.env.VITE_API_URL}/api/group/${groupId}`, {
          headers: { Authorization: `Bearer ${token}` },
        });
    
        if (!res.ok) {
          console.error("שגיאה בטעינת הקבוצה", res.status);
          return;
        }
    
        const data = await res.json();
        console.log("Group data:", data); // 👈 תוסיפי את זה
        setGroup(data);
      } catch (err) {
        console.error("שגיאה בטעינת פרטי הקבוצה", err);
      }
    };
    

    const fetchCourses = async () => {
      try {
        const res = await fetch(`${import.meta.env.VITE_API_URL}/api/group/${groupId}/courses`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        const data = await res.json();
        setCourses(data);
      } catch (err) {
        console.error("שגיאה בטעינת קורסים", err);
      }
    };

    fetchGroup();
    fetchCourses();
  }, [token, groupId]);

  // 
  
  const handleAddCourse = async () => {
    if (!newCourseName.trim() || !token || !groupId) return;
  
    try {
      const res = await fetch(`${import.meta.env.VITE_API_URL}/api/Course`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
          name: newCourseName,
          groups: [{ id: Number(groupId), name: group?.name ?? "" }]
        }),
      });
  
      if (!res.ok) throw new Error("שגיאה ביצירת קורס");
  
      const created = await res.json();
      setCourses([...courses, created]);
      setNewCourseName("");
      setShowCreateForm(false);
    } catch (err) {
      console.error(err);
    }
  };
  

  const handleDeleteCourse = async (courseId: number) => {
    if (!window.confirm("האם למחוק את הקורס?") || !token) return;

    try {
      const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}`, {
        method: "DELETE",
        headers: { Authorization: `Bearer ${token}` },
      });

      if (!res.ok) throw new Error("שגיאה במחיקת קורס");

      setCourses(courses.filter((c) => c.id !== courseId));
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div className="p-6">
      {!group ? (
        <h2 className="text-xl font-bold mb-4 text-right">טוען...</h2>
      ) : (
        <h2 className="text-xl font-bold mb-4 text-right">
          הקורסים של קבוצת {group.name}
        </h2>
      )}

      {/* כפתור לפתיחת הטופס */}
      <button
        onClick={() => {
          setShowCreateForm((prev) => {
            const next = !prev;
            if (!next) setNewCourseName(""); // מנקה את הקלט כשסוגרים
            return next;
          });
        }}
        style={{
          position: "fixed",
          top: "20px",
          right: "20px",
          backgroundColor: "#fe5ca8",
          color: "white",
          padding: "10px 20px",
          borderRadius: "8px",
          zIndex: 9999,
          display: "inline-block",
          width: "auto",
          maxWidth: "none",
        }}
      >
        {showCreateForm ? "✖️" : "➕ הוספת קורס"}
      </button>

      {/* טופס הוספת קורס */}
      {showCreateForm && (
        <div className="container">
          <input
            type="text"
            placeholder="שם קורס חדש"
            value={newCourseName}
            onChange={(e) => setNewCourseName(e.target.value)}
            className="border px-3 py-2 rounded w-full max-w-sm"
          />
          <div className="mt-2 space-x-2">
            <button
              onClick={handleAddCourse}
              className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
            >
              שמור
            </button>
          </div>
        </div>
      )}

      {/* רשימת הקורסים */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-6">
        {courses.map((course) => (
          <CourseCard
            key={course.id}
            course={course}
            onDelete={() => handleDeleteCourse(course.id)}
          />
        ))}
      </div>
    </div>
  );
};

export default GroupCoursesPage;



