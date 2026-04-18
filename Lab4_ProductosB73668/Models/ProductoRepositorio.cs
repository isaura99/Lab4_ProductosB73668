namespace Lab4_ProductosB73668.Models
{
    public static class ProductoRepositorio
    {
        private static readonly List<Producto> productos = new List<Producto>();
        private static int siguienteId = 1;

        public static List<Producto> ObtenerTodos()
        {
            return productos;
        }

        public static Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(producto => producto.Id == id);
        }

        public static void Agregar(Producto producto)
        {
            producto.Id = siguienteId;
            siguienteId++;
            productos.Add(producto);
        }

        public static void Actualizar(Producto productoModificado)
        {
            Producto? productoExistente = ObtenerPorId(productoModificado.Id);
            if (productoExistente == null) return;

            productoExistente.Nombre = productoModificado.Nombre;
            productoExistente.Precio = productoModificado.Precio;
            productoExistente.Categoria = productoModificado.Categoria;
        }

        public static void Eliminar(int id)
        {
            Producto? producto = ObtenerPorId(id);
            if (producto == null) return;

            productos.Remove(producto);
        }
    }
}