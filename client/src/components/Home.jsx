import {useState, useEffect} from "react";
import { getAllChores } from "../managers/choreManager";

export default function Home() {
  const [chores, setChores] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getAllChores()
      .then((data) => {
        setChores(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching chores:", err);
        setLoading(false);
      });
  }, []);

  if (loading) return <div>Loading chores...</div>;

  return (
    <div className="container mt-5">
      <h1>House Rules Chores</h1>
      <div className="row">
        {chores.map((chore) => (
          <div key={chore.id} className="col-md-4 mb-3">
            <div className="border p-3">
              <h5>{chore.name}</h5>
              <p>Difficulty: {chore.difficulty}</p>
              <p>Frequency: Every {chore.choreFrequencyDays} days</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}