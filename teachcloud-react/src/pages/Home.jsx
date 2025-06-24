import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div className="container">
    <div>
  
<h1 style={{
  background: 'linear-gradient(to right, #10B981, #2563EB)',
  WebkitBackgroundClip: 'text',
  WebkitTextFillColor: 'transparent',
  fontSize: '2rem',
  fontWeight: 'bold'
}}>
  TeachCloud
</h1>
      <h2>🤩🎉 ברוכים הבאים</h2>
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
