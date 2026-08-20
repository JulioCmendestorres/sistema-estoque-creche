//FUNÇÃO PARA LISTAR OS USUÁRIOS
async function carregar() {
    try {
        const res = await fetch('/api/Usuarios');
        const dados = await res.json();

        const tbody = document.getElementById('tabela');
        tbody.innerHTML = ''; // Limpa a tabela

        dados.forEach(usuario => {
            tbody.innerHTML += `
                <tr>
                    <td>${usuario.id}</td>
                    <td>${usuario.nome}</td>
                    <td>${usuario.email}</td>
                    <td>${usuario.papel}</td>
                    <td>
                        <button class="excluir" onclick="excluir(${usuario.id})">Excluir</button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        document.getElementById('tabela').innerHTML = '<tr><td colspan="5">Erro ao carregar os dados.</td></tr>';
    }
}

//FUNÇÃO PARA CRIAR - FAZ POST
document.getElementById('formUsuario').addEventListener('submit', async (evento) => {
    evento.preventDefault();

    const nomeInput = document.getElementById('nome').value;
    const emailInput = document.getElementById('email').value;
    const senhaInput = document.getElementById('senha').value;
    const papelInput = document.getElementById('papel').value;

    await fetch('/api/Usuarios', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            nome: nomeInput,
            email: emailInput,
            senha: senhaInput,
            papel: papelInput,
            ativo: true
        })
    });

    document.getElementById('formUsuario').reset();
    carregar(); // Atualiza a tabela para mostrar o novo usuário
});

//FUNÇÃO PARA EXCLUIR NO BANCO
async function excluir(id) {
    if (confirm('Tem certeza que deseja excluir este usuário?')) {
        await fetch(`/api/Usuarios/${id}`, { method: 'DELETE' });
        carregar();
    }
}

//CARREGA A TABELA AO ABRIR A PAGINA
carregar();
