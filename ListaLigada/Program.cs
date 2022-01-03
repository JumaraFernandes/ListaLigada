
using System;
using System.Collections.Generic;

namespace Trabalho
{
	
 class Program
	{private static string[] lstMenu = { 
 		"Inserir novo elemento na Lista     ",
 		"Contar número de elementos da lista ",
		"Pesquisar por chave nome ",
        "Pesquisar por chave numero ",
        "Listar elementos ascendentemente por chave nome",
        "Listar elementos ascendentemente por chave numero",
        "Remover elemento da Lista    ",
		"Gravar lista em disco",
	     "Ler lista do disco"    ,    
		"Sair da aplicação ",                
								};
// =================================			
// Bloco principal do programa
public static void Main(string[] args)
 {
  MenuOpcoes menu = new MenuOpcoes(lstMenu);
  int opcao;
  Ficha dados = new Ficha();
  ListaDupla<Ficha> lista = new ListaDupla<Ficha>();
    string nome;
    int numero;
    string obs;
    DateTime data = new DateTime();
    int dia;
    int mes;
    int ano;
    Ficha f1 = new Ficha(1, "redny", "edjnsd", data);
    Ficha f2 = new Ficha(2, "jumara", "edjnsd", data);
    Ficha f3 = new Ficha(3, "Tatian", "edjnsd", data);
    Ficha f4 = new Ficha(4, "Ana", "edjnsd", data);
    lista.AddInOrden(f1);
    lista.AddInOrden(f2);
    //lista.AddInOrden(f4);
    lista.AddInOrden(f3);
    Ficha fi;
    lista.Remove(f4);
    lista.MostrarNome();
    Console.WriteLine();
    lista.MostrarNumero();
    Console.ReadKey();
    
  do
  {opcao=menu.Menu();
  	Console.WriteLine("\n");
    switch (opcao) {
	 	  case 0 :Console.WriteLine("Operação de inserção....");
                   Console.Write("Digite Nome: ");
	 	            nome=Console.ReadLine();
	 	           Console.Write("Digite Número: ");
	 	           int.TryParse(Console.ReadLine(),out numero);
                    Console.WriteLine("Digite o Obs:");
                     obs=Console.ReadLine();
                     Console.WriteLine("Digite a data");
                     Console.WriteLine("Dia:");
                     int.TryParse(Console.ReadLine(),out dia);
                     Console.WriteLine("Mês:");
                    int.TryParse(Console.ReadLine(),out mes);
                     Console.WriteLine("Ano:");
                    int.TryParse(Console.ReadLine(),out ano); 
                     data  = new DateTime(ano,mes, dia);
                    dados = new Ficha(numero, nome,obs,data);
                    lista.AddInOrden(dados);
	 			   break;
	 	  case 1 :Console.WriteLine("Contar número de elementos da lista.");
	 	           Console.WriteLine("Total de elementos {0}",lista.Count);
	 	           Console.ReadKey();
	 	  		   break;
	 	  case 2 :Console.Write("Pesquisar por chave Nome: ");
	 	           nome = Console.ReadLine();
                Ficha f = new Ficha(nome);
                Ficha saida;
                lista.PesquisaNome(f, out saida);
                Console.WriteLine(saida.ToString());
                Console.ReadKey();
	 	           break;
	 	  case 3 :Console.Write(" Pesquisar por chave numero: ");
	 	           int.TryParse(Console.ReadLine(),out numero);
                Ficha n = new Ficha(numero);
                lista.PesquisaNumero(n, out saida);
                Console.WriteLine(saida);
                Console.ReadKey();
	 			   break;		 			
	 	  case 4:Console.WriteLine("Listar elementos ascendentemente por chave nome");
                    lista.MostrarNome();
                    Console.ReadKey();
	 			   break;
         case 5:Console.WriteLine("Listar elementos ascendentemente por chave numero");
                 lista.MostrarNumero();
                 Console.ReadKey();
	 			   break;	
          case 6:Console.Write("Remover  Elemento da Lista "); 
               int.TryParse(Console.ReadLine(),out numero);
               Ficha novo = new Ficha(numero);
                lista.Remove(novo);	
                Console.ReadKey();
                break;
             		 			
	 	  case 7:Console.Write("Gravar Dados:\nDigite nome do ficheiro: ");
	 	           ListaDupla<Ficha>.GravarDados(lista,Console.ReadLine());
             break;     		 			
	  	  case 8:Console.Write("Ler Dados:\nDigite nome do ficheiro: ");	       
	 	           try {
	 	                lista = ListaDupla<Ficha>.LerDados(Console.ReadLine());
	 	                 Console.WriteLine("Lidos {0} elementos ",lista.Count);
	 	               }
	 	           catch(Exception info)
	 	               {Console.WriteLine(info.Message);
  		                Console.ReadKey();
  		                lista = new ListaDupla<Ficha>();  // lista vazia
	 	               }
	 	  		   break;
	 	}
    }while (opcao!=9);
	 

   }// fim do Main
 } // fim da class
}
