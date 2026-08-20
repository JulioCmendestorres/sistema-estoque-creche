//FUNÇÃO PARA LISTAR AS TABELAS
        async function carregar() {
            try {
                const res = await fetch('/api/CategoriasItens');
                const dados = await res.json();
                
                const tbody = document.getElementById('tabela');
                tbody.innerHTML = ''; // Limpa a tabela

                dados.forEach(categoria => {
                    tbody.innerHTML += `
                        <tr>
                            <td>${categoria.id}</td>
                            <td>${categoria.nome}</td>
                            <td>${categoria.descricao || ''}</td>
                            <td>
                                <button class="excluir" onclick="excluir(${categoria.id})">Excluir</button>
                            </td>
                        </tr>
                    `;
                });
            } catch (e) {
                document.getElementById('tabela').innerHTML = '<tr><td colspan="4">Erro ao carregar os dados.</td></tr>';
            }
        }

        //FUNÇÃO PARA CRIAR - FAZ POST
        document.getElementById('formCategoria').addEventListener('submit', async (evento) => {
            evento.preventDefault();
            
            const nomeInput = document.getElementById('nome').value;
            const descricaoInput = document.getElementById('descricao').value;

            await fetch('/api/CategoriasItens', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ 
                    nome: nomeInput, 
                    descricao: descricaoInput, 
                    ativo: true 
                })
            });

            document.getElementById('formCategoria').reset(); 
            carregar(); // Atualiza a tabela para mostrar o novo item
        });

        //FUNÇÃO PARA EXCLUIR NO BANCO
        async function excluir(id) {
            if (confirm('Tem certeza que deseja excluir esta categoria?')) {
                await fetch(`/api/CategoriasItens/${id}`, { method: 'DELETE' });
                carregar();
            }
        }

        //CARREGA A TABELA AO ABRIR A PAGINA
        carregar();