create procedure getBusdata
as
begin
select * from BusInfo where BoardingPoint='MUM';
end

execute getBusdata