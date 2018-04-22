
function SetPromocaoLanche(idLanche, nomePromocao) {
    $.post(
        URLActionAlterarPromocaoLanche,
        { idLanche, nomePromocao },
        function (res) {
            if (res && res.success === true) {
                alert("Promoção alterada com sucesso!");
                $(`#tdPromo-${idLanche}`)[0].innerHTML = nomePromocao;
            }
            else {
                alert("Erro ao alterar a promoção do lanche!");
            }
        }
    );
}