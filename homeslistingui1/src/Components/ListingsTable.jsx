import { Button, Table } from "react-bootstrap";

export default function ListingsTable({ listings, onSelectListing }) {
  const listOfProperties = listings.map((property, idx) => (
    <tr key={property.id}>
      <td>{idx + 1}</td>
      <td>{property.name}</td>
      <td>{property.price}</td>
      <td>{property.location}</td>
      <td>
        <Button variant="primary" onClick={() => onSelectListing(property)}>
          View
        </Button>{" "}
      </td>
    </tr>
  ));
  return (
    <>
      {listOfProperties && listOfProperties.length > 0 ? (
        <Table striped bordered hover>
          <thead>
            <tr>
              <th scope="row">Sl. No</th>
              <th>Name</th>
              <th>Price</th>
              <th>Location</th>
            </tr>
          </thead>
          <tbody>{listOfProperties}</tbody>
        </Table>
      ) : (
        <h1>No Data Available</h1>
      )}
    </>
  );
}
