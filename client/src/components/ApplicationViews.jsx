import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "../managers/auth/AuthorizedRoute";
import Login from "../managers/auth/Login";
import Home from "./Home";
import UserProfileList from "./UserProfileList";
import UserProfileDetails from "./UserProfileDetails";  // FIX: correct import
import ChoresList from "./ChoresList";
import ChoreDetails from "./ChoreDetails";
import CreateChore from "./CreateChore"; 
import MyChores from "./MyChores";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <Home />
          </AuthorizedRoute>
        }
      />
      <Route path="login" element={<Login setLoggedInUser={setLoggedInUser} />} />
      
      <Route path="/userprofiles">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <UserProfileList />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <UserProfileDetails />
            </AuthorizedRoute>
          }
        />
      </Route>

      <Route path="/chores">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ChoresList loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <ChoreDetails />
            </AuthorizedRoute>
          }
        />
        <Route
          path="create"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <CreateChore />
            </AuthorizedRoute>
          }
        />
      </Route>

      <Route path="*" element={<p>Whoops, nothing here...</p>} />
      <Route
  path="/mychores"
  element={
    <AuthorizedRoute loggedInUser={loggedInUser}>
      <MyChores loggedInUser={loggedInUser} />
    </AuthorizedRoute>
  }
/>
    </Routes>
  );
}