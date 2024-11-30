﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        public PadraoDAO()
        {
            SetTabela();
        }

        protected string Tabela { get; set; }

        protected abstract SqlParameter[] CriaParametros(T model);

        protected abstract T MontaModel(DataRow registro);

        protected abstract void SetTabela();

        protected bool ChaveIdentity { get; set; } = false;

        public virtual int Insert(T model)
        {
            return HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model), ChaveIdentity);
        }

        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model), ChaveIdentity);
        }

        public virtual void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id),
                 new SqlParameter("tabela", Tabela)
            };

            HelperDAO.ExecutaProc("spDelete", p, ChaveIdentity);
        }

        public virtual T Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id),
                 new SqlParameter("tabela", Tabela)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", p);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public virtual T ConsultaPedido(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id),
                 new SqlParameter("tabela", Tabela)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spConsultaPedido", p);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public virtual int ConsultaQuantidadeProdutosNoPedido(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spQuantidadeProdutosNoPedido", p);

            return int.Parse(tabela.Rows[0].ItemArray[0].ToString());
        }

        public virtual List<T> ConsultaProdutosNoPedido(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spProdutosNoPedido", p);

            List<T> lista = new List<T>();

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));

            return lista;
        }

        public virtual int ProximoId()
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("tabela", Tabela) 
            };
            
            var tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0][0]);
        }

        public virtual List<T> Listagem()
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("tabela", Tabela),
                 new SqlParameter("Ordem", "1") // 1 é o primeiro campo da tabela
            };

            var tabela = HelperDAO.ExecutaProcSelect("spListagem", p);

            List<T> lista = new List<T>();

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));

            return lista;
        }
    }
}