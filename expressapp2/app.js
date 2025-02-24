import express from 'express';
import dotenv from 'dotenv';
import mongoose from 'mongoose';
import propertyRoutes from './src/routes/propertyRoutes.js';
import userRoutes from './src/routes/userRoutes.js';

dotenv.config();

const app = express();
const PORT = process.env.PORT || 3000;
const MONGO_URI= process.env.MONGO_URI

mongoose.connect(MONGO_URI)
    .then(()=>
        console.log("MongoDB Connected"))
    .catch(err => console.log(err));


app.use(express.json());
// app.use('/properties', propertyRoutes);
app.use('/api/properties', propertyRoutes);
app.use('/users', userRoutes);
app.listen(PORT, ()=>{
    console.log(`Server is running on http://localhost:${PORT}`);
})