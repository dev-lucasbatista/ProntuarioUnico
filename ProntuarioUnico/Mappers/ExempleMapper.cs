using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class ExempleMapper : Profile
    {
        public ExempleMapper()
        {
            //CreateMap<AtendimentoPaciente, HistoricoExcelView>()
            //    .ForMember(excelView => excelView.Ih_Paciente, _ => _.MapFrom(viewModel => viewModel.Ih_Paciente));
        }

        public override string ProfileName
        {
            get { return "ExempleMapper"; }
        }
    }
}