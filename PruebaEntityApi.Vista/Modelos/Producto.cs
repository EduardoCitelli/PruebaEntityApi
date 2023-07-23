namespace PruebaEntityApi.Vista.Modelos
{
    using PruebaEntityApi.Vista.Modelos;
    using System.ComponentModel.DataAnnotations;

    public class Producto
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
