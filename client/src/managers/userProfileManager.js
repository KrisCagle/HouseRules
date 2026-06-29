const _apiUrl = "http://localhost:5001/api/userprofile"

export const getAllProfiles = () => {
    return fetch(_apiUrl, {
    credentials: "include",
  }).then((res) => res.json());
};

export const getProfileById = () => {
    return fetch(`${_apiUrl}/${id}`, {
        credentials: "include",   
    }).then((res) => res.json());
};