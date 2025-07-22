// import React from "react";
// import { Lesson } from "../types/lesson";


// type Props = {
//     lesson: Lesson;
//     onDelete: (id: number) => void;
//     onClick?: () => void;
//   };
  

// const LessonCard = ({ lesson, onDelete, onClick }: Props) => {
//   return (
//     <div
//       className="container"
//       onClick={onClick}
//     >
//       <h3 className="text-lg font-bold text-blue-800 mb-1 text-right">
//         {lesson.title}
//       </h3>

//       {lesson.description ? (
//         <p className="text-sm text-gray-600 text-right">{lesson.description}</p>
//       ) : (
//         <p className="text-sm text-gray-400 italic text-right">אין תיאור</p>
//       )}

//       {lesson.date && (
//         <p className="text-xs text-right text-gray-500 mt-1">
//           תאריך: {new Date(lesson.date).toLocaleDateString("he-IL")}
//         </p>
//       )}

//       <button
//         onClick={(e) => {
//           e.stopPropagation(); // כדי לא להפעיל את ה-onClick הכללי
//           onDelete(lesson.id);
//         }}
//         className="absolute top-2 left-2 text-red-600 hover:text-red-800"
//       >
//         🗑
//       </button>
//     </div>
//   );
// };

// export default LessonCard;


import React from "react";
import { Lesson } from "../types/lesson";

type Props = {
  lesson: Lesson;
  onDelete: (id: number) => void;
  onClick?: () => void;
  token: string | null;
};

const LessonCard = ({ lesson, onDelete, onClick, token }: Props) => {
  const handleDelete = async (e: React.MouseEvent) => {
    e.stopPropagation(); // לא להפעיל את onClick הכללי

    if (!token) {
      console.error("אין טוקן");
      return;
    }

    try {
      const response = await fetch(
        `${import.meta.env.VITE_API_URL}/api/lesson/${lesson.id}`,
        {
          method: "DELETE",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (response.ok) {
        onDelete(lesson.id);
      } else {
        console.error("❌ מחיקה נכשלה");
      }
    } catch (error) {
      console.error("שגיאה במחיקה:", error);
    }
  };

  return (
    <div className="container" onClick={onClick}>
      <h3 className="text-lg font-bold text-blue-800 mb-1 text-right">
        {lesson.title}
      </h3>

      {lesson.description ? (
        <p className="text-sm text-gray-600 text-right">
          {lesson.description}
        </p>
      ) : (
        <p className="text-sm text-gray-400 italic text-right">אין תיאור</p>
      )}

      {lesson.date && (
        <p className="text-xs text-right text-gray-500 mt-1">
          תאריך: {new Date(lesson.date).toLocaleDateString("he-IL")}
        </p>
      )}

      <button
        onClick={handleDelete}
        className="absolute top-2 left-2 text-red-600 hover:text-red-800"
      >
        🗑
      </button>
    </div>
  );
};

export default LessonCard;
