use s16503

select * from Doctor
DELETE FROM Prescription

DROP TABLE Prescription
DROP TABLE Doctor
DROP TABLE Medicament

SELECT * 
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Patient')

SELECT 
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Patient')


SELECT name AS 'Foreign Key Constraint Name', 
	       OBJECT_SCHEMA_NAME(parent_object_id) + '.' + OBJECT_NAME(parent_object_id) AS 'Child Table'
   FROM sys.foreign_keys 
   WHERE  referenced_object_id = object_id('Patient')


 ALTER TABLE patient DROP CONSTRAINT Prescription_Patient;

 exec sp_fkeys 'Medicament';

 ALTER TABLE [dbo].[Prescription] DROP CONSTRAINT [Prescription_Patient]
 ALTER TABLE [dbo].[Prescription_Medicament] DROP CONSTRAINT [Prescription_Medicament_Prescription]
 ALTER TABLE [dbo].[Prescription_Medicament] DROP CONSTRAINT [Prescription_Medicament_Medicament]
 
