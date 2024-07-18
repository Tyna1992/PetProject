import React from "react";
import { useState } from "react";
import notify from "../../Utils/Notify";
import "./ContactForm.css";

const ContactForm = () => {
  const [formData, setFormData] = useState({
    email: "",
    name: "",
    subject: "",
    message: "",
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("/api/EmailSender/sendContactEmail", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });
      if (response.ok) {
        notify("Email sent successfully!", "success");
        setFormData({
          email: "",
          name: "",
          subject: "",
          message: "",
        });
      } else {
        notify("Email sending failed!", "error");
      }
    } catch (error) {
      console.error(error);
      notify("Email sending failed!", "error");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="contact-form">
        <h2>Contact us</h2>
        <label>Email:</label>
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
        <label>Name:</label>
        <input
          type="text"
          name="name"
          value={formData.name}
          onChange={handleChange}
          required
        />
        <label>Subject:</label>
        <input
          type="text"
          name="subject"
          value={formData.subject}
          onChange={handleChange}
          required
        />
        <label>Message:</label>
        <textarea
          name="message"
          value={formData.message}
          onChange={handleChange}
          required
        />
      </div>
      <button className="contact-form-submit" type="submit">
        Send
      </button>
    </form>
  );
};

export default ContactForm;
