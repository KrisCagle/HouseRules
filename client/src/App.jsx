import { useState, useEffect } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";

function App() {
  const [loggedInUser, setLoggedInUser] = useState(null);

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  console.log("loggedInUser:", loggedInUser);

  return (
    <>
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  );
}

export default App;