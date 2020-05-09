var Medico = window.Medico || {

}

Medico.MontarTela = function () {
    try {
        Medico.CriarComponentes();
    } catch (ex) {
        alert(ex);
    }
}

Medico.CriarComponentes = function () {
    try {
        debugger;
    } catch (ex) {
        alert(ex);
    }
}

Medico.ControleCheckBox = function (controle) {
    try {
        var nomeInputSenhaAntiga = 'input[name^="medicoViewModel.SenhaAntiga"]';
        var nomeInputNovaSenha = 'input[name^="medicoViewModel.NovaSenha"]';
        var nomeInputConfirmarNovaSenha = 'input[name^="medicoViewModel.ConfirmarSenhaNova"]';

        var inputSenhaAntiga = $(nomeInputSenhaAntiga);
        var inputNovaSenha = $(nomeInputNovaSenha);
        var inputConfirmarNovaSenha = $(nomeInputConfirmarNovaSenha);

        inputSenhaAntiga[0].disabled = !controle.checked;
        inputNovaSenha[0].disabled = !controle.checked;
        inputConfirmarNovaSenha[0].disabled = !controle.checked;

        inputSenhaAntiga[0].value = "";
        inputNovaSenha[0].value = "";
        inputConfirmarNovaSenha[0].value = "";
    } catch (ex) {
        alert(ex);
    }
}

$(document).ready(function () {
    Medico.MontarTela();
});