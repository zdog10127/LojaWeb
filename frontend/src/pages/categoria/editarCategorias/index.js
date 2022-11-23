import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { FaArrowLeft } from 'react-icons/fa';
import api from '../../../services/api';

import './styles.css';

export default function EditarCategorias() {
    const [idCategoria, setIdCategoria] = useState(0);
    const [codigo, setCodigo] = useState(0);
    const [descricao, setDescricao] = useState('');
    const [categorias, setCategorias] = useState([]);

    useEffect(() => {
        api.get(`categorias/${idCategoria}`)
            .then(resultado => {
                setCodigo(resultado.data.codigo);
                setDescricao(resultado.data.descricao);
            });
    }, [idCategoria]);

    async function Atualizar() {
        const data = {
            "idCategoria": idCategoria,
            codigo,
            descricao
        };

        console.log(data);

        try {
            await api.put(`categorias/${idCategoria}`, data)
            alert('Categoria atualizada');
        } catch (error) {
            alert('Erro ao atualizar a categoria');
        }
    };

    return (
        <div className='edit-container'>
            <header>
                <Link to="/categorias">
                    <FaArrowLeft size={18} color="#FFF" />
                </Link>
                <h1>Editar Categoria</h1>
            </header>

            <div className='content'>
                <form onSubmit={Atualizar}>
                    <div className='input-group'>
                        <h3>Codigo da Categoria</h3>
                        <input 
                            type='number'
                            placeholder='Codigo da categoria'
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
                        Atualizar
                    </button>
                </form>
            </div>
        </div>
    )
}