const _apiUrl = "http://localhost:5001/api/auth";

export const tryGetLoggedInUser = () => {
  return fetch(`${_apiUrl}/me`, {
    credentials: "include",
  })
    .then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        return null;
      }
    })
    .catch(() => null);
};

export const login = (email, password) => {
  return fetch(`${_apiUrl}/login`, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  }).then((res) => res.json());
};

export const register = (registration) => {
  return fetch(`${_apiUrl}/register`, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(registration),
  }).then((res) => res.json());
};

export const logout = () => {
  return fetch(`${_apiUrl}/logout`, {
    method: "POST",
    credentials: "include",
  });
};