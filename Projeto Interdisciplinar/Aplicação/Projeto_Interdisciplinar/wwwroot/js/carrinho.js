// $url = '10.5.10.34';
$url = '192.168.15.86';
$idCarrinho = '#IdCarrinho';

function Pesquisar() {
    var codigoCarrinho = $($idCarrinho).val(); // codigo perguntado no input da tela - Ex: 123

    if (codigoCarrinho != "")
        Carrinho('urn:ngsi-ld:leitor:' + codigoCarrinho);
}

var AdicionarCarrinho = function (carrinho, produto) {

    var base_path = window.location.origin;

    $.ajax({
        type: "POST",
        url: base_path + "/Carrinho/AdicionarCarrinho",
        data: {
            'idCarrinho': carrinho,
            'idProduto': produto,
        },
        cache: false,
        dataType: "html"
    });
};

var EfetuarPedido = function (idCarrinho) {

    debugger;
    var base_path = window.location.origin;

    $.ajax({
        type: "POST",
        url: base_path + "/Carrinho/EfetuarPedido",
        data: {
            'idCarrinho': idCarrinho
        },
        cache: false,
        dataType: "html",
        success: function (data, textStatus, XMLHttpRequest) {

            alert('Pedido efetuado com sucesso!!');
            window.location.href = base_path;
        },

    });
};

var Carrinho = function (codigoCarrinho) {

    var base_path = window.location.origin;

    $.ajax({
        cache: false,
        type: 'GET',
        url: 'http://' + $url + ':1026/v2/entities',
        dataType: 'json',
        headers: {
            "Accept": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/"
        },
        success: function (data, textStatus, XMLHttpRequest) {

            // Encontrar o item com o ID "urn:ngsi-ld:leitor:123" por exemplo
            var itemEncontrado = null;
            for (var i = 0; i < data.length; i++) {
                if (data[i].id === codigoCarrinho) {
                    itemEncontrado = data[i];
                    break;
                }
            }

            // Verificar se o item foi encontrado e exibi-lo
            if (itemEncontrado) {
                AdicionarCarrinho($($idCarrinho).val(), Number(itemEncontrado.produto.value));
                window.location.reload;

                window.location.href = base_path + "/Carrinho/?idCarrinho=" + $($idCarrinho).val();
            }
        },
    });
};

var Visualizar = function () {

    var base_path = window.location.origin;
    var codigoCarrinho = $($idCarrinho).val();

    window.location.href = base_path + "/Carrinho/Visualizar?idCarrinho=" + codigoCarrinho;
};