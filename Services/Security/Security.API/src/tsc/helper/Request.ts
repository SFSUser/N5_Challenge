import axios, { AxiosRequestConfig, Method } from 'axios';
import { HttpResponse } from '../entity/common/CommonEntity';

/**
 * Generic class, manages the connection to the API
 * @class Request
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class Request {
    public static async execute(route: string, method: Method, data: any = {}): Promise<HttpResponse> {
        let path = route;
        var response = new HttpResponse();
        var result: any = null;
        try {
            result = await axios({
                method: method,
                url: path,
                headers: {
                    authorization: "",//UserBL.SessionData?.token,
                    contentType: "application/json"
                }, 
                data
            });
            response.data = result.data;
        } catch {}

        response.result = result?.status == 200;
        return response;
    }

    public static async get(route: string, params: any = {}, data: any = {}): Promise<HttpResponse> {
        let me = this;
        route += me.getParams(params);
        return me.execute(route, "get", data);
    }

    public static async delete(route: string, params: any = {}, data: any = {}): Promise<HttpResponse> {
        let me = this;
        route += me.getParams(params);
        return me.execute(route, "delete", data);
    }

    public static getParams(params: any){
        var strParams = [];
        Object.keys(params).forEach(key => { 
            strParams.push(key + "=" + encodeURIComponent(params[key]));
        });
        return strParams.length > 0 ? "?" + strParams.join("&") : "";
    }

    public static async post(route: string, data: any): Promise<HttpResponse> {
        let me = this;
        return me.execute(route, "post", data);
    }

    public static async patch(route: string, data: any): Promise<HttpResponse> {
        let me = this;
        return me.execute(route, "patch", data);
    }

    public static async put(route: string, data: any): Promise<HttpResponse> {
        let me = this;
        return me.execute(route, "put", data);
    }
}