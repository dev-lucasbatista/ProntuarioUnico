var Login = window.Login || {

}

Login.Logar = function () {
    var lstrCPF = new String();
    var lstrSenha = new String();
    var lobjLogar = new Object();
    try {
        if (navigator.userAgent.toLowerCase().indexOf('chrome') < 0 &&
            navigator.userAgent.toLowerCase().indexOf('firefox') < 0) {
            throw 'Navegador não suportado';
        } else {
            lstrCPF = $('#txtLogin_Login').val();
            lstrSenha = $('#txtLogin_Senha').val();
            
            lobjLogar = {
                vstrCPF: lstrCPF.trim(),
                vstrSenha: lstrSenha.trim()
            };
            $.ajax({
                type: 'POST',
                url: gstrGlobalPath + 'Login/Logar',
                async: false,
                data: JSON.stringify(lobjLogar),
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (data, textStatus, XMLHttpRequest) {
                    var lstrReturnURL = new String('');
                    try {
                        if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                        
                        
                        Redirecionar(null, 'Home/Index');

                    } catch (ex) {
                        alert(ex);
                    }
                },
                error: function () {
                    throw 'Ocorreu um erro!';
                } 
            });
        }
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_EsqueceuSenha_Click = function () {
    try {
        $('#frmLogin_Entrar').css({ display: 'none' });
        $('#frmLogin_Senha').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_CriarConta_Click = function () {
    try {
        $('#frmLogin_Entrar').css({ display: 'none' });
        $('#frmLogin_CriarConta').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.AutenticarPessoa = function () {
    var lblnRetorno = false;
    var lstrCPF = new String();
    var vstrSenha = new String();

    try {
        lstrCPF = $('#txtLogin_Login').val();
        lstrSenha = $('#txtLogin_Senha').val();

        lobjLogar = {
            vstrCPF: lstrCPF.trim(),
            vstrSenha: lstrSenha.trim()
        };
        $.ajax({
            type: 'POST',
            url: gstrGlobalPath + 'Login/AutenticaPessoa',
            async: false,
            data: JSON.stringify(lobjLogar),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus, XMLHttpRequest) {
                try {
                    if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                    lblnRetorno = data.Retorno;
                    if (!lblnRetorno) {
                        $('#divLogin_ModalRecuperarSenha').modal("show", true);
                        $('#msgRetorno').text("CPF ou senha inválidos.");
                    }
                } catch (ex) {
                    alert(ex);
                }
            },
            error: function () {
                throw 'Ocorreu um erro!';
            }
        });
        return lblnRetorno;
    } catch (ex) {
        alert(ex);
    }
}

Login.AutenticarMedico = function () {
    var lblnRetorno = false;
    var lstrCRM = new String();
    var lstrSenha = new String();

    try {
        
        lstrCRM = $('#LoginCRM').val();
        lstrSenha = $('#LoginSenha_Medico').val();

        lobjLogar = {
            vstrCRM: lstrCRM.trim(),
            vstrSenha: lstrSenha.trim()
        };
        $.ajax({
            type: 'POST',
            url: gstrGlobalPath + 'Login/AutenticaMedico',
            async: false,
            data: JSON.stringify(lobjLogar),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus, XMLHttpRequest) {
                try {
                    if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                    lblnRetorno = data.Retorno;
                    if (!lblnRetorno) {
                        $('#divLogin_ModalRecuperarSenha').modal("show", true);
                        $('#msgRetorno').text("CRM ou senha inválidos.");
                    }
                } catch (ex) {
                    alert(ex);
                }
            },
            error: function () {
                throw 'Ocorreu um erro!';
            }
        });
        return lblnRetorno;
    } catch (ex) {
        alert(ex);
    }
}

Login.CadastrarPessoaFisica = function () {
    var lobjModel = new Object();
    var lblnRetorno = false;
    try {
        lobjModel.Nome = $('#txtLogin_Nome').val();
        lobjModel.CPF = $('#txtLogin_CPF').val();
        lobjModel.DataNascimento = new Date($('#txtLogin_DtNasc').val());
        lobjModel.Email = $('#txtLogin_Email').val();
        lobjModel.Senha = $('#txtLogin_CadastroSenha').val();
        lobjModel.ConfirmarSenha = $('#txtLogin_CadastroSenha_Confirmar').val();
        $.ajax({
            type: 'POST',
            url: gstrGlobalPath + 'Login/AutenticarCadastroPF',
            async: false,
            data: JSON.stringify(lobjModel),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus, XMLHttpRequest) {
                var lobjRetorno = new Object();
                try {
                    if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                    lobjRetorno = data.Retorno;
                    lblnRetorno = lobjRetorno.Cadastro
                    $('#divLogin_ModalRecuperarSenha').modal("show", true);
                    $('#msgRetorno').text(lobjRetorno.Mensagem);
                    $('#BtnModal').click(function () {
                        if (lblnRetorno) {
                            Redirecionar(null, 'Login/Login');
                        }
                    });
                } catch (ex) {
                    alert(ex);
                }
            },
            error: function () {
                throw 'Ocorreu um erro!';
            }
        });
        return lblnRetorno;
    } catch (ex) {
        alert(ex);
    }
}

Login.AutenticarRecuperarAcessoPessoaFisica = function () {
    var lobjEntrada = new Object()
    var lstrCPF = new String();
    var lblnRetorno = false;
    try {
        lstrCPF = $('#txtLogin_NovaSenha').val();
        lobjEntrada = {
            cpf: lstrCPF.trim()
        }
        $.ajax({
            type: 'POST',
            url: gstrGlobalPath + 'Login/AutenticarRecuperarAcessoPessoaFisica',
            async: false,
            data: JSON.stringify(lobjEntrada),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus, XMLHttpRequest) {
                var lobjRetorno = new Object();
                try {
                    if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                    lobjRetorno = data.Retorno;
                    lblnRetorno = lobjRetorno.Cadastro
                    $('#divLogin_ModalRecuperarSenha').modal("show", true);
                    $('#msgRetorno').text(lobjRetorno.Mensagem);
                    $('#BtnModal').click(function () {
                        if (lblnRetorno) {
                            Redirecionar(null, 'Login/Login');
                        }
                    });
                } catch (ex) {
                    alert(ex);
                }
            },
            error: function () {
                throw 'Ocorreu um erro!';
            }
        });
        return lblnRetorno;
    } catch (ex) {
        alert(ex);
    }
}

Login.AutenticarRecuperarAcessoMedico = function () {
    var lobjEntrada = new Object()
    var lstrCRM = new String();
    var lblnRetorno = false;
    try {
        lstrCRM = $('#txtLogin_NovaSenha_Medico').val();
        lobjEntrada = {
            crm: lstrCRM.trim()
        }
        $.ajax({
            type: 'POST',
            url: gstrGlobalPath + 'Login/AutenticarRecuperarAcessoMedico',
            async: false,
            data: JSON.stringify(lobjEntrada),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus, XMLHttpRequest) {
                var lobjRetorno = new Object();
                try {
                    if (data.Exception != null) { throw JSON.parse(data.Exception).Message }
                    lobjRetorno = data.Retorno;
                    lblnRetorno = lobjRetorno.Cadastro
                    $('#divLogin_ModalRecuperarSenha').modal("show", true);
                    $('#msgRetorno').text(lobjRetorno.Mensagem);
                    $('#BtnModal').click(function () {
                        if (lblnRetorno) {
                            Redirecionar(null, 'Login/Login');
                        }
                    });
                } catch (ex) {
                    alert(ex);
                }
            },
            error: function () {
                throw 'Ocorreu um erro!';
            }
        });
        return lblnRetorno;
    } catch (ex) {
        alert(ex);
    }
}

//#region Voltar

Login.btnLayoutVoltar_Click = function () {
    try {
        $('#frmLogin_Senha').css({ display: 'none' });
        $('#frmLogin_Entrar').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_Cancelar_Click = function () {
    try {
        $('#frmLogin_CriarConta').css({ display: 'none' });
        $('#frmLogin_Entrar').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_SouMedico_Click = function () {
    try {
        $('#frmLogin_Entrar').css({ display: 'none' });
        $('#frmLogin_Entrar_Medico').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_EsqueceuSenha_Medico_Click = function () {
    try {
        $('#frmLogin_Entrar_Medico').css({ display: 'none' });
        $('#frmLogin_Senha_Medico').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.btnLayoutVoltarMedico_Click = function () {
    try {
        $('#frmLogin_Senha_Medico').css({ display: 'none' });
        $('#frmLogin_Entrar_Medico').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

Login.spnLogin_MedicoVoltar_Click = function () {
    try {
        $('#frmLogin_Entrar_Medico').css({ display: 'none' });
        $('#frmLogin_Entrar').css({ display: 'block' });
    } catch (ex) {
        alert(ex);
    }
}

//#endregion Voltar