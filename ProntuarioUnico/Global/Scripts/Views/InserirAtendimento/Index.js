var InserirAtendimento_Index = window.InserirAtendimento_Index || {
    marrDataSource_cboInserirAtendimentoIndex_TipoAtendimento: [
        {
            value: 1,
            name: 'Cirurgia'
        },
        {
            value: 2,
            name: 'Consulta'
        },
        {
            value: 3,
            name: 'Exame'
        }
    ],
    marrDataSource_cboInserirAtendimentoIndex_Especialidade: [
        {
            value: 1,
            name: 'Ecocardiografia'
        },
        {
            value: 2,
            name: 'Gastroenterologia'
        }
    ]
}

InserirAtendimento_Index.MontarTela = function () {
    try {
        InserirAtendimento_Index.CriarComponentes();
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.CriarComponentes = function () {
    try {
        // Carrega título da página
        TituloPagina('Cadastro de Atendimento');
        // Carregar cboInserirAtendimentoIndex_TipoAtendimento
        InserirAtendimento_Index.Carregar_cboInserirAtendimentoIndex_TipoAtendimento(this.marrDataSource_cboInserirAtendimentoIndex_TipoAtendimento);
        // Carregar cboInserirAtendimentoIndex_Especialidade
        InserirAtendimento_Index.Carregar_cboInserirAtendimentoIndex_Especialidade(this.marrDataSource_cboInserirAtendimentoIndex_Especialidade);
        // Carregar filtro
        InserirAtendimento_Index.Carregar_Filtro();
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.Carregar_cboInserirAtendimentoIndex_TipoAtendimento = function (varrDataSource) {
    var lobjTipoAtendimento_Template = new Object();
    var lobjTipoAtendimento = new Object();
    try {
        function render(props) {
            return function (tok, i) {
                return (i % 2) ? props[tok] : tok;
            };
        }
        // Gerar template
        lobjTipoAtendimento_Template = $('script[data-template="tmpInserirAtendimento_Option"]').text().split(/\$\{(.+?)\}/g);
        $('#cboInserirAtendimentoIndex_TipoAtendimento').append(varrDataSource.map(function (lobjTipoAtendimento) {
            return lobjTipoAtendimento_Template.map(render(lobjTipoAtendimento)).join('');
        }));
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.Carregar_cboInserirAtendimentoIndex_Especialidade = function (varrDataSource) {
    var lobjEspecialidade_Template = new Object();
    var lobjEspecialidade = new Object();
    try {
        function render(props) {
            return function (tok, i) {
                return (i % 2) ? props[tok] : tok;
            };
        }
        // Gerar template
        lobjEspecialidade_Template = $('script[data-template="tmpInserirAtendimento_Option"]').text().split(/\$\{(.+?)\}/g);
        $('#cboInserirAtendimentoIndex_Especialidade').append(varrDataSource.map(function (lobjEspecialidade) {
            return lobjEspecialidade_Template.map(render(lobjEspecialidade)).join('');
        }));
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.Salvar = function () {
    var lobjAtendimento = new Object();
    try {
        lobjAtendimento.Prontuario_NR = parseInt($('#txtInserirAtendimento_NrProntuario').val());
        lobjAtendimento.Especialidade_ID = parseInt($('#cboInserirAtendimentoIndex_Especialidade option:selected').attr('key_expr'));
        lobjAtendimento.TipoAtendimento_ID = parseInt($('#cboInserirAtendimentoIndex_TipoAtendimento option:selected').attr('key_expr'));
        lobjAtendimento.Atendimento_DS = $('#txtInserirAtendimento_Observacoes').val();
        console.log(lobjAtendimento);
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.Carregar_Filtro = function () {
    var lobjFiltro = new Object();
    var lobjFiltroContent = new Object();
    try {
        lobjFiltro = document.getElementsByClassName('cssInserirAtendimentoIndex_Filtro');

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
            }//InserirAtendimento_Index.Filtro_Click();
        }
    } catch (ex) {
        alert(ex);
    }
}

InserirAtendimento_Index.Filtro_Click = function () {
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

$(document).ready(function () {
    InserirAtendimento_Index.MontarTela();
});