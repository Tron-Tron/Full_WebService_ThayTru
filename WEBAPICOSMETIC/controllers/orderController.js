const Order = require("../database/models/Order");
const { asyncMiddleware } = require("../middleware/asyncMiddleware");
const ErrorRespone = require("../model/ErrorResponse");
const SuccessResponse = require("../model/SuccessResponse");

exports.createNewOrder = asyncMiddleware(async (req, res, next) => {
  const { email, product, order_desc, total, status } = req.body;
  console.log("product", product);
  const newOrder = new Order({
    email,
    product,
    order_desc,
    total,
    status,
  });
  const saved_order = await newOrder.save();
  //tao thanh cong thi 200 hoac 201
  res.status(201).json(saved_order);
});
exports.getAllOrders = asyncMiddleware(async (req, res, next) => {
  const orders = await Order.find();
  res.status(200).json(orders);
});
exports.getOrders = asyncMiddleware(async (req, res, next) => {
  const orders = await Order.find().select("-product");
  res.status(200).json(orders);
});
exports.deleteOrderById = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;
  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "OrderId is empty"));
  }
  const deletedOrder = await Order.findByIdAndDelete(orderId);
  if (!deletedOrder) {
    return next(new ErrorRespone(400, "Can not delete this order"));
  }
  res.status(200).json(new SuccessResponse(200, "Delete Successfully!"));
});
exports.updateOrderById = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;

  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }

  const updatedOrder = await Role.findOneAndUpdate({ _id: orderId }, req.body, {
    new: true,
  });
  if (!updatedOrder) {
    return next(new ErrorRespone(400, "Can not Update"));
  }
  res.status(200).json(updatedOrder);
});
exports.getProductOrder = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;
  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }
  const products = await Order.findById(orderId)
    .select("product")
    .catch((err) => {
      return next(new ErrorRespone(404, "Product is not found"));
    });
  console.log(products);
  if (products) {
    res.status(200).json(products.product);
  }
});
exports.postProductOrder = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;
  const { sku, amount, total } = req.body;
  console.log("orderId", orderId);
  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }
  console.log("product", req.body);
  const updatedOrder = await Order.findByIdAndUpdate(
    orderId,
    { $push: { product: req.body } },
    {
      new: true,
      safe: true,
      upsert: true,
    }
  );
  console.log("updatedOrder", updatedOrder);
  if (!updatedOrder) {
    return next(new ErrorRespone(400, "Can not Update"));
  }
  res.status(200).json(updatedOrder);
});
exports.deleteProductOrder = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;
  const { productId } = req.params;
  console.log(productId);
  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }
  if (!productId.trim()) {
    return next(new ErrorRespone(400, "productId is empty"));
  }
  const deletedPro = await Order.findByIdAndUpdate(
    orderId,
    { $pull: { product: { _id: productId } } },
    { new: true }
    // function (err, model) {
    //   if (err) {
    //     console.log(err);
    //     return res.send(err);
    //   }
    //   return res.status(200).json(model);
    // }
  );
  console.log("de", deletedPro);
  if (!deletedPro) {
    return next(new ErrorRespone(400, "Can not Update"));
  }
  res.status(200).json(new SuccessResponse("deleted"));
});
exports.UpdateProduct = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;
  const { productId } = req.params;
  const { sku } = req.body;

  console.log("producItd", productId);
  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }

  if (!productId.trim()) {
    return next(new ErrorRespone(400, "productId is empty"));
  }

  const updatedProduct = await Order.update(
    { "product._id": productId },
    {
      $set: {
        "product.$": req.body,
      },
    }
  );
  res.status(200).json(updatedProduct);
});
exports.updateOrder = asyncMiddleware(async (req, res, next) => {
  const { orderId } = req.params;

  if (!orderId.trim()) {
    return next(new ErrorRespone(400, "orderId is empty"));
  }

  const updatedOrder = await Order.findOneAndUpdate(
    { _id: orderId },
    req.body,
    {
      new: true,
    }
  );
  if (!updatedOrder) {
    return next(new ErrorRespone(400, "Can not Update"));
  }
  res.status(200).json(new SuccessResponse(200, updatedOrder));
});
