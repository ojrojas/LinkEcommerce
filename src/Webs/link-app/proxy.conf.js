module.exports = {
  "/identity": {
    target:
      process.env["services__identity-ecommerce__https__0"] ||
      process.env["services__identity-ecommerce__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/identity": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/catalogs": {
    target:
      process.env["services__catalogs-ecommerce__https__0"] ||
      process.env["services__catalogs-ecommerce__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/catalogs": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/basket": {
    target:
      process.env["services__basket-ecommerce__https__0"] ||
      process.env["services__basket-ecommerce__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/basket": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/orders": {
    target:
      process.env["services__orders-ecommerce__https__0"] ||
      process.env["services__orders-ecommerce__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/orders": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },


};

console.log(module.exports);
