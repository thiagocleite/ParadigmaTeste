using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma
{
    class Arvore
    {
        public Node root;
        public Arvore()
        {
            root = null;
        }
        public void PopularArvore(int[] arvore)
        {
            int aux = -1;
            int pos = 0;
            int raiz = 0;
            bool galho = true;// se true preenche galho esquerdo se false preenche galho direito

            //Extrai Raiz como base
            for (int i = 0; i < arvore.Length; i++)
            {
                if (arvore[i] > aux)
                {
                    aux = arvore[i];
                    pos = i;
                }
            }

            raiz = aux;
            InserirNode(raiz,galho);
            for (int i = pos-1; i >= 0; i--)
            {
                InserirNode(arvore[i], galho);
            }
            galho = false;
            for (int i = pos+1; i < arvore.Length; i++)
            {
                InserirNode(arvore[i], galho);
            }
        }
        public void InserirNode(int valor, bool galho)
        {
            Node novoNode = new Node();
            novoNode.info = valor;
            if (root == null)
            {
                root = novoNode;
                Console.WriteLine("Criando no Raiz : {0}", valor);
            }
            else
            {
                Node atual = root;
                Node pai;
                while (true)
                {
                    pai = atual;
                    if (galho)
                    {
                        atual = atual.galhoEsq;
                        if (atual == null)
                        {
                            pai.galhoEsq = novoNode;
                            break;
                        }
                    }
                    else
                    {
                        atual = atual.galhoDir;
                        if (atual == null)
                        {
                            pai.galhoDir = novoNode;
                            break;
                        }
                    }
                }
                Console.WriteLine("Adicionado na árvore: {0}", valor);
            }
        }
        public void naOrdem(Node raiz)
        {
            if (!(raiz == null)) {
                naOrdem(raiz.galhoEsq);
                raiz.ExibirNode();
                naOrdem(raiz.galhoDir);
            }
        }
        public void Desenhar(Node raiz, bool galho = true)
        {
            if (!(raiz == null))
            {
                raiz.ExibirNode();
                if (galho) { Console.Write(" -> "); }
                else { Console.WriteLine("\nV"); }
                Desenhar(raiz.galhoDir);
                Desenhar(raiz.galhoEsq,false);
            }
        }
    }
}
