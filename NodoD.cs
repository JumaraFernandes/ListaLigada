using System;
 
namespace Trabalho
{
/// <summary>
/// Classe NODO utilizada para guardar as informações
/// </summary>
   [Serializable]
   public class NodoD<K>
	{
   	
     // auto implemented propriedades...
     public K Info {get; set;}	    	// informação a guardar
     public NodoD<K> Next {get; set;}	// apontador para o nodo seguinte
     public NodoD<K> Prev {get; set;}	// apontador para o nodo anterior
	 
	 // construtor...
	 public NodoD(K info)
	  {
	   this.Info=info;
	   this.Next=null;
	   this.Prev=null;
	  } 
	} // fim da classe...
}
