import IProp from "../../../core/IProp";
import Permission from "../PermissionEntity";

export default class PermissionFormProp implements IProp {
    public permission: Permission = null;
    public onClose: CallableFunction = null;
}