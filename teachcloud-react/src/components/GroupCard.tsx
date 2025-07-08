import React from "react";
import { Group } from "../types/groupTypes";
import { useNavigate } from "react-router-dom";

type Props = {
  group: Group;
  onDelete: (id: number) => void;
};

const GroupCard = ({ group, onDelete }: Props) => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/teacher-area/groups/${group.id}/courses`);
  };

  return (
    <div className="container">

      {/* כפתור מחיקה */}
      <button
        onClick={() => onDelete(group.id)}
        className="absolute top-2 right-2 text-red-500 hover:text-red-700 text-sm"
        title="מחיקה"
      >
        🗑
      </button>

      {/* קליק לניווט */}
      <div onClick={handleClick} className="cursor-pointer text-right">
        <h3 className="text-lg font-bold text-blue-800">{group.name}</h3>
        <p className="text-sm text-gray-600">{group.courseName}</p>
      </div>
    </div>
  );
};

export default GroupCard;



