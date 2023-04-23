var controles = function () {
    return {
        txtUsuario: "#LoginUsuario",
        txtSenha: "#SenhaUsuario",
    }
};
 
function modalLogin() {

    $.ajax({
        url: "/Autenticacao/_Login",
        dataType: 'html',
        beforeSend: function () {

        },
        success: function (data) {

            $('#modal-body').html(data);
            $('#modal_validacao').modal('show');
            document.getElementById("titulo-modal").innerHTML = 'Login';
        }
    });
}

function efetuarLogin(usuario, senha) {
    
    if (txtUsuario.val() == "" && txtSenha.val() == "") {
        mostrarAvisoPopup("Usuário e senha são obrigatórios");
        return;
    }
    else if (txtUsuario.val() == "") {
        mostrarAvisoPopup("Usuário é obrigatório");
        return;
    }
    else if (txtSenha.val() == "") {
        mostrarAvisoPopup("Usuário é obrigatório");
        return;
    }
    else {
        $.ajax({
            url: "/Autenticacao/_Login",
            dataType: 'html',
            beforeSend: function () {

            },
            success: function (data) {

                $('#modal-body').html(data);
                $('#modal_validacao').modal('show');
                document.getElementById("titulo-modal").innerHTML = 'Login';
            }
        });
    }
}

var mostrarAvisoPopup = function (msg, beforeClose) {
    return mostrarErroPopupTitulo("Aviso!", msg, beforeClose);
}

var mostrarErroPopupTitulo = function (Titulo, msg, beforeClose) {
    if (msg != null && msg != "") {
        $(".dialog-msg-erro").remove();

        var html = "<div id='dialog-msg-erro' class='dialog-msg-erro msgErro'>" +
            "<div id='msg-erro'>" +
            "<span class='control-label' style='text-align: center'>" + msg + "</span>" +
            "</div>" +
            "</div>";

        $("#form").append(html);

        return $(".dialog-msg-erro").dialog({
            autoOpen: true,
            width: 466,
            resizable: false,
            modal: true,
            show: "puff",
            hide: "puff",
            title: Titulo,
            dialogClass: 'dialogErro',
            beforeClose: function (event, ui) {
                $(".overlay-carregando").remove();
                if (beforeClose != undefined)
                    beforeClose();
            },
            open: function (event, ui) {
                //hide close button.
                $(this).parent().children().children('.ui-dialog-titlebar-close').attr('id', 'btn_close_modal');
                $(this).parent().children().children('.ui-dialog-titlebar-close').html('X').style('color', 'white', 'important');
            },
        });
    }
}