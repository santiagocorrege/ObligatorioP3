using Papeleria.LogicaNegocio.Entidades.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioParametro
    {
        public string GetValorString(string nombre);
        public int GetValorInt(string nombre);
        public DateTime GetValorDateTime(string nombre);
        public Parametro GetByName(string nombre);

        public decimal GetValorDecimal(string nombre);
        public void Update(String nombreParametro, string valor);
    }
}
