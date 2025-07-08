// import type React from "react";
// import { useEffect, useState } from "react";
// import { getTeacherCourses } from "../../api/courseApi";
// import CourseCard from "../../components/CourseCard";
// import { useAuth } from "../../hooks/useAuth";
// import Modal from "../../components/Modal";

// type Course = {
//   id: number;
//   name: string;
//   description?: string;
//   teacherId: number;
//   teacherName: string | null;
//   studyGroups: any[];
// };

// function CreateCourseForm({ onCourseCreated }: { onCourseCreated: () => void }) {
//   const { token } = useAuth();
//   const [courseName, setCourseName] = useState("");
//   const [groups, setGroups] = useState([{ name: "" }]);
//   const [isSubmitting, setIsSubmitting] = useState(false);

//   const handleGroupNameChange = (index: number, value: string) => {
//     const newGroups = [...groups];
//     newGroups[index].name = value;
//     setGroups(newGroups);
//   };

//   const addGroup = () => setGroups([...groups, { name: "" }]);
//   const removeGroup = (index: number) =>
//     setGroups(groups.filter((_, i) => i !== index));

//   const handleSubmit = async (e: React.FormEvent) => {
//     e.preventDefault();
//     if (!token) {
//       alert("אין הרשאה, אנא התחבר/י");
//       return;
//     }

//     const payload = {
//       name: courseName,
//       studyGroups: groups.filter((g) => g.name.trim() !== ""),
//     };

//     setIsSubmitting(true);
//     try {
//       const res = await fetch(`${import.meta.env.VITE_API_URL}/api/Course/my`, {
//         method: "POST",
//         headers: {
//           "Content-Type": "application/json",
//           Authorization: `Bearer ${token}`,
//         },
//         body: JSON.stringify(payload),
//       });

//       if (!res.ok) throw new Error("שגיאה ביצירת הקורס");

//       alert("קורס נוצר בהצלחה!");
//       setCourseName("");
//       setGroups([{ name: "" }]);
//       onCourseCreated();
//     } catch (error) {
//       alert("אירעה שגיאה");
//       console.error("❌ שגיאה:", error);
//     } finally {
//       setIsSubmitting(false);
//     }
//   };

//   return (
//     <form onSubmit={handleSubmit} className="mb-6 p-6 border rounded bg-white shadow-md">
//       <h3>הוסף קורס חדש</h3>
//       <div>
//         <label className="block mb-1 font-medium">שם הקורס:</label>
//         <input
//           type="text"
//           value={courseName}
//           onChange={(e) => setCourseName(e.target.value)}
//           required
//           className="border p-2 rounded w-full"
//         />
//       </div>
//       <div className="mb-4">
//         <label className="block mb-1 font-medium">קבוצות לימוד:</label>
//         {groups.map((group, idx) => (
//           <div key={idx} className="flex items-center gap-2 mb-2">
//             <input
//               type="text"
//               value={group.name}
//               onChange={(e) => handleGroupNameChange(idx, e.target.value)}
//               required
//               className="border p-2 rounded flex-grow"
//             />
//             {groups.length > 1 && (
//               <button type="button" onClick={() => removeGroup(idx)} className=" ">
//                 מחק
//               </button>
//             )}
//           </div>
//         ))}
//         {/* <button type="button" onClick={addGroup} className="text-blue-600 hover:underline">
//           ➕ הוסף קבוצה
//         </button> */}
//       </div>
//       <div className="text-center mt-6">
//         <button
//           type="submit"
//           disabled={isSubmitting}
//           className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded"
//         >
//           {isSubmitting ? "שולח..." : "צור קורס"}
//         </button>
//       </div>
//     </form>
//   );
// }

// const TeacherCoursesPage = () => {
//   const { token } = useAuth();
//   const [courses, setCourses] = useState<Course[]>([]);
//   const [isModalOpen, setIsModalOpen] = useState(false);

//   const fetchCourses = async () => {
//     if (!token) return;
//     try {
//       const res = await getTeacherCourses(token);
//       setCourses(res);
//     } catch (error) {
//       console.error("❌ שגיאה בטעינת הקורסים:", error);
//     }
//   };

//   useEffect(() => {
//     fetchCourses();
//   }, [token]);

//   return (
//     <div className="p-6">
//       <div className="flex justify-between items-center mb-4">
//         <h2 className="text-xl font-bold">הקורסים שלי</h2>


//         <button
//           onClick={() => {
//             console.log("✅ כפתור נלחץ");
//             setIsModalOpen(true);
//           }}
//           style={{
//             position: "fixed",
//             top: "20px",
//             right: "20px",
//             backgroundColor: "#fe5ca8",
//             color: "white",
//             padding: "10px 20px",
//             borderRadius: "8px",
//             zIndex: 9999,
//             display: "inline-block", // ✅ הכרחי
//             width: "auto",           // ✅ לא 100%
//             maxWidth: "none",        // ליתר ביטחון
//           }}

//         >
//           ➕ הוסף קורס
//         </button>




//       </div>
//       {courses.length === 0 ? (
//         <p className="text-center text-gray-500">לא נמצאו קורסים</p>
//       ) : (
//         <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
//           {courses.map((course) => (
//             <CourseCard key={course.id} course={course} />
//           ))}
//         </div>
//       )}

//       <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} title="">
//         <CreateCourseForm
//           onCourseCreated={() => {
//             fetchCourses();
//             setIsModalOpen(false);
//           }}
//         />
//       </Modal>
//       <Modal isOpen={true} onClose={() => {}} title="בדיקה">
//   <div className="text-center">
//     <p className="text-lg text-pink-700 font-semibold">אני באמצע המסך?</p>
//   </div>
// </Modal>


//     </div>
//   );
// };

// export default TeacherCoursesPage;



import React, { useEffect, useState } from "react";
import { getTeacherCourses, deleteCourse } from "../../api/courseApi";
import CourseCard from "../../components/CourseCard";
import { useAuth } from "../../hooks/useAuth";
import Modal from "../../components/Modal";

type Course = {
  id: number;
  name: string;
  description?: string;
  teacherId: number;
  teacherName: string | null;
  studyGroups: any[];
};

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
      studyGroups: groups.filter((g) => g.name.trim() !== ""),
    };

    setIsSubmitting(true);
    try {
      const res = await fetch(`${import.meta.env.VITE_API_URL}/api/Course/my`, {
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
      onCourseCreated();
    } catch (error) {
      alert("אירעה שגיאה");
      console.error("❌ שגיאה:", error);
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="container">
      <h3>הוסף קורס חדש</h3>
      <div>
        <label className="block mb-1 font-medium">שם הקורס:</label>
        <input
          type="text"
          value={courseName}
          onChange={(e) => setCourseName(e.target.value)}
          required
          className="border p-2 rounded w-full"
        />
      </div>
      <div className="mb-4">
        <label className="block mb-1 font-medium">קבוצות לימוד:</label>
        {groups.map((group, idx) => (
          <div key={idx} className="flex items-center gap-2 mb-2">
            <input
              type="text"
              value={group.name}
              onChange={(e) => handleGroupNameChange(idx, e.target.value)}
              required
              className="border p-2 rounded flex-grow"
            />
            {groups.length > 1 && (
              <button type="button" onClick={() => removeGroup(idx)} className="text-red-600">
                מחק
              </button>
            )}
          </div>
        ))}
      </div>
      <div className="text-center mt-6">
        <button
          type="submit"
          disabled={isSubmitting}
          className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded"
        >
          {isSubmitting ? "שולח..." : "צור קורס"}
        </button>
      </div>
    </form>
  );
}

const TeacherCoursesPage = () => {
  const { token } = useAuth();
  const [courses, setCourses] = useState<Course[]>([]);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const fetchCourses = async () => {
    if (!token) return;
    try {
      const res = await getTeacherCourses(token);
      setCourses(res);
    } catch (error) {
      console.error("❌ שגיאה בטעינת הקורסים:", error);
    }
  };

  useEffect(() => {
    fetchCourses();
  }, [token]);

  const handleDelete = async (id: number) => {
    if (!token) return;
    try {
      await deleteCourse(id, token);
      setCourses((prev) => prev.filter((c) => c.id !== id));
    } catch (error) {
      alert("שגיאה במחיקת הקורס");
      console.error(error);
    }
  };

  return (
    <div className="p-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-bold">הקורסים שלי</h2>
        <button
          onClick={() => setIsModalOpen(true)}
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
          ➕ הוסף קורס
        </button>
      </div>

      {courses.length === 0 ? (
        <p className="text-center text-gray-500">לא נמצאו קורסים</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          {courses.map((course) => (
            <CourseCard key={course.id} course={course} onDelete={handleDelete} />
          ))}
        </div>
      )}

      <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} title="">
        <CreateCourseForm
          onCourseCreated={() => {
            fetchCourses();
            setIsModalOpen(false);
          }}
        />
      </Modal>
    </div>
  );
};

export default TeacherCoursesPage;
