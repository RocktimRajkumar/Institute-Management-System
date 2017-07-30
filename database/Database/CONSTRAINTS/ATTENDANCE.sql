--------------------------------------------------------
--  Constraints for Table ATTENDANCE
--------------------------------------------------------

  ALTER TABLE "IMS"."ATTENDANCE" MODIFY ("SUB" NOT NULL ENABLE);
  ALTER TABLE "IMS"."ATTENDANCE" MODIFY ("COURSEID" NOT NULL ENABLE);
  ALTER TABLE "IMS"."ATTENDANCE" MODIFY ("STUID" NOT NULL ENABLE);
  ALTER TABLE "IMS"."ATTENDANCE" MODIFY ("DEPTID" NOT NULL ENABLE);
