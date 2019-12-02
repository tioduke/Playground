begin
  merge into CUSTOMER
    using (select 1 from dual) on (CUSTOMER.CUSTOMER_ID = 1)
  when not matched then
    insert (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) values (1, 'A', 'Asterix', '111111111', 10.2, to_date('1933-01-01', 'YYYY-MM-DD'), to_date('2017-04-01', 'YYYY-MM-DD'));
  merge into CUSTOMER
    using (select 1 from dual) on (CUSTOMER.CUSTOMER_ID = 2)
  when not matched then
    insert (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) values (2, 'B', 'Panoramix', '222222222', 23.14, to_date('1920-02-01', 'YYYY-MM-DD'), to_date('2017-04-02', 'YYYY-MM-DD'));
  merge into CUSTOMER
    using (select 1 from dual) on (CUSTOMER.CUSTOMER_ID = 3)
  when not matched then
    insert (CUSTOMER_ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE) values (3, 'A', 'Obelix', '333333333', 11.14, to_date('1934-02-03', 'YYYY-MM-DD'), to_date('2017-04-01', 'YYYY-MM-DD'));
  merge into ADDRESS
    using (select 1 from dual) on (ADDRESS.ADDRESS_ID = 1)
  when not matched then
    insert (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) values (1, 1, '200 rue de La Gaule');
  merge into ADDRESS
    using (select 1 from dual) on (ADDRESS.ADDRESS_ID = 2)
  when not matched then
    insert (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) values (2, 1, 'asterix@village.gaulois.fr');
  merge into ADDRESS
    using (select 1 from dual) on (ADDRESS.ADDRESS_ID = 3)
  when not matched then
    insert (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) values (3, 2, '1 Stonehenge');
  merge into ADDRESS
    using (select 1 from dual) on (ADDRESS.ADDRESS_ID = 4)
  when not matched then
    insert (ADDRESS_ID, CUSTOMER_ID, ADDRESS_VALUE) values (4, 3, '204 rue de La Gaule');
end;
