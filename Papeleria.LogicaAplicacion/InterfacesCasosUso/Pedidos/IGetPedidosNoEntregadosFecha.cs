﻿using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos
{
    public interface IGetPedidosNoEntregadosFecha
    {
       public IEnumerable<DtoPedidoNoEntregado> Ejecutar(DateTime date);
    }
}
