/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 10/11/2019
* Descripción: Modelo tabla de usuarios para login en la aplicación
* *******************************************************************************************************
*/

using System;
using System.Collections.Generic;

namespace CEL.Models
{
    /// <summary>
    /// Clase modelo de la tabla usuarios
    /// </summary>
    public partial class Usuarios
    {
        /// <summary>
        /// Nick name usuario
        /// </summary>
        /// <value></value>
        public string Usuario{get;set;}

        /// <summary>
        /// Contraseña usuario
        /// </summary>
        /// <value></value>
        public string Password{get;set;}

        /// <summary>
        /// Indicador si el usuario tienen sesion activa
        /// </summary>
        /// <value></value>
        public bool? Logueado{get;set;}

        /// <summary>
        /// Indicador si el usuario se encuentra activo
        /// </summary>
        /// <value></value>
        public bool? Activo{get;set;}

        /// <summary>
        /// Indicador de tipo de usuario (Fk tabla tipo Usuario)
        /// </summary>
        /// <value></value>
        public int Tipo_usuario{get;set;}

        /// <summary>
        /// Indicador de bloqueo de usuario por multiples intentos de login
        /// </summary>
        /// <value></value>
        public bool? Bloqueo{get;set;}

        /// <summary>
        /// Indicador de cambio de contraseña inmediato tras recuperación  o tiempo expirado de vigencia
        /// </summary>
        /// /// <value></value>
        public  bool? Cambio_pass{get;set;}      

        /// <summary>
        /// Fecha de expiración de la contraseña de usuario 
        /// </summary>
        /// <value></value>
        public DateTime? Expiracion{get;set;}

        /// <summary>
        /// Id Tabla Usuarios
        /// </summary>
        /// <value></value>
        public int IdUsuarios {get;set;}

    }
}