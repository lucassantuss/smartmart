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