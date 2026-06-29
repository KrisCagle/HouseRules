import { useState, useEffect } from "react";
import { getMyChores, completeChore } from "../managers/choreManager";

export default function MyChores({ loggedInUser }) {
  const [chores, setChores] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getMyChores()
      .then((data) => {
        setChores(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching my chores:", err);
        setLoading(false);
      });
  }, []);

  const handleComplete = (choreId) => {
    completeChore(choreId, loggedInUser.id)
      .then(() => {
        alert("Chore completed!");
        // Re-fetch to update the list
        getMyChores().then((data) => {
          setChores(data);
        });
      })
      .catch((err) => {
        console.error("Error completing chore:", err);
      });
  };

  if (loading) return <div>Loading your chores...</div>;

  return (
    <div className="container mt-5">
      <h1>My Chores</h1>
      {chores && chores.length > 0 ? (
        <div className="row">
          {chores.map((chore) => (
            <div key={chore.id} className="col-md-4 mb-3">
              <div className="border p-3">
                <h5 style={{ color: chore.isOverdue ? "red" : "black" }}>
                  {chore.name}
                </h5>
                <p>Difficulty: {chore.difficulty}</p>
                <p>Frequency: Every {chore.choreFrequencyDays} days</p>
                {chore.isOverdue && (
                  <p style={{ color: "red", fontWeight: "bold" }}>
                    ⚠️ Overdue!
                  </p>
                )}
                <button
                  className="btn btn-success btn-sm"
                  onClick={() => handleComplete(chore.id)}
                >
                  Complete
                </button>
              </div>
            </div>
          ))}
        </div>
      ) : (
        <p>No chores assigned to you, or all are up to date!</p>
      )}
    </div>
  );
}