const StudentArea = () => {
  const fullName = localStorage.getItem("fullName");

    return (
      <div>
        <h2>  ברוך הבא תלמיד</h2>
        <h1>{fullName} 👋</h1>
        <p>כאן תוכל לראות את הקורסים שלך וכו'</p>
      </div>
    );
  };
  
  export default StudentArea;
  