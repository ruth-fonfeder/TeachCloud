// import React, { useEffect, useState } from "react";
// import { useParams } from "react-router-dom";
// import { useAuth } from "../../context/AuthContext";
// import { Lesson } from "../../types/lesson";
// import LessonCard from "../../components/LessonCard";

// const CourseLessonsPage = () => {
//   const { token } = useAuth();
//   const { courseId } = useParams();
//   const [lessons, setLessons] = useState<Lesson[]>([]);
//   const [courseName, setCourseName] = useState("");
//   const [showCreateForm, setShowCreateForm] = useState(false);
//   const [newLessonTitle, setNewLessonTitle] = useState("");

//   useEffect(() => {
//     if (!token || !courseId) return;

//     const fetchLessons = async () => {
//       try {
//         const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}/lessons`, {
//           headers: { Authorization: `Bearer ${token}` },
//         });
//         if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
//         const data = await res.json();
//         setLessons(data);
//       } catch (err) {
//         console.error("שגיאה בטעינת שיעורים", err);
//       }
//     };

//     const fetchCourseName = async () => {
//       try {
//         const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}`, {
//           headers: { Authorization: `Bearer ${token}` },
//         });
//         const data = await res.json();
//         setCourseName(data.name);
//       } catch (err) {
//         console.error("שגיאה בטעינת שם הקורס", err);
//       }
//     };

//     fetchLessons();
//     fetchCourseName();
//   }, [token, courseId]);

//   const handleAddLesson = async () => {
//     if (!newLessonTitle.trim()) return;

//     try {
//       const res = await fetch(`${import.meta.env.VITE_API_URL}/api/lesson`, {
//         method: "POST",
//         headers: {
//           "Content-Type": "application/json",
//           Authorization: `Bearer ${token}`,
//         },
//         body: JSON.stringify({
//           title: newLessonTitle,
//           studyGroupId: 0, // יש להחליף בהתאם לקבוצה הרלוונטית
//         }),
//       });
//       if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
//       const createdLesson = await res.json();
//       setLessons((prev) => [...prev, createdLesson]);
//       setNewLessonTitle("");
//       setShowCreateForm(false);
//     } catch (err) {
//       console.error("שגיאה ביצירת שיעור", err);
//     }
//   };

//   return (
//     <div className="p-6">
//       <h2>ברוכה הבאה לקורס {courseName}</h2>
//       {/* <h2 className="text-xl font-bold mb-4 text-right">
//         ברוכה הבאה לקורס {courseName || "טוען..."}
//       </h2> */}

//       {/* כפתור לפתיחת/סגירת טופס הוספת שיעור */}
//       <button
//         onClick={() => {
//           setShowCreateForm((prev) => {
//             if (prev) setNewLessonTitle("");
//             return !prev;
//           });
//         }}
//         style={{
//           position: "fixed",
//           top: "20px",
//           right: "20px",
//           backgroundColor: "#fe5ca8",
//           color: "white",
//           padding: "10px 20px",
//           borderRadius: "8px",
//           zIndex: 9999,
//           display: "inline-block",
//           width: "auto",
//           maxWidth: "none",
//         }}
//       >
//         {showCreateForm ? "✖️ ביטול" : "➕ הוסף שיעור"}
//       </button>

//       {/* טופס הוספת שיעור */}
//       {showCreateForm && (
//         <div className="container mt-6">
//           <input
//             type="text"
//             placeholder="כותרת שיעור חדש"
//             value={newLessonTitle}
//             onChange={(e) => setNewLessonTitle(e.target.value)}
//             className="border px-3 py-2 rounded w-full max-w-sm"
//           />
//           <div className="mt-2 space-x-2">
//             <button
//               onClick={handleAddLesson}
//               className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
//             >
//               שמור
//             </button>
//           </div>
//         </div>
//       )}

//       {/* רשימת השיעורים */}
//       <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-6">
//         {lessons.map((lesson) => (
//           <LessonCard
//             key={lesson.id}
//             lesson={lesson}
//             onDelete={(id) => setLessons((prev) => prev.filter((l) => l.id !== id))}
//           />
//         ))}
//       </div>
//     </div>
//   );
// };

// export default CourseLessonsPage;



// import React, { useEffect, useState } from "react";
// import { useParams } from "react-router-dom";
// import { useAuth } from "../../context/AuthContext";
// import { Lesson } from "../../types/lesson";
// import LessonCard from "../../components/LessonCard";

// const CourseLessonsPage = () => {
//   const { token } = useAuth();
//   const { courseId } = useParams();
//   const [lessons, setLessons] = useState<Lesson[]>([]);
//   const [courseName, setCourseName] = useState("");
//   const [studyGroupId, setStudyGroupId] = useState<number | null>(null);
//   const [showCreateForm, setShowCreateForm] = useState(false);
//   const [newLessonTitle, setNewLessonTitle] = useState("");

//   useEffect(() => {
//     if (!token || !courseId) return;

//     // מביאים את הקורס ומגדירים גם את מזהה קבוצת הלימוד (studyGroupId)
//     const fetchCourse = async () => {
//       try {
//         const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}`, {
//           headers: { Authorization: `Bearer ${token}` },
//         });
//         if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
//         const data = await res.json();
//         setCourseName(data.name);
//         setStudyGroupId(data.studyGroupId); // מניח שהקורס מחזיר גם studyGroupId
//       } catch (err) {
//         console.error("שגיאה בטעינת שם הקורס", err);
//       }
//     };

//     // מביאים את השיעורים
//     const fetchLessons = async () => {
//       try {
//         const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}/lessons`, {
//           headers: { Authorization: `Bearer ${token}` },
//         });
//         if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
//         const data = await res.json();
//         setLessons(data);
//       } catch (err) {
//         console.error("שגיאה בטעינת שיעורים", err);
//       }
//     };

//     fetchCourse();
//     fetchLessons();
//   }, [token, courseId]);

//   const handleAddLesson = async () => {
//     console.log("נלחץ על כפתור שמירת שיעור"); // בדיקה
//     console.log("studyGroupId:", studyGroupId);

//     if (!newLessonTitle.trim() || !studyGroupId) return;

//     try {
//       const res = await fetch(`${import.meta.env.VITE_API_URL}/api/lesson`, {
//         method: "POST",
//         headers: {
//           "Content-Type": "application/json",
//           Authorization: `Bearer ${token}`,
//         },
//         body: JSON.stringify({
//           title: newLessonTitle,
//           studyGroupId: studyGroupId,
//         }),
        
//       });
//       if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
//       const createdLesson = await res.json();
//       setLessons((prev) => [...prev, createdLesson]);
//       setNewLessonTitle("");
//       setShowCreateForm(false);
//     } catch (err) {
//       console.error("שגיאה ביצירת שיעור", err);
//     }
    
//   };

//   return (
//     <div className="p-6">
//       <h2>ברוכה הבאה לקורס {courseName || "טוען..."}</h2>

//       <button
//         onClick={() => {
//           setShowCreateForm((prev) => {
//             if (prev) setNewLessonTitle("");
//             return !prev;
//           });
//         }}
//         style={{
//           position: "fixed",
//           top: "20px",
//           right: "20px",
//           backgroundColor: "#fe5ca8",
//           color: "white",
//           padding: "10px 20px",
//           borderRadius: "8px",
//           zIndex: 9999,
//           display: "inline-block",
//           width: "auto",
//           maxWidth: "none",
//         }}
//       >
//         {showCreateForm ? "✖️ ביטול" : "➕ הוסף שיעור"}
//       </button>

//       {showCreateForm && (
//         <div className="container mt-6">
//           <input
//             type="text"
//             placeholder="כותרת שיעור חדש"
//             value={newLessonTitle}
//             onChange={(e) => setNewLessonTitle(e.target.value)}
//             className="border px-3 py-2 rounded w-full max-w-sm"
//           />
//           <div className="mt-2 space-x-2">
//             <button
//               onClick={handleAddLesson}
//               className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
//             >
//               שמור
//             </button>
//           </div>
//         </div>
//       )}

//       <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-6">
//         {lessons.map((lesson) => (
//           <LessonCard
//             key={lesson.id}
//             lesson={lesson}
//             onDelete={(id) => setLessons((prev) => prev.filter((l) => l.id !== id))}
//           />
//         ))}
//       </div>
//     </div>
//   );
// };

// export default CourseLessonsPage;



import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { Lesson } from "../../types/lesson";
import LessonCard from "../../components/LessonCard";

const CourseLessonsPage = () => {
  const { token } = useAuth();
  const { courseId } = useParams();
  const [lessons, setLessons] = useState<Lesson[]>([]);
  const [courseName, setCourseName] = useState("");
  const [studyGroupId, setStudyGroupId] = useState<number | null>(null);
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [newLessonTitle, setNewLessonTitle] = useState("");

  useEffect(() => {
    if (!token || !courseId) return;

    const fetchCourse = async () => {
      try {
        const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
        const data = await res.json();
        console.log("Course data:", data); // בדיקה אם יש studyGroupId בכלל
        setCourseName(data.name);
        setStudyGroupId(data.studyGroupId); // מניח שהקורס מחזיר גם studyGroupId
      } catch (err) {
        console.error("שגיאה בטעינת שם הקורס", err);
      }
    };

    const fetchLessons = async () => {
      try {
        const res = await fetch(`${import.meta.env.VITE_API_URL}/api/course/${courseId}/lessons`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
        const data = await res.json();
        setLessons(data);
      } catch (err) {
        console.error("שגיאה בטעינת שיעורים", err);
      }
    };

    fetchCourse();
    fetchLessons();
  }, [token, courseId]);

  const handleAddLesson = async () => {
    console.log("נלחץ על כפתור שמירת שיעור"); // בדיקה
    console.log("studyGroupId:", studyGroupId); // בדיקה

    if (!newLessonTitle.trim()) {
      console.warn("לא הוזנה כותרת שיעור");
      return;
    }

    if (!studyGroupId) {
      console.warn("❗️ studyGroupId לא הוגדר. אי אפשר לשמור שיעור.");
      return;
    }

    try {
      const res = await fetch(`${import.meta.env.VITE_API_URL}/api/lesson`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
          title: newLessonTitle,
          studyGroupId: studyGroupId,
        }),
      });
      if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
      const createdLesson = await res.json();
      console.log("✅ שיעור נוצר:", createdLesson); // בדיקה
      setLessons((prev) => [...prev, createdLesson]);
      setNewLessonTitle("");
      setShowCreateForm(false);
    } catch (err) {
      console.error("שגיאה ביצירת שיעור", err);
    }
  };

  return (
    <div className="p-6">
      <h2>ברוכה הבאה לקורס {courseName || "טוען..."}</h2>

      <button
        onClick={() => {
          setShowCreateForm((prev) => {
            if (prev) setNewLessonTitle("");
            return !prev;
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
        {showCreateForm ? "✖️ ביטול" : "➕ הוסף שיעור"}
      </button>

      {showCreateForm && (
        <div className="container mt-6">
          <input
            type="text"
            placeholder="כותרת שיעור חדש"
            value={newLessonTitle}
            onChange={(e) => setNewLessonTitle(e.target.value)}
            className="border px-3 py-2 rounded w-full max-w-sm"
          />
          <div className="mt-2 space-x-2">
            <button
              onClick={handleAddLesson}
              className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
            >
              שמור
            </button>
          </div>
        </div>
      )}

      <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-6">
        {lessons.map((lesson) => (
          <LessonCard
            key={lesson.id}
            lesson={lesson}
            onDelete={(id) => setLessons((prev) => prev.filter((l) => l.id !== id))}
          />
        ))}
      </div>
    </div>
  );
};

export default CourseLessonsPage;
