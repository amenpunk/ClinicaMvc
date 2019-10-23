-- esta funcion funciona :v
create function join_det(@id_exp int, @id_fact int)
returns table 
as return  (

select  1 as cant,c.asunto,@id_fact as fac,c.monto_caja from expediente e INNER JOIN
consulta c ON e.id_expediente  = c.id_expediente
where c.id_expediente = @id_exp

)
--select * from dbo.join_det(12,2)

--creo que esta mierda tambien funcino

create procedure sp_detalle
    @fac int, 
    @expe int
    as 
        insert into detalle_fac(cantidad,nombre_consulta,num_factura,precio)
        select cant,asunto,fac,monto_caja from dbo.join_det(@expe,@fac)
select * from detalle_fac
insert into
select * from detalle_fac
--exec sp_detalle @fac = 1, @expe = 12

-- jaja este tambien

create trigger tr_detalle on factura after insert 
AS
declare @id_fact int = (select IDENT_CURRENT('factura'))
declare @id_exp int = (select id_expediente from factura where num_factura = @id_fact)
exec sp_detalle @fac = @id_fact , @expe = @id_exp
