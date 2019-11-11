/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 11/11/2019
* Descripción: Interfaz para metodos de la clase Cls_Manager
* *******************************************************************************************************
*/

namespace CEL.DLL.Iterfaces
{
    public interface I_DB_Manager
    {
        /// <summary>
        /// Método que retorna la cadena de conexión que se ensambla en la configuración de la aplicación
        /// </summary>
        /// <returns></returns>
        string GetCadenaConecxion();
       
    }
}