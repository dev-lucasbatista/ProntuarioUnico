var Layout = window.Layout || {
    meleDivLayout_ContentMenu: document.querySelector('#divLayout_ContentMenu'),
    meleBtnMenu: document.querySelector('#btnMenu')
}

Layout.AbrirProntuario = function () {
    try {
        Redirecionar('Home/Index');
    } catch (ex) {
        alert(ex);
    }
}

Layout.btnLayout_PrincipalClick = function () {
    try {
        Redirecionar('InserirAtendimento/Index');
    } catch (ex) {
        alert(ex);
    }
}

Layout.Sair = function () {
    try {
        Redirecionar('Login');
    } catch (ex) {
        alert(ex);
    }
}