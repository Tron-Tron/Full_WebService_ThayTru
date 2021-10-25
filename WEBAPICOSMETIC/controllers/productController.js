const Product = require("../database/models/Product");
const { asyncMiddleware } = require("../middleware/asyncMiddleware");
const ErrorRespone = require("../model/ErrorResponse");
const SuccessResponse = require("../model/SuccessResponse");

exports.getAllProducts = asyncMiddleware(async (req, res, next) => {
  const product = await Product.find();
  res.status(200).json(product);
});
exports.createNewProduct = asyncMiddleware(async (req, res, next) => {
  const {
    sku,
    name_product,
    price,
    quantity,
    category,
    description,
    image,
  } = req.body;
  // console.log(req.body);
  const newProduct = new Product({
    sku,
    name_product,
    price,
    quantity,
    category,
    description,
    image,
  });
  console.log(newProduct);
  const saved_product = await newProduct.save();
  //tao thanh cong thi 200 hoac 201
  res.status(201).json(saved_product);
});
exports.deleteProductById = asyncMiddleware(async (req, res, next) => {
  const { productId } = req.params;

  //tim productId tren database
  const doc = await Product.findByIdAndDelete(productId);
  if (!doc) {
    return next(new ErrorRespone(404, "productId is not found"));
  }
  res
    .status(200)
    .json(new SuccessResponse(200, `product has is ${productId} was deleted`));
});
exports.getProductById = asyncMiddleware(async (req, res, next) => {
  const { productId } = req.params;

  //tim productId tren database
  const doc = await Product.findById(productId).populate({
    path: "category_detail",
  });
  if (!doc) {
    return next(new ErrorRespone(404, "productId is not found"));
  }
  res.status(200).json(new SuccessResponse(200, doc));
});
exports.updateProductById = asyncMiddleware(async (req, res, next) => {
  const { productId } = req.params;

  if (!productId.trim()) {
    return next(new ErrorRespone(400, "productId is empty"));
  }

  const updatedProduct = await Product.findOneAndUpdate(
    { _id: productId },
    req.body,
    {
      new: true,
    }
  );
  if (!updatedProduct) {
    return next(new ErrorRespone(400, "Can not Update"));
  }
  res.status(200).json(new SuccessResponse(200, updatedProduct));
});
