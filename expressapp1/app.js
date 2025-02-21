import express from 'express';
import dotenv from 'dotenv';
import mongoose from 'mongoose';

dotenv.config();

const app = express();
const PORT = process.env.PORT || 3000;
const MONGO_URI= process.env.MONGO_URI

mongoose.connect(MONGO_URI)
    .then(()=>
        console.log("MongoDB Connected"))
    .catch(err => console.log(err));


app.use(express.json());

// let properties = [
//     {id:1, name: "Luxury Apartments", price: 1500000, location:"Bengaluru"},
//     {id:2, name: "LakeView", price: 1000000, location:"Bengaluru"},
// ];


// Schema
const propertySchema = new mongoose.Schema({
    name: String,
    location: String,
    price: Number
});
const Property = mongoose.model('Property', propertySchema);


app.get('/properties',async (req, res)=>{
    // res.json(properties);
    const properties = await Property.find();
    res.json(properties);
});


app.get('/properties/:propertyId', async (req, res)=>{
    // const property = properties.find(p => p.id === parseInt(req.params.propertyId));

    // if(!property) return res.status(404).json({message: "Property Not Found"});

    // res.json(property);

    const property = await Property.findById(req.params.propertyId);
    if(!property) return res.status(404).json({message: "Property Not Found"});
    res.json(property);
});

// http://localhpost:3000/properties/search?location="Bengaluru"
// app.get('/properties/search',(req,res)=>{
//     const location = req.query.location;
//     console.log('Location: ',location);
//     const property = properties.find(p => p.location == location);

//     if(!property) return res.status(404).json({message: "Property Not Found"});

//     res.json(property);
// });


app.post('/properties',async (req, res)=>{
    // const { name, price, location } = req.body;
    // const newProperty = { id: properties.length+1, name, price, location };
    // properties.push(newProperty);

    // res.status(201).json(newProperty);

    const newProperty = new Property(req.body);
    await newProperty.save();
    res.status(201).json(newProperty);
});

app.listen(PORT, ()=>{
    console.log(`Server is running on http://localhost:${PORT}`);
})