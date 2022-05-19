import IState from "../../../core/IState";
import Permission from "../PermissionEntity";

export default class PermissionFormState implements IState {
    public permission: Permission = new Permission();
}