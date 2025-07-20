// import React from "react";

// type Course = {
//   id: number;
//   name: string;
//   description?: string;
//   teacherId: number;
//   teacherName: string | null;
//   studyGroups: any[];
// };

// type Props = {
//   course: Course;
//   onDelete: (id: number) => void;
// };

// const CourseCard = ({ course, onDelete }: Props) => {
//   return (



//       <div className="container relative">
      
//         <h3 className="text-lg font-bold text-blue-800 mb-1 text-right">{course.name}</h3>
//         {course.description ? (
//           <p className="text-sm text-gray-600 text-right">{course.description}</p>
//         ) : (
//           <p className="text-sm text-gray-400 italic text-right"> </p>
          
//         )}
//           <button
//           onClick={() => onDelete(course.id)}
//           className=""
//         >
//           🗑
//         </button>
//     </div>
//   );
// };

// export default CourseCard;


import React from "react";
import { useNavigate } from "react-router-dom";

type Course = {
  id: number;
  name: string;
  description?: string;
  teacherId: number;
  teacherName: string | null;
  studyGroups: any[];
};

type Props = {
  course: Course;
  onDelete: (id: number) => void;
};

const CourseCard = ({ course, onDelete }: Props) => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/courses/${course.id}/lessons`);
  };

  return (
    <div
      className="container relative border p-4 rounded shadow hover:bg-gray-100 cursor-pointer"
      onClick={handleClick}
    >
      <h3 className="text-lg font-bold text-blue-800 mb-1 text-right">
        {course.name}
      </h3>

      {course.description ? (
        <p className="text-sm text-gray-600 text-right">{course.description}</p>
      ) : (
        <p className="text-sm text-gray-400 italic text-right">אין תיאור</p>
      )}

      <button
        onClick={(e) => {
          e.stopPropagation(); // כדי לא להפעיל את הניווט
          onDelete(course.id);
        }}
        className="absolute top-2 left-2 text-red-600 hover:text-red-800"
      >
        🗑
      </button>
    </div>
  );
};

export default CourseCard;
