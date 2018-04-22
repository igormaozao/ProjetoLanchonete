function AdicionarLancheListaPedido() {
    let elemento = $("#lanchesSelect")[0];
    
    $.get(
        URLActionGetLanche,
        { idLanche: elemento.value },
        function (res) {
            adicionarLanchePedido(res.lanche);
        }
    );
}

function CriarPedido() {
    let lanchesPedido = [];
    Object.keys(LanchesTabela).map(key => lanchesPedido.push(LanchesTabela[key]));

    $.post(
        URLActionCriarPedido,
        { lanchesPedido },
        function (res) {
            if (res && res.success === true) {
                alert("Pedido Criado com sucesso!");
            }
            else {
                alert("Erro ao criar pedido!");
            }
        }
    );
}

function removerLanchePedido(lancheUID) {
    delete LanchesTabela[lancheUID];
    listarLanchesPedido();
}

function adicionarLanchePedido(lanche) {
    lanche.UID = randomID();
    LanchesTabela[lanche.UID] = lanche;
    listarLanchesPedido();
}

function listarLanchesPedido() {
    let tabela = $("#tBodyListaLanches")[0];
    tabela.innerHTML = ''; //Zera a tabela
    let valorTotal = 0.0;

    Object.keys(LanchesTabela).map((key) => {
        let lanche = LanchesTabela[key];
        let ingredientes = lanche.ingredientes.map(i => `${i.quantidade || 1} ${i.nome}`).join(", ");
        valorTotal += lanche.valorTotal;

        tabela.insertRow(-1).innerHTML = `
            <tr>
                <td><button type="button" class="btn-sm btn-danger glyphicon glyphicon-remove" onclick="removerLanchePedido('${key}')" /></td>
                <td>${lanche.nome}</td>
                <td>${ingredientes}</td>
                <td>${floatToMoedaReal(lanche.valorDesconto)}</td>
                <td>${floatToMoedaReal(lanche.valorTotal)}</td>
                <td><button id="btnOpenModal" type="button" class="btn btn-info" onclick="abrirModalIngredientes('${key}')">Alterar Ingredientes</button></td>
            </tr>`;
    });

    let tdValorTotal = $("#tdValorTotalPedido")[0];
    tdValorTotal.innerHTML = floatToMoedaReal(valorTotal);
}

function abrirModalIngredientes(lancheUID) {
    $("#myModal").modal('show', lancheUID);
}

function listarIngredientesLanche(lanche) {
    let tabela = $("#tBodyListaIngredientes")[0];
    tabela.innerHTML = '';

    if (lanche.ingredientes.length > 0) {
        lanche.ingredientes.map((ingrediente) => {

            tabela.insertRow(-1).innerHTML = `
                <tr>
                    <td>${ingrediente.nome}</td>
                    <td><input id="${removerEspacos(ingrediente.nome)}" type="number" min="1" max="10" class="form-control input-number" value="${ingrediente.quantidade || 1}" onchange="setQuantidadeIngrediente('${ingrediente.nome}')"></td>
                </tr>`;
        });
    }
}

function setQuantidadeIngrediente(nomeIngrediente) {
    let input = $(`#${removerEspacos(nomeIngrediente)}`)[0];
    LanchesTabela[LancheAtual.UID].ingredientes.map(i => {
        if (i.nome === nomeIngrediente) {
            i.quantidade = parseInt(input.value);
        }
    });
}

function adicionarIngrediente() {
    let select = $("#selectIngrediente")[0];
    let nomeIngrediente = select.value;
    if (LancheAtual.ingredientes.findIndex(i => i.nome === nomeIngrediente) >= 0) {
        //Ingrediente já está no lanche
        LanchesTabela[LancheAtual.UID].ingredientes.map((i) => {
            if (i.nome === nomeIngrediente) {
                if (i.quantidade === undefined) i.quantidade = 1;
                i.quantidade++;
            }
        });
    }
    else {
        //Adiciona o ingrediente novo
        let ingrediente = DadosIngredientes.find(i => i.nome === nomeIngrediente);
        ingrediente.quantidade = 1;

        LanchesTabela[LancheAtual.UID].ingredientes.push(ingrediente);
    }

    listarIngredientesLanche(LancheAtual);
}

$(function () {

    $("#myModal").on("shown.bs.modal", function (e) {
        let lancheUID = e.relatedTarget;
        let lanche = LanchesTabela[lancheUID];
        LancheAtual = lanche;

        listarIngredientesLanche(lanche);
    });

    $("#myModal").on("hide.bs.modal", function () {

        $.post(URLActionCalcularDescontoLanche,
            LanchesTabela[LancheAtual.UID],
            (res) => {
                if (res && res.success === true) {
                    res.lanche.UID = LancheAtual.UID;
                    LanchesTabela[LancheAtual.UID] = res.lanche;
                    listarLanchesPedido();
                }
                else {
                    alert("Erro calculando valor do lanche!");
                }
            }
        );
    });
});