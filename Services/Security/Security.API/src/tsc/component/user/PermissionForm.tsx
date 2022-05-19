import React from "react";
import { Component } from "react";
import PermissionFormProp from "../../entity/user/props/PermissionFormProp";
import PermissionFormState from "../../entity/user/states/PermissionFormState";
import Permission from '../../entity/user/PermissionEntity';
import { Center } from '../utils/Fragment';
import FormHelper from '../../helper/FormHelper';
import { Button, Card, Form, Row, Col, Table, FormGroup, InputGroup, FormControl } from 'react-bootstrap';
import Alert, { Swal } from "../utils/Alert";
import * as I from 'react-feather';
import PermissionBL from "../../BL/PermissionBL";

export default class PermissionForm extends Component<PermissionFormProp, PermissionFormState> {

    public constructor(props) {
        super(props);
        this.state = new PermissionFormState();
    }

    componentDidMount(){
        let me = this;
        me.setState({
            permission: me.props.permission
        });
    }

    private async handleSubmit(e: any) {
        e.preventDefault();
        let me = this;
        let result = await Alert.confirm("Guardar permiso", "¿Confirmas que deseas guardar cambios?")
        if(result.isConfirmed) {
            await me.save();
        }
    }

    private async save() {
        let me = this;
        var user: Permission = me.state.permission;
        var result = await PermissionBL.modifyPermission(user);
        Swal.result({result: result});
    }

    private close(){
        let me = this;
        me.props.onClose && me.props.onClose();
    }
    
    render(){
        let me = this;
        FormHelper.initialize( this, "user");
        return(
            <>
                <Form onSubmit={ e => me.handleSubmit(e) }>
                    <Row>
                        <Col sm="12" md="6">
                            <Form.Group className="mb-3">
                                <Form.Label>Nombre</Form.Label>
                                <Form.Control onChange={ e => FormHelper.handle(e) } name="nombre" value={ me.state.permission.nombreEmpleado } placeholder="Nombre" />
                            </Form.Group>
                        </Col>
                        <Col sm="12" md="6">
                            <Form.Group className="mb-3">
                                <Form.Label>Apellido</Form.Label>
                                <Form.Control onChange={ e => FormHelper.handle(e) } name="apellido" value={ me.state.permission.apellidoEmpleado } placeholder="Apellido" />
                            </Form.Group>
                        </Col>
                        <Col sm="12" md="6">
                            <Form.Group className="mb-3">
                                <Form.Label>Tipo permiso</Form.Label>
                                <Form.Control onChange={ e => FormHelper.handle(e) } name="tipoPermiso" value={ me.state.permission.tipoPermiso } placeholder="Tipo permiso" />
                            </Form.Group>
                        </Col>
                        <Col sm="12" md="6">
                            <Form.Group className="mb-3">
                                <Form.Label>Fecha permiso</Form.Label>
                                <Form.Control onChange={ e => FormHelper.handle(e) } name="fechaPermiso" value={ me.state.permission.fechaPermiso } placeholder="Fecha permiso" />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Center>
                        <Button type="submit">
                            <I.Save/> Guardar cambios
                        </Button>
                        <Button className="ml-2" onClick={ e => me.close() } variant="danger">
                            <I.SkipBack/> Volver
                        </Button>
                    </Center>
                </Form>
                {/*me.state.permission.id > 0 &&
                    <UserPermission user={me.state.permission} />
                */}
            </>
        );
    }
}