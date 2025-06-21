import React from "react";
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <div style={{ padding: "2rem", textAlign: "center" }}>
      <h1>404 - הדף לא נמצא</h1>
      <p>מצטערים, הדף שחיפשת לא קיים.</p>
      <Link to="/">חזרה לעמוד הבית</Link>
    </div>
  );
};

export default NotFound;
