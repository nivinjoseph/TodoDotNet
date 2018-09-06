"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const n_web_1 = require("@nivinjoseph/n-web");
const n_config_1 = require("@nivinjoseph/n-config");
let IndexController = class IndexController extends n_web_1.Controller {
    execute() {
        return Promise.resolve({
            config: {
                apiUrl: n_config_1.ConfigurationManager.getConfig("apiUrl")
            }
        });
    }
};
IndexController = __decorate([
    n_web_1.route("/*"),
    n_web_1.httpGet,
    n_web_1.view("~/client/dist/index-view.html")
], IndexController);
exports.IndexController = IndexController;
//# sourceMappingURL=index-controller.js.map