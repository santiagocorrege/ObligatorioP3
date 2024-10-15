using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedido
{
    public class AnularPedido : IAnularPedido
    {
        private IRepositorioPedido _repoPedido;

        public AnularPedido(IRepositorioPedido repoPedido)
        {
            _repoPedido = repoPedido;
        }
        public void Ejecutar(int id)
        {
            if (id == null || id == 0) throw new ArgumentNullException("El id no puede ser nulo");
            _repoPedido.AnularPedidoById(id);
        }
    }
}
