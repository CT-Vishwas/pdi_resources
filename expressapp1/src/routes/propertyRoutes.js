import express from 'express';

import {
    getAllProperties,
    getPropertyById,
    createProperty
} from '../controllers/propertyController.js';

const router = express.Router();

router.get('/', getAllProperties);
router.get('/:propertyId', getPropertyById);
router.post('/', createProperty);

export default router;