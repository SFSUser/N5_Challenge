/**
 * Cookies helper
 * @class Cookies
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class Cookies {

    public static set(key: string, value: string, exdays: number = 999) {
        this.setHour(key, value, exdays * 24);
    }

    public static setHour(key: string, value: string, exhours: number = 1) {
        var d = new Date();
        d.setTime(d.getTime() + (exhours * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = key + "=" + value + ";" + expires + ";path=/";
    }

    public static get(key: string, defaults: string = ""): string {
        var name = key + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return defaults;
    }

    public static exists(key: string): boolean {
        return document.cookie.includes(key);
    }

    public static remove(key: string) {
        document.cookie = key +'=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    }
}