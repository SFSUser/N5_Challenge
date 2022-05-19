import React, { Component } from 'react';
import { Button, Card, Form, Row, Col, Table, FormGroup, InputGroup, FormControl } from 'react-bootstrap';
import PermissionPageProp from '../entity/page/props/PermissionPageProp';
import PermissionPageState from '../entity/page/states/PermissionPageState';
import PermissionBL from '../BL/PermissionBL';
import Permission from '../entity/user/PermissionEntity';
import { Center } from '../component/utils/Fragment';
import FormHelper from '../helper/FormHelper';
import PermissionForm from '../component/user/PermissionForm';
import Alert from '../component/utils/Alert';
import * as I from 'react-feather';

export default class PermissionPage extends Component<PermissionPageProp, PermissionPageState> {

    public constructor(props: PermissionPageProp){
        super(props);
        this.state = new PermissionPageState();
    }

    componentDidMount(){
        let me = this;
        me.prepare();
    }

    public async prepare(){
        let me = this;
        me.listPermissions();
    }

    private async listPermissions(){
        let me = this;
        me.setState({busy: true});
        var result = await PermissionBL.getPermissions();
        me.setState({
            busy: false,
            permissions: result.getList(Permission)
        });
    }

    private selectPermission(permission: Permission|null) {
        let me = this;
        me.setState({
            permission
        });
    }   

    private handleClose(){
        let me = this;
        me.selectPermission(null);
        me.listPermissions();
    }

    render() {
        let me = this;
        return (
            <div className="fixer pt-2">
                <Card>
                    <Card.Header>
                        <Button className="float-right" onClick={ e => me.selectPermission(new Permission()) } variant="success">
                            <I.Plus/> Crear nuevo
                        </Button>
                        Usuarios registrados
                    </Card.Header>
                    <Card.Body>
                        {!me.state.permission &&
                            <Table size="sm">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Nombre</th>
                                        <th>Apellido</th>
                                        <th>Fecha permiso</th>
                                        <th>Tipo permiso</th>
                                        <th>Opciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {me.state.permissions.sort( (a, b) => a.id - b.id ).map( u =>
                                        <tr key={ u.id }>
                                            <td>{ u.id}</td>
                                            <td>{ u.nombreEmpleado}</td>
                                            <td>{ u.apellidoEmpleado }</td>
                                            <td>{ u.fechaPermiso }</td>
                                            <td>{ u.tipoPermiso }</td>
                                            <td>
                                                <Button onClick={ e => me.selectPermission(u) } size="sm" color="primary">
                                                    <I.Edit size="15"/> Editar
                                                </Button>
                                            </td>
                                        </tr>
                                    )}
                                </tbody>
                            </Table>
                        }
                        {me.state.permission &&
                            <PermissionForm permission={me.state.permission} onClose={ e => me.handleClose() } />
                        }
                    </Card.Body>
                </Card>
            </div>
        );
    }
}