using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization; 
using System.Collections;


namespace Trabalho
{
	/// <summary>
	/// Description of ListaLigada.
	/// </summary>
[Serializable]
public class ListaDupla<T> where T : IComparable<T>, IComparer<T>
{
	private NodoD<T> primeiroNumero;	// onde come�a a lista propriamente dita
	private NodoD<T> primeiroNome;
	int c;
		
	
	public ListaDupla()
	{
	 this.primeiroNumero=null;
	 this.primeiroNome=null;
	 c = 0;
	}


   /// <summary>
   /// Propriedade apenas de leitura para verificar se lista vazia
   /// Complexidade temporal: O(1)
   /// </summary>
    public bool ListaVazia
	{get {
    	  if (this.Count==0)
    			return true;
		     else
	    	    return false;
		 }		
	}
    
    /// <summary>
    /// Devolve a informa��o guardada no primeiro elemento da Lista. null se vazio
    /// Complexidade temporal: O(1)
    /// </summary>
    
	/// <summary>
	/// propriedade que devolve o n�mero de elementos na lista
    /// Complexidade temporal:
	/// </summary>
   public int Count
        {get {
			  return c;
        	 } 	
        }
   public NodoD<T> AddFirst (T dados, NodoD<T> primeiro)
	{
		NodoD<T> novo = new NodoD<T>(dados);
		 novo.Next = primeiro;	// novo antes do primeiro		
		 primeiro = novo;		// primeiro passa a ser o novo
		 
		 // compor anterior (Prev) do agora segundo, caso exista
		 if (novo.Next!=null) // existe outro � frente do primeiro
		 	(novo.Next).Prev = novo;
		 return primeiro;
	}
   public void AddInOrden(T dados)
   {
   	AddNumero(dados);
   	AddNome(dados);
   	this.c++;
   }
   public void AddNumero(T dados)
   {
   		// inserir no inicio caso lista vazia ou valor < primeiro da lista
		 if (this.ListaVazia==true || dados.CompareTo(this.primeiroNumero.Info)<0)
		    {
		 	 this.primeiroNumero =this.AddFirst(dados, primeiroNumero);
		 	 return;
		    }
			NodoD<T> novo = new NodoD<T>(dados);
			// falta agora a parte de inser��o no meio ou fim;
			NodoD<T> aux = primeiroNumero;
			while(aux.Next != null && (aux.Next).Info.CompareTo(dados)<0)
            {
				aux = aux.Next;
            }

			//no fim do while temos aux imediatamente antes do local
			//0nde vamos inserir o novo nodo

			novo.Next = aux.Next;
			novo.Prev = aux;
			//colocar novo a seguir ao aux

			aux.Next = novo;
   }
   public void AddNome(T dados)
   {
   	// inserir no inicio caso lista vazia ou valor < primeiro da lista
		 if (this.ListaVazia==true || dados.CompareTo(primeiroNome.Info)>0)
		    {
		 	 this.primeiroNome = this.AddFirst(dados, primeiroNome);
		 	 return;
		    }
			NodoD<T> novo = new NodoD<T>(dados);
			// falta agora a parte de inser��o no meio ou fim;
			NodoD<T> aux = primeiroNome;
			while(aux.Next != null && (aux.Next).Info.Compare((aux.Next).Info, dados)>0)
            {
				aux = aux.Next;
            }

			//no fim do while temos aux imediatamente antes do local
			//0nde vamos inserir o novo nodo

			novo.Next = aux.Next;
			novo.Prev = aux;
			//colocar novo a seguir ao aux

			aux.Next = novo;
			if(novo.Next!=null)
				(novo.Next).Prev=novo;
	

		// se estiver no meio
	 		// colocar seguinte a "apontar" para novo 
	}
		
	/// <summary>
	/// Remove o primeiro elemento da lista
    /// Complexidade temporal: O(1)
	/// </summary>
	public NodoD<T> RemoveFirst(NodoD<T> primeiro)
	{
	 if (this.ListaVazia==true)	// nada a remover
			return primeiro;
	 // indicar que o primeiro "passa a ser o segundo"
	 primeiro = primeiro.Next;
	 if (primeiro!=null)	// caso exista um "novo" primeiro
	 	primeiro.Prev=null;
	 return primeiro;
	}
	public void RemoveNome (T chave)
	{
		if (this.ListaVazia==true)	// n�o h� nada a remover....
			return;
		//se for logo o primeiro
		NodoD<T> aux = this.primeiroNome;
		if(aux.Info.Compare(aux.Info, chave)==0)
            {
				this.primeiroNome = this.RemoveFirst(this.primeiroNome);
				return;
            }
		
			

			while(aux.Next != null && aux.Next.Info.Compare(aux.Next.Info, chave)!= 0)
            {
				aux = aux.Next;
            }

			if (aux.Next == null)
				return;
			
			aux.Next = aux.Next.Next;
			
			if(aux.Next != null)
			{
				aux.Next.Prev = aux;
			}
	}
	public void RemoveNumero (T chave)
	{
		if (this.ListaVazia==true)	// n�o h� nada a remover....
			return;
		//se for logo o primeiro
		if(this.primeiroNumero.Info.CompareTo(chave)==0)
            {
				this.primeiroNumero = this.RemoveFirst(this.primeiroNumero);
				return;
            }
		NodoD<T> aux = primeiroNumero;
		while(aux.Next != null && aux.Next.Info.CompareTo(chave)!=0)
		{
			aux = aux.Next;
		}
		if(aux.Next == null)
		{
			return;
		}
		aux.Next = aux.Next.Next;
		if(aux.Next != null)
		{
			aux.Next.Prev = aux;
		}
	}

	/// <summary>
	/// procura e remove um determinado elemento da lista
    /// Complexidade temporal: O(N)
	/// </summary>
	/// <param name="chave"></param>
	/// <returns>devolve true caso encontre e remova, false caso n�o exista</returns>
	public void Remove (T chave)
	{
	 if (this.ListaVazia==true)	// n�o h� nada a remover....
			return;
	 
	 RemoveNome(chave);
	 RemoveNumero(chave);
		
	}

	public void PesquisaNome(T chave, out T saida)
	{		
		NodoD<T> aux = primeiroNumero;
	    saida = default(T);
	    if(ListaVazia==true)
	    	return;
	
	    while (aux != null && aux.Info.Compare(aux.Info, chave) != 0)
	    {
	        aux = aux.Next;
	    }
	    //Chegados aqui existe ou n�o existe
	    if (aux == null)   //Se aux passou limites da lista 
	        return;  //N�o existe
	   	
	    saida = aux.Info;
	}
	public void PesquisaNumero(T chave, out T saida)
	{		
		NodoD<T> aux = primeiroNumero;
	    saida = default(T);
	    if(ListaVazia==true)
	    	return;
	
	    while (aux != null && aux.Info.CompareTo(chave) != 0)
	    {
	        aux = aux.Next;
	    }
	    if (aux == null)  
	        return; 
	   	
	    saida = aux.Info;
		}
		public void MostrarNumero()
		{
			NodoD<T> aux = this.primeiroNumero;
			while(aux != null)
			{
				Console.WriteLine(aux.Info.ToString());
				aux = aux.Next;
			}
		}
	public void MostrarNome()
	{
		NodoD<T> aux = this.primeiroNome;
		while(aux != null)
		{
			Console.WriteLine(aux.Info.ToString());
			aux = aux.Next;
		}
	}

	  public static void GravarDados(ListaDupla<T> lst, string nomeficheiro)
		{
	  	 BinaryFormatter formatador = new BinaryFormatter();
	  	 FileStream ficheiro = new FileStream(nomeficheiro, FileMode.Create);
	  	 formatador.Serialize(ficheiro,lst);
	  	 ficheiro.Close();	  		
	    }
      public static ListaDupla<T> LerDados(string nomeficheiro)
		{
      	ListaDupla<T> lst = new ListaDupla<T>();
	  	BinaryFormatter formatador = new BinaryFormatter();
	    FileStream ficheiro = new FileStream(nomeficheiro, FileMode.Open);
	    lst = (ListaDupla<T>)formatador.Deserialize(ficheiro);
	    ficheiro.Close();
	    return lst;
		}
	}
}
