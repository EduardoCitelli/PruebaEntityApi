namespace PruebaEntityApi.Vista.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PruebaEntityApi.Vista.AccesoDatos;
    using PruebaEntityApi.Vista.Modelos;
    using System.ComponentModel.DataAnnotations;

    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly TiendaContexto tiendaContexto;

        public CategoriasController(TiendaContexto tiendaContexto)
        {
            this.tiendaContexto = tiendaContexto;
        }

        [HttpPost]
        public async Task<bool> Crear([FromBody] CategoriasCreateModel model)
        {
                var categoriaNueva = new Categoria
                {
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                };

                await tiendaContexto.AddAsync(categoriaNueva);
                await tiendaContexto.SaveChangesAsync();
                return true;
        }

        [HttpGet]
        public List<CategoriasViewModel> Obtener()
        {
            return tiendaContexto.Categorias.Select(entidad =>
                new CategoriasViewModel
                {
                    Id = entidad.Id,
                    Nombre = entidad.Nombre,
                    Descripcion = entidad.Descripcion,
                }
            ).ToList();
        }
    }

    public class CategoriasCreateModel
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;
    }

    public class CategoriasViewModel : CategoriasCreateModel
    {
        public int Id { get; set; }
    }
}