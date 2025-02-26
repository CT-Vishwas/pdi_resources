import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import { Container, Row, Col } from "react-bootstrap";

function ListingsModal({ selectedListing, show, handleClose }) {
  if (show && selectedListing) {
    return (
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>{selectedListing.name}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Container>
            <Row>
              <Col>
                <strong>Price</strong>
              </Col>
              <Col>{selectedListing.price}</Col>
            </Row>
            <Row>
              <Col>
                <strong>Location</strong>
              </Col>
              <Col>{selectedListing.location}</Col>
            </Row>
          </Container>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    );
  }
}

export default ListingsModal;
