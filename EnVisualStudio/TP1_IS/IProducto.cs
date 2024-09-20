using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IProducto
{
    string Nombre { get; set; }
    decimal Precio { get; set; }
    string Categoria { get; set; }

    void ActualizarPrecio(decimal nuevoPrecio);
}
