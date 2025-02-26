import ListingsModal from "../Components/ListingsModal";
import ListingsTable from "../Components/ListingsTable";
import React, { useEffect, useState } from "react";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useNavigate } from "react-router";
import { getAllListings } from "../Services/HomeListingService";
import "./HomePage.styles.css";

// const data = [
//   { id: 1, name: "Luxury Apt", price: 20222, location: "Bengluru" },
//   { id: 2, name: "VKS Apt", price: 20222, location: "Bengluru" },
// ];

function HomePage() {
  const [listings, setListings] = useState([]);
  const [show, setShow] = useState(false);
  const [selectedListing, setSelectedListing] = useState(null);
  let navigate = useNavigate();

  const handleClose = () => setShow(false);
  const handleSelectedListing = (listing) => {
    setSelectedListing(listing);
    setShow(true);
  };

  useEffect(() => {
    getAllListings()
      .then((data) => {
        setListings(data);
      })
      .catch((error) => {
        console.error("Error fetching products:", error);
      });
  }, []);

  const addProperty = () => {
    navigate("/addListing");
  };

  return (
    <>
      {/* <Link className="btn btn-primary" to="/addListing">
        Add Property
      </Link> */}
      <Container>
        <Col>
          <Row>
            <ListingsTable
              listings={listings}
              onSelectListing={handleSelectedListing}
            />
          </Row>
          <ListingsModal
            selectedListing={selectedListing}
            show={show}
            handleClose={handleClose}
          />
        </Col>
        <Row>
          <Button className="btn btn-success" onClick={addProperty}>
            Add Listing
          </Button>
        </Row>
      </Container>
    </>
  );
}

export default HomePage;
