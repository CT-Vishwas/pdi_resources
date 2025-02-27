import ListingsModal from "../Components/ListingsModal";
import ListingsTable from "../Components/ListingsTable";
import React, { useEffect, useState } from "react";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useNavigate } from "react-router";

const data = [
  { id: 1, name: "Luxury Apt", price: 20222, location: "Bengluru" },
  { id: 2, name: "VKS Apt", price: 20222, location: "Bengluru" },
];

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
    setListings(data);
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
            <Button onClick={addProperty}>Add Listing</Button>
          </Row>
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
      </Container>
    </>
  );
}

export default HomePage;
