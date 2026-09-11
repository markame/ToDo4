using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using ToDo.Service;

namespace ToDo.Model
{
    public class Atividade: ConexaoSqlite
    {
        private int id;
        private string nome;
        private string descricao;
        private DateTime dataCriacao;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public int Status { get => status; set => status = value; }

        public string Inserir(Atividade a)
        {   
            try
            {
                var comando = Conn().CreateCommand();
                comando.CommandText = @"Insert Into Atividade (nome, descricao,dataCriacao, status)" +
                    "Values(@nome,@descricao,@dataCriacao,@status)";
                comando.Parameters.AddWithValue("@nome", a.Nome);
                comando.Parameters.AddWithValue("@descricao", a.Descricao);
                comando.Parameters.AddWithValue("@dataCriacao", a.DataCriacao);
                comando.Parameters.AddWithValue("@status", a.Status);
                comando.ExecuteNonQuery();
                return "Atividade inserida com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao inserir atividade: " + ex.Message;
            }
        }
    }

    
}
