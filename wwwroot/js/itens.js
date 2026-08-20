//FUNÇÃO PARA LISTAR OS ITENS
async function carregar() {
    try {
        const res = await fetch('/api/Itens');
        const dados = await res.json();

        const tbody = document.getElementById('tabela');
        tbody.innerHTML = ''; // Limpa a tabela

        dados.forEach(item => {
            tbody.innerHTML += `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nome}</td>
                    <td>${item.codigoInterno}</td>
                    <td>${item.quantidadeAtual}</td>
                    <td>${item.quantidadeMinima}</td>
                    <td>${item.unidadeMedida || ''}</td>
                    <td>
                        <button class="excluir" onclick="excluir(${item.id})">Excluir</button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        document.getElementById('tabela').innerHTML = '<tr><td colspan="7">Erro ao carregar os dados.</td></tr>';
    }
}

//FUNÇÃO PARA CRIAR - FAZ POST
document.getElementById('formItem').addEventListener('submit', async (evento) => {
    evento.preventDefault();

    const nomeInput = document.getElementById('nome').value;
    const codigoInternoInput = document.getElementById('codigoInterno').value;
    const categoriaIdInput = document.getElementById('categoriaId').value;
    const quantidadeAtualInput = document.getElementById('quantidadeAtual').value;
    const quantidadeMinimaInput = document.getElementById('quantidadeMinima').value;
    const unidadeMedidaInput = document.getElementById('unidadeMedida').value;
    const descricaoInput = document.getElementById('descricao').value;

    await fetch('/api/Itens', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            nome: nomeInput,
            codigoInterno: codigoInternoInput,
            categoriaId: parseInt(categoriaIdInput),
            quantidadeAtual: parseInt(quantidadeAtualInput),
            quantidadeMinima: parseInt(quantidadeMinimaInput) || 0,
            unidadeMedida: unidadeMedidaInput,
            descricao: descricaoInput,
            ativo: true
        })
    });

    document.getElementById('formItem').reset();
    carregar(); // Atualiza a tabela para mostrar o novo item
});

//FUNÇÃO PARA EXCLUIR NO BANCO
async function excluir(id) {
    if (confirm('Tem certeza que deseja excluir este item?')) {
        await fetch(`/api/Itens/${id}`, { method: 'DELETE' });
        carregar();
    }
}

//CARREGA A TABELA AO ABRIR A PAGINA
carregar();
