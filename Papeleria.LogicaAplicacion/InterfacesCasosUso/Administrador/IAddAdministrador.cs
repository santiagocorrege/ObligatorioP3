﻿using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Administrador
{
    public interface IAddAdministrador
    {
        void Ejecutar(DtoAdministrador dto);
    }
}
