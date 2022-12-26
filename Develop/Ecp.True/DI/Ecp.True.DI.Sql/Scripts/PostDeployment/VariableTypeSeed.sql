﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF	OBJECT_ID('Admin.VariableType') IS NOT NULL
BEGIN

-- Clearing any junk data from the reserved space
--DELETE FROM [Admin].[VariableType] WHERE VariableTypeId > 3 AND VariableTypeId < 101

-- Inserting Seed data with Identity
SET IDENTITY_INSERT [Admin].[VariableType] ON 

IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 1)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (1, N'Interfase',                'I',   'INTERFASE',   1, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '1' AND ([Name] <> 'Interfase'                  OR [ShortName] <> 'I'    OR [FicoName] IS NULL OR [FicoName] <> 'INTERFASE'     OR [IsConfigurable] <> 1))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Interfase',                 [ShortName] = 'I',   [FicoName] = 'INTERFASE'      ,[IsConfigurable] = 1 WHERE [VariableTypeId] = '1'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 2)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (2, N'Tolerancia',               'T',   'TOLERANCIA',  1, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '2' AND ([Name] <> 'Tolerancia'                 OR [ShortName] <> 'T'    OR [FicoName] IS NULL OR [FicoName] <> 'TOLERANCIA'    OR [IsConfigurable] <> 1))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Tolerancia',                [ShortName] = 'T',   [FicoName] = 'TOLERANCIA'     ,[IsConfigurable] = 1 WHERE [VariableTypeId] = '2'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 3)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (3, N'Pérdida No Identificada',  'PNI', 'PNI',         1, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '3' AND ([Name] <> 'Pérdida No Identificada'    OR [ShortName] <> 'PNI'  OR [FicoName] IS NULL OR [FicoName] <> 'PNI'           OR [IsConfigurable] <> 1))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Pérdida No Identificada',   [ShortName] = 'PNI', [FicoName] = 'PNI'            ,[IsConfigurable] = 1 WHERE [VariableTypeId] = '3'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 4)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (4, N'Inventario Inicial',       'IO',   NULL,         0, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '4' AND ([Name] <> 'Inventario Inicial'         OR [ShortName] <> 'IO'   OR [FicoName] IS NULL OR [FicoName] <>  NULL           OR [IsConfigurable] <> 0))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Inventario Inicial',        [ShortName] = 'IO',  [FicoName] =  NULL            ,[IsConfigurable] = 0 WHERE [VariableTypeId] = '4'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 5)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (5, N'Entrada',                  'E',    NULL,         0, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '5' AND ([Name] <> 'Entrada'                    OR [ShortName] <> 'E'    OR [FicoName] IS NULL OR [FicoName] <>  NULL           OR [IsConfigurable] <> 0))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Entrada',                   [ShortName] = 'E',   [FicoName] =  NULL            ,[IsConfigurable] = 0 WHERE [VariableTypeId] = '5'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 6)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (6, N'Salida',                   'S',    NULL,         0, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '6' AND ([Name] <> 'Salida'                     OR [ShortName] <> 'S'    OR [FicoName] IS NULL OR [FicoName] <>  NULL           OR [IsConfigurable] <> 0))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Salida',                    [ShortName] = 'S',   [FicoName] =  NULL            ,[IsConfigurable] = 0 WHERE [VariableTypeId] = '6'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 7)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (7, N'Pérdida Identificada',     'PI',   'PI',         1, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '7' AND ([Name] <> 'Pérdida Identificada'       OR [ShortName] <> 'PI'   OR [FicoName] IS NULL OR [FicoName] <>  'PI'           OR [IsConfigurable] <> 1))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Pérdida Identificada',      [ShortName] = 'PI',  [FicoName] =  'PI'            ,[IsConfigurable] = 1 WHERE [VariableTypeId] = '7'	END
IF NOT EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = 8)	BEGIN	INSERT [Admin].[VariableType] ([VariableTypeId], [Name], [ShortName], [FicoName], [IsConfigurable], [CreatedBy], [CreatedDate]) VALUES (8, N'Inventario Final',         'IF',   'INVENTARIO', 1, N'System', @CurrentTime)	END	ELSE IF EXISTS (SELECT 'X' FROM [Admin].[VariableType] WHERE [VariableTypeId] = '8' AND ([Name] <> 'Inventario Final'           OR [ShortName] <> 'IF'   OR [FicoName] IS NULL OR [FicoName] <>  'INVENTARIO'   OR [IsConfigurable] <> 1))	BEGIN	UPDATE [Admin].[VariableType] SET [Name] = 'Inventario Final',          [ShortName] = 'IF',  [FicoName] =  'INVENTARIO'    ,[IsConfigurable] = 1 WHERE [VariableTypeId] = '8'	END


SET IDENTITY_INSERT [Admin].[VariableType] OFF
END	