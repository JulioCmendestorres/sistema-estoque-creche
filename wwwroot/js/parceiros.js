//FUNÇÃO PARA LISTAR OS PARCEIROS
async function carregar() {
    try {
        const res = await fetch('/api/Parceiros');
        const dados = await res.json();

        const tbody = document.getElementById('tabela');
        tbody.innerHTML = ''; // Limpa a tabela

        dados.forEach(parceiro => {
            tbody.innerHTML += `
                <tr>
                    <td>${parceiro.id}</td>
                    <td>${parceiro.nome}</td>
                    <td>${parceiro.cnpj}</td>
                    <td>${parceiro.tipo}</td>
                    <td>${parceiro.telefone || ''}</td>
                    <td>
                        <button class="excluir" onclick="excluir(${parceiro.id})">Excluir</button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        document.getElementById('tabela').innerHTML = '<tr><td colspan="6">Erro ao carregar os dados.</td></tr>';
    }
}

//FUNÇÃO PARA CRIAR - FAZ POST
document.getElementById('formParceiro').addEventListener('submit', async (evento) => {
    evento.preventDefault();

    const nomeInput = document.getElementById('nome').value;
    const cnpjInput = document.getElementById('cnpj').value;
    const tipoInput = document.getElementById('tipo').value;
    const telefoneInput = document.getElementById('telefone').value;
    const emailInput = document.getElementById('email').value;
    const enderecoInput = document.getElementById('endereco').value;

    await fetch('/api/Parceiros', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            nome: nomeInput,
            cnpj: cnpjInput,
            tipo: tipoInput,
            telefone: telefoneInput,
            email: emailInput,
            endereco: enderecoInput,
            ativo: true
        })
    });

    document.getElementById('formParceiro').reset();
    carregar(); // Atualiza a tabela para mostrar o novo parceiro
});

//FUNÇÃO PARA EXCLUIR NO BANCO
async function excluir(id) {
    if (confirm('Tem certeza que deseja excluir este parceiro?')) {
        await fetch(`/api/Parceiros/${id}`, { method: 'DELETE' });
        carregar();
    }
}

//CARREGA A TABELA AO ABRIR A PAGINA
carregar();
