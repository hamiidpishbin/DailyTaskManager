const saveTokenToLocalStorage = (token) => {
  localStorage.setItem("accessToken", token);
};

const getTokenFromLocalStorage = () => {
  return localStorage.getItem("accessToken");
};

const clearTokenFromLocalStorage = () => {
  localStorage.removeItem("accessToken");
};

const isLoggedIn = () => {
  return !!localStorage.getItem("accessToken");
};

const logout = () => {
  localStorage.removeItem("accessToken");
};

export {
  saveTokenToLocalStorage,
  getTokenFromLocalStorage,
  clearTokenFromLocalStorage,
  isLoggedIn,
  logout,
};
