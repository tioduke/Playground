begin
  insert into CUSTOMER (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) select 1, 'A', 'Asterix', '111111111', 10.2, to_date('1933-01-01', 'YYYY-MM-DD'), to_date('2017-04-01', 'YYYY-MM-DD') from dual where not exists (select 1 from CUSTOMER where CUSTOMER_ID = 1);
  insert into CUSTOMER (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) select 2, 'B', 'Panoramix', '222222222', 23.14, to_date('1920-02-01', 'YYYY-MM-DD'), to_date('2017-04-02', 'YYYY-MM-DD') from dual where not exists (select 1 from CUSTOMER where CUSTOMER_ID = 2);
  insert into CUSTOMER (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) select 3, 'A', 'Obelix', '333333333', 11.14, to_date('1934-02-03', 'YYYY-MM-DD'), to_date('2017-04-01', 'YYYY-MM-DD') from dual where not exists (select 1 from CUSTOMER where CUSTOMER_ID = 3);
  insert into ADDRESS (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) select 1, 1, '200 rue de La Gaule' from dual where not exists (select 1 from ADDRESS where ADDRESS_ID = 1);
  insert into ADDRESS (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) select 2, 1, 'asterix@village.gaulois.fr' from dual where not exists (select 1 from ADDRESS where ADDRESS_ID = 2);
  insert into ADDRESS (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) select 3, 2, '1 Stonehenge' from dual where not exists (select 1 from ADDRESS where ADDRESS_ID = 3);
  insert into ADDRESS (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) select 4, 3, '204 rue de La Gaule' from dual where not exists (select 1 from ADDRESS where ADDRESS_ID = 4);
end;
