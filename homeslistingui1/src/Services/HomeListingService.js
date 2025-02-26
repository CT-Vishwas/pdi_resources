
const BASE_URL = 'http://localhost:3000/'

const getAllListings = async () => {
    const url = BASE_URL+'properties'
    const options = {method: 'GET'};

try {
    const response = await fetch(url, options);
    const data = await response.json();
    console.log(data);
    return data;
} catch (error) {
    console.error(error);
}
}

export default getAllListings;