// import { Link } from "react-router-dom";

// const TeacherArea = () => {
//   const fullName = localStorage.getItem("fullName");
//     return (
//       <div>
//         <h2>ברוך הבא מורה</h2>
//         <h1>✨ {fullName} </h1>
//         <p>כאן תוכל לנהל משתמשים, מוסדות ודוחות</p>

//         <div className="container">
//         <Link to="/teacher-area/courses">
         
//             <h3 >ניהול קורסים</h3>
          
          
//         </Link>
//         {/* אפשר להוסיף פה עוד תפריטים כמו "קבצים", "נוכחות", וכו' */}
//       </div>
//     </div>
      
//     );
//   };
  
//   export default TeacherArea;


import { Link } from "react-router-dom";

const TeacherArea = () => {
  const fullName = localStorage.getItem("fullName");

  return (
    <div>
      <h2>ברוך הבא מורה</h2>
      <h1>✨ {fullName} </h1>
      <p>כאן תוכל לנהל קורסים וקבוצות לימוד</p>

      <div className="container space-y-4">
        <Link to="/teacher-area/groups" className="block p-4 border rounded shadow hover:bg-gray-100">
          <h3 className="text-lg font-semibold">📚 קבוצות לימוד</h3>
          <p className="text-sm text-gray-600">כניסה לקבוצות הלימוד שלך ולצפייה בקורסים של כל קבוצה</p>
        </Link>

        <Link to="/teacher-area/courses" className="block p-4 border rounded shadow hover:bg-gray-100">
          <h3 className="text-lg font-semibold">📖 ניהול קורסים</h3>
          <p className="text-sm text-gray-600">כל הקורסים שלך מרוכזים כאן</p>
        </Link>
      </div>
    </div>
  );
};

export default TeacherArea;


