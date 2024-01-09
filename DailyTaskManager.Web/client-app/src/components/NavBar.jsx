import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="bg-purple-800 text-white p-3">
      <div className="container mx-auto flex justify-between items-center">
        <div className="text-lg font-semibold">
          <a href="/">Daily Task Manager</a>
        </div>
        <ul className="flex">
          <li><Link to="/" className="px-3 py-2 hover:bg-gray-700">Home</Link></li>
          <li><Link to="/about" className="px-3 py-2 hover:bg-gray-700">About</Link></li>
          <li><Link to="/services" className="px-3 py-2 hover:bg-gray-700">Services</Link></li>
          <li><Link to="/contact" className="px-3 py-2 hover:bg-gray-700">Contact</Link></li>
        </ul>
      </div>
    </nav>
  );
};

export default Navbar;