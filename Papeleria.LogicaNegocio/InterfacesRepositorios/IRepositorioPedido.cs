using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        decimal GetMontoPedido(int id);

        IEnumerable<Pedido> GetNoEntregadosFecha(DateTime date);

        public void AnularPedidoById(int id);

        public IEnumerable<Pedido> GetPedidosAnulados();
    }
}
