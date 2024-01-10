import React from "react";
import { Link } from "react-router-dom";

const navbarStyle = "px-3 py-2 hover:bg-purple-500 hover:rounded-full";

const Navbar = ({isUserLoggedIn, handleUserLogout}) => {
  return (
    isUserLoggedIn ?
    <nav className="bg-purple-800 text-white p-3">
      <div className="container mx-auto flex justify-between items-center">
        <div className="text-lg font-semibold">
          <a href="/">Daily Task Manager</a>
        </div>
        <ul className="flex">
          <li><Link to="/" className={navbarStyle}>Home</Link></li>
          <li><Link to="/about" className={navbarStyle}>About</Link></li>
          <li><Link to="/services" className={navbarStyle}>Services</Link></li>
          <li><Link to="/contact" className={navbarStyle}>Contact</Link></li>
        </ul>
        <button onClick={handleUserLogout} className={navbarStyle} >Log Out</button>
      </div>
    </nav>
    : null
  );
};

export default Navbar;