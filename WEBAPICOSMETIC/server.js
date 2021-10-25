const express = require("express");

const { connectDB } = require("./database/connectDB");
const app = express();
const auth = require("./route/api/auth");
const PORT = 3000;
const { errorMiddleware } = require("./middleware/errorMiddleware");

const user = require("./route/api/user");
const product = require("./route/api/product");
const category = require("./route/api/category");
const order = require("./route/api/order");

const dotenv = require("dotenv");
const cors = require("cors");
//config env
dotenv.config();

//middleware parse body
app.use(express.json());
app.use(cors());
console.log(process.env.JWT_KEY);
connectDB();
//route
app.use("/api/v1/auth", auth);
app.use("/api/v1/user", user);

app.use("/api/v1/product", product);
app.use("/api/v1/order", order);

app.use("/api/v1/category", category);
//viet duoi route
app.use(errorMiddleware);

app.listen(PORT, () => {
  console.log(`server is running in port ${PORT}`);
});
