// Write your Javascript code.
function randomID() {
    return Math.random().toString(36).replace(/[^a-z]+/g, '').substr(2, 10);
}

function floatToMoedaReal(valor) {
    return `R$${valor.toFixed(2)}`;
}

function removerEspacos(texto) {
    return texto.replace(/\s+/g, '');
}