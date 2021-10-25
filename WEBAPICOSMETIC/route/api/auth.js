const express = require("express");
const route = express.Router();
const authController = require("../../controllers/authController");

//authentication va authorization

//authentication: noi ve thong tin cua user dang hoat dong
//authorization: xac dinh  quyen cua user de su dung

// route.get(
//   "/test",
//   jwtAuth,
//   authorize("admin"),
//   asyncMiddleware(async (req, res, next) => {
//     res.status(200).json({ success: true });
//   })
// );

route.post("/register", authController.register);
route.post("/login", authController.login);

module.exports = route;
