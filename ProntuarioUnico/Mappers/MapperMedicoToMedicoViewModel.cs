using AutoMapper;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class MapperMedicoToMedicoViewModel : Profile
    {
        public MapperMedicoToMedicoViewModel()
        {
            CreateMap<Medico, MedicoViewModel>()
                .ForMember(model => model.Codigo, _ => _.MapFrom(viewModel => viewModel.Codigo))
                .ForMember(model => model.CRM, _ => _.MapFrom(viewModel => viewModel.CRM))
                .ForMember(model => model.CodigoPessoaFisica, _ => _.MapFrom(viewModel => viewModel.CodigoPessoaFisica))
                .ForMember(model => model.NomeGuerra, _ => _.MapFrom(viewModel => viewModel.NomeGuerra))
                .ForMember(model => model.Email, _ => _.MapFrom(viewModel => viewModel.Email));
        }

        public override string ProfileName
        {
            get { return "MapperMedicoToMedicoViewModel"; }
        }
    }
}