const mongoose = require("mongoose");
const connectDB = () => {
  try {
    if (!mongoose.connection.readyState) {
      mongoose
        .connect("mongodb://localhost:27017/node-course", {
          useNewUrlParser: true,
          useFindAndModify: true,
          useUnifiedTopology: true,
          useCreateIndex: true,
        })
        .then(() => {
          console.log("DB is connected");
        });
    }
  } catch (error) {}
};

exports.connectDB = connectDB;
