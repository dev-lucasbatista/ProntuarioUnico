using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class MapperNovoUsuarioPessoaFisicaViewModelToPessoaFisica : Profile
    {
        public MapperNovoUsuarioPessoaFisicaViewModelToPessoaFisica()
        {
            CreateMap<NovoUsuarioPessoaFisicaViewModel, PessoaFisica>()
                .ForMember(model => model.Nome, _ => _.MapFrom(viewModel => viewModel.Nome))
                .ForMember(model => model.CPF, _ => _.MapFrom(viewModel => viewModel))
                .ForMember(model => model.DataNascimento, _ => _.MapFrom(viewModel => viewModel.DataNascimento))
                .ForMember(model => model.Email, _ => _.MapFrom(viewModel => viewModel.Email))
                .ForMember(model => model.Senha, _ => _.MapFrom(viewModel => viewModel.Senha));
        }

        public override string ProfileName
        {
            get { return "MapperNovoUsuarioPessoaFisicaViewModelToPessoaFisica"; }
        }
    }
}