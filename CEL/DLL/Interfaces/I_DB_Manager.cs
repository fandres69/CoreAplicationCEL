/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 11/11/2019
* Descripción: Interfaz para metodos de la clase Cls_Manager
* *******************************************************************************************************
*/
using CEL.DLL.Iterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Security.Cryptography;

namespace CEL.DLL.Iterfaces
{
    public interface I_DB_Manager
    {
        /// <summary>
        /// Método que retorna la cadena de conexión que se ensambla en la configuración de la aplicación
        /// </summary>
        /// <returns></returns>
        string GetCadenaConecxion();
        IConfiguration Config{get;}
       
    }
}