import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FaArrowLeft, FaEdit, FaTrashAlt } from 'react-icons/fa';
import api from '../../../services/api';

import './styles.css';

export default function Produtos() {
    const [produtos, setProdutos] = useState([]);
    
    const history = useHistory();

    useEffect(() => {
        api.get('produtos')
            .then(response => {
                setProdutos(response.data);
            });
    }, []);

    function Remover(idProduto) {
        api.delete(`produtos/${idProduto}`)
            .then(response => {
                alert('Produto excluido');
                setProdutos(produtos.filter(produto => produto.idProduto !== idProduto));
            }).catch(err => {
                alert('Erro ao excluir Produto');
            });
    };

    function Editar(idProduto) {
        history.push(`/editar-produtos/${idProduto}`)
    };

    return (
        <div className='product-container'>
            <header>
                <Link to='/'>
                    <FaArrowLeft size={18} color="#FFF" />
                </Link>
                <h1>Produtos</h1>
            </header>

            <Link to='/gravar-produtos'>
                <p style={{ color: '#FFF' }}>Gravar Produto</p>
            </Link>

            <div className='content'>
                <ul>
                    {produtos.map(produto => (
                        <li key={produto.idProduto}>
                            <p>{produto.descricao}</p>
                            <p>{produto.preco}</p>
                            <div className='actions'>
                                <FaEdit size={20} color="#000" onClick={() => Editar(produto.idProduto)} />
                                <FaTrashAlt size={20} color="#000" onClick={() => Remover(produto.idProduto)} />
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}