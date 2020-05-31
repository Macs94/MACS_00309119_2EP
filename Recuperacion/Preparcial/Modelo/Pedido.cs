using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Pedido
    {
        public string idPedido { get; set; }
        public string idUsuario { get; set; }
        public string idArticulo { get; set; }
        public string cantidad { get; set; }

        public Pedido(string idPedido, string idUsuario, string idArticulo, string cantidad)
        {
            this.idPedido = idPedido;
            this.idUsuario = idUsuario;
            this.idArticulo = idArticulo;
            this.cantidad = cantidad;
        }
    }
}
