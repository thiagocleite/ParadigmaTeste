using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma
{
    public static class OrganizarArvore
    {
        public static int[] Organizar(int[] arvore)
        {
            int aux = -1;
            int pos = 0;
            int raiz = 0;
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

            //Ordena galho esquerdo
            for (int i = 0; i < pos - 1; i++)
            {
                for (int j = 0; j < pos - 1; j++)
                {
                    if (arvore[j] > arvore[j + 1])
                    {
                        aux = arvore[j];
                        arvore[j] = arvore[j + 1];
                        arvore[j + 1] = aux;
                    }
                }
            }
            //Ordena galho direito
            for (int i = pos + 1; i < arvore.Length - 1; i++)
            {
                for (int j = pos + 1; j < arvore.Length - 1; j++)
                {

                    if (arvore[j] < arvore[j + 1])
                    {
                        aux = arvore[j];
                        arvore[j] = arvore[j + 1];
                        arvore[j + 1] = aux;
                    }
                }
            }
            //retorna arvore ordenada
            return arvore;
        }
    }
}
