function apagarUsuario(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = 'Acesso/Delete?id=' + id;
}