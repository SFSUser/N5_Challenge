import Swal, { SweetAlertIcon, SweetAlertResult } from "sweetalert2";
import { HttpResponse } from "../../entity/common/CommonEntity";

/**
 * Alert messages utilities
 * @class Alert
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class Alert {
    private static successMessage: string = "La acción se realizó correctamente";
    private static errorMessage: string = "Ocurrió un error";

    /**
     * Show alert
     */
    public static async show(title: string, message: string, icon: SweetAlertIcon = "info") {
        
        return await Swal.fire(title, message, icon);
    }

    /**
     * Alert from result
     */
    public static result(
            { result = null, state = false, success = Alert.successMessage, error = Alert.errorMessage}
            :
            { result: HttpResponse, state?: boolean, success?: string, error?: string }
        ) {
        state = result != null ? result.result : state;
        let me = this;
        if(state) {
            me.success(success);
        } else {
            me.error(error);
        }
    }

    /**
     * Error alert
     */
    public static async error(message: string = Alert.errorMessage) {
        let me = this;
        return me.show("Error", message, "error");
    }
    
    /**
     * Success alert
     */
    public static async success(message: string = Alert.successMessage) {
        let me = this;
        return me.show("Correcto", message, "success");
    }

    /**
     * Confirm alert
     */
    public static async confirm(title: string, message: string): Promise<SweetAlertResult> {
        let me = this;
        return await Swal.fire({
            title: title,
            text: message,
            showCancelButton: true,
            confirmButtonText: `Aceptar`,
            denyButtonText: `Cancelar`,
            icon: "question"
        });
    }
}

export {
    Alert as Swal
};