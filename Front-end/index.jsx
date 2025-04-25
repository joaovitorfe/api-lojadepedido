import React, { useEffect, useState } from 'react';
import axios from 'axios';

// Componente principal da aplicação
function App() {
  // Estados para armazenar os pedidos, status de carregamento e possíveis erros
  const [pedidos, setPedidos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // useEffect para buscar os pedidos ao carregar o componente
  useEffect(() => {
    const fetchPedidos = async () => {
      try {
        setLoading(true); // Define o estado de carregamento como verdadeiro
        // Faz uma requisição GET para buscar os pedidos
        const response = await axios.get('http://localhost:5189/api/pedido');
        setPedidos(response.data); // Atualiza o estado com os dados recebidos
        setError(null); // Reseta o erro caso a requisição seja bem-sucedida
      } catch (err) {
        console.error('Erro ao buscar pedidos:', err); // Loga o erro no console
        // Define uma mensagem de erro para exibição ao usuário
        setError('Não foi possível carregar os pedidos. Tente novamente mais tarde.');
      } finally {
        setLoading(false); // Define o estado de carregamento como falso
      }
    };

    fetchPedidos(); // Chama a função para buscar os pedidos
  }, []); // O array vazio garante que o efeito seja executado apenas uma vez

  // Renderiza uma mensagem de carregamento enquanto os dados estão sendo buscados
  if (loading) return <div>Carregando...</div>;

  // Renderiza uma mensagem de erro caso ocorra algum problema na requisição
  if (error) return <div style={{ color: 'red' }}>{error}</div>;

  // Renderiza a lista de pedidos ou uma mensagem caso não haja pedidos
  return (
    <div>
      <h1>Pedidos</h1>
      {pedidos.length === 0 ? (
        <p>Nenhum pedido encontrado</p> // Mensagem exibida se não houver pedidos
      ) : (
        <ul>
          {pedidos.map(pedido => (
            <li key={pedido.id}>
              {/* Exibe as informações de cada pedido */}
              Pedido #{pedido.id} - Status: {pedido.status}
              <br />
              Data: {new Date(pedido.dataCriacao).toLocaleString()}
              <br />
              Valor Total: R$ {pedido.valorTotal.toFixed(2)}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;

// O código acima é um exemplo de um componente React que busca e exibe uma lista de pedidos de uma API.
// Ele utiliza o hook useEffect para fazer a requisição quando o componente é montado e gerencia estados de carregamento e erro.