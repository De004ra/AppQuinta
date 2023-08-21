using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conexao = new MySqlConnection(@"Server = Localhost;database=dbAppBanco;user = root; password = 12345678");

            conexao.Open();
            Console.WriteLine("Banco conectado!");

            Console.WriteLine("Digite seu nome ae amigao");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite seu cargo ae amigao");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite seu Data de Nascimento ae amigao");
            string dataNasc = Console.ReadLine();

            MySqlCommand ObjCommand = new MySqlCommand();
            ObjCommand.Connection = conexao;

            string strUpdate = "update tbUsuario set NomeUso = 'Lucas' where IdUso = 4;";
            ObjCommand.CommandText = strUpdate;
            ObjCommand.ExecuteNonQuery();

            string strDelete = "DELETE FROM TBUSUARIO WHERE IdUso = 3";
            ObjCommand.CommandText = strDelete;
            ObjCommand.ExecuteNonQuery(); 
           
            string strInsert = $"insert into tbUsuario(NomeUso, Cargo, DataNasc)values('{nome}', '{cargo}', STR_TO_DATE('{dataNasc}', '%d/%m/%Y'))";
            ObjCommand.CommandText = strInsert;
            ObjCommand.ExecuteNonQuery();

            var strSelect = "SELECT * FROM tbUsuario";

            ObjCommand.CommandText = strSelect;

            MySqlDataReader leitor = ObjCommand.ExecuteReader();

            while (leitor.Read())
            {
                var resposta = $"{leitor["IdUso"]} | {leitor["NomeUso"]} | {leitor["Cargo"]} | {leitor["DataNasc"]}";
                Console.WriteLine(resposta);
            }

            leitor.Close();            
            conexao.Close();

            Console.Read();
        }
    }
}