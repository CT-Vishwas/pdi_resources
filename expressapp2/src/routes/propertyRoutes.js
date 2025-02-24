import express from 'express';

import {
    getAllProperties,
    getPropertyById,
    createProperty
} from '../controllers/propertyController.js';
import authMiddleware from '../middleware/authMiddleware.js';

const router = express.Router();

router.get('/', authMiddleware, getAllProperties);
router.get('/:propertyId', authMiddleware, getPropertyById);
router.post('/',authMiddleware, createProperty);

export default router;