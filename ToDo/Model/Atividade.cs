using System;
using System.Collections.Generic;
using System.Data;
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
        private String dataCriacao;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public String DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public int Status { get => status; set => status = value; }

        public string Inserir(Atividade a)
        {   
            try
            {
                Conn().Open();
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
        public List<Atividade> GetAllAtividades()
        {
            List<Atividade> atividades = new List<Atividade>();
            Conn().Open();
            var commando = Conn().CreateCommand();
             commando.CommandText = @"Select * From Atividade";
            var reader = commando.ExecuteReader();
            Atividade atv = new Atividade();
            while (reader.Read())
            {
                atv.Nome = reader.GetString(0);
                atv.Descricao = reader.GetString(1);
                atv.DataCriacao = reader.GetString(2);
                atv.Status = reader.GetInt32(3);
                atividades.Add(atv);
            }
            return atividades; 
        }
    }

    
}
