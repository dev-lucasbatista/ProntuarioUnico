using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class MapperPessoaFisicaViewModelToPessoaFisica : Profile
    {
        public MapperPessoaFisicaViewModelToPessoaFisica()
        {
            CreateMap<PessoaFisicaViewModel, PessoaFisica>()
                .ForMember(model => model.Codigo, _ => _.MapFrom(viewModel => viewModel.Codigo))
                .ForMember(model => model.Nome, _ => _.MapFrom(viewModel => viewModel.Nome))
                .ForMember(model => model.DataNascimento, _ => _.MapFrom(viewModel => viewModel.DataNascimento))
                .ForMember(model => model.Email, _ => _.MapFrom(viewModel => viewModel.Email))
                .ForMember(model => model.CPF, _ => _.MapFrom(viewModel => viewModel.CPF.Trim().Replace(".", "").Replace("-", "")));
        }

        public override string ProfileName
        {
            get { return "MapperPessoaFisicaViewModelToPessoaFisica"; }
        }
    }
}