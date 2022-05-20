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

export class PermissionType {
    public id: number = 0;
    public descripcion: Date;
}
