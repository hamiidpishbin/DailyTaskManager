const saveTokenToLocalStorage = (token) => {
  localStorage.setItem("accessToken", token);
};

const getTokenFromLocalStorage = () => {
  return localStorage.getItem("accessToken");
};

const clearTokenFromLocalStorage = () => {
  localStorage.removeItem("accessToken");
};

export {
  saveTokenToLocalStorage,
  getTokenFromLocalStorage,
  clearTokenFromLocalStorage,
};
