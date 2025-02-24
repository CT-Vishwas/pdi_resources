import User from "../models/userModel.js";
import dotenv from 'dotenv';
import bcrypt from 'bcryptjs';
import jwt from 'jsonwebtoken';

dotenv.config()


export const registerUser = async (req,res) =>{
    try{
        const { name, email, password } = req.body;

        // Check if user exists
        let user = await User.findOne({email});
        if (user) return res.status(400).json({message: "User Exists"});

        // Hash the password
        const hashedPassword = await bcrypt.hash(password, 10);

        // Create the new user
        user = new User({name, email, password: hashedPassword });
        await user.save();

        res.status(201).json({message: "User registered sucessfully"});
    } catch(error){
        res.status(500).json({ message: error.message });
    }
}


export const loginUser = async (req, res)=>{
    try{
        const { email, password } = req.body;

        // Check if the user exists
        const user = await User.findOne({email});
        if(!user) return res.status(400).json({message: "Invalid Email"});

        // validate the password
        const isMatch = await bcrypt.compare(password, user.password);
        if(!isMatch) return res.status(400).json({ message: "Invalid email or password"});

        // Generate the token
        const token = jwt.sign({id: user._id, email: user.email }, process.env.JWT_SECRET, { expiresIn: '1h'});

        res.json({ token });
    } catch(error){
        res.status(500).json({ message: error.message });
    }
}