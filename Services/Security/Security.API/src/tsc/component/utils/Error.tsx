import React, { Component } from "react";
import LoaderBackdropProp from "../../entity/utils/props/LoaderBackdropProp";
import loader from '../../../img/loaders/loader_1.gif';
import * as I from 'react-feather';

export default class Error extends Component<LoaderBackdropProp> {
    render() {
        let me = this;
        return (
            me.props.visible ? 
                <div className="text-center">
                    <h2 className="text-danger">
                        <I.Server/> Error
                    </h2>
                    <h3>{me.props.message}</h3>
                </div>
            : 
            <></>
        );
    }
}