/*
*********************************************************************************************************
* Autor: Fabio Andrés Tobón Quesada
* Fecha Creación: 10/11/2019
* Descripción: Constructor de entidad de la tabla usuarios para uso en Dbcontex
* *******************************************************************************************************
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEL.Models;

namespace CEL.Models.TbModels
{
    /// <summary>
    /// Constructor de entidad de la tabla usuarios 
    /// </summary>
    public class TbUsuario : IEntityTypeConfiguration<Usuarios>
    {
        void IEntityTypeConfiguration<Usuarios>.Configure(EntityTypeBuilder<Usuarios> entity)
        {
            entity.HasKey(e =>e.IdUsuarios);
            entity.ToTable("Usuario", "dbo");
            entity.Property(e=>e.Usuario);   
            entity.Property(e=>e.Password);   
            entity.Property(e=>e.Logueado);   
            entity.Property(e=>e.Activo);   
            entity.Property(e=>e.Tipo_usuario);   
            entity.Property(e=>e.Bloqueo);   
            entity.Property(e=>e.Cambio_pass);   
            entity.Property(e=>e.Expiracion);   
            entity.Property(e=>e.IdUsuarios);   
        }
    }	
}	