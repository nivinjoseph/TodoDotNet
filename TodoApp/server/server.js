"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const n_web_1 = require("@nivinjoseph/n-web");
const n_config_1 = require("@nivinjoseph/n-config");
const index_controller_1 = require("./controllers/index/index-controller");
const server = new n_web_1.WebApp(n_config_1.ConfigurationManager.getConfig("PORT"))
    .enableWebPackDevMiddleware()
    .registerStaticFilePath("client/dist", true)
    .registerControllers(index_controller_1.IndexController);
server.bootstrap();
//# sourceMappingURL=server.js.map