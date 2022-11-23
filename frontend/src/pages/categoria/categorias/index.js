import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FaArrowLeft, FaEdit, FaTrashAlt } from 'react-icons/fa';
import api from '../../../services/api';

import './styles.css';

export default function Categorias() {
    const [categorias, setCategorias] = useState([]);
    
    const history = useHistory();

    useEffect(() => {
        api.get('categorias')
            .then(response => {
                setCategorias(response.data);
            });
    }, []);

    function Remover(idCategoria) {
        api.delete(`categorias/${idCategoria}`)
            .then(response => {
                alert('Categoria excluida');
                setCategorias(categorias.filter(categoria => categoria.idCategoria !== idCategoria));
            }).catch(err => {
                alert('Erro ao excluir a Categoria');
            });
    };

    function Editar(idCategoria) {
        history.push(`/editar-categoria/${idCategoria}`)
    };

    return (
        <div className='category-container'>
            <header>
                <Link to='/'>
                    <FaArrowLeft size={18} color="#FFF" />
                </Link>
                <h1>Categoria</h1>
            </header>

            <Link to='/gravar-categoria'>
                <p style={{ color: '#FFF' }}>Gravar Categoria</p>
            </Link>

            <div className='content'>
                <ul>
                    {categorias.map(categoria => (
                        <li key={categoria.idCategoria}>
                            <strong>{categoria.codigoCategoria}</strong>
                            <p>{categoria.descricao}</p>
                            <div className='actions'>
                                <FaEdit size={20} color="#000" onClick={() => Editar(categoria.idCategoria)} />
                                <FaTrashAlt size={20} color="#000" onClick={() => Remover(categoria.idCategoria)} />
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}