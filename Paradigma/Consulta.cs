using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Paradigma
{
    class Consulta
    {
        private static string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thiag\source\repos\Paradigma\Paradigma\bin\Debug\netcoreapp3.1\dbDesafio.mdf;Integrated Security=True;Connect Timeout=30";
        private string strConsulta;
        private static SqlConnection conn = new SqlConnection(conexao);
        private static SqlCommand strSql;
        private static SqlDataReader dr;
        public void ExecutarConsulta()
        {
            strConsulta = @"SELECT
                            Departamento.Nome AS Departamento,
                            Pessoa.Nome,
                            Pessoa.Salario
                            FROM
                            Pessoa
                            INNER JOIN
                            (SELECT Pessoa.DeptId, MAX(Pessoa.Salario) AS Salario FROM Pessoa GROUP BY Pessoa.DeptId)
                            t ON t.DeptId = Pessoa.DeptId and t.Salario = Pessoa.Salario
                            INNER JOIN
                            Departamento ON Departamento.Id = Pessoa.DeptId ORDER BY Departamento.Id ASC";

            strSql = new SqlCommand(strConsulta, conn);
            dr = strSql.ExecuteReader();
            if (dr.HasRows)
            {
                Console.WriteLine("{0}\t\t\t\t\t\t{1}\t\t\t\t\t\t\t{2}", dr.GetName(0),
                         dr.GetName(1),
                         dr.GetName(2));
                while (dr.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}", dr.GetValue(0),
                        dr.GetValue(1),
                        dr.GetValue(2));
                }
            }
            else
            {
                Console.WriteLine("Nenhum dado foi encontrado");
            }
            dr.Close();
        }
        public void Conectar()
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Erro.setErro(e.Message);
                throw new Exception("Ocorreu um erro");
            }
        }
        public void Desconectar()
        {
            conn.Close();
        }
    }
}
