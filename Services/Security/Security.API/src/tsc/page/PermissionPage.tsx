import React, { Component } from 'react';
import { Button, Card, Table } from 'react-bootstrap';
import PermissionPageProp from '../entity/page/props/PermissionPageProp';
import PermissionPageState from '../entity/page/states/PermissionPageState';
import PermissionBL from '../BL/PermissionBL';
import Permission from '../entity/user/PermissionEntity';
import PermissionForm from '../component/permission/PermissionForm';
import * as I from 'react-feather';
import moment from 'moment';

/**
 * Permission page (list of permissions)
 * @class PermissionPage
 * @author Samael Fierro <sfstricks@hotmail.com>
 */
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

    /**
     * List permissions
     */
    private async listPermissions(){
        let me = this;
        me.setState({busy: true});
        var result = await PermissionBL.getPermissions();
        me.setState({
            busy: false,
            permissions: result.getList(Permission)
        });
    }

    /**
     * Select permission
     * @param permission 
     */
    private async selectPermission(permission: Permission|null) {
        let me = this;
        permission = permission?.id > 0 ? await (await PermissionBL.getPermission(permission.id)).getElement(Permission) : permission;
        me.setState({
            permission
        });
    }   

    /**
     * Handle close event from permission form
     */
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
                        {/*<Button className="float-right" onClick={ e => me.selectPermission(new Permission()) } variant="success">
                            <I.Plus/> Crear nuevo
                        </Button>*/}
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
                                            <td>{ moment(u.fechaPermiso).format("Y/MM/DD HH:mm:ss") }</td>
                                            <td>{ u.permissionType.descripcion }</td>
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