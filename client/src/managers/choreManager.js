const _apiUrl = "http://localhost:5001/api/chore";

export const getAllChores = () => {
  return fetch(_apiUrl, {
    credentials: "include",
  }).then((res) => res.json());
};

export const getChoreById = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    credentials: "include",
  }).then((res) => res.json());
};

export const createChore = (chore) => {
  return fetch(_apiUrl, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(chore),
  }).then((res) => res.json());
};

export const updateChore = (id, chore) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "PUT",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(chore),
  }).then((res) => res.json());
};

export const deleteChore = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
    credentials: "include",
  });
};

export const completeChore = (choreId, userId) => {
  return fetch(`${_apiUrl}/${choreId}/complete?userId=${userId}`, {
    method: "POST",
    credentials: "include",
  });
};
