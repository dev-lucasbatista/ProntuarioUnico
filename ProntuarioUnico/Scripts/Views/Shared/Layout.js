var Layout = window.Layout || {
    meleDivLayout_ContentMenu: document.querySelector('#divLayout_ContentMenu'),
    meleBtnMenu: document.querySelector('#btnMenu')
}

Layout.Sair = function () {
    try {
        location.href = gstrGlobalPath + 'Login';
    } catch (ex) {
        alert(ex);
    }
}

Layout.btnLayout_PrincipalClick = function () {
    try {
        Redirecionar(null, 'Atendimento/Index');
    } catch (ex) {
        alert(ex);
    }
}

window.addEventListener('click', (e) => {
    var lblnExibir = false;
    try {
        
    } catch (ex) {
        alert(ex);
    }
});