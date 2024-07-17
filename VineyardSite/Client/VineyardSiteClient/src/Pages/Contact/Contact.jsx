import React from "react";
import ContactForm from "../../Components/ContactForm/ContactForm";
import "./Contact.css";

const Contact = () => {
  return (
    <div className="contact-container">
      <div className="contact-img">
        <img
          src="https://ewineasia.com/image/catalog/alfainternational/Page%20Banner/winebanner.jpg"
          alt="Csobancy Bormanufaktura"
        />
        <div className="contact-text">
          <h1>Contact</h1>
        </div>
      </div>
      <div className="contact-content">
        <div className="contact-vinery">
          <h2>Csobánc Vinery</h2>
          <p>
            <b>Csobánci Bormanufacture</b>
          </p>
          <p>Tapolca, Hosszú-hegy 1, 8297</p>
          <p>Email: csobancibormanufaktura@gmail.com</p>
          <br />
          <p>
            <b>Opening hours:</b>
          </p>
          <p>Mondey-Friday: 8-17 h</p>
          <p>Saturday: 9-13 h</p>
          <br />
          <p>
            <b>Phone number:</b>
          </p>
          <p>+36 (30) 549 6073</p>
        </div>
        <div className="contact-office">
          <h2>Csobánc Office</h2>
          <p>Tapolca, Hosszú-hegy 1, 8297</p>
          <p>Email: office.csobancibormanufaktura@gmail.com</p>
          <br />
          <br />
          <p>
            <b>Opening hours:</b>
          </p>
          <p>Monday-Friday: 8-17 h</p>
          <p>Lunch break: 12-13 h</p>
          <br />
          <p>
            <b>Phone number:</b>
          </p>
          <p>+36 (87) 123 456</p>
        </div>
      </div>
      <ContactForm />
    </div>
  );
};

export default Contact;
