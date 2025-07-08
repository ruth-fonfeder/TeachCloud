import React from "react";

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
  return (



      <div className="container relative">
      
        <h3 className="text-lg font-bold text-blue-800 mb-1 text-right">{course.name}</h3>
        {course.description ? (
          <p className="text-sm text-gray-600 text-right">{course.description}</p>
        ) : (
          <p className="text-sm text-gray-400 italic text-right">אין תיאור</p>
          
        )}
          <button
          onClick={() => onDelete(course.id)}
          className=""
        >
          🗑
        </button>
    </div>
  );
};

export default CourseCard;
