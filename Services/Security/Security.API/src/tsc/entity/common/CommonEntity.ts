import { Icon } from "react-feather";
import TextHelper from "../../helper/TextHelper";
import Reflection from "../../helper/Reflection";

/**
 * Http response common utilities
 * @class HttpResponse
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export class HttpResponse {
    public result: boolean = false;
    public message: string = "";
    public data: any;

    public get OK(){
        return this.result;
    }

    public getElement<T = any>(entity: any): T{
        return Reflection.parseEntity(this.data, entity);
    }

    public getList<T = any[]>(entity: any, callback: CallableFunction = () => {}): T[] {
        var data = Reflection.parseEntityArray(this.data, entity, callback);
        data = Reflection.uniqueList(data);
        return data;
    }
}

/**
 * Layout common utilities
 * @class Layout
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export class Layout {
    public constructor(
        {login = true, index = 0, path, component, title, description, icon, permission, helmet = false}: 
        {login?: boolean, index?: number, path: string, component: any, icon: Icon, title: string, permission: number[], description?: string, helmet?: boolean}
    ) 
    {
        let me = this;
        me.login = login;
        me.path = path;
        me.component = component;
        me.title = title;
        me.description = description;
        me.index = index;
        me.icon = icon;
        me.permission = permission;
        me.helmet = helmet;
    }
    public index: number = 0;
    public login?: boolean = true;
    public path: string = "";
    public component: any = null;
    public title: string = "";
    public description: string = "";
    public icon: any;
    public permission: number[] = [];
    public helmet?: boolean = true;

    public get Login() {
        let me = this;
        return me.login == undefined || me.login;
    }
}

export class DataEntity {
    private common_data_fields: string[] = ["contenido"];
    public descripcion: string = "";
    public data_fields: string[] = [];
    public contenido: string = "";
    public data: any = null;

    public get DataFields(){
        let me = this;
        var fields = me.common_data_fields;
        if(me.data_fields?.length > 0){
            fields = Array.prototype.concat(fields, me.data_fields);
        }
        return fields;
    }
    
    public get ContenidoText(): string{
        return TextHelper.trimText(this.contenido, 100);
    }

    public get ContenidoTextMedium(): string{
        return TextHelper.trimText(this.contenido, 250);
    }

    public load() {
        let me = this;
        if(me.descripcion.includes("json_data")) {
            me.data = JSON.parse(me.descripcion);
        } else {
            me.data = {
                "json_data": true,
                "contenido": me.descripcion
            };
        }
        me.DataFields.map(field => {
            me[field] = me.data[field];
        })
        return me.data;
    }

    public save(){
        let me = this;
        me.data = me.data ?? {};
        me.DataFields.map(field => {
            me.data[field] = me[field];
        });
        me.data["json_data"] = true;
        me.descripcion = JSON.stringify(me.data);
    }
}
