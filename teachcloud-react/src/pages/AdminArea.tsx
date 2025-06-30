import { Link } from "react-router-dom";

const TeacherArea = () => {
  const fullName = localStorage.getItem("fullName");

  return (
    <div className="p-6 text-center">
      <h2 className="text-2xl font-bold mb-2">ברוך הבא מורה</h2>
      <h1 className="text-xl mb-4">✨ {fullName}</h1>
      <p className="mb-6 text-gray-600">כאן תוכל לנהל קורסים וקבוצות לימוד</p>

      {/* ריבוע לקישור */}
      <div className="border rounded-lg shadow p-4 bg-gray-50 max-w-md mx-auto">
        <h3 className="font-semibold text-lg mb-2">הקורסים שלי</h3>
        <p className="text-sm text-gray-500 mb-4">
          יצירה, צפייה וניהול של קורסים אישיים
        </p>
        <Link
          to="/teacher/courses"
          className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition"
        >
          עבור לקורסים שלי
        </Link>
      </div>
    </div>
  );
};

export default TeacherArea;
