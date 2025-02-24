import Property from "../models/propertyModel.js";

export const getAllProperties = async (req, res)=>{
    // res.json(properties);
    const properties = await Property.find();
    res.json(properties);
};


export const getPropertyById = async (req, res)=>{
    // const property = properties.find(p => p.id === parseInt(req.params.propertyId));

    // if(!property) return res.status(404).json({message: "Property Not Found"});

    // res.json(property);

    const property = await Property.findById(req.params.propertyId);
    if(!property) return res.status(404).json({message: "Property Not Found"});
    res.json(property);
};


export const createProperty = async (req, res)=>{
    // const { name, price, location } = req.body;
    // const newProperty = { id: properties.length+1, name, price, location };
    // properties.push(newProperty);

    // res.status(201).json(newProperty);

    const newProperty = new Property(req.body);
    await newProperty.save();
    res.status(201).json(newProperty);
};