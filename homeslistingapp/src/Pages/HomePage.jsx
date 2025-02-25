import Footer from "../Components/Footer";
import Header from "../Components/Header";
import ListingsModal from "../Components/ListingsModal";
import ListingsTable from "../Components/ListingsTable";
import React, { useState } from "react";

function HomePage() {
  const listings = [
    { id: 1, name: "Luxury Apt", price: 20222, location: "Bengluru" },
    { id: 2, name: "VKS Apt", price: 20222, location: "Bengluru" },
  ];

  const [show, setShow] = useState(false);
  const [selectedListing, setSelectedListing] = useState(null);

  const handleClose = () => setShow(false);
  const handleSelectedListing = (listing) => {
    setSelectedListing(listing);
    setShow(true);
  };
  return (
    <>
      <Header />
      <ListingsTable
        listings={listings}
        onSelectListing={handleSelectedListing}
      />
      <ListingsModal
        selectedListing={selectedListing}
        show={show}
        handleClose={handleClose}
      />
      <Footer />
    </>
  );
}

export default HomePage;
