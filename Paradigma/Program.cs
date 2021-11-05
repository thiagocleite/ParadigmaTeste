using System;
using System.Data.SqlClient;

namespace Paradigma
{
    class Program
    {
        static void Main(string[] args)
        {

            //Parte 1
            try
            {
                Consulta consulta = new Consulta();
                consulta.Conectar();
                consulta.ExecutarConsulta();
                consulta.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu o erro : {0}", Erro.getMsg());
                Console.WriteLine("No caminho {0}", e.StackTrace);
            }
            //Parte 2 
            //Arvore em Array

            int[] arv1 = { 3, 2, 1, 6, 0, 5 };
            int[] arv2 = { 7, 5, 13, 9, 1, 6, 4 };
            foreach (var item in OrganizarArvore.Organizar(arv1))
            {
                Console.Write(item + "->");
            }
            Console.WriteLine("");
            foreach (var item in OrganizarArvore.Organizar(arv2))
            {
                Console.Write(item + "->");
            }
            Console.WriteLine("");

            //Arvore Binaria Degenerada

            Arvore arv = new Arvore();
            arv.PopularArvore(arv1);
            arv.naOrdem(arv.root);

            Arvore arvOutra = new Arvore();
            arvOutra.PopularArvore(arv2);
            arvOutra.naOrdem(arvOutra.root);

            Arvore arvD = new Arvore();
            arvD.PopularArvore(arv1);
            arvD.Desenhar(arvD.root);
            Console.ReadLine();
        }
    }
}