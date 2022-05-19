import React, { Component } from "react";
import ImgHeadProp from "../../entity/utils/props/ImgHeadProp";

export default class ImgHead extends Component<ImgHeadProp> {
    render() {
        let me = this;
        return (
            <div className={"text-center p-2"} style={{ 
                    height:me.props.height??"auto",
                    backgroundImage: `linear-gradient(rgb(255 255 255 / ${me.props.percentage}%), rgb(255 255 255)), url('${me.props.image}')`,
                    backgroundPosition: 'center',
                    backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    borderRadius: "5px"
                }}>
                {me.props.children}
            </div>
        );
    }
}