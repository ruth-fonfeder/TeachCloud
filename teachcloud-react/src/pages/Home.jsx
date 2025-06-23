import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div className="container">
    <div>
      <h1>🤩🎉 ברוכים הבאים</h1>
      {/* <Link to="/register">הרשמה</Link>
      <Link to="/login">התחברות</Link> */}
      <Link to="/register">הרשמה</Link>
<span style={{ margin: '0 10px' }}></span>
<Link to="/login">התחברות</Link>
      </div>
    </div>
  );
};

export default Home;
