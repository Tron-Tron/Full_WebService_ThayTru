const express = require("express");
const { authorize } = require("../../middleware/authorize");
const { jwtAuth } = require("../../middleware/jwtAuth");
const orderController = require("../../controllers/orderController");
const router = express.Router();

// router.use(jwtAuth, authorize("guest"));
router
  .route("/")
  .post(orderController.createNewOrder)
  .get(orderController.getAllOrders);
router.get("/load", orderController.getOrders);
router.get("/:orderId", orderController.getProductOrder);
router.delete("/:orderId", orderController.deleteOrderById);
router.delete("/:orderId/:productId", orderController.deleteProductOrder);
router.patch("/:orderId", orderController.postProductOrder);
router.patch("/:orderId/:productId", orderController.UpdateProduct);
router.patch("update/:orderId", orderController.updateOrder);
//router.patch("/:orderId", orderController.updateOrderById);
module.exports = router;
