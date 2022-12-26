﻿/*==============================================================================================================================
--Author:        Microsoft
--Created date : Feb-03-2020
--Updated date : Mar-20-2020
--Updated date : Apr-06-2020 -- Added SystemName as per PBI 28962
--Updated date : Apr-22-2020 -- Added EventType Column as per PBI 25056
--Updated date : May-05-2020 -- Added MovementTransactionId Column
--Updated date : Jun-15-2020 -- Added BatchId and AttributeId column as per PBI 31874
--<Description>: This table holds the data for quality attributes of movements before cutoff. This table is being used in before cutoff report.</Description>
=================================================================================================================================*/
CREATE TABLE Admin.OperationalMovementQuality
(
	--Columns
     OperationalMovementQualityId   INT                                 NOT NULL IDENTITY(1,1),
	 RNo							INT									NOT NULL,
	 BatchId                        NVARCHAR (25)                       NULL,
	 MovementId						VARCHAR	 (50) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	 MovementTransactionId			INT                                 NULL,
	 CalculationDate				DATETIME							NOT NULL,
	 MovementTypeName				NVARCHAR (150)						NULL,
	 SourceNode						NVARCHAR (150)						NULL,
	 DestinationNode				NVARCHAR (150)						NULL,
	 SourceProduct					NVARCHAR (150)						NULL,
	 DestinationProduct				NVARCHAR (150)						NULL,
	 NetStandardVolume				DECIMAL	 (18,2)						NULL,
	 GrossStandardVolume			DECIMAL	 (18,2)						NULL,
	 MeasurementUnit				NVARCHAR (150)						NULL,
	 EventType                      NVARCHAR (20)                       NULL,
	 SystemName						VARCHAR  (50)						NULL,	 
	 Movement						NVARCHAR (150)						NULL,
	 PercentStandardUnCertainty		DECIMAL	 (5,2)						NULL,
	 Uncertainty					DECIMAL	 (18,2)						NULL,
	 AttributeId                    NVARCHAR (150)                      NULL,
	 AttributeValue					NVARCHAR (150)						NULL,									
     ValueAttributeUnit				NVARCHAR (150)						NULL,										
     AttributeDescription			NVARCHAR (150)						NULL,	
	 ProductID						NVARCHAR (20)						NOT NULL,
     ExecutionId				    INT					                NOT NULL,

	 --Internal Common Columns													
	 [CreatedBy]					NVARCHAR (260)						NOT NULL,
	 [CreatedDate]					DATETIME							NOT NULL,

    --Constraints
    CONSTRAINT [PK_OperationalMovementQualityId]                PRIMARY KEY CLUSTERED ([OperationalMovementQualityId] ASC),
    CONSTRAINT [FK_OperationalMovementQuality_ReportExecution]	FOREIGN KEY ([ExecutionId])			REFERENCES [Admin].[ReportExecution] ([ExecutionId])
)
GO

ALTER TABLE [Admin].[OperationalMovementQuality] SET (LOCK_ESCALATION = DISABLE)
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The correlative number of the record',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'RNo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The batch number of the record',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'BatchId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The identifier of the movement',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'MovementId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The datetime when the calculation was done',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'CalculationDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the movement type',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'MovementTypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the source node',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'SourceNode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the destination node',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'DestinationNode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the source product',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'SourceProduct'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the destination product',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'DestinationProduct'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the net standard volume',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'NetStandardVolume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the gross standard volume',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'GrossStandardVolume'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the measurement unit',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'MeasurementUnit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the system',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'SystemName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the percentage standard of the uncertainty',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'PercentStandardUnCertainty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the movement',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'Movement'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the uncertainty',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'Uncertainty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The id of the attribute',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'AttributeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the attribute',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'AttributeValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the attribute unit',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'ValueAttributeUnit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The description of the attribute',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'AttributeDescription'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The identifier of the product',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'ProductID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The identifier of the execution of the record',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'ExecutionId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The creator of the record, normally system (common column)',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'CreatedBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The datetime when the record is created (common column)',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'CreatedDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The identifier of movement',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'MovementTransactionId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The type of the event (Insert, Update, etc)',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = N'COLUMN',
    @level2name = N'EventType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This table holds the data for quality attributes of movements before cutoff. This table is being used in before cutoff report.',
    @level0type = N'SCHEMA',
    @level0name = N'Admin',
    @level1type = N'TABLE',
    @level1name = N'OperationalMovementQuality',
    @level2type = NULL,
    @level2name = NULL