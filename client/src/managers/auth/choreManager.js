const _apiUrl = "http://localhost:5001/api/chore";

export const getAllChores = () => {
  return fetch(_apiUrl, {
    credentials: "include",
  }).then((res) => res.json());
};