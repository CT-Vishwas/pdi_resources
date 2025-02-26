import { useState } from "react";
import { createListing } from "../Services/HomeListingService";
import { useNavigate } from "react-router";

function AddListing() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    name: "",
    price: 0,
    location: "",
  });

  const [name, setName] = useState("");
  const [price, setPrice] = useState(0);
  const [location, setLocation] = useState("");

  const handleChange = (event) => {
    const { name, value } = event.target;
    switch (name) {
      case "name":
        setName(value);
        break;
      case "price":
        setPrice(parseFloat(value)); // Ensure price is a number
        break;
      case "location":
        setLocation(value); // Ensure quantity is an integer
        break;
      default:
        break;
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const formData = { name, price, location };
    console.log(`Form submitted ${JSON.stringify(formData)}`);
    createListing(formData)
      .then((data) => {
        console.log("New Listing Created", data);
        navigate("/");
      })
      .catch((error) => {
        console.log(error);
      });

    setFormData({
      name: "",
      price: 0,
      location: "",
    });
  };
  return (
    <form onSubmit={handleSubmit}>
      <div
        className="container"
        style={{
          padding: "10px",
          display: "flex",
          flexDirection: "column",
          justifyContent: "space-evenly",
        }}
      >
        <label htmlFor="name">Name: </label>
        <input
          name="name"
          id="name"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
        <label htmlFor="price">Price: </label>
        <input
          name="price"
          id="price"
          type="number"
          className="form-control"
          onChange={handleChange}
        />

        <label htmlFor="location">Location: </label>
        <input
          name="location"
          id="location"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
        <button type="submit">Add Property</button>
      </div>
    </form>
  );
}

export default AddListing;
