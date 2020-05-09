var Index = window.Index || {
    marrDataSource_TbProntuario: [
        {
            Atendimento_NR: 17896,
            Atendimento_TP: 'Consulta',
            Atendimento_DT: '15/11/2019 11:30',
            Medico_NM: 'Dr. Jorge Neto',
            Medico_Especialidade: 'Cirurgião gastro',
            Atendimento_DS: 'Casos de dores abdominais crônicas indicativos de gastrite, requisição de exames.Casos de dores abdominais crônicas indicativos de gastrite, requisição de exames.'
        },
        {
            Atendimento_NR: 17523,
            Atendimento_TP: 'Exame',
            Atendimento_DT: '13/11/2019 14:00',
            Medico_NM: 'Dr William Saad',
            Medico_Especialidade: 'Cirurgião gastro',
            Atendimento_DS: 'Verificação de pedras na vesícula.'
        },
        {
            Atendimento_NR: 17000,
            Atendimento_TP: 'Exame',
            Atendimento_DT: '12/11/2019 14:00',
            Medico_NM: 'Dr William Saad',
            Medico_Especialidade: 'Cirurgião gastro',
            Atendimento_DS: 'Verificação de gatrite.'
        }
    ]
}

Index.MontarTela = function () {
    try {
        Index.CriarComponentes();
    } catch (ex) {
        alert(ex);
    }
}

Index.CriarComponentes = function () {
    try {
        // Carrega os dados da tabela
        Index.GerarTbProntuario(Index.marrDataSource_TbProntuario);
        // Ação de clique nas linhas da tabela
        $('.cssIndex_TbProntuario_Row').click(function () {
            Index.TbProntuario_Expandir($(this)[0]);
        });
    } catch (ex) {
        alert(ex);
    }
}

Index.TbProntuario_Expandir = function (vobjElmento) {
    try {
        if ($(vobjElmento.nextElementSibling).css('display') == 'table-row') {
            $(vobjElmento.nextElementSibling).css({ display: 'none' })
            vobjElmento.children[3].children[0].children[0].src = gstrGlobalPath + '/Content/Imagens/Home/imgDown.png'
        } else {
            $(vobjElmento.nextElementSibling).css({ display: 'table-row' })
            vobjElmento.children[3].children[0].children[0].src = gstrGlobalPath + '/Content/Imagens/Home/imgUp.png'
        }
    } catch (ex) {
        alert(ex);
    }
}

Index.GerarTbProntuario = function (varrDataSource) {
    var lobjProntuario_Template = new Object();
    var lobjProntuario = new Object();
    try {

        function render(props) {
            return function (tok, i) {
                return (i % 2) ? props[tok] : tok;
            };
        }

        // Gerar template
        lobjProntuario_Template = $('script[data-template="tmpIndex_TbProntuario_Rows"]').text().split(/\$\{(.+?)\}/g);
        $('#tblIndex_TbProntuario tbody').append(varrDataSource.map(function (lobjProntuario) {
            return lobjProntuario_Template.map(render(lobjProntuario)).join('');
        }));
    } catch (ex) {
        alert(ex);
    }
}

// Ativa assim que a página é totalmente renderizada
//$(document).ready({

//    Index.MontarTela();
//});
$(document).ready(function () {
    Index.MontarTela();
});