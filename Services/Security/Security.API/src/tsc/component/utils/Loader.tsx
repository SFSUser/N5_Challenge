import React, { Component } from "react";
import LoaderBackdropProp from "../../entity/utils/props/LoaderBackdropProp";
import loader from '../../../img/loaders/loader_1.gif';

/**
 * Loader component
 * @class Loader
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
export default class Loader extends Component<LoaderBackdropProp> {
    render() {
        let me = this;
        return (
            me.props.visible ? 
                <div className="text-center">
                    <img src={loader} height={100}/>
                    <h3>{me.props.message}</h3>
                </div>
            : 
            <></>
        );
    }
}