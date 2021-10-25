function isNumber(number) {
  if (typeof number === "number" && number !== NaN && number !== Infinity) {
    return true;
  }
}

function add(a, b) {
  return new Promise((res, reject) => {
    if (isNumber(a) && isNumber(b)) {
      return res(a + b);
    } else reject(new Error("khong hop le"));
  });
}
add(Infinity, 2)
  .then((data) => console.log(data))
  .catch((err) => console.log(err));
