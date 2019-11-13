/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 11/11/2019
* Descripción: DBcontext base de datos CELDB
* *******************************************************************************************************
*/

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CEL.Models;
using CEL.Models.TbModels;
using CEL.DLL.Interfaces;
using EntityFrameworkCore.Mysql;
using EntityFrameworkCore.Oracle;
using EntityFrameworkCore.Psql;
using MySql.Data.MySqlClient;

namespace CEL.Models.BDContext
{
     public partial class CELDbContext : DbContext
    {
       public I_Cls_Manager Manager{get;set;}

       public CELDbContext(I_Cls_Manager man)
       {
           Manager=man;
       }
        /// <summary>
        /// Función en la que se configura la base de datos con la cual se va a conectar
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string BProvider= Manager.Config.GetSection("Entornodev:Baseprovider").Value.ToString();

            switch (BProvider)
            {
                case "Mysql":
                optionsBuilder.UseMySql(Manager.Get_cadena_con());
                break;
                case "Psql":
                optionsBuilder.UseNpgsql(Manager.Get_cadena_con());
                break;
                case "Sqlserver":
                optionsBuilder.UseSqlServer(Manager.Get_cadena_con());
                break;
                case "Oracle":
                optionsBuilder.UseOracle(Manager.Get_cadena_con());
                break;
                default:
                break;
            }
            
        }



    }
}
