import Permission from "tsc/entity/user/PermissionEntity";
import IState from "../../../core/IState";

export default class PermissionPageState implements IState {
    public permissions: Permission[] = [];
    public permission: Permission = null;
    public busy: boolean = false;
}