import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import Home from './pages/home';
import Produtos from './pages/produto/produtos';
import GravarProdutos from './pages/produto/gravarProdutos';
import EditarProdutos from './pages/produto/editarProdutos';

import Categorias from './pages/categoria/categorias';
import GravarCategorias from './pages/categoria/gravarCategorias';
import EditarCategorias from './pages/categoria/editarCategorias';

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path='/' exact component={Home} />
                <Route path='/produtos' component={Produtos} />
                <Route path='/gravar-produtos' component={GravarProdutos} />
                <Route path='/editar-produtos/:id'><EditarProdutos /></Route>
                <Route path='/categorias' component={Categorias} />
                <Route path='/gravar-categoria' component={GravarCategorias} />
                <Route path='/editar-categoria/:id'><EditarCategorias /></Route>
            </Switch>
        </BrowserRouter>
    )
}