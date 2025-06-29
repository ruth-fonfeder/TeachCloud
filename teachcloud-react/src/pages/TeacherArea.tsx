import { Link } from "react-router-dom";

const TeacherArea = () => {
  const fullName = localStorage.getItem("fullName");
    return (
      <div>
        <h2>ברוך הבא מורה</h2>
        <h1>✨ {fullName} </h1>
        <p>כאן תוכל לנהל משתמשים, מוסדות ודוחות</p>

        <div className="container">
        <Link to="/teacher-area/courses">
         
            <h3 >ניהול קורסים</h3>
          
          
        </Link>
        {/* אפשר להוסיף פה עוד תפריטים כמו "קבצים", "נוכחות", וכו' */}
      </div>
    </div>
      
    );
  };
  
  export default TeacherArea;

