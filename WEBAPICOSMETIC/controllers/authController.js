const User = require("../database/models/User");
const { asyncMiddleware } = require("../middleware/asyncMiddleware");
const ErrorRespone = require("../model/ErrorResponse");
const jwt = require("jsonwebtoken");
const SuccessResponse = require("../model/SuccessResponse");

exports.register = asyncMiddleware(async (req, res, next) => {
  const { name, phone, address, email, password } = req.body;
  const newUser = new User({ name, phone, address, email, password });
  const saved_user = await newUser.save();
  res.status(201).json(new SuccessResponse(201, saved_user));
  //Su dung UserSchema de luu du lieu len MongoDB
});

exports.login = asyncMiddleware(async (req, res, next) => {
  const { email, password } = req.body;
  const isExistEmail = await User.findOne({ email });
  if (isExistEmail) {
    //neu ton tai user tren database
    const isMatchPassword = await User.comparePassword(
      password,
      isExistEmail.password
    );
    if (isMatchPassword) {
      //generate jsonwebtoken
      //payload la nhung thu muon luu trong token

      const token = jwt.sign(
        {
          //payload
          email: isExistEmail.email,
          name: isExistEmail.name,
          phone: isExistEmail.phone,
          address: isExistEmail.address,
          role: isExistEmail.role,
        },
        process.env.JWT_KEY //secret key
      );
      console.log(token);
      return res.status(200).json(
        new SuccessResponse(200, {
          token,
          role: isExistEmail.role,
          email: isExistEmail.email,
          name: isExistEmail.name,
          phone: isExistEmail.phone,
          address: isExistEmail.address,
        })
      );
    } else {
      return next(new ErrorRespone(404, "Password is incorrect"));
    }
  } else {
    //404: http status khi khong tim thay tai nguyen
    return next(new ErrorRespone(404, "Email is not found"));
  }
});
