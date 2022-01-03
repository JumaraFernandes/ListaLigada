using System;
using System.Collections.Generic;

namespace Trabalho
{
/// <summary>
/// Classe que permite criar menus de op��es muito simples e manipula-las em Consola.
/// </summary>
public class MenuOpcoes
{
	private static string retorno = "123456789ABCDEFGHIJKLMNOPQRSTUVWYZ";
	private string[] opcao;
	/// <summary>
	/// M�todo que recebe uma lista de op��es, criando um menu com elas
	/// </summary>
	/// <param name="lista">Op��es a serem criadas no menu</param>
	public MenuOpcoes(params string[] lista)
	{
	 opcao = new string[lista.Length];
	 for (int i=0;i<lista.Length;i++)
	 	opcao[i]=lista[i];
	}
	public int Menu()
	{ConsoleKeyInfo tecla;
	 int escolha = 0;
	 do {
	 	Console.Clear(); 
	 	Console.ForegroundColor=ConsoleColor.DarkYellow;
	 	Console.WriteLine("\nOp��es Dispon�veis: ");
	 	for (int i=0;i<this.opcao.Length;i++)
		 {
		 	if(escolha==i)
		 	{
		 		Console.BackgroundColor=ConsoleColor.DarkYellow;
		 		Console.BackgroundColor=ConsoleColor.White;
		 		Console.WriteLine(" [{0}] - {1}",i,opcao[i]);
		 		Console.ResetColor();
		 	}else
		 	{
		 		Console.WriteLine(" [{0}] - {1}",i,opcao[i]);
		 	}
		 }
	   tecla=Console.ReadKey(true);		 
	   if (tecla.Key==ConsoleKey.DownArrow)
	       escolha=escolha+1;
	   if (tecla.Key==ConsoleKey.UpArrow)
	       escolha=escolha-1;
	   if (escolha==-1) 
	   	    escolha=opcao.Length;
	   if (escolha==opcao.Length)
	   	    escolha=0;		 
	 }while (tecla.Key!= ConsoleKey.Enter);
	 return escolha;
	}		
			
		
  }// Fim classe Menu
}
