import React from "react";
import { RouteComponentProps, withRouter } from "react-router";

import ReactGA from 'react-ga4';
ReactGA.initialize('G-JN0S83KLG6');

export class GaPage extends React.Component<RouteComponentProps> {
    private ga(){
        var route = window.location.pathname + window.location.search;
        ReactGA.pageview(route);
    }

    render(): React.ReactNode {
        this.ga();
        return (
            this.props.children
        )
    }
}

export default withRouter(GaPage);