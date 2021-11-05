using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma
{
    class Node
    {
        public int info;
        public Node galhoEsq;
        public Node galhoDir;
        public void ExibirNode()
        {
            Console.Write(info + " ");
        }
    }
}
