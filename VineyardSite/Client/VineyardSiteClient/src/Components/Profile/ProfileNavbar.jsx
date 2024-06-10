import { Link } from "react-router-dom";

const ProfileNavbar = ({ setActiveTab, activeTab }) => {
  return (
    <div className="profile-tabs">
      <Link
        onClick={() => setActiveTab("personalInformation")}
        className={activeTab === "personalInformation" ? "activeLink" : "link"}
      >
        Personal Information
      </Link>
      <Link
        onClick={() => setActiveTab("change-password")}
        className={activeTab === "change-password" ? "activeLink" : "link"}
      >
        Change password
      </Link>
      <Link
        onClick={() => setActiveTab("add-address")}
        className={activeTab === "add-address" ? "activeLink" : "link"}
      >
        Address
      </Link>
      <Link
        onClick={() => setActiveTab("payment-methods")}
        className={activeTab === "payment-methods" ? "activeLink" : "link"}
      >
        Payment methods
      </Link>
      <Link
        onClick={() => setActiveTab("orders")}
        className={activeTab === "orders" ? "activeLink" : "link"}
      >
        Orders
      </Link>
    </div>
  );
};

export default ProfileNavbar;
