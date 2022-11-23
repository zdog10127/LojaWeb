import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';

import { FaArrowLeft } from 'react-icons/fa';

import './styles.css';

export default function GravarProdutos() {
    const [codigo, setCodigo] = useState(0);
    const [descricao, setDescricao] = useState('');
    const [idProduto, setIdProduto] = useState(0);
    const [preco, setPreco] = useState(0);
    const [produtos, setProdutos] = useState([]);

    const history = useHistory();

    useEffect(() => {
        api.get('produtos')
            .then(response => {
                setProdutos(response.data);
            });
    }, []);

    async function Gravar() {
        const data = {
            "idProduto": idProduto,
            codigo,
            descricao,
            preco
        };
    
        try {
            await api.post('produtos', data);
            alert ('Cadastrar Produtos');
    
            history.push("/produtos");
        } catch (error) {
            alert('Ops! Houve um erro, tente novamente');
        }
    };

    return (
        <div className='register-contatiner'>
            <header>
                <Link to="/produtos">
                    <FaArrowLeft size={18} color='#FFF' />
                </Link>
                <h1>Registrar um novo produto</h1>
            </header>

            <div className='content'>
                <form onSubmit={Gravar}>
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
                        Registrar
                    </button>
                </form>
            </div>
        </div>
    );
}

