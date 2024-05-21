import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import notify from "../Utils/Notify";
import "../index.css";

function LogoutButton() {
    const navigate = useNavigate();
    const location = useLocation();

    async function handleLogout() {
        try {
            const response = await fetch("/api/Auth/Logout", {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json",
                },
            });
            if (response.ok) {
                if (location.pathname !== "/") {
                    navigate("/");
                    window.location.reload();
                } else {
                    window.location.reload();
                }
            }
        } catch (error) {
            notify("Logout failed!", "error");
            console.error("Logout failed", error);
        }
    }
    return <button className="homeButton" onClick={handleLogout}>Logout</button>;
}

export default LogoutButton;