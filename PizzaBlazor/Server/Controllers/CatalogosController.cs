using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Server.Data;
using PizzaBlazor.Shared.Models;
using System.Net;

namespace PizzaBlazor.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CatalogosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //[HttpGet Tamano]es recomendable que cada spoin tenga su nombre respectivamente
        [HttpGet]
        public async Task<List<Tamanos>> Tamanos()
        {
            List<Tamanos> tamanos = new List<Tamanos>();

            //Linq
            tamanos = await context.Tamanos.ToListAsync();
            //select * from Tamanos

            //tamanos = new List<Tamanos>()
            //{
            //  new Tamanos{Id = 1, Tamano = "Personal", Precio = 10.0f},
            //  new Tamanos{Id = 2, Tamano = "Chica", Precio = 20.0f},
            //  new Tamanos { Id = 3, Tamano = "Mediana", Precio = 30.0f },
            //  new Tamanos { Id = 4, Tamano = "Grande", Precio = 40.0f },
            //};

            return tamanos;
            
        }
        
        [HttpGet("tipoMasa")]
        public async Task<List<TipoMasa>> TipoMasa()
        {
            List<TipoMasa> tipoMasa = new List<TipoMasa>();

            tipoMasa = await context.Masas.ToListAsync();
            //tipoMasa = new List<TipoMasa>()
            //{
            //    new TipoMasa{Id = 1, Tipo = "Tradicional", Precio = 20.0f},
            //    new TipoMasa{Id = 2, Tipo = "Crunch", Precio = 25.0f},
            //    new TipoMasa{Id = 3, Tipo = "Orilla de queso", Precio = 30.0f},
            //    new TipoMasa{Id = 4, Tipo = "Sarten", Precio = 35.0f},
            //};

            return tipoMasa;

        }

        [HttpGet("ingredientes")]
        public async Task<List<Ingrediente>> Ingrediente()
        {
            List<Ingrediente> ingredientes= new List<Ingrediente>();

            ingredientes = await context.Ingredientes.ToListAsync();

            //ingredientes = new List<Ingrediente>()
            //{
            //    new Ingrediente{Id = 1, Nombre = "Jamon", Precio = 10.0f},
            //    new Ingrediente{Id = 2, Nombre = "Piña", Precio = 18.0f},
            //    new Ingrediente{Id = 3, Nombre = "Carne", Precio = 23.0f},
            //    new Ingrediente{Id = 4, Nombre = "Jalapeño", Precio = 12.0f},
            //    new Ingrediente{Id = 5, Nombre = "Queso", Precio = 15.0f},
            //};

            return ingredientes;

        }

        [HttpPost("nvoIngrediente")]
        public async Task<int> NuevoIngrediente(Ingrediente nvoIngrediente)
        {
            context.Add(Ingrediente);
            await context.SaveChangesAsync();
            return nvoIngrediente.Id;
        }
    }
}
