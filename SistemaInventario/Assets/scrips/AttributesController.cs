using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesController : MonoBehaviour
{
    public int cantidad;
    public string tipo;
    public string subtipo;
   public void setCantidad (int cantidad)
   {
    this.cantidad = cantidad;
   }
   public int getCantidad()
   {
    return this.cantidad;
   }

  // public void Accion()
  // {
   // if (tipo=="arma")
   // {
   //     if (subtipo=="espada")
   //     {
    //        Debug.Log("Quitar x vida")
   //     }
   // }else if (tipo=="objeto_utilizable")
   // {
    //    if (subtipo== "pocion-vida")
   //     {
    //        Debug.Log("recuperar x vida")
   //    }
  //  }
  // }
}

