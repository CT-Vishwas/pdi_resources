# 21 Feb 2025

- Started the session with discussing how to build a backend from scratch
- For Example: Assume you are given a problem statement
> Create a Web application for a Real Estate Company to advertise & book the properties available with them
> You have to think interms of 2 perspectives
> User
> Admin
> Then figureout the modules
> figure out pages that the app will have
> figure out the backend end points your app will have
> figure out the entities or tables for the same
> Document the abov process which will give you the clarity while building the app & keep you focused
> The draw ERD to judge the associations
> next start implementing the backend endpoints

- Next we started implementing the Home listings app 
- For each resource we have to build a minimum CRUD endpoints
- then based on requirements we can add more
- Building the express app
- In app.js

### `Lab: CRUD for property listings`  
```js
import express from 'express';

const app = express();
const PORT = 3000;

// Middleware to parse JSON data
app.use(express.json());

// Sample property data (in-memory database)
let properties = [
    { id: 1, name: "Luxury Apartment", price: 150000, location: "New York" },
    { id: 2, name: "Beach House", price: 200000, location: "California" }
];

// Route: Get all properties
app.get('/properties', (req, res) => {
    res.json(properties);
});

// Route: Get a single property by ID
app.get('/properties/:id', (req, res) => {
    const property = properties.find(p => p.id === parseInt(req.params.id));
    if (!property) return res.status(404).json({ message: "Property not found" });
    res.json(property);
});

// Route: Add a new property
app.post('/properties', (req, res) => {
    const { name, price, location } = req.body;
    const newProperty = { id: properties.length + 1, name, price, location };
    properties.push(newProperty);
    res.status(201).json(newProperty);
});

// Route: Update a property
app.put('/properties/:id', (req, res) => {
    const property = properties.find(p => p.id === parseInt(req.params.id));
    if (!property) return res.status(404).json({ message: "Property not found" });

    property.name = req.body.name || property.name;
    property.price = req.body.price || property.price;
    property.location = req.body.location || property.location;

    res.json(property);
});

// Route: Delete a property
app.delete('/properties/:id', (req, res) => {
    properties = properties.filter(p => p.id !== parseInt(req.params.id));
    res.json({ message: "Property deleted successfully" });
});

// http://localhpost:3000/properties/search?location="Bengaluru"
app.get('/properties/search',(req,res)=>{
    const location = req.query.location;
    const property = properties.find(p => p.location === location);
 
    if(!property) return res.status(404).json({message: "Property Not Found"});
 
    res.json(property);
});

// Start the server
app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});
```
Test the above api

- Created the online MongoDB
- https://www.mongodb.com
- [Atlas](http://cloud.mongodb.com)
- [Local MongoDB Download & Install](https://www.mongodb.com/products/self-managed/community-edition)
- [Compass GUI](https://www.mongodb.com/products/tools/compass) to interact with mongodb
- We can connect to DB using Express 
- [Refer](https://expressjs.com/en/guide/database-integration.html)
- We will use [Mongoose](https://github.com/Automattic/mongoose)
- Lab: Connecting to MongoDB
```js
import mongoose from 'mongoose';
const MONGO_URI= process.env.MONGO_URI
 
mongoose.connect(MONGO_URI)
    .then(()=>
        console.log("MongoongoDB Connected"))
    .catch(err => console.log(err));
```

- Then we connected to Mongodb, we learnt about schemas

```js
// Schema
const propertySchema = new mongoose.Schema({
    name: String,
    location: String,
    price: Number
});
const Property = mongoose.model('Property', propertySchema);
```

- Modify our endpoints to use this

```js
app.post('/properties',async (req, res)=>{
    // const { name, price, location } = req.body;
    // const newProperty = { id: properties.length+1, name, price, location };
    // properties.push(newProperty);
 
    // res.status(201).json(newProperty);
 
    const newProperty = new Property(req.body);
    await newProperty.save();
    res.status(201).json(newProperty);
});
 
app.get('/properties',async (req, res)=>{
    // res.json(properties);
    const properties = await Property.find();
    res.json(properties);
});
```

- Next we saw how to organize our code into different files, 
- our endpoints should work the same
- Refer the github repo for code


