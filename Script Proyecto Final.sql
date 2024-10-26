---------------Creacion de usuario administrador ---------------------
SHOW PDBS;
--prueba de github
--drop user "Adminbd" 
--DROP ROLE AdminBD1
CREATE USER C##Admindb IDENTIFIED BY Admin;
GRANT DBA TO C##Admindb;
GRANT CONNECT, RESOURCE, DBA, CREATE SESSION, CREATE TABLE, CREATE VIEW, CREATE PROCEDURE, CREATE SEQUENCE, CREATE TRIGGER, CREATE SYNONYM, UNLIMITED TABLESPACE TO C##Admindb;

-- Conceder privilegios de manipulación de datos
GRANT INSERT ANY TABLE, UPDATE ANY TABLE, DELETE ANY TABLE, SELECT ANY TABLE TO C##Admindb;

-- Conceder privilegios de alteración y eliminación de objetos
GRANT ALTER ANY TABLE, DROP ANY TABLE, ALTER ANY PROCEDURE, DROP ANY PROCEDURE, ALTER ANY SEQUENCE, DROP ANY SEQUENCE,
DROP ANY VIEW, ALTER ANY TRIGGER, DROP ANY TRIGGER, DROP ANY SYNONYM TO C##Admindb;


--CREACION DE LAS TABLAS DE LA BD ProyectoFInal
CREATE TABLE TIPOPRODUCTO (
   IDTIPOPROD           NUMBER                        NOT NULL,
   NOMBRETIPOPROD       VARCHAR2(4000)                NULL,
   FECHACREATIPOP       TIMESTAMP                     NULL,
   FECHAMODTIPOP        TIMESTAMP                     NULL,
   USMODTPROD           NUMBER                        NULL,
   CONSTRAINT PK_TIPOPRODUCTO PRIMARY KEY (IDTIPOPROD)
);

CREATE TABLE UMEDIDA (
   IDUMEDIDA            NUMBER                        NOT NULL,
   NOMMEDIDA            VARCHAR2(4000)                NULL,
   FECHAMODMEDIDA       TIMESTAMP                     NULL,
   FECHACREAMEDIDA      TIMESTAMP                     NULL,
   USMODMED             NUMBER                        NULL,
   CONSTRAINT PK_UMEDIDA PRIMARY KEY (IDUMEDIDA)
);

CREATE TABLE COLOR (
   IDCOLOR              NUMBER                        NOT NULL,
   NOMBRECOLOR          VARCHAR2(4000)                NULL,
   FECHACREACOLOR       TIMESTAMP                     NULL,
   FECHAMODCOLOR        TIMESTAMP                     NULL,
   USMODCOLOR           NUMBER                        NULL,
   CONSTRAINT PK_COLOR PRIMARY KEY (IDCOLOR)
);

CREATE TABLE ESTADO (
   IDESTADO             NUMBER                        NOT NULL,
   NOMBREESTADO         VARCHAR2(4000)                NULL,
   FECHACREAESTADO      TIMESTAMP                     NULL,
   FECHABAJAESTADO      TIMESTAMP                     NULL,
   USMODESTADO          NUMBER                        NULL,
   CONSTRAINT PK_ESTADO PRIMARY KEY (IDESTADO)
);

CREATE TABLE ORDEN (
   IDORDEN              NUMBER                        NOT NULL,
   FECHACREAORDEN       TIMESTAMP                     NULL,
   FECHAMODORDEN        TIMESTAMP                     NULL,
   FECHAENTREGA         TIMESTAMP                     NULL,
   USMODORDEN           NUMBER                        NULL,
   CONSTRAINT PK_ORDEN PRIMARY KEY (IDORDEN)
);

CREATE TABLE PROVEEDOR (
   IDPROVEEDOR          NUMBER                        NOT NULL,
   FECHACREAPROV        TIMESTAMP                     NULL,
   FECHAMODPROV         TIMESTAMP                     NULL,
   NOMBREPROV           VARCHAR2(4000)                NULL,
   TELPROV              VARCHAR2(4000)                NULL,
   DIRECCIONPROV        VARCHAR2(4000)                NULL,
   USMODPROV            NUMBER                        NULL,
   CONSTRAINT PK_PROVEEDOR PRIMARY KEY (IDPROVEEDOR)
);

CREATE TABLE COTIZACION (
   IDCOTIZACION         NUMBER                        NOT NULL,
   IDESTADO             NUMBER                        NULL,
   IDORDEN              NUMBER                        NULL,
   FECHACOT             TIMESTAMP                     NULL,
   TOTALCOT             NUMBER                        NULL,
   FECHACREACOT         TIMESTAMP                     NULL,
   FECHAMODCOT          TIMESTAMP                     NULL,
   USMODCOT             NUMBER                        NULL,
   CONSTRAINT PK_COTIZACION PRIMARY KEY (IDCOTIZACION),
   CONSTRAINT FK_COTIZACION_ESTADO FOREIGN KEY (IDESTADO) REFERENCES ESTADO(IDESTADO),
   CONSTRAINT FK_COTIZACION_ORDEN FOREIGN KEY (IDORDEN) REFERENCES ORDEN(IDORDEN)
);

CREATE TABLE VENTA (
   IDVENTA              NUMBER                        NOT NULL,
   IDCOTIZACION         NUMBER                        NULL,
   FECHAVENTA           TIMESTAMP                     NULL,
   MONTOTOTAL           NUMBER                        NULL,
   USMODVENTA           NUMBER                        NULL,
   CONSTRAINT PK_VENTA PRIMARY KEY (IDVENTA),
   CONSTRAINT FK_VENTA_COTIZACION FOREIGN KEY (IDCOTIZACION) REFERENCES COTIZACION(IDCOTIZACION)
);

CREATE TABLE DETALLE_VENTA (
   COD_DETALLE_VENTA    NUMBER                        NOT NULL,
   IDVENTA              NUMBER                        NULL,
   PRECIO_UNITARIO      NUMBER                        NULL,
   CANTIDAD_DETALLEVENTA NUMBER                        NULL,
   TOTAL_DETALLE_VENTA  NUMBER                        NULL,
   FECHACREAVENTA       DATE                           NULL,
   FECHAMODDETALLEVENTA DATE                           NULL,
   USMODDETALLEVENTA    NUMBER                        NULL,
   CONSTRAINT PK_DETALLE_VENTA PRIMARY KEY (COD_DETALLE_VENTA),
   CONSTRAINT FK_DETALLEVENTA_VENTA FOREIGN KEY (IDVENTA) REFERENCES VENTA(IDVENTA)
);

CREATE TABLE PRODUCTO (
   IDPRODUCTO           NUMBER                        NOT NULL,
   IDUMEDIDA            NUMBER                        NULL,
   IDTIPOPROD           NUMBER                        NULL,
   IDCOLOR              NUMBER                        NULL,
   COD_DETALLE_VENTA    NUMBER                        NULL,
   IDCOTIZACION         NUMBER                        NULL,
   NOMBREPROD           VARCHAR2(4000)                NULL,
   ALTO                 NUMBER                        NULL,
   FECHACREAPROD        TIMESTAMP                     NULL,
   FECHAMODPROD         TIMESTAMP                     NULL,
   CANTIDAD             NUMBER                        NULL,
   ANCHO                NUMBER                        NULL,
   USMODPRODUCT         NUMBER                        NULL,
   CONSTRAINT PK_PRODUCTO PRIMARY KEY (IDPRODUCTO),
   CONSTRAINT FK_PRODUCTO_TIPOPROD FOREIGN KEY (IDTIPOPROD) REFERENCES TIPOPRODUCTO(IDTIPOPROD),
   CONSTRAINT FK_PRODUCTO_UMEDIDA FOREIGN KEY (IDUMEDIDA) REFERENCES UMEDIDA(IDUMEDIDA),
   CONSTRAINT FK_PRODUCTO_COLOR FOREIGN KEY (IDCOLOR) REFERENCES COLOR(IDCOLOR),
   CONSTRAINT FK_PRODUCTO_COTIZACION FOREIGN KEY (IDCOTIZACION) REFERENCES COTIZACION(IDCOTIZACION)
);

CREATE TABLE MATERIAPRIMA (
   IDPRODUCTO           NUMBER                        NOT NULL,
   IDMATERIAPRIMA       NUMBER                        NOT NULL,
   NOMBREMATERIA        VARCHAR2(4000)                NULL,
   CANTIDADMATERIA      NUMBER                        NULL,
   PRECIOMATERIA        NUMBER                        NULL,
   FECHAINGRESOMATERIA  TIMESTAMP                     NULL,
   FECHAMODMATERIA      TIMESTAMP                     NULL,
   DETALLE              VARCHAR2(4000)                NULL,
   USMODMAT             NUMBER                        NULL,
   CONSTRAINT PK_MATERIAPRIMA PRIMARY KEY (IDPRODUCTO, IDMATERIAPRIMA),
   CONSTRAINT FK_MATERIAPRIMA_PRODUCTO FOREIGN KEY (IDPRODUCTO) REFERENCES PRODUCTO(IDPRODUCTO)
);

CREATE TABLE MATERIAPROVEEDOR (
   IDPRODUCTO           NUMBER                        NOT NULL,
   IDMATERIAPRIMA       NUMBER                        NOT NULL,
   IDPROVEEDOR          NUMBER                        NOT NULL,
   CONSTRAINT PK_RELATIONSHIP_12 PRIMARY KEY (IDPRODUCTO, IDMATERIAPRIMA, IDPROVEEDOR),
   CONSTRAINT FK_MATERIAPROVEEDOR_MATERIAPRIMA FOREIGN KEY (IDPRODUCTO, IDMATERIAPRIMA) REFERENCES MATERIAPRIMA(IDPRODUCTO, IDMATERIAPRIMA),
   CONSTRAINT FK_MATERIAPROVEEDOR_PROVEEDOR FOREIGN KEY (IDPROVEEDOR) REFERENCES PROVEEDOR(IDPROVEEDOR)
);

CREATE TABLE TIPOPAGO (
   IDTIPOPAGO           NUMBER                        NOT NULL,
   NOMBREPAGO           VARCHAR2(4000)                NULL,
   FECHACREAP           TIMESTAMP                     NULL,
   FECHABAJAPAGO        TIMESTAMP                     NULL,
   USMODTPAGO           NUMBER                        NULL,
   CONSTRAINT PK_TIPOPAGO PRIMARY KEY (IDTIPOPAGO)
);

CREATE TABLE PAGO (
   IDPAGO               NUMBER                        NOT NULL,
   IDTIPOPAGO           NUMBER                        NULL,
   IDVENTA              NUMBER                        NULL,
   FECHAPAGO            TIMESTAMP                     NULL,
   TOTAL                NUMBER                        NULL,
   FECHAMODPAGO         TIMESTAMP                     NULL,
   USMODPAGO            NUMBER                        NULL,
   FECHACREAPAGO        TIMESTAMP                     NULL,
   CONSTRAINT PK_PAGO PRIMARY KEY (IDPAGO),
   CONSTRAINT FK_PAGO_VENTA FOREIGN KEY (IDVENTA) REFERENCES VENTA(IDVENTA),
   CONSTRAINT FK_PAGO_TIPOPAGO FOREIGN KEY (IDTIPOPAGO) REFERENCES TIPOPAGO(IDTIPOPAGO)
);

CREATE TABLE ROL (
   IDROL                NUMBER                        NOT NULL,
   NOMBREROL            VARCHAR2(4000)                NULL,
   FECHACREAROL         TIMESTAMP                     NULL,
   FECHABAJAROL         TIMESTAMP                     NULL,
   USMODROL             NUMBER                        NULL,
   CONSTRAINT PK_ROL PRIMARY KEY (IDROL)
);

CREATE TABLE USUARIO (
   IDUSUARIO            NUMBER                        NOT NULL,
   IDROL                NUMBER                        NULL,
   NOMBRE               VARCHAR2(4000)                NULL,
   APELLIDO             VARCHAR2(4000)                NULL,
   CORREO               VARCHAR2(4000)                NULL,
   TELEFONO             VARCHAR2(4000)                NULL,
   DIRECCION            VARCHAR2(4000)                NULL,
   FECHAREGISTRO        TIMESTAMP                     NULL,
   PASSWORD             VARCHAR2(4000)                NULL,
   FECHAMOD             TIMESTAMP                     NULL,
   NIT                  VARCHAR2(4000)                NULL,
   DPI                  VARCHAR2(4000)                NULL,
   USMODUS              NUMBER                        NULL,
   CONSTRAINT PK_USUARIO PRIMARY KEY (IDUSUARIO),
   CONSTRAINT FK_USUARIO_ROL FOREIGN KEY (IDROL) REFERENCES ROL(IDROL)
);

CREATE TABLE BITACORA (
   IDBITACORA           NUMBER                        NOT NULL,
   IDUSUARIO            NUMBER                        NULL,
   FECHAHORA            TIMESTAMP                     NULL,
   ENTAFECTADA          NUMBER                        NULL,
   CONSTRAINT PK_BITACORA PRIMARY KEY (IDBITACORA),
   CONSTRAINT FK_BITACORA_USUARIO FOREIGN KEY (IDUSUARIO) REFERENCES USUARIO(IDUSUARIO)
);

CREATE TABLE ACCION (
   IDACCION             NUMBER                        NOT NULL,
   IDBITACORA           NUMBER                        NULL,
   NOMBREACCION         VARCHAR2(4000)                NULL,
   FECHACREAACCION      TIMESTAMP                     NULL,
   FECHAMODACCION       TIMESTAMP                     NULL,
   USMODACCION          NUMBER                        NULL,
   CONSTRAINT PK_ACCION PRIMARY KEY (IDACCION),
   CONSTRAINT FK_ACCION_BITACORA FOREIGN KEY (IDBITACORA) REFERENCES BITACORA(IDBITACORA)
);

--------------------------------------CREACION DE ROLES--------------------------------------
CREATE ROLE admin_role;

GRANT ALL PRIVILEGES ON TIPOPRODUCTO TO admin_role;
GRANT ALL PRIVILEGES ON UMEDIDA TO admin_role;
GRANT ALL PRIVILEGES ON COLOR TO admin_role;
GRANT ALL PRIVILEGES ON ESTADO TO admin_role;
GRANT ALL PRIVILEGES ON ORDEN TO admin_role;
GRANT ALL PRIVILEGES ON PROVEEDOR TO admin_role;
GRANT ALL PRIVILEGES ON COTIZACION TO admin_role;
GRANT ALL PRIVILEGES ON VENTA TO admin_role;
GRANT ALL PRIVILEGES ON DETALLE_VENTA TO admin_role;
GRANT ALL PRIVILEGES ON PRODUCTO TO admin_role;
GRANT ALL PRIVILEGES ON MATERIAPRIMA TO admin_role;
GRANT ALL PRIVILEGES ON MATERIAPROVEEDOR TO admin_role;
GRANT ALL PRIVILEGES ON TIPOPAGO TO admin_role;
GRANT ALL PRIVILEGES ON PAGO TO admin_role;
GRANT ALL PRIVILEGES ON ROL TO admin_role;
GRANT ALL PRIVILEGES ON USUARIO TO admin_role;
GRANT ALL PRIVILEGES ON BITACORA TO admin_role;
GRANT ALL PRIVILEGES ON ACCION TO admin_role;

CREATE ROLE user_role;

GRANT SELECT, UPDATE ON TIPOPRODUCTO TO user_role;
GRANT SELECT, UPDATE ON UMEDIDA TO user_role;
GRANT SELECT, UPDATE ON COLOR TO user_role;
GRANT SELECT, UPDATE ON ESTADO TO user_role;
GRANT SELECT, UPDATE ON ORDEN TO user_role;
GRANT SELECT, UPDATE ON PROVEEDOR TO user_role;
GRANT SELECT, UPDATE ON COTIZACION TO user_role;
GRANT SELECT, UPDATE ON VENTA TO user_role;
GRANT SELECT, UPDATE ON DETALLE_VENTA TO user_role;
GRANT SELECT, UPDATE ON PRODUCTO TO user_role;
GRANT SELECT, UPDATE ON MATERIAPRIMA TO user_role;
GRANT SELECT, UPDATE ON MATERIAPROVEEDOR TO user_role;
GRANT SELECT, UPDATE ON TIPOPAGO TO user_role;
GRANT SELECT, UPDATE ON PAGO TO user_role;
GRANT SELECT, UPDATE ON ROL TO user_role;
GRANT SELECT, UPDATE ON USUARIO TO user_role;
GRANT SELECT, UPDATE ON BITACORA TO user_role;
GRANT SELECT, UPDATE ON ACCION TO user_role;

CREATE ROLE consulta_role;

GRANT SELECT ON TIPOPRODUCTO TO consulta_role;
GRANT SELECT ON UMEDIDA TO consulta_role;
GRANT SELECT ON COLOR TO consulta_role;
GRANT SELECT ON ESTADO TO consulta_role;
GRANT SELECT ON ORDEN TO consulta_role;
GRANT SELECT ON PROVEEDOR TO consulta_role;
GRANT SELECT ON COTIZACION TO consulta_role;
GRANT SELECT ON VENTA TO consulta_role;
GRANT SELECT ON DETALLE_VENTA TO consulta_role;
GRANT SELECT ON PRODUCTO TO consulta_role;
GRANT SELECT ON MATERIAPRIMA TO consulta_role;
GRANT SELECT ON MATERIAPROVEEDOR TO consulta_role;
GRANT SELECT ON TIPOPAGO TO consulta_role;
GRANT SELECT ON PAGO TO consulta_role;
GRANT SELECT ON ROL TO consulta_role;
GRANT SELECT ON USUARIO TO consulta_role;
GRANT SELECT ON BITACORA TO consulta_role;
GRANT SELECT ON ACCION TO consulta_role;

GRANT admin_role TO admin_user;
GRANT user_role TO some_user;
GRANT consulta_role TO read_only_user;


CREATE OR REPLACE VIEW VISTA_USUARIOS AS
SELECT a.IDUSUARIO, a.NOMBRE, a.APELLIDO, a.CORREO, a.TELEFONO, a.DIRECCION, a.PASSWORD, b.DESCRIPCION_IDENT, c.NOMBREROL, a.NOIDENT
FROM USUARIO a
INNER JOIN IDENTIFICACION b ON a.IDIDENT = b.IDIDENT
INNER JOIN ROL c ON a.IDROL = c.IDROL
WHERE a.ACTIVO = '1';

CREATE OR REPLACE PROCEDURE P_GuardarUs(
    pOpcion IN NUMBER,
    pIdUs IN NUMBER,
    pNombre IN VARCHAR2,
    pApellido IN VARCHAR2,
    pCorreo IN VARCHAR2,
    pTelefono IN VARCHAR2,
    pDireccion IN VARCHAR2,
    pPasswor IN VARCHAR2,
    pIdIdent IN NUMBER,
    pRol IN NUMBER,
    pnoIdent IN VARCHAR2
) AS
    vFechaCreaUs TIMESTAMP;
    vFechaModUs TIMESTAMP;
    vRol NUMBER;
    vUsername VARCHAR2(30);
    vPassword VARCHAR2(30);
BEGIN

    IF pRol IS NULL THEN
        IF pCorreo LIKE '%@pvc.com' THEN
            vRol := 2;
        ELSE
            vRol := 1;
        END IF;
    ELSE
        vRol := pRol;
    END IF;

    BEGIN
        INSERT INTO ROL (IDROL, NOMBREROL)
        VALUES (vRol, CASE WHEN vRol = 1 THEN 'user' WHEN vRol = 2 THEN 'consulta' ELSE 'admin' END);
    EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            NULL;
    END;

    IF pOpcion = 1 THEN
        vFechaCreaUs := SYSTIMESTAMP;
        INSERT INTO USUARIO (
            NOMBRE, APELLIDO, CORREO, TELEFONO, DIRECCION, PASSWORD, IDIDENT, IDROL, NOIDENT, FECHAREGISTRO, ACTIVO
        ) VALUES (
            pNombre, pApellido, pCorreo, pTelefono, pDireccion, pPasswor, pIdIdent, vRol, pnoIdent, vFechaCreaUs, '1'
        );

  
        vUsername := LOWER(pNombre || '_' || pApellido);
        vPassword := 'default_password'; 

        EXECUTE IMMEDIATE 'CREATE USER ' || vUsername || ' IDENTIFIED BY ' || vPassword;
        EXECUTE IMMEDIATE 'GRANT ' || CASE WHEN vRol = 1 THEN 'user_role' WHEN vRol = 2 THEN 'consulta_role' ELSE 'admin_role' END || ' TO ' || vUsername;

    ELSE
        vFechaModUs := SYSTIMESTAMP;
        UPDATE USUARIO
        SET NOMBRE = pNombre,
            APELLIDO = pApellido,
            CORREO = pCorreo,
            TELEFONO = pTelefono,
            DIRECCION = pDireccion,
            PASSWORD = pPasswor,
            IDIDENT = pIdIdent,
            IDROL = vRol,
            NOIDENT = pnoIdent,
            FECHAMOD = vFechaModUs
        WHERE IDUSUARIO = pIdUs;
    END IF;
END;



CREATE OR REPLACE PROCEDURE P_EliminarUsuario(nIdUs IN NUMBER) AS
BEGIN
    UPDATE USUARIO
    SET ACTIVO = '0'
    WHERE IDUSUARIO = nIdUs;
END;

CREATE OR REPLACE PROCEDURE P_ValidarAcceso(
    pCorreo IN VARCHAR2,
    pPassword IN VARCHAR2,
    pResultado OUT VARCHAR2
) AS
BEGIN
    SELECT IDUSUARIO INTO pResultado
    FROM USUARIO
    WHERE CORREO = pCorreo AND PASSWORD = pPassword AND ACTIVO = '1';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        pResultado := 'INVALID';
END;

CREATE SEQUENCE BITACORA_SEQ START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE ACCION_SEQ START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER TRG_USUARIO_AUDIT
AFTER INSERT OR UPDATE OR DELETE ON USUARIO
FOR EACH ROW
DECLARE
    vIdBitacora NUMBER;
BEGIN
    IF INSERTING THEN
        INSERT INTO BITACORA (IDBITACORA, IDUSUARIO, FECHAHORA, ENTAFECTADA)
        VALUES (BITACORA_SEQ.NEXTVAL, :NEW.IDUSUARIO, SYSTIMESTAMP, 1);
        vIdBitacora := BITACORA_SEQ.CURRVAL;
    ELSIF UPDATING THEN
        INSERT INTO BITACORA (IDBITACORA, IDUSUARIO, FECHAHORA, ENTAFECTADA)
        VALUES (BITACORA_SEQ.NEXTVAL, :NEW.IDUSUARIO, SYSTIMESTAMP, 2);
        vIdBitacora := BITACORA_SEQ.CURRVAL;
    ELSIF DELETING THEN
        INSERT INTO BITACORA (IDBITACORA, IDUSUARIO, FECHAHORA, ENTAFECTADA)
        VALUES (BITACORA_SEQ.NEXTVAL, :OLD.IDUSUARIO, SYSTIMESTAMP, 3);
        vIdBitacora := BITACORA_SEQ.CURRVAL;
    END IF;

    IF INSERTING THEN
        INSERT INTO ACCION (IDACCION, IDBITACORA, NOMBREACCION, FECHACREAACCION, USMODACCION)
        VALUES (ACCION_SEQ.NEXTVAL, vIdBitacora, 'INSERT', SYSTIMESTAMP, :NEW.USMODUS);
    ELSIF UPDATING THEN
        INSERT INTO ACCION (IDACCION, IDBITACORA, NOMBREACCION, FECHACREAACCION, USMODACCION)
        VALUES (ACCION_SEQ.NEXTVAL, vIdBitacora, 'UPDATE', SYSTIMESTAMP, :NEW.USMODUS);
    ELSIF DELETING THEN
        INSERT INTO ACCION (IDACCION, IDBITACORA, NOMBREACCION, FECHACREAACCION, USMODACCION)
        VALUES (ACCION_SEQ.NEXTVAL, vIdBitacora, 'DELETE', SYSTIMESTAMP, :OLD.USMODUS);
    END IF;
END;

CREATE OR REPLACE FUNCTION obtener_detalles_producto (
    pIdProducto IN NUMBER
) RETURN PRODUCTO%ROWTYPE IS
    vDetalles PRODUCTO%ROWTYPE;
BEGIN
    SELECT *
    INTO vDetalles
    FROM PRODUCTO
    WHERE IDPRODUCTO = pIdProducto;

    RETURN vDetalles;
END;

CREATE OR REPLACE FUNCTION calcular_inventario_total
RETURN NUMBER IS
    vTotalInventario NUMBER;
BEGIN
    SELECT SUM(CANTIDAD)
    INTO vTotalInventario
    FROM PRODUCTO;

    RETURN vTotalInventario;
END;

