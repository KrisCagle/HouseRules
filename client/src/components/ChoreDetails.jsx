import { useState, useEffect } from "react";
import { getChoreById } from "../managers/choreManager";
import { getAllProfiles } from "../managers/userProfileManager";
import { useParams } from "react-router-dom";

export default function ChoreDetails() {
  const { id } = useParams();
  const [chore, setChore] = useState(null);
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    Promise.all([getChoreById(id), getAllProfiles()])
      .then(([choreData, usersData]) => {
        setChore(choreData);
        setUsers(usersData);
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
        // Re-fetch the chore to update assignments
        getChoreById(id).then((updatedChore) => {
          setChore(updatedChore);
        });
      })
      .catch((err) => {
        console.error("Error updating assignment:", err);
      });
  };

  if (loading) return <div>Loading Details...</div>;
  if (!chore) return <div>Chore not found</div>;

  const mostRecentCompletion = chore.choreCompletions?.[0];
  const assignedUserIds = chore.choreAssignments?.map((a) => a.userProfileId) || [];

  return (
    <div className="container mt-5">
      <h1>{chore.name}</h1>

      <div className="border p-3 mb-4">
        <h3>Chore Details</h3>
        <p>
          <strong>Difficulty:</strong> {chore.difficulty}
        </p>
        <p>
          <strong>Frequency:</strong> Every {chore.choreFrequencyDays} days
        </p>
      </div>

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