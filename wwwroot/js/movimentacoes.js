//FUNÇÃO PARA LISTAR AS MOVIMENTAÇÕES
async function carregar() {
    try {
        const res = await fetch('/api/Movimentacoes');
        const dados = await res.json();

        const tbody = document.getElementById('tabela');
        tbody.innerHTML = ''; // Limpa a tabela

        dados.forEach(mov => {
            tbody.innerHTML += `
                <tr>
                    <td>${mov.id}</td>
                    <td>${mov.numeroMovimentacao}</td>
                    <td>${mov.tipoMovimentacao}</td>
                    <td>${mov.itemId}</td>
                    <td>${mov.quantidade}</td>
                    <td>${mov.status}</td>
                    <td>
                        <button class="excluir" onclick="excluir(${mov.id})">Excluir</button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        document.getElementById('tabela').innerHTML = '<tr><td colspan="7">Erro ao carregar os dados.</td></tr>';
    }
}

//FUNÇÃO PARA CRIAR - FAZ POST
document.getElementById('formMovimentacao').addEventListener('submit', async (evento) => {
    evento.preventDefault();

    const numeroMovimentacaoInput = document.getElementById('numeroMovimentacao').value;
    const tipoMovimentacaoInput = document.getElementById('tipoMovimentacao').value;
    const itemIdInput = document.getElementById('itemId').value;
    const quantidadeInput = document.getElementById('quantidade').value;
    const valorUnitarioInput = document.getElementById('valorUnitario').value;
    const parceiroIdInput = document.getElementById('parceiroId').value;
    const responsavelIdInput = document.getElementById('responsavelId').value;
    const dataMovimentacaoInput = document.getElementById('dataMovimentacao').value;
    const beneficiarioInput = document.getElementById('beneficiario').value;
    const descricaoSaidaInput = document.getElementById('descricaoSaida').value;
    const observacoesInput = document.getElementById('observacoes').value;

    await fetch('/api/Movimentacoes', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            numeroMovimentacao: numeroMovimentacaoInput,
            tipoMovimentacao: tipoMovimentacaoInput,
            itemId: parseInt(itemIdInput),
            quantidade: parseInt(quantidadeInput),
            valorUnitario: valorUnitarioInput ? parseFloat(valorUnitarioInput) : null,
            parceiroId: parceiroIdInput ? parseInt(parceiroIdInput) : null,
            responsavelId: parseInt(responsavelIdInput),
            dataMovimentacao: dataMovimentacaoInput,
            beneficiario: beneficiarioInput,
            descricaoSaida: descricaoSaidaInput,
            observacoes: observacoesInput,
            status: 'pendente'
        })
    });

    document.getElementById('formMovimentacao').reset();
    carregar(); // Atualiza a tabela para mostrar a nova movimentação
});

//FUNÇÃO PARA EXCLUIR NO BANCO
async function excluir(id) {
    if (confirm('Tem certeza que deseja excluir esta movimentação?')) {
        await fetch(`/api/Movimentacoes/${id}`, { method: 'DELETE' });
        carregar();
    }
}

//CARREGA A TABELA AO ABRIR A PAGINA
carregar();
