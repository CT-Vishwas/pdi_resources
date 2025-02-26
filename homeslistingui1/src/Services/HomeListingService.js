
const BASE_URL = 'http://localhost:3000/properties'

export const getAllListings = async () => {
    const options = {method: 'GET'};
    try {
        const response = await fetch(BASE_URL, options);
        const data = await response.json();
        console.log('In service',data);
        return data;
    } catch (error) {
        console.error(error);
    }
}

export const createListing = async (listing)=>{
    const options = {
        method: 'POST',
        headers: {'content-type': 'application/json'},
        body: JSON.stringify(listing)
      };
      
      try {
          const response = await fetch(BASE_URL, options);
          const data = await response.json();
          console.log(data);
      } catch (error) {
          console.error(error);
      }
}