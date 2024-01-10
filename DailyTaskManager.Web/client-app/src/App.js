import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import SignupPage from "./pages/SignupPage";
import LoginPage from "./pages/LoginPage";
import HomePage from "./pages/HomePage";
import { useState } from "react";
import { clearTokenFromLocalStorage, isLoggedIn } from "./api/tokenHandler";
import Navbar from "./components/NavBar";

function App() {
  const [isUserLoggedIn, setIsUserLoggedIn] = useState(isLoggedIn());

  const handleUserLogin = (isUserLoggedIn) => {
    setIsUserLoggedIn(isUserLoggedIn);
  };

  const handleUserLogout = () => {
    clearTokenFromLocalStorage();
    setIsUserLoggedIn(false);
  }

  return (
    <BrowserRouter>
      <Navbar isUserLoggedIn={isUserLoggedIn} handleUserLogout={handleUserLogout} />
      <div className="min-h-full h-screen flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
        <div className="max-w-md w-full space-y-8">
          <Routes>
            <Route
              path="/"
              element={
                !isUserLoggedIn ? (
                  <LoginPage handleUserLogin={handleUserLogin} />
                ) : (
                  <HomePage />
                )
              }
            />
            <Route path="/signup" element={<SignupPage />} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
