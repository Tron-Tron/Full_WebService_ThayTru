const express = require("express");
const { authorize } = require("../../middleware/authorize");
const { jwtAuth } = require("../../middleware/jwtAuth");
const categoryController = require("../../controllers/categoryController");
const router = express.Router();

//router.use(jwtAuth, authorize("admin"));

router.delete("/:categoryId", categoryController.deleteCategoryById);
router.get("/name", categoryController.getAllCategoryJustName);
router.get("/:categoryId", categoryController.getCategoryById);
router.patch("/:categoryId", categoryController.updateCategoryById);
router.get("/", categoryController.getAllCategory);
router.post("/", categoryController.createNewCategory);
// router.get("/:name", categoryController.getProductByCategory);
module.exports = router;
