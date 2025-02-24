import mongoose from "mongoose";

// Schema
const propertySchema = new mongoose.Schema({
    name: String,
    location: String,
    price: Number
});
const Property = mongoose.model('Property', propertySchema);

export default Property;