
select top 1 *
   into #temp
  from tbSync


insert into tbSync
select *
  from #temp
  
  
  select *
    from tbSync
  
  
  insert into tbSync
  select TableName + '3'
		, NEWID()
		, ChangedKey + '3'
		, 'I'
  from #temp
  
  
  delete
    from tbSync
   where tablename like '%appoint%'