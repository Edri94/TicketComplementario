select * 
from PRODUCTO_CONTRATADO pc, CATALOGOS..COTITULAR be
where pc.producto = 8009
and pc.fecha_contratacion between '2015-01-01' and '2016-12-31'
and pc.status_producto = 8001
and pc.cuenta_cliente = be.cuenta_cliente


select * from CATALOGOS..APODERADO
where cuenta_cliente in ('732397','732399','732400','732403','732404','732405','732406','732409','732410','732419','732423','732422','732425','732426','732429',
'732435','732436','732440','732443','732444','732449','732450','732454','732455','732456','732458','732461'
)


732397  cotitular


734580
734577
192481
377704
377705
377706
278508

select * from BLOQUEO_OBSERVACION

/*
'primero buscar la descripciÛn que se pasa como bloqueoobservacion y obtener el id del bloque en el catalogo
        s = "select bloqueo_observacion from TICKET..BLOQUEO_OBSERVACION "
        s &= " where descripcion_bloqueo_observacio = '" & BloqueoObservacion & "'"
  */      
        
        select bloqueo_observacion, * from TICKET..BLOQUEO_OBSERVACION 
        where descripcion_bloqueo_observacio = 'OTROS'
        
        
Insert into TICKET..BLOQUEO_CUENTAS_DINAMICO  
(producto_contratado, bloqueo_obervacion, fecha_bloqueo_proceso,  consultor_bloquea, fecha_restriccion, tipo_bloqueo )  
values (574347,8, '2020-02-24','520','2020-02-24' '12:40',1 )

Insert into TICKET..BLOQUEO_CUENTAS_DINAMICO  
(producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso,  consultor_bloquea, fecha_restriccion, tipo_bloqueo )  
values (574347,8, '2020-02-24','520','2020-02-24 12:40',1 )


Update TICKET..PRODUCTO_CONTRATADO 
SET status_producto=SP.status_producto 
from STATUS_PRODUCTO SP, PRODUCTO_CONTRATADO PC 
where PC.producto_contratado = 574347 
and PC.agencia = 1  
and SP.status_producto_global = 4 
and SP.producto = PC.producto 
and PC.producto = 8009


select * 
--SET status_producto=SP.status_producto 
from STATUS_PRODUCTO SP, PRODUCTO_CONTRATADO PC 
where PC.producto_contratado = 574347 
and PC.agencia = 1  
and SP.status_producto_global = 4 
and SP.producto = PC.producto 
and PC.producto = 8009

status_producto descripcion_status producto status_producto_global agencia producto_contratado producto cuenta_cliente clave_producto_contratado fecha_contratacion      fecha_vencimiento       status_producto agencia
--------------- ------------------ -------- ---------------------- ------- ------------------- -------- -------------- ------------------------- ----------------------- ----------------------- --------------- -------
8004            Bloqueada          8009     4                      1       574347              8009     734580                                   2019-10-29 11:33:00     NULL                    8001            1
despues de la actualizaciÛn
8004            Bloqueada          8009     4                      1       574347              8009     734580                                   2019-10-29 11:33:00     NULL                    8004            1


Insert into TICKET..EVENTO_PRODUCTO  
(producto_contratado, fecha_evento, status_producto, comentario_evento, usuario)  
values (574347, getdate(),8004,'Mantenimiento Cuenta Bloqueada','520')

select count(*) from ticket..DETALLE_STATUS where producto_contratado = 574347 and status_bloqueo = 1

Insert into TICKET..DETALLE_STATUS  
( producto_contratado, explicacion, status_bloqueo )  
values ( 574347, 'Bloqueo de Prueba 001', 1 )

select * from DETALLE_STATUS 
where producto_contratado = 574347

Insert into TICKET..BLOQUEO_CUENTAS_HISTORICO  
(producto_contratado, bloqueo_observacion,fecha_bloqueo_proceso, consultor_bloquea, fecha_reactivacion)  
select bc.producto_contratado, bc.bloqueo_observacion, bc.fecha_bloqueo_proceso,  bc.consultor_bloquea, '2020-02-19 11:30' 
from BLOQUEO_CUENTAS_DINAMICO bc, BLOQUEO_OBSERVACION bo  
where producto_contratado = 574347 and bc.bloqueo_observacion = bo.bloqueo_observacion  and bo.status_bloqueo = 1

Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio 
from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO 
where producto_contratado = 574347 and BC.bloqueo_observacion = BO.bloqueo_observacion and status_bloqueo = 3 

select * from BLOQUEO_CUENTAS_DINAMICO
where producto_contratado = 574347 

select * from BLOQUEO_OBSERVACION

select * from BLOQUEO_CUENTAS_DINAMICO

Delete TICKET..BLOQUEO_CUENTAS_DINAMICO 
select *
FROM TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO 
where producto_contratado = 574347 and BC.bloqueo_observacion = BO.bloqueo_observacion and BO.status_bloqueo = 1

Insert into TICKET..BLOQUEO_CUENTAS_DINAMICO  
(producto_contratado, bloqueo_observacion, fecha_bloqueo_proceso,  consultor_bloquea, fecha_restriccion, tipo_bloqueo )  values (574347,12, '24/02/2020 05:46:38 p. m.','520','24/02/2020 05:46:38 p. m.' '15:35',3 )


Select explicacion, status_bloqueo from TICKET..DETALLE_STATUS where producto_contratado = 574347

Select explicacion, status_bloqueo from TICKET..DETALLE_STATUS where producto_contratado = 574347

Select bc.bloqueo_observacion, bo.descripcion_bloqueo_observacio from TICKET..BLOQUEO_CUENTAS_DINAMICO BC, BLOQUEO_OBSERVACION BO where producto_contratado = 574347 and BC.bloqueo_observacion = BO.bloqueo_observacion and status_bloqueo = 3  


    Select autorizado AS AUTORIZADO, ltrim(IsNull(nombre_aut,'')) NOMBRE, ltrim(IsNull(paterno_aut,'')) APELLIDOPAT, ltrim(IsNull(materno_aut,'')) APELLIDOMAT    
    From CATALOGOS..AUTORIZADO  Where cuenta_cliente = '' and agencia = 1
    
    Select * From CATALOGOS..AUTORIZADO  Where cuenta_cliente = '731191' 
    Select * From CATALOGOS..APODERADO  Where cuenta_cliente = '731191' 
    
    
    select * from CATALOGOS..USUARIO
    --where nombre_usuario like '%ANGEL%'
    where login like '%B03708%'
    
    INSERT INTO CATALOGOS..USUARIO VALUES ('B9420709','Jq/Rlp0+Ws4=',NULL,	'ANGEL ARTURO ESTRADA BALDERAS', 4, '2020-12-12', '2020-02-26', 7,0,'00C0000000D0B79A00BFBFBF','00CFCFCF8000000500000000','000000000000000000000000',0,'Jq/Rlp0+Ws4=')
    
    
    B9420709	IIcóâëqÅ^Ss\Ua^Ss\Ve	NULL	ANGEL ARTURO ESTRADA BALDERAS           	2	2020-02-14 17:18:00	2020-02-26 14:21:00	7	0	00C0000000D0B79A00E1DBD3	00E4DAC78000000500000000	000000000000000000000000	0	ICcóâëqÅ^Ss\Ua^Ss\Ve
    
    
    select * from CATALOGOS..USUARIO
where login = 'B0756465'

update CATALOGOS..USUARIO
set password = 'Jq/Rlp0+Ws4='
where login = 'B0756465'