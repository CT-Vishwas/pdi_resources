import { useState } from "react";

function AddListing() {
  const [formData, setFormData] = useState({
    name: "",
    price: 0,
    location: "",
  });

  //   const [formErrors, setFormerrors] = useState({});
  //   const [submitted, setSubmitted] = useState(false);

  //   const handleChange = (e) => {
  //     const { name, value } = e.target;
  //     setFormData({
  //       ...formData,
  //       [name]: value,
  //     });
  //   };

  //   const validateForm = () => {
  //     let errors = {};
  //   };

  const handleSubmit = (e) => {
    e.preventDefault();
    // if(validateForm){
    // }
    console.log(`Form submitted ${formData}`);

    setFormData({
      name: "",
      price: 0,
      location: "",
    });
  };
  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="name">Name: </label>
        <input name="name" id="name" type="text" />
        <label htmlFor="price">Price: </label>
        <input name="price" id="price" type="number" />

        <label htmlFor="location">Location: </label>
        <input name="location" id="location" type="text" />
        <button type="submit">Add Property</button>
      </div>
    </form>
  );
}

export default AddListing;
