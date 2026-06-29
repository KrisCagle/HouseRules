import { useState, useEffect } from "react";
import { getProfileById } from "../managers/userProfileManager";
import { useParams } from "react-router-dom";

export default function UserProfileDetails() {
  const { id } = useParams();
  const [profile, setProfile] = useState(null);  // FIX: null not []
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getProfileById(id)  // FIX: add id parameter
      .then((data) => {
        setProfile(data);  // FIX: use profile not details
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching details:", err);
        setLoading(false);
      });
  }, [id]);  // FIX: add id to dependency array

  if (loading) return <div>Loading Details...</div>;
  if (!profile) return <div>Profile not found</div>;

  return (
    <div className="container mt-5">
      <h1>{profile.firstName} {profile.lastName}</h1>

      <div className="border p-3 mb-4">
        <h3>Profile Info</h3>
        <p>
          <strong>Email:</strong> {profile.email}
        </p>
        <p>
          <strong>Address:</strong> {profile.address}
        </p>
      </div>

      <div className="border p-3 mb-4">
        <h3>Assigned Chores</h3>
        {profile.choreAssignments && profile.choreAssignments.length > 0 ? (
          <ul>
            {profile.choreAssignments.map((assignment) => (
              <li key={assignment.id}>{assignment.chore.name}</li>
            ))}
          </ul>
        ) : (
          <p>No chores assigned</p>
        )}
      </div>

      <div className="border p-3">
        <h3>Completed Chores</h3>
        {profile.choreCompletions && profile.choreCompletions.length > 0 ? (
          <ul>
            {profile.choreCompletions.map((completion) => (
              <li key={completion.id}>
                {completion.chore.name} - Completed on{" "}
                {new Date(completion.completedOn).toLocaleDateString()}
              </li>
            ))}
          </ul>
        ) : (
          <p>No chores completed</p>
        )}
      </div>
    </div>
  );
}