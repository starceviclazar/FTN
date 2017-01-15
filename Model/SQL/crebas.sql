/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     1/13/2017 11:14:59 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEASUREMENT') and o.name = 'FK_MEASUREM_RTU_TO_ME_RTU')
alter table MEASUREMENT
   drop constraint FK_MEASUREM_RTU_TO_ME_RTU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RTU') and o.name = 'FK_RTU_RTU_TO_LO_LOCATION')
alter table RTU
   drop constraint FK_RTU_RTU_TO_LO_LOCATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOCATION')
            and   type = 'U')
   drop table LOCATION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEASUREMENT')
            and   name  = 'RTU_TO_MEASUREMENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEASUREMENT.RTU_TO_MEASUREMENT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEASUREMENT')
            and   type = 'U')
   drop table MEASUREMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RTU')
            and   name  = 'RTU_TO_LOCATION_FK'
            and   indid > 0
            and   indid < 255)
   drop index RTU.RTU_TO_LOCATION_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RTU')
            and   type = 'U')
   drop table RTU
go

/*==============================================================*/
/* Table: LOCATION                                              */
/*==============================================================*/
create table LOCATION (
   LOCATION_ID          int  IDENTITY(1,1)                not null,
   LAT                  float              not null,
   LNG                  float              not null,
   ADDRESS              varchar(200)         not null,
   constraint PK_LOCATION primary key nonclustered (LOCATION_ID)
)
go

/*==============================================================*/
/* Table: MEASUREMENT                                           */
/*==============================================================*/
create table MEASUREMENT (
   MEASUREMENT_ID       int  IDENTITY(1,1)                not null,
   RTU_ID               int                  not null,
   MEASUREMENT_VALUE                float              not null,
   MEASUREMENT_TIME                 datetime2            not null,
   MEASUREMENT_TYPE                 int                  not null,
   constraint PK_MEASUREMENT primary key nonclustered (MEASUREMENT_ID)
)
go

/*==============================================================*/
/* Index: RTU_TO_MEASUREMENT_FK                                 */
/*==============================================================*/
create index RTU_TO_MEASUREMENT_FK on MEASUREMENT (
RTU_ID ASC
)
go

/*==============================================================*/
/* Table: RTU                                                   */
/*==============================================================*/
create table RTU (
   RTU_ID               int    IDENTITY(1,1)              not null,
   LOCATION_ID          int                  not null,
   NAME                 varchar(200)         not null,
   RTU_TYPE                 int                  not null,
   constraint PK_RTU primary key nonclustered (RTU_ID)
)
go

/*==============================================================*/
/* Index: RTU_TO_LOCATION_FK                                    */
/*==============================================================*/
create index RTU_TO_LOCATION_FK on RTU (
LOCATION_ID ASC
)
go

alter table MEASUREMENT
   add constraint FK_MEASUREM_RTU_TO_ME_RTU foreign key (RTU_ID)
      references RTU (RTU_ID)
go

alter table RTU
   add constraint FK_RTU_RTU_TO_LO_LOCATION foreign key (LOCATION_ID)
      references LOCATION (LOCATION_ID)
go

