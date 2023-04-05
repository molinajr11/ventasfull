using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasApi.Models;
using VentasApi.Models.Response;
using VentasApi.Models.Request;

namespace VentasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            
            try
            {
               
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Clientes.OrderByDescending(d=>d.Id).ToList();
                    respuesta.Exito = 1;
                    respuesta.Data=lst;
                   
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensjae=ex.Message;
            }
            return Ok(respuesta);


        }

        [HttpPost]
        public IActionResult Add(ClienteRequest  clienteRequest)
        {
            Respuesta respuesta =new Respuesta();  
            try
            {
                using(VentaRealContext db= new VentaRealContext())
                {
                    Cliente oCliente= new Cliente();
                    oCliente.Nombre = clienteRequest.nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
               
            }
            catch (Exception ex)
            {
                respuesta.Mensjae = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest clienteRequest)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(clienteRequest.Id);
                    oCliente.Nombre = clienteRequest.nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensjae = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete("{Id }")]
        public IActionResult Delete(int Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensjae = ex.Message;
            }
            return Ok(respuesta);
        }

    }
}
