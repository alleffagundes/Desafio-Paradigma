using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    internal class Arvore
    {

        #region [ Propriedades ]

        public Galho raiz { get; set; }
        public bool chegouNaRaiz { get; set; } 

        #endregion


        public void Adicionar(int valor)
        {
            
            if (valor == raiz.valor) // Ínicio querendo saber se o valor atual do array é a raiz, isso me permite trocar a direção do preenchimento, se não tiver chegado ainda, preencho a esquerda, depois da raiz, vou para direita!
            {
                chegouNaRaiz = true;
                return;
            }

            if (!chegouNaRaiz)
            {
                Galho novoGalho = new Galho();
                Galho anterior = new Galho();
                if (raiz.esquerda == null) //Se só tiver a raiz, eu já preenchedo próximo node a esquerda. 
                {
                    anterior.valor = valor; //Preencho os ambos direita e esquerda para cada node pra poder move-los com facilidade. 
                    anterior.direita = raiz;
                    raiz.esquerda = anterior;
                    return; // Retorna por que não precisa passar pelos outros já que só tem ele.
                }
                Galho proximo = raiz.esquerda; // Começa a leitura pelo valor a esquerda da raiz. 
                while (proximo != null)
                {
                    anterior = proximo; //Salvado o valor. 
                    if (valor > anterior.valor) //Verifico se o valor é maior que o node atual
                    {
                        if (anterior.direita.valor == raiz.valor)
                        {
                            proximo = anterior.esquerda; //Se for o node atual tiver ligado com a raiz, eu preciso alterar ela também!
                            novoGalho.valor = valor;
                            novoGalho.direita = raiz;
                            anterior.direita = novoGalho;
                            novoGalho.esquerda = anterior;
                            raiz.esquerda = novoGalho;
                        }
                        else
                        {
                            proximo = anterior.esquerda; //Se não basta trocar os valores o novoGalho serve para criar um node novo com o valor, que recebe a direita e esquerda correspondente a sua posição. 
                            if (proximo != null)
                            {
                                if (valor > proximo.valor)
                                {
                                    novoGalho.valor = valor;
                                    novoGalho.esquerda = anterior.esquerda;
                                    novoGalho.direita = anterior;
                                    anterior.esquerda = novoGalho;
                                }
                            }
                            else
                            {
                                novoGalho.valor = valor;
                                novoGalho.direita = anterior;
                                anterior.esquerda = novoGalho;
                            }
                        }

                    }
                    else if(valor < anterior.valor) //Se o valor for menor fazemos a mesma coisa, porém considerando mover apenas caso o valor for maior, já que a ordem é descrescente!
                    {
                        proximo = anterior.esquerda;
                        if (proximo != null)
                        {
                            if (valor > proximo.valor)
                            {
                                novoGalho.valor = valor;
                                novoGalho.esquerda = anterior.esquerda;
                                novoGalho.direita = anterior;
                                anterior.esquerda = novoGalho;
                            }
                        }
                        else
                        {
                            novoGalho.valor = valor;
                            novoGalho.direita = anterior;
                            anterior.esquerda= novoGalho;
                        }
                    }

                }

            }
            if (chegouNaRaiz) //Abaixo tem a versão para direita, que é a mesma coisa da esquerda, só que indo para direita. 
            {
                Galho novoGalho = new Galho();
                Galho anterior = new Galho();
                if (raiz.direita == null)
                {
                    anterior.valor = valor;
                    anterior.esquerda = raiz;
                    raiz.direita = anterior;
                   
                    return;
                }
                Galho proximo = raiz.direita;
                while (proximo != null)
                {
                    anterior = proximo;
                    if (valor > anterior.valor)
                    {
                        if (anterior.esquerda.valor == raiz.valor)
                        {
                            proximo = anterior.direita;
                            novoGalho.valor = valor;
                            novoGalho.esquerda = raiz;
                            anterior.esquerda = novoGalho;
                            novoGalho.direita = anterior;
                            raiz.direita = novoGalho;

                        }
                        else
                        {
                            proximo = anterior.direita;
                            if (proximo != null)
                            {
                                if (valor > proximo.valor)
                                {
                                    novoGalho.valor = valor;
                                    novoGalho.direita = anterior.direita;
                                    novoGalho.esquerda = anterior;
                                    anterior.direita = novoGalho;
                                }
                            }
                            else
                            {
                                if (valor != anterior.esquerda.valor)
                                {
                                    novoGalho.valor = valor;
                                    novoGalho.esquerda = anterior;
                                    anterior.direita = novoGalho;
                                }
                            }
                        }

                    }
                    else if (valor < anterior.valor)
                    {
                        proximo = anterior.direita;
                        if (proximo != null)
                        {
                            if (valor > proximo.valor)
                            {
                                novoGalho.valor = valor;
                                novoGalho.esquerda = anterior;
                                novoGalho.direita = proximo;
                                proximo.esquerda = novoGalho;
                                anterior.direita = novoGalho;
                            }
                        }
                        else
                        {
                            novoGalho.valor = valor;
                            novoGalho.esquerda = anterior;
                            anterior.direita = novoGalho;
                        }
                    }
             
                }
            }
        }

    }
}
