"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("material-design-icons/iconfont/material-icons.css");
require("./styles/main.scss");
const n_app_1 = require("@nivinjoseph/n-app");
const shell_view_model_1 = require("./components/shell/shell-view-model");
const remote_todo_service_1 = require("./services/todo/remote-todo-service");
const list_todos_view_model_1 = require("./pages/list-todos/list-todos-view-model");
const manage_todo_view_model_1 = require("./pages/manage-todo/manage-todo-view-model");
const Routes = require("./pages/routes");
const todo_view_model_1 = require("./components/todo/todo-view-model");
class Installer {
    install(registry) {
        registry.registerSingleton("TodoService", remote_todo_service_1.RemoteTodoService);
    }
}
const client = new n_app_1.ClientApp("#app")
    .useInstaller(new Installer())
    .useAccentColor("#93C5FC")
    .registerComponents(shell_view_model_1.ShellViewModel, todo_view_model_1.TodoViewModel)
    .registerPages(list_todos_view_model_1.ListTodosViewModel, manage_todo_view_model_1.ManageTodoViewModel)
    .useAsInitialRoute(Routes.listTodos)
    .useAsUnknownRoute(Routes.listTodos)
    .useHistoryModeRouting();
client.bootstrap();
//# sourceMappingURL=client.js.map