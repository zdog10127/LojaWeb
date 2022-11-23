import React from 'react';
import { Link } from 'react-router-dom';
import { FaLongArrowAltRight } from 'react-icons/fa';

import './styles.css';

export default function Home() {
    return (
        <div className='home-container'>
            <Link to='/produtos'>
                <section className='card'>
                    <h1>Produtos</h1>
                    <p>
                        Clique aqui para visualizar os produtos.
                    </p>
                    <FaLongArrowAltRight size={20} color="#008000" />
                </section>
            </Link>

            <Link to='/categorias'>
                <section className='card'>
                    <h1>Categorias</h1>
                    <p>
                        Clique aqui para visualizar as categorias.
                    </p>
                    <FaLongArrowAltRight size={20} color="#008000" />
                </section>
            </Link>
        </div>
    );
}