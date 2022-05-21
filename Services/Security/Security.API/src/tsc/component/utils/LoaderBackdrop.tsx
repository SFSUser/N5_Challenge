import React, { Component } from "react";
import LoaderBackdropProp from "../../entity/utils/props/LoaderBackdropProp";
import loader from '../../../img/loaders/loader_1.gif';

/**
 * LoaderBackdrop component
 * @class LoaderBackdrop
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class LoaderBackdrop extends Component<LoaderBackdropProp> {

    /**
     * Check if the component is translucent
     */
    get Translucid(){
        let me = this;
        if(me.props.translucid == false){
            return false;
        }
        return true;
    }

    render() {
        let me = this;
        return (
            me.props.visible ? 
                <div className={`loader ${me.Translucid ? 'loader__translucid' : ''}`}>
                    <img src={loader}/>
                    <h3>{me.props.message}</h3>
                </div>
            : 
            <></>
        );
    }
}