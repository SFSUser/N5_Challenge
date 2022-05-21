import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { BrowserRouter } from 'react-router-dom';
import { Navbar } from 'react-bootstrap';
import { MainContext } from '../context/MainContext';
import BasePageProp from '../entity/page/props/BasePageProp';
import BasePageState from '../entity/page/states/BasePageState';
import { LAYOUT } from '../constant/layout';
import Helmet from 'react-helmet';
import { Layout } from '../entity/common/CommonEntity';
import 'animate.css';

export default class BasePage extends Component<BasePageProp, BasePageState> {  
    static contextType = MainContext;

    constructor(props: BasePageProp){
        super(props);
        this.state = new BasePageState();
    }

    componentDidMount(){
        let me = this;
    }

    private Navigation(){
        let me = this;
        return (
            <div className="pr-2 pl-2">
                <Switch>
                    {LAYOUT.map( (l: Layout, i: number) => {
                        return (
                            <Route key={ i } exact path={l.path}>
                                <l.component/>
                            </Route>
                        );
                    })}
                </Switch>
            </div>
        );
    }

    render (){
        let me = this;
        return (
            <div className="base-page">
                <Helmet>
                    <meta charSet="utf-8" />
                    <title>N5 Challenge</title>
                </Helmet>
                <BrowserRouter>
                    <Navbar bg="light" variant="light" className={ me.context.main.Login ? "desktop-logo-login" : "desktop-logo"}>
                        <Navbar.Brand>
                        </Navbar.Brand>
                        <Navbar.Brand href="#title" className="desktop">
                            <div>N5 Challenge</div>
                        </Navbar.Brand>
                    </Navbar>
                    <>{me.Navigation()}</>
                </BrowserRouter>
            </div>
        );
    }
}