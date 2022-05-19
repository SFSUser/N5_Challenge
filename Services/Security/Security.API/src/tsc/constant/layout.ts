import { Layout } from "../entity/common/CommonEntity";
import * as I from 'react-feather';
import PermissionPage from "../page/PermissionPage";

const layout: any = {
    LOGIN: new Layout({
        login: false,
        title: "Iniciar sesión",
        path: "/",
        component: PermissionPage,
        icon: I.LogIn,
        permission: [],
        helmet: false
    })
}

export const LAYOUT: any = Object.values(layout);