// import "@babel/polyfill";
import "material-design-icons/iconfont/material-icons.css";
import "./styles/main.scss";
import { ComponentInstaller, Registry } from "@nivinjoseph/n-ject";
import { ClientApp } from "@nivinjoseph/n-app";
import { ShellViewModel } from "./components/shell/shell-view-model";
import { RemoteTodoService } from "./services/todo/remote-todo-service";
import { ListTodosViewModel } from "./pages/list-todos/list-todos-view-model";
import { ManageTodoViewModel } from "./pages/manage-todo/manage-todo-view-model";
import * as Routes from "./pages/routes";
// import { LocalTodoService } from "./services/todo/local-todo-service";
import { TodoViewModel } from "./components/todo/todo-view-model";


class Installer implements ComponentInstaller
{
    public install(registry: Registry): void
    {
        // registry.registerSingleton("TodoService", LocalTodoService);
        registry.registerSingleton("TodoService", RemoteTodoService);
    }
}


const client = new ClientApp("#app")
    .useInstaller(new Installer())
    .useAccentColor("#93C5FC")
    .registerComponents(ShellViewModel, TodoViewModel)
    .registerPages(ListTodosViewModel, ManageTodoViewModel)
    .useAsInitialRoute(Routes.listTodos)
    .useAsUnknownRoute(Routes.listTodos)
    .useHistoryModeRouting();

client.bootstrap();