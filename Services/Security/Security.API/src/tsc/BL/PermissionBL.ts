import Permission from '../entity/user/PermissionEntity';
import Request from '../helper/Request';
import { USER_ACTIONS } from '../constant/API';
import { HttpResponse } from '../entity/common/CommonEntity';

/**
 * Manages the connection to the permissions API
 * @class PermissionBL
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class PermissionBL {
    /**
     * Modify permission
     * @param permission 
     * @returns response
     */
    public static async modifyPermission(permission: Permission): Promise<HttpResponse> {
        let result: HttpResponse = null;
        if(permission.id > 0){
            result = await Request.post(USER_ACTIONS.API_MODIFY_PERMISSION + permission.id, permission)
        } else {
            result = await Request.post(USER_ACTIONS.API_MODIFY_PERMISSION + permission.id, permission);
        }
        var response = new HttpResponse();
        response.result = true;
        return response;
    }

    /**
     * Get Permissions list
     * @returns response
     */
    public static async getPermissions() {
        let response = await Request.get(USER_ACTIONS.API_GET_PERMISSIONS);
        response.data = response.data;
        response.data = response.getList<Permission>(Permission);
        return response;
    }

    /**
     * Get Permission by id
     * @param id 
     * @returns response
     */
    public static async getPermission(id: number) {
        let response = await Request.get(USER_ACTIONS.API_REQUEST_PERMISION + id);
        response.data = response.data;
        response.data = response.getElement<Permission>(Permission);
        return response;
    }
}