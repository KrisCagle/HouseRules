import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { getAllChores, deleteChore, completeChore } from "../managers/choreManager";


export default function ChoresList({ loggedInUser }) {
    const [chores, setChores] = useState([]);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        getAllChores()
        .then((data) => {
            setChores(data);
            setLoading(false);
        })
        .catch((err) => {
            console.error("Error fetching details", err);
            setLoading(false);
        });
    }, []);

    if (loading) return <div>Loading Chores</div>
    if (!chores || chores.length === 0) return <div>List not found</div>

    const handleDelete = (choreId) => {
        deleteChore(choreId).then(() => {
            setChores(chores.filter(c => c.id !== choreId));
        });
    };

    const handleComplete = (choreId) => {
        completeChore(choreId, loggedInUser.id).then(() => {
            alert("Chore completed!");
        }).catch((err) => {
            console.error("Error completing chore:", err);
        });
    };

    return (
        <div className="container mt-5">
            <h1>Chores</h1>
            {loggedInUser?.roles?.includes("Admin") && (
                <Link to="/chores/create" className="btn btn-primary mb-3">
                    Create New Chore
                </Link>
            )}
            <div className="row">
                {chores.map((chore) => (
                    <div key={chore.id} className="col-md-4 mb-3">
                        <div className="border p-3">
                            <h5>{chore.name}</h5>
                            <p>Difficulty: {chore.difficulty}</p>
                            <p>Frequency: Every {chore.choreFrequencyDays} days</p>
                            <button 
                                className="btn btn-success btn-sm me-2"
                                onClick={() => handleComplete(chore.id)}
                            >
                                Complete
                            </button>
                            {loggedInUser?.roles?.includes("Admin") && (
                                <button 
                                    className="btn btn-danger btn-sm"
                                    onClick={() => handleDelete(chore.id)}
                                >
                                    Delete
                                </button>
                            )}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}