import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createChore } from "../managers/choreManager";

export default function CreateChore() {
  const navigate = useNavigate();
  const [name, setName] = useState("");
  const [difficulty, setDifficulty] = useState(1);
  const [choreFrequencyDays, setChoreFrequencyDays] = useState(1);
  const [errors, setErrors] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    setErrors(null);  // Clear previous errors
    
    const newChore = {
      name,
      difficulty: parseInt(difficulty),
      choreFrequencyDays: parseInt(choreFrequencyDays)
    };

    createChore(newChore)
      .then((res) => {
        if (res.errors) {
          setErrors(res.errors);
        } else {
          navigate("/chores");
        }
      })
      .catch((err) => {
        console.error("Error creating chore:", err);
        setErrors({ general: ["Failed to create chore"] });
      });
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <h2>Create New Chore</h2>
          
          {errors && (
            <div style={{ color: "red" }}>
              {Object.keys(errors).map((key) => (
                <p key={key}>
                  <strong>{key}:</strong> {errors[key].join(", ")}
                </p>
              ))}
            </div>
          )}
          
          <form onSubmit={handleSubmit}>
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

            <button type="submit" className="btn btn-primary">
              Create Chore
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}