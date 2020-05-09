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
        // Carrega título da página
        TituloPagina('Prontuário - #20485');
        // Carrega os dados da tabela
        Index.GerarTbProntuario(Index.marrDataSource_TbProntuario);
        // Ação de clique nas linhas da tabela
        $('.cssIndex_TbProntuario_Row').click(function () {
            Index.TbProntuario_Expandir($(this)[0]);
        });
        // Carregar filtro
        Index.Carregar_Filtro();
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

Index.Carregar_Filtro = function () {
    var lobjFiltro = new Object();
    var lobjFiltroContent = new Object();
    try {
        lobjFiltro = document.getElementsByClassName('cssIndex_Filtro');

        for (var i = 0; i < lobjFiltro.length; i++) {
            lobjFiltro[i].onclick = function () {
                lobjFiltroContent = this.nextElementSibling;

                if (lobjFiltroContent.style.maxHeight) {
                    lobjFiltroContent.style.maxHeight = null;
                    lobjFiltroContent.style.borderBottom = 'none';
                    lobjFiltroContent.style.padding = '0';
                    this.getElementsByTagName('button')[0].firstElementChild.src = gstrGlobalPath + 'Content/Imagens/InserirAtendimento/add.png';
                } else {
                    lobjFiltroContent.style.maxHeight = '100vh';
                    lobjFiltroContent.style.borderBottom = 1 + 'px solid #B7A5A5';
                    lobjFiltroContent.style.padding = '20px 20px 10px';
                    this.getElementsByTagName('button')[0].firstElementChild.src = gstrGlobalPath + 'Content/Imagens/InserirAtendimento/close.png';
                }
            }
        }
    } catch (ex) {
        alert(ex);
    }
}

Index.Filtro_Click = function () {
    var lobjFiltroContent = new Object();
    try {
        lobjFiltroContent = this.nextElementSibling;

        if (lobjFiltroContent.style.maxHeight) {
            lobjFiltroContent.style.maxHeight = null;
        } else {
            lobjFiltroContent.style.maxHeight = lobjFiltroContent.scrollHeight + 'px';
        }
    } catch (ex) {
        alert(ex);
    }
}

// Ativa assim que a página é totalmente renderizada
$(document).ready(function () {
    Index.MontarTela();
});