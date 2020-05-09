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
                        debugger;
                        
                        
                        Redirecionar('Home/Index');

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

//#endregion Voltar