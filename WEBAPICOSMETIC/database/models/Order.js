const mongoose = require("mongoose");
const { Schema } = mongoose;

const OrderSchema = new Schema(
  {
    email: {
      type: String,
      required: [true, "email is required"],
    },
    product: [
      {
        sku: {
          type: String,
          required: true,
        },
        amount: {
          type: Number,
          required: true,
        },
        total: {
          type: Number,
          required: true,
        },
      },
    ],
    order_desc: {
      type: String,
      required: [true, "Description is required"],
    },
    total: {
      type: Number,
      required: [true, "total is required"],
    },

    status: {
      type: Number,
      enum: [1, 0],
      required: true,
      default: 1,
    },
  },
  {
    toJSON: { virtuals: true },
    timestamps: true,
  }
);

module.exports = mongoose.model("Order", OrderSchema);
