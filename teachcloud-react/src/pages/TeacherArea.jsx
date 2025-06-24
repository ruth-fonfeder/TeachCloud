const AdminArea = () => {
  const fullName = localStorage.getItem("fullName");
    return (
      <div>
        <h2>ברוך הבא מורה</h2>
        <h1>✨ {fullName} </h1>
        <p>כאן תוכל לנהל משתמשים, מוסדות ודוחות</p>
      </div>
    );
  };
  
  export default AdminArea;
  