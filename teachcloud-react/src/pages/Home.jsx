import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div className="container">
    <div>
      <h1>🤩🎉 ברוכים הבאים</h1>
      <Link to="/register">הרשמה</Link>
      </div>
    </div>
  );
};

export default Home;
