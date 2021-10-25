const express = require("express");
const productController = require("../../controllers/productController");
const { authorize } = require("../../middleware/authorize");
const { jwtAuth } = require("../../middleware/jwtAuth");
const router = express.Router();

router
  .route("/")
  .get(productController.getAllProducts)
  .post(productController.createNewProduct);

router
  .route("/:productId")
  .get(productController.getProductById)
  .delete(productController.deleteProductById)
  .patch(productController.updateProductById);
module.exports = router;
