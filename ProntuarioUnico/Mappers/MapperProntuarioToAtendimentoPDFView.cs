using AutoMapper;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class MapperProntuarioToAtendimentoPDFView : Profile
    {
        public MapperProntuarioToAtendimentoPDFView()
        {
            CreateMap<Prontuario, AtendimentoPDFView>()
                .ForMember(model => model.NumeroAtendimento, _ => _.MapFrom(viewModel => Convert.ToString(viewModel.NumeroAtendimento)))
                .ForMember(model => model.TipoAtendimento, _ => _.MapFrom(viewModel => viewModel.TipoAtendimento))
                .ForMember(model => model.DataAtendimento, _ => _.MapFrom(viewModel => viewModel.DataAtendimento.ToString("dd/MM/yyyy hh:mm tt")))
                .ForMember(model => model.NomeMedico, _ => _.MapFrom(viewModel => viewModel.NomeMedico))
                .ForMember(model => model.Especialidade, _ => _.MapFrom(viewModel => viewModel.Especialidade))
                .ForMember(model => model.Sintomas, _ => _.MapFrom(viewModel => viewModel.Sintomas))
                .ForMember(model => model.Diagnostico, _ => _.MapFrom(viewModel => viewModel.Diagnostico))
                .ForMember(model => model.Prescricao, _ => _.MapFrom(viewModel => viewModel.Prescricao))
                .ForMember(model => model.Observacoes, _ => _.MapFrom(viewModel => viewModel.Observacoes));
        }

        public override string ProfileName
        {
            get { return "MapperProntuarioToAtendimentoPDFView"; }
        }
    }
}