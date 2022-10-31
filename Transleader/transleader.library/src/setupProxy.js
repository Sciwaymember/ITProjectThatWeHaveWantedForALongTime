const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/library",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7274',
        secure: false
    });

    app.use(appProxy);
};
