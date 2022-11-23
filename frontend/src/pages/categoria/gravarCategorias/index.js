import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';

import { FaArrowLeft } from 'react-icons/fa';

import './styles.css';

export default function GravarCategorias() {
    const [codigo, setCodigo] = useState(0);
    const [descricao, setDescricao] = useState('');
    const [idCategoria, setIdCategoria] = useState(0);
    const [categorias, setCategorias] = useState([]);

    const history = useHistory();

    useEffect(() => {
        api.get('categorias')
            .then(response => {
                setCategorias(response.data);
            });
    }, []);

    async function Gravar() {
        const data = {
            "idCategoria": idCategoria,
            codigo,
            descricao,
        };
    
        try {
            await api.post('categorias', data);
            alert ('Cadastrar Categoria');
    
            history.push("/categorias");
        } catch (error) {
            alert('Ops! Houve um erro, tente novamente');
        }
    };

    return (
        <div className='register-contatiner'>
            <header>
                <Link to="/categorias">
                    <FaArrowLeft size={18} color='#FFF' />
                </Link>
                <h1>Registrar um novo produto</h1>
            </header>

            <div className='content'>
                <form onSubmit={Gravar}>
                    <div className='input-group'>
                        <h3>Codigo da Categoria</h3>
                        <input 
                            type='number'
                            placeholder='Codigo da Categoria'
                            value={codigo}
                            onChange={e => setCodigo(e.target.value)}
                        />
                        <p>Apenas números</p>
                    </div>

                    <div className='input-group'>
                        <h3>Nome</h3>
                        <input 
                            type='text'
                            placeholder='Nome da Categoria'
                            value={descricao}
                            onChange={e => setDescricao(e.target.value)}
                        />
                    </div>

                    <button type="submit">
                        Registrar
                    </button>
                </form>
            </div>
        </div>
    );
}

