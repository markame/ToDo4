using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Data.Sqlite;

namespace ToDo.Service
{
    public class ConexaoSqlite
    {
        public readonly string _connectionString;
       
        public ConexaoSqlite()
        {
            _connectionString = "Data Source=todo.db";
            CtbAtividade();
            Conn();

           
        }
        public SqliteConnection Conn()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            connection.CreateCommand();
            return connection;
        }
        public string CtbAtividade()
        {
            try
            {
                var comando = Conn().CreateCommand();
                comando.CommandText = @"Create table if not exists Atividade(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nome TEXT NOT NULL,
                    descricao TEXT NOT NULL,
                    dataCriacao DATETIME NOT NULL,
                    status INTEGER NOT NULL     
                )";
                comando.ExecuteNonQuery();
                Conn().Close();
                return "Inserido com sucesso";
            }
            catch (Exception ex)
            {
                Conn().Close();
                return ex.Message;
            }
        }
    }
}
