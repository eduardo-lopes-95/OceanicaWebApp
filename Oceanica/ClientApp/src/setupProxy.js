const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = 'https://localhost:44498';

const context =  [
  "/Contract",
  "/Vessel",
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
