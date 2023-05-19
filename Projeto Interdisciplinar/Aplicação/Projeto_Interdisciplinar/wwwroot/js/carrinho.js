$url = '10.5.10.34';
// $url = '192.168.15.86';
$idCarrinho = '#IdCarrinho';

function init() {
    var codigoCarrinho = 'urn:ngsi-ld:leitor:123';

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

            // Encontrar o item com o ID "urn:ngsi-ld:leitor:123"
            var itemEncontrado = null;
            for (var i = 0; i < data.length; i++) {
                if (data[i].id === codigoCarrinho) {
                    itemEncontrado = data[i];
                    break;
                }
            }

            // Verificar se o item foi encontrado e exibi-lo
            if (itemEncontrado) {
                console.log(itemEncontrado);
            } else {
                console.log("Item não encontrado");
            }


        },
    });
}

function Pesquisar() {
    const carrinhoAtual = data[0];
    // const carrinhoAtual = data[idCarrinho];

    for (const key in carrinhoAtual) {
        if (key.startsWith("p")) {
            const propertyName = key; // Nome da Proprieda - Ex: p1
            const propertyValue = carrinhoAtual[key].value; // Valor da Propriedade - Ex: 1

            AdicionarCarrinho(propertyValue, 1);
        }
    }
}

function Alterar(id, valor) {

    $.ajax({
        cache: false,
        type: 'POST',
        url: 'http://' + $url + ':1026/v2/entities/urn:ngsi-ld:leitor:' + id + '/attrs',
        headers: {
            "Content-Type": "application/json",
            "fiware-service": "helixiot",
            "fiware-servicepath": "/"
        },
        data: JSON.stringify({
            "id": valor
        }),
        dataType: 'json',
        success: function (data, textStatus, XMLHttpRequest) {

            console.log(data);
        },
    });
}

var AdicionarCarrinho = function (idProduto, qtd) {

    var base_path = window.location.origin;

    $.ajax({
        type: "POST",
        url: base_path + "/Carrinho/AdicionarCarrinho",
        data: {
            idProduto: idProduto,
            Quantidade: qtd
        },
        cache: false,
        dataType: "html",
        success: function (data) {

        }
    });
};