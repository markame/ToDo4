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
            Conn();
            CtbAtividade();
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
                comando.CommandText = @"Create or replace table Atividade(
                    id INTEGER PRIMARY KEY NOT NULL AUTOINCREMENT,
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
