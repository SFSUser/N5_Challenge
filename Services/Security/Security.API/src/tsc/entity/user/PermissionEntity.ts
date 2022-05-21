/**
 * Permission entity
 * @class Permission
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class Permission {
    constructor(){
        let me = this;
    }

    public id: number = 0;
    public nombreEmpleado: string = "";
    public apellidoEmpleado: string = "";
    public tipoPermiso: number = 0;
    public fechaPermiso: string = "";
    public permissionType: PermissionType;
}

/**
 * Permission type
 * @class PermissionType
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export class PermissionType {
    public id: number = 0;
    public descripcion: Date;
}
