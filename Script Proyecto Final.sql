---------------Creacion de usuario administrador ---------------------
SHOW PDBS;
--prueba de git
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