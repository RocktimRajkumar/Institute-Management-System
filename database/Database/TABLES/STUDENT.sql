--------------------------------------------------------
--  DDL for Table STUDENT
--------------------------------------------------------

  CREATE TABLE "IMS"."STUDENT" 
   (	"STUID" VARCHAR2(20 BYTE), 
	"PID" NUMBER(20,0), 
	"DEPTID" VARCHAR2(4 BYTE), 
	"BATCHNO" VARCHAR2(10 BYTE), 
	"HOBBY" VARCHAR2(30 BYTE), 
	"CURRENTSTATUS" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 5242880 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
