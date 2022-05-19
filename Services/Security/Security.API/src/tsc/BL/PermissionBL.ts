import Permission from '../entity/user/PermissionEntity';
import Request from '../helper/Request';
import { USER_ACTIONS } from '../constant/API';
import { HttpResponse } from '../entity/common/CommonEntity';

export default class PermissionBL {

    public static async modifyPermission(user: Permission): Promise<HttpResponse> {
        let result: HttpResponse = null;
        if(user.id > 0){
            result = await Request.put(USER_ACTIONS.API_MODIFY_PERMISSION, user);
        } else {
            result = await Request.put(USER_ACTIONS.API_MODIFY_PERMISSION, user);
        }
        var response = new HttpResponse();
        response.result = true;
        return response;
    }

    public static async getPermissions() {
        let response = await Request.get(USER_ACTIONS.API_GET_PERMISSIONS);
        response.data = response.data;
        response.data = response.getList<Permission>(Permission);
        return response;
    }

    public static async getPermission(id: number) {
        let response = await Request.get(USER_ACTIONS.API_REQUEST_PERMISION);
        response.data = response.data;
        response.data = response.getElement<Permission>(Permission);
        return response;
    }
}