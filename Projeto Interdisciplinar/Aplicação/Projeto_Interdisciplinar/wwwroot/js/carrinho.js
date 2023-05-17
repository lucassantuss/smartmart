$url = '192.168.15.86';
$idCarrinho = '#IdCarrinho';

function Pesquisar() {

    var codigoCarrinho = $($idCarrinho).val();

    console.log(codigoCarrinho);

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

            const carrinhoAtual = data[0];
            // const carrinhoAtual = data[idCarrinho];

            for (const key in carrinhoAtual) {
                if (key.startsWith("p")) {
                    const propertyName = key; // Nome da Proprieda - Ex: p1
                    const propertyValue = carrinhoAtual[key].value; // Valor da Propriedade - Ex: 1

                    AdicionarCarrinho(propertyValue, 1);
                }
            }
        },
    });
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