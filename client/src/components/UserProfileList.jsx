import { useState, useEffect } from "react";
import { getAllProfiles } from "../managers/userProfileManager";
import { Link } from "react-router-dom";

export default function UserProfileList() {
    const [profiles, setProfiles] =useState([]);
    const [loading, setLoading] =useState(true);

    useEffect(() => {
        getAllProfiles()
        .then((data) => {
            setProfiles(data);
            setLoading(false);
        })
        .catch((err) =>{
            console.error("Error fetching profiles:", err);
            setLoading(false);
        });
    }, []);


   if (loading) return <div> Loading Profiles... </div> 

   return (
    <div className="container mt-5">
        <h1>Profiles</h1>
        <div className="row">
            {profiles.map((profile) => (
                <div key={profile.id} className="col-md-4 mb-3">
                    <div className="border p-3">
                       <h5>{profile.firstName} {profile.lastName}</h5>
                        <p>Email: {profile.email}</p>
                        <p>Address: {profile.address}</p>
                        <Link to={`/userprofiles/${profile.id}`}>Details</Link>
                    </div>
                </div>
            ))}
        </div>
    </div>
   )
}