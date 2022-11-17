// See https://aka.ms/new-console-template for more informatio


using System.Collections;

namespace Desafio
{
    public class ProgramClass
    {
        static ArrayList arrayList = new ArrayList();


        // Olá, vou tentar explicar o meu processo aqui. Comecei esse menu ai por que eu queria fazer mais coisa, mas acabei ficando sem tempo.
        public static void Main(string[] args)
        {
            Console.WriteLine("0 - Visualizar valores pré-definidos.");
            object obj = Console.ReadLine();
            while (!obj.Equals("0"))
            {
                Console.WriteLine("Informe 0 - para visualizar os pré-definidos ");
                obj = Console.ReadLine();
            }
            string menu = obj.ToString();
            if (menu == "0")
            {
                //Aqui começo preenchendo o array.

                arrayList.Clear();
                arrayList.Add("3");
                arrayList.Add("2");
                arrayList.Add("1");
                arrayList.Add("6");
                arrayList.Add("0");
                arrayList.Add("5");
                int MaiorValor = encontrarMaiorValorArray(); // Depois encontro o valor mais alto para iniciar logo a árvore com a raiz, achei mais facil fazer assim, já que já sabia dessa condição do que fica passado valor por valor no array dentro da árvore. 
                Arvore arvore = new Arvore(); //somos nozes!
                Galho novoGalho = new Galho();
                novoGalho.valor = MaiorValor;
                arvore.raiz = novoGalho;
                arvore.chegouNaRaiz = false; //Inicializando a árvore. 
                for (int i = 0; i < arrayList.Count; i++)
                {
                    arvore.Adicionar(int.Parse(arrayList[i].ToString())); //Adicionando os nodes!
                }

                //Printing!
                Console.WriteLine("Primeiro Array : ");
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Console.Write(arrayList[i].ToString() + ",");
                }
                Console.WriteLine(" \n Lado Esquerdo! Raiz: " + arvore.raiz.valor);
                Galho proximo = new Galho();
                proximo = arvore.raiz.esquerda;
                while(proximo != null)
                {
                    Console.WriteLine(proximo.valor + ",");
                    proximo = proximo.esquerda;
                }
                Console.WriteLine("Lado Direito! Raiz: " + arvore.raiz.valor);
                proximo = new Galho();
                proximo = arvore.raiz.direita;
                while (proximo != null)
                {
                    Console.WriteLine(proximo.valor + ",");
                    proximo = proximo.direita;
                }

                //Second Verse, same as the first! 

                arrayList.Clear();
                arrayList.Add("7");
                arrayList.Add("5");
                arrayList.Add("13");
                arrayList.Add("9");
                arrayList.Add("1");
                arrayList.Add("6");
                arrayList.Add("4");
                MaiorValor = encontrarMaiorValorArray();
                arvore = new Arvore(); //somos nozes!
                novoGalho = new Galho();
                novoGalho.valor = MaiorValor;
                arvore.raiz = novoGalho;
                arvore.chegouNaRaiz = false;
                for (int i = 0; i < arrayList.Count; i++)
                {
                    arvore.Adicionar(int.Parse(arrayList[i].ToString()));
                }
                Console.WriteLine("Primeiro Array : ");
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Console.Write(arrayList[i].ToString() + ",");
                }
                Console.WriteLine(" \nLado Esquerdo! Raiz: " + arvore.raiz.valor);
                proximo = new Galho();
                proximo = arvore.raiz.esquerda;
                while (proximo != null)
                {
                    Console.WriteLine(proximo.valor + ",");
                    proximo = proximo.esquerda;
                }
                Console.WriteLine("Lado Direito! Raiz: " + arvore.raiz.valor);
                proximo = new Galho();
                proximo = arvore.raiz.direita;
                while (proximo != null)
                {
                    Console.WriteLine(proximo.valor + ",");
                    proximo = proximo.direita;
                }

            }


        }

        static int encontrarMaiorValorArray()
        {
            int posicao = 0;
            int maiorValor = int.Parse(arrayList[0].ToString());
            for (int i = 0; i < arrayList.Count; i++)
            {

                if (maiorValor < int.Parse(arrayList[i].ToString()))
                {
                    maiorValor = int.Parse(arrayList[i].ToString());
                    posicao = i;
                }
            }

            return maiorValor;
        }

    }
}