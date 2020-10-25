using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected string Tabela { get; set; }
        protected string Chave { get; set; }
        protected string OrderBy { get; set; }
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);

        public virtual int Insert(T model)
        {
            var dt = HelperDAO.ExecutaProcSelect("spInsert_" + this.Tabela, this.CriaParametros(model));

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);

            return 0;
        }

        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + this.Tabela, this.CriaParametros(model));
        }

        public virtual void Delete(T model)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", model.Id),
                new SqlParameter("tabela", this.Tabela)
            };

            HelperDAO.ExecutaProc("spDelete", parametros);
        }

        public virtual void Delete(T model, SqlConnection conexao, SqlTransaction transacao)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", model.Id),
                new SqlParameter("chave", this.Chave),
                new SqlParameter("tabela", this.Tabela)
            };

            HelperDAO.ExecutaProc("spDelete", conexao, transacao, parametros);
        }

        public virtual void Delete(int id)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("chave", this.Chave),
                new SqlParameter("tabela", this.Tabela)
            };

            HelperDAO.ExecutaProc("spDelete", parametros);
        }

        public virtual void Delete(int id, SqlConnection conexao, SqlTransaction transacao)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", this.Tabela)
            };

            HelperDAO.ExecutaProc("spDelete", conexao, transacao, parametros);
        }

        public virtual T Consulta(int id)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("chave", this.Chave),
                new SqlParameter("tabela", this.Tabela)
            };

            var dt = HelperDAO.ExecutaProcSelect("spConsulta", parametros);

            if (dt.Rows.Count == 0)
                return null;

            return this.MontaModel(dt.Rows[0]);
        }

        public virtual int ProximoId()
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("tabela", this.Tabela)
            };

            var dt = HelperDAO.ExecutaProcSelect("spProximoId", parametros);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public virtual IEnumerable<T> Listagem()
        {
            if (string.IsNullOrEmpty(this.OrderBy))
                this.OrderBy = "Id";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("tabela", this.Tabela),
                new SqlParameter("ordem", this.OrderBy)
            };

            var dt = HelperDAO.ExecutaProcSelect("spListagem", parametros);

            if (dt.Rows.Count == 0)
                return null;

            List<T> itens = new List<T>();

            foreach (DataRow registro in dt.Rows)
            {
                itens.Add(this.MontaModel(registro));
            }

            return itens;
        }

        public virtual IEnumerable<T> Listagem(int id)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("chave", this.Chave),
                new SqlParameter("tabela", this.Tabela)
            };

            var dt = HelperDAO.ExecutaProcSelect("spConsulta", parametros);

            if (dt.Rows.Count == 0)
                return null;

            List<T> itens = new List<T>();

            foreach (DataRow registro in dt.Rows)
            {
                itens.Add(this.MontaModel(registro));
            }

            return itens;
        }
    }
}
