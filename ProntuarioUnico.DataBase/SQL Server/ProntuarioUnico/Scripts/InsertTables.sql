USE [ProntuarioUnico]
GO

INSERT INTO [dbo].[TIPO_ATENDIMENTO]
           ([DS_TIPO_ATENDIMENTO]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Consultas'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[TIPO_ATENDIMENTO]
           ([DS_TIPO_ATENDIMENTO]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Exame'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Dermatologia'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Ortopedia'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Psiquiatria'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Oftalmologia'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Cardiologia'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ESPECIALIDADE_ATENDIMENTO]
           ([DS_ESPECIALIDADE]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Urologia'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[PESSOA_FISICA]
           ([NM_PESSOA_FISICA]
           ,[DT_NASCIMENTO]
           ,[DS_TELEFONE]
           ,[NR_CPF]
           ,[DS_SENHA]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('André Matias'
           ,'1998-12-25'
           ,'1155322139'
           ,'12345695246'
           ,'teste'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[PESSOA_FISICA]
           ([NM_PESSOA_FISICA]
           ,[DT_NASCIMENTO]
           ,[DS_TELEFONE]
           ,[NR_CPF]
           ,[DS_SENHA]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           ('Robson Mauricio'
           ,'1990-02-13'
           ,'1142316548'
           ,'45698725482'
           ,'teste'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[MEDICO]
           ([CRM_MEDICO]
           ,[CD_PESSOA_FISICA]
           ,[NM_GUERRA]
           ,[DS_SENHA]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           (52715573
           ,1
           ,'Dr Robson Mauricio'
           ,'teste'
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ATENDIMENTO_PACIENTE]
           ([CD_PESSOA_FISICA]
           ,[CRM_MEDICO]
           ,[ID_TIPO_ATENDIMENTO]
           ,[ID_ESPECIALIDADE]
           ,[DT_ATENDIMENTO]
           ,[DS_SINTOMA]
           ,[DS_DIAGNOSTICO]
           ,[DS_PRESCRICAO]
           ,[DS_OBSERVACAO]
           ,[IE_ATIVO]
           ,[DT_ATUALIZACAO])
     VALUES
           (1
           ,52715573
           ,1
           ,5
           ,GETDATE()
           ,'Calor intenso e sufocameno.'
           ,'Pressão alta'
           ,'Remédio para pressão alta'
           ,'Medir a pressão'
           ,1
           ,GETDATE())
GO