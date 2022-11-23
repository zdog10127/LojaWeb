import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { FaArrowLeft } from 'react-icons/fa';
import api from '../../../services/api';

import './styles.css';

export default function EditarProdutos() {
    const [idProduto, setIdProduto] = useState(0);
    const [codigo, setCodigo] = useState(0);
    const [descricao, setDescricao] = useState('');
    const [preco, setPreco] = useState(0);

    useEffect(() => {
        api.get(`produtos/${idProduto}`)
            .then(resultado => {
                setCodigo(resultado.data.codigo);
                setDescricao(resultado.data.descricao);
                setPreco(resultado.data.preco);
            });
    }, [idProduto]);

    async function Atualizar() {
        const data = {
            "idProduto": idProduto,
            codigo,
            descricao,
            preco
        };

        console.log(data);

        try {
            await api.put(`produtos/${idProduto}`, data)
            alert('Produto atualizado');
        } catch (error) {
            alert('Erro ao atualizar o produto');
        }
    };

    return (
        <div className='edit-container'>
            <header>
                <Link to="/produtos">
                    <FaArrowLeft size={18} color="#FFF" />
                </Link>
                <h1>Editar Produto</h1>
            </header>

            <div className='content'>
                <form onSubmit={Atualizar}>
                    <div className='input-group'>
                        <h3>Codigo do Produto</h3>
                        <input 
                            type='number'
                            placeholder='Codigo do Produto'
                            value={codigo}
                            onChange={e => setCodigo(e.target.value)}
                        />
                        <p>Apenas números</p>
                    </div>

                    <div className='input-group'>
                        <h3>Nome</h3>
                        <input 
                            type='text'
                            placeholder='Nome do Produto'
                            value={descricao}
                            onChange={e => setDescricao(e.target.value)}
                        />
                    </div>

                    <div className='input-group'>
                        <h3>Preço</h3>
                        <input 
                            type='number'
                            placeholder='Preço do Produto'
                            value={preco}
                            onChange={e => setPreco(e.target.value)}
                        />
                        <p>Apenas números</p>
                    </div>

                    <button type="submit">
                        Atualizar
                    </button>
                </form>
            </div>
        </div>
    )
}