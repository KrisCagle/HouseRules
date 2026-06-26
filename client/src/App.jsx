import { useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
// import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";

function App() {
  const [loggedInUser, setLoggedInUser] = useState(null);

  return (
    <>
      {/* <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} /> */}
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  );
}

export default App;