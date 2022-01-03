using System;
using System.Collections.Generic;

namespace Trabalho
{
	/// <summary>
	/// Description of FichaDados.
	/// </summary>
	[Serializable]
	public struct Ficha: IComparable<Ficha>, IComparer<Ficha>
	{
	   string nome;
	   int numero;
	  string obs;
	  DateTime data;

#region Construtores
       
	 public Ficha(string nome)
	  {
		  this.nome=nome;
		  this.numero = -1;
		  this.data = new DateTime();
		  this.obs = null;
	  }	
	  public Ficha(int numero)
	  {
		  this.numero=numero;
		  this.nome = null;
		  this.data = new DateTime();
		  this.obs = null;
	  }
	  public Ficha(int numero, string nome,string obs, DateTime data)
	  {this.nome=nome;
	   this.numero=numero;
	   this.obs=obs;
	   this.data=data;
	  }
#endregion

#region M�todos dos objetos da classe


	public int CompareTo(Ficha outro)
	{
	 return this.numero - outro.numero;		
	}

	/// <summary>
	/// M�todo que permite visualizar os dados tipo Ficha de uma forma mais "agrad�vel".
	/// </summary>
	/// <returns></returns>
		public override string ToString()
		{
		 return this.numero+"("+this.nome+")";
		}
		public int Compare(Ficha ficha1, Ficha ficha2)
		{
			if(ficha1.nome == ficha2.nome)
				return 0;
			int resultado = ficha1.nome[0] - ficha2.nome[0];
			return resultado;
		}

#endregion
				
	} // fim da classe
}
