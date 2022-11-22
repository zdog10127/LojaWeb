﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Dominio.Entidades
{
    public class RetornoDto
    {
        public bool HouveErro { get; set; }
        public string? TituloErro { get; set; }
        public string? MensagemDeErro { get; set; }
        public string? CodigoErro { get; set; }
        public string? Codigo { get; set; }
        public object? ObjetoRetorno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotaRequisicao"></param>
        /// <returns></returns>
        public CreatedResult RetornarResultado(string rotaRequisicao)
        {
            ProblemDetails detalhesDoProblema = new();
            detalhesDoProblema.Status = int.Parse(CodigoErro);
            detalhesDoProblema.Type = "";
            detalhesDoProblema.Detail = Codigo + "" + MensagemDeErro;
            detalhesDoProblema.Title = TituloErro;
            detalhesDoProblema.Instance = rotaRequisicao;

            CreatedResult createdResult = new("", null);
            createdResult.StatusCode = int.Parse(CodigoErro);
            createdResult.Value = detalhesDoProblema;

            return createdResult;
        }
    }
}
