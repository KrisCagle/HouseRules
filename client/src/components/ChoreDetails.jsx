import { useState, useEffect } from "react";
import { getChoreById, updateChore } from "../managers/choreManager";
import { getAllProfiles } from "../managers/userProfileManager";
import { useParams, useNavigate } from "react-router-dom";

export default function ChoreDetails() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [chore, setChore] = useState(null);
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [name, setName] = useState("");
  const [difficulty, setDifficulty] = useState(1);
  const [choreFrequencyDays, setChoreFrequencyDays] = useState(1);
  const [errors, setErrors] = useState(null);

  useEffect(() => {
    Promise.all([getChoreById(id), getAllProfiles()])
      .then(([choreData, usersData]) => {
        setChore(choreData);
        setUsers(usersData);
        setName(choreData.name);
        setDifficulty(choreData.difficulty);
        setChoreFrequencyDays(choreData.choreFrequencyDays);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching data:", err);
        setLoading(false);
      });
  }, [id]);

  const handleAssignmentChange = (userId, isChecked) => {
    const endpoint = isChecked
      ? `http://localhost:5001/api/chore/${id}/assign?userId=${userId}`
      : `http://localhost:5001/api/chore/${id}/unassign?userId=${userId}`;

    fetch(endpoint, {
      method: "POST",
      credentials: "include",
    })
      .then(() => {
        getChoreById(id).then((updatedChore) => {
          setChore(updatedChore);
        });
      })
      .catch((err) => {
        console.error("Error updating assignment:", err);
      });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setErrors(null);

    const updatedChore = {
      name,
      difficulty: parseInt(difficulty),
      choreFrequencyDays: parseInt(choreFrequencyDays),
    };

    updateChore(id, updatedChore)
      .then((res) => {
        if (res.errors) {
          setErrors(res.errors);
        } else {
          navigate("/chores");
        }
      })
      .catch((err) => {
        console.error("Error updating chore:", err);
        setErrors({ general: ["Failed to update chore"] });
      });
  };

  if (loading) return <div>Loading Details...</div>;
  if (!chore) return <div>Chore not found</div>;

  const mostRecentCompletion = chore.choreCompletions?.[0];
  const assignedUserIds = chore.choreAssignments?.map((a) => a.userProfileId) || [];

  return (
    <div className="container mt-5">
      <h1>Edit Chore: {chore.name}</h1>

      {errors && (
        <div style={{ color: "red" }}>
          {Object.keys(errors).map((key) => (
            <p key={key}>
              <strong>{key}:</strong> {errors[key].join(", ")}
            </p>
          ))}
        </div>
      )}

      <form onSubmit={handleSubmit} className="mb-4">
        <div className="mb-3">
          <label htmlFor="name" className="form-label">
            Chore Name
          </label>
          <input
            type="text"
            className="form-control"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>

        <div className="mb-3">
          <label htmlFor="difficulty" className="form-label">
            Difficulty (1-5)
          </label>
          <input
            type="number"
            className="form-control"
            id="difficulty"
            min="1"
            max="5"
            value={difficulty}
            onChange={(e) => setDifficulty(e.target.value)}
            required
          />
        </div>

        <div className="mb-3">
          <label htmlFor="frequency" className="form-label">
            Frequency (Days)
          </label>
          <input
            type="number"
            className="form-control"
            id="frequency"
            min="1"
            max="14"
            value={choreFrequencyDays}
            onChange={(e) => setChoreFrequencyDays(e.target.value)}
            list="frequencySuggestions"
            required
          />
          <datalist id="frequencySuggestions">
            <option value="1">Daily</option>
            <option value="3">Every 3 days</option>
            <option value="7">Weekly</option>
            <option value="10">Every 10 days</option>
            <option value="14">Bi-weekly</option>
          </datalist>
        </div>

        <button type="submit" className="btn btn-primary me-2">
          Save Changes
        </button>
        <button
          type="button"
          className="btn btn-secondary"
          onClick={() => navigate("/chores")}
        >
          Cancel
        </button>
      </form>

      <div className="border p-3 mb-4">
        <h3>Assign to Users</h3>
        {users && users.length > 0 ? (
          <div>
            {users.map((user) => (
              <div key={user.id} className="form-check">
                <input
                  className="form-check-input"
                  type="checkbox"
                  id={`user-${user.id}`}
                  checked={assignedUserIds.includes(user.id)}
                  onChange={(e) => handleAssignmentChange(user.id, e.target.checked)}
                />
                <label className="form-check-label" htmlFor={`user-${user.id}`}>
                  {user.firstName} {user.lastName}
                </label>
              </div>
            ))}
          </div>
        ) : (
          <p>No users available</p>
        )}
      </div>

      <div className="border p-3">
        <h3>Most Recent Completion</h3>
        {mostRecentCompletion ? (
          <p>
            Completed on{" "}
            {new Date(mostRecentCompletion.completedOn).toLocaleDateString()}
          </p>
        ) : (
          <p>Not yet completed</p>
        )}
      </div>
    </div>
  );
}