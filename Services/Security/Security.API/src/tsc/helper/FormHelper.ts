import { Component } from "react";

/**
 * Form common utilities
 * @class FormHelper
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class FormHelper {

    private static component: Component;
    public static object: string;

    /**
     * Initialize form helper
     * @param e Event
     * @param object State identifier
     */
    public static initialize(e: Component, object: string = null){
        let me = this;
        me.component = e;
        if(object) {
            me.object = object;
        }
    }
    
    /**
     * Handle input event
     * @param e Event
     * @param nameField 
     * @param namespace 
     */
    public static handle(e: any, nameField: string = null, namespace: string = null) {
        let me = this;
        var space = namespace ? namespace : me.object;
        var name = nameField ? nameField : e.target.name;
        var value = e.target.value;
        var type = e.target.type;
        var state: any = {};
        
        if(type == "checkbox"){
            value = e.target.checked;
        }

        if(space) {
            var base = me.component.state[space];
            base[name] = value;
            state[space] = base;
        } else {
            state[name] = value;
        }
        me.component.setState(state);
    }
}