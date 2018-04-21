function AdicionarLancheListaPedido() {
    let elemento = $("#lanchesSelect")[0];
    if (elemento.value == "-1") {
        var lanche = {
            nome: "Personalizado",
            ingredientes: []
        };
    }
    else {
        $.get(
            URLActionGetLanche,
            { idLanche: elemento.value },
            function (res) {
                console.log(res.lanche);
                adicionarDadosLanche(res.lanche);
            }
        )
    }
}


function adicionarDadosLanche(lanche) {
    let tabela = $("#tBodyListaLanches")[0];

    let ingredientes = lanche.ingredientes.map(i => `1 ${i.nome}`).join(", ");
    lanche.UID = randomID();

    tabela.insertRow(-1).innerHTML = `
        <tr>
            <td>${lanche.nome}</td>
            <td>${ingredientes}</td>
            <td>${floatToMoedaReal(lanche.valorTotal)}</td>
            <td><button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">Alterar Ingredientes</button></td>
        </tr>`;

    LanchesTabela[lanche.UID] = lanche;
}

$(function () {
    $("#btnAdicionarIngrediente").click(function () {

    });
});