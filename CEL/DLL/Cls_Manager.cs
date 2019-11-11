/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 11/11/2019
* Descripción: Clase para gestion de conexiones a bases de datos
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

namespace CEL.DLL
{
    public class Cls_Manager:I_DB_Manager
    {
    

    public Cls_Manager(IConfiguration configuration)
    {
        Config=configuration;
    }
    
    #region Variables
    /// <summary>
    /// Variable que hereda de la interfaz de configuración de la aplicación
    /// </summary>
    /// <value></value>
    public IConfiguration Config{get;}

    /// <summary>
    /// Variable que recibirá el valor del entorno de trabajo (Desarrollo, preproducción o producción)
    /// </summary>
    /// <value></value>
    private string Entrono_dev{get;set;}

    /// <summary>
    /// Usuario de la BD
    /// </summary>
    /// <value></value>
    private string Usuario{get;set;}

    /// <summary>
    /// Password de usuario de la BD
    /// </summary>
    /// <value></value>
    private string Pass{get;set;}

    /// <summary>
    /// Dirección  ip de la BD
    /// </summary>
    /// <value></value>
    private string Source{get;set;}

    /// <summary>
    /// Nombre del esquema de base de datos a conectar
    /// </summary>
    /// <value></value>
    private string Base{get;set;}

    /// <summary>
    /// Variable con la cadena de conexcion ensamblada
    /// </summary>
    /// <value></value>
    public string Cadena_con{get;set;}

    public string key{get;set;}

    #endregion

    #region Metodos

    /// <summary>
    /// Método que retorna la cadena de conexión que se ensambla en la configuración de la aplicación
    /// </summary>
    /// <returns></returns>
    public string GetCadenaConecxion()
    {
        try
        {
            
        }
        catch (System.Exception ex)
        {
            
            //throw;
        }
        return Cadena_con;
    }

        
    #endregion


    #region Crypto

        /// <summary>
        /// Funcion que encrypt contenido tipo text
        /// </summary>
        /// <param name="texto">Valor a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public string Encriptar(string texto)
        {
            try
            {
                

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

                texto = texto.Replace("+", "-");
            }
            catch (Exception)
            {

            }
            return texto;
        }

        /// <summary>
        /// Funcion que desencripta un text
        /// </summary>
        /// <param name="textoEncriptado">Texto encriptado</param>
        /// <returns>Texto desencriptado</returns>
        public string Desencriptar(string textoEncriptado)
        {
            try
            {
                textoEncriptado = textoEncriptado.Replace("-", "+");                
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }

        #endregion

    }
}