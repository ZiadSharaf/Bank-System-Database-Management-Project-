/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     5/15/2024 11:47:48 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCOUNT') and o.name = 'FK_ACCOUNT_HANDLE_EMPLOYEE')
alter table ACCOUNT
   drop constraint FK_ACCOUNT_HANDLE_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCOUNT') and o.name = 'FK_ACCOUNT_HOLD_CUSTOMER')
alter table ACCOUNT
   drop constraint FK_ACCOUNT_HOLD_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BRANCH') and o.name = 'FK_BRANCH_HAS_BANK')
alter table BRANCH
   drop constraint FK_BRANCH_HAS_BANK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CUSTOMER') and o.name = 'FK_CUSTOMER_SERVE_EMPLOYEE')
alter table CUSTOMER
   drop constraint FK_CUSTOMER_SERVE_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEAL_WITH') and o.name = 'FK_DEAL_WIT_DEAL_WITH_BRANCH')
alter table DEAL_WITH
   drop constraint FK_DEAL_WIT_DEAL_WITH_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEAL_WITH') and o.name = 'FK_DEAL_WIT_DEAL_WITH_CUSTOMER')
alter table DEAL_WITH
   drop constraint FK_DEAL_WIT_DEAL_WITH_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DEPENDENT') and o.name = 'FK_DEPENDEN_RESPONSIB_CUSTOMER')
alter table DEPENDENT
   drop constraint FK_DEPENDEN_RESPONSIB_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLOYEE') and o.name = 'FK_EMPLOYEE_EMPLOYS_BRANCH')
alter table EMPLOYEE
   drop constraint FK_EMPLOYEE_EMPLOYS_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAN') and o.name = 'FK_LOAN_BORROW_CUSTOMER')
alter table LOAN
   drop constraint FK_LOAN_BORROW_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAN') and o.name = 'FK_LOAN_MANAGE_EMPLOYEE')
alter table LOAN
   drop constraint FK_LOAN_MANAGE_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAN') and o.name = 'FK_LOAN_OFFER_BRANCH')
alter table LOAN
   drop constraint FK_LOAN_OFFER_BRANCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONE') and o.name = 'FK_PHONE_OWNS_CUSTOMER')
alter table PHONE
   drop constraint FK_PHONE_OWNS_CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCOUNT')
            and   name  = 'HANDLE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ACCOUNT.HANDLE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCOUNT')
            and   name  = 'HOLD_FK'
            and   indid > 0
            and   indid < 255)
   drop index ACCOUNT.HOLD_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCOUNT')
            and   type = 'U')
   drop table ACCOUNT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BANK')
            and   type = 'U')
   drop table BANK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BRANCH')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index BRANCH.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BRANCH')
            and   type = 'U')
   drop table BRANCH
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CUSTOMER')
            and   name  = 'SERVE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CUSTOMER.SERVE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEAL_WITH')
            and   name  = 'DEAL_WITH2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEAL_WITH.DEAL_WITH2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DEAL_WITH')
            and   name  = 'DEAL_WITH_FK'
            and   indid > 0
            and   indid < 255)
   drop index DEAL_WITH.DEAL_WITH_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEAL_WITH')
            and   type = 'U')
   drop table DEAL_WITH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPENDENT')
            and   type = 'U')
   drop table DEPENDENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLOYEE')
            and   name  = 'EMPLOYS_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLOYEE.EMPLOYS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLOYEE')
            and   type = 'U')
   drop table EMPLOYEE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOAN')
            and   name  = 'MANAGE_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOAN.MANAGE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOAN')
            and   name  = 'OFFER_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOAN.OFFER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOAN')
            and   name  = 'BORROW_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOAN.BORROW_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAN')
            and   type = 'U')
   drop table LOAN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONE')
            and   name  = 'OWNS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONE.OWNS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHONE')
            and   type = 'U')
   drop table PHONE
go

/*==============================================================*/
/* Table: ACCOUNT                                               */
/*==============================================================*/
create table ACCOUNT (
   ACCOUNT_NUMBER       numeric(38)          identity,
   CUSTOMER_SSN         numeric(15)          not null,
   EMPLOYEE_ID          varchar(50)          not null,
   ACCOUNT_BALANCE      money                not null,
   ACCOUNT_TYPE         varchar(50)          not null,
   constraint PK_ACCOUNT primary key nonclustered (ACCOUNT_NUMBER)
)
go

/*==============================================================*/
/* Index: HOLD_FK                                               */
/*==============================================================*/
create index HOLD_FK on ACCOUNT (
CUSTOMER_SSN ASC
)
go

/*==============================================================*/
/* Index: HANDLE_FK                                             */
/*==============================================================*/
create index HANDLE_FK on ACCOUNT (
EMPLOYEE_ID ASC
)
go

/*==============================================================*/
/* Table: BANK                                                  */
/*==============================================================*/
create table BANK (
   BANK_CODE            varchar(50)          not null,
   BANK_NAME            varchar(100)         not null,
   BANK_ADDRESS         varchar(1000)        not null,
   constraint PK_BANK primary key nonclustered (BANK_CODE)
)
go

/*==============================================================*/
/* Table: BRANCH                                                */
/*==============================================================*/
create table BRANCH (
   BRANCH_NUMBER        numeric(38)          not null,
   BANK_CODE            varchar(50)          not null,
   BRANCH_ADDRESS       varchar(1000)        not null,
   constraint PK_BRANCH primary key nonclustered (BRANCH_NUMBER)
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on BRANCH (
BANK_CODE ASC
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   CUSTOMER_SSN         numeric(15)          not null,
   EMPLOYEE_ID          varchar(50)          not null,
   CUSTOMER_NAME        varchar(100)         not null,
   CUSTOMER_ADDRESS     varchar(1000)        not null,
   constraint PK_CUSTOMER primary key nonclustered (CUSTOMER_SSN)
)
go

/*==============================================================*/
/* Index: SERVE_FK                                              */
/*==============================================================*/
create index SERVE_FK on CUSTOMER (
EMPLOYEE_ID ASC
)
go

/*==============================================================*/
/* Table: DEAL_WITH                                             */
/*==============================================================*/
create table DEAL_WITH (
   BRANCH_NUMBER        numeric(38)          not null,
   CUSTOMER_SSN         numeric(15)          not null,
   constraint PK_DEAL_WITH primary key (BRANCH_NUMBER, CUSTOMER_SSN)
)
go

/*==============================================================*/
/* Index: DEAL_WITH_FK                                          */
/*==============================================================*/
create index DEAL_WITH_FK on DEAL_WITH (
BRANCH_NUMBER ASC
)
go

/*==============================================================*/
/* Index: DEAL_WITH2_FK                                         */
/*==============================================================*/
create index DEAL_WITH2_FK on DEAL_WITH (
CUSTOMER_SSN ASC
)
go

/*==============================================================*/
/* Table: DEPENDENT                                             */
/*==============================================================*/
create table DEPENDENT (
   CUSTOMER_SSN         numeric(15)          not null,
   DEPENDENT_NAME       varchar(100)         not null,
   DEPENDENT_GENDER     char(1)              not null,
   DEPENDENT_BIRTH_DATE datetime             not null,
   constraint PK_DEPENDENT primary key (CUSTOMER_SSN)
)
go

/*==============================================================*/
/* Table: EMPLOYEE                                              */
/*==============================================================*/
create table EMPLOYEE (
   EMPLOYEE_ID          varchar(50)          not null,
   BRANCH_NUMBER        numeric(38)          not null,
   EMPLOYEE_NAME        varchar(100)         not null,
   EMPLOYEE_ADDRESS     varchar(1000)        not null,
   constraint PK_EMPLOYEE primary key nonclustered (EMPLOYEE_ID)
)
go

/*==============================================================*/
/* Index: EMPLOYS_FK                                            */
/*==============================================================*/
create index EMPLOYS_FK on EMPLOYEE (
BRANCH_NUMBER ASC
)
go

/*==============================================================*/
/* Table: LOAN                                                  */
/*==============================================================*/
create table LOAN (
   LOAN_NUMBER          numeric(38)          not null,
   CUSTOMER_SSN         numeric(15)          not null,
   BRANCH_NUMBER        numeric(38)          not null,
   EMPLOYEE_ID          varchar(50)          not null,
   LOAN_AMOUNT          money                not null,
   LOAN_TYPE            varchar(30)          not null,
   LOAN_REQUEST         text                 null,
   constraint PK_LOAN primary key nonclustered (LOAN_NUMBER)
)
go

/*==============================================================*/
/* Index: BORROW_FK                                             */
/*==============================================================*/
create index BORROW_FK on LOAN (
CUSTOMER_SSN ASC
)
go

/*==============================================================*/
/* Index: OFFER_FK                                              */
/*==============================================================*/
create index OFFER_FK on LOAN (
BRANCH_NUMBER ASC
)
go

/*==============================================================*/
/* Index: MANAGE_FK                                             */
/*==============================================================*/
create index MANAGE_FK on LOAN (
EMPLOYEE_ID ASC
)
go

/*==============================================================*/
/* Table: PHONE                                                 */
/*==============================================================*/
create table PHONE (
   CUSTOMER_PHONE       varchar(20)          not null,
   CUST_SSN             numeric(20)          not null,
   CUSTOMER_SSN         numeric(15)          not null,
   constraint PK_PHONE primary key nonclustered (CUSTOMER_PHONE, CUST_SSN)
)
go

/*==============================================================*/
/* Index: OWNS_FK                                               */
/*==============================================================*/
create index OWNS_FK on PHONE (
CUSTOMER_SSN ASC
)
go

alter table ACCOUNT
   add constraint FK_ACCOUNT_HANDLE_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (EMPLOYEE_ID)
go

alter table ACCOUNT
   add constraint FK_ACCOUNT_HOLD_CUSTOMER foreign key (CUSTOMER_SSN)
      references CUSTOMER (CUSTOMER_SSN)
go

alter table BRANCH
   add constraint FK_BRANCH_HAS_BANK foreign key (BANK_CODE)
      references BANK (BANK_CODE)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_SERVE_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (EMPLOYEE_ID)
go

alter table DEAL_WITH
   add constraint FK_DEAL_WIT_DEAL_WITH_BRANCH foreign key (BRANCH_NUMBER)
      references BRANCH (BRANCH_NUMBER)
go

alter table DEAL_WITH
   add constraint FK_DEAL_WIT_DEAL_WITH_CUSTOMER foreign key (CUSTOMER_SSN)
      references CUSTOMER (CUSTOMER_SSN)
go

alter table DEPENDENT
   add constraint FK_DEPENDEN_RESPONSIB_CUSTOMER foreign key (CUSTOMER_SSN)
      references CUSTOMER (CUSTOMER_SSN)
go

alter table EMPLOYEE
   add constraint FK_EMPLOYEE_EMPLOYS_BRANCH foreign key (BRANCH_NUMBER)
      references BRANCH (BRANCH_NUMBER)
go

alter table LOAN
   add constraint FK_LOAN_BORROW_CUSTOMER foreign key (CUSTOMER_SSN)
      references CUSTOMER (CUSTOMER_SSN)
go

alter table LOAN
   add constraint FK_LOAN_MANAGE_EMPLOYEE foreign key (EMPLOYEE_ID)
      references EMPLOYEE (EMPLOYEE_ID)
go

alter table LOAN
   add constraint FK_LOAN_OFFER_BRANCH foreign key (BRANCH_NUMBER)
      references BRANCH (BRANCH_NUMBER)
go

alter table PHONE
   add constraint FK_PHONE_OWNS_CUSTOMER foreign key (CUSTOMER_SSN)
      references CUSTOMER (CUSTOMER_SSN)
go

