const express = require("express");
const { authorize } = require("../../middleware/authorize");
const { jwtAuth } = require("../../middleware/jwtAuth");
const userController = require("../../controllers/userController");
const router = express.Router();

router.get("/all", userController.getAllUsers);
router.get("/:userId", userController.getUserById);
router.post("/", userController.createNewUser);
router.delete("/:userId", userController.deleteUserById);
router.patch("/:userId", userController.updateUserById);

module.exports = router;
//put: -> thay the record cu bang record moi
//patch: -> update field trong record
