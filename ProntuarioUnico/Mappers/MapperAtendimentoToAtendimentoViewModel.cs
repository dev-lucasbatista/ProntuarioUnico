using AutoMapper;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Atendimento;


namespace ProntuarioUnico.Mappers
{
    public class MapperAtendimentoToAtendimentoViewModel : Profile
    {
        public MapperAtendimentoToAtendimentoViewModel()
        {
            CreateMap<Atendimento, AtendimentoViewModel>()
                .ForMember(model => model.CodigoPessoaFisica, _ => _.MapFrom(viewModel => viewModel.CodigoPessoaFisica))
                .ForMember(model => model.CodigoTipoAtendimento, _ => _.MapFrom(viewModel => viewModel.CodigoTipoAtendimento))
                .ForMember(model => model.CodigoEspecialidade, _ => _.MapFrom(viewModel => viewModel.CodigoEspecialidade))
                .ForMember(model => model.Sintomas, _ => _.MapFrom(viewModel => viewModel.Sintomas))
                .ForMember(model => model.Diagnostico, _ => _.MapFrom(viewModel => viewModel.Diagnostico))
                .ForMember(model => model.Prescricao, _ => _.MapFrom(viewModel => viewModel.Prescricao))
                .ForMember(model => model.Observacao, _ => _.MapFrom(viewModel => viewModel.Observacao));
        }

        public override string ProfileName
        {
            get { return "MapperAtendimentoToAtendimentoViewModel"; }
        }
    }
}