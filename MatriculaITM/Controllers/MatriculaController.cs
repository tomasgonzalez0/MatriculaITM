using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatriculaITM.Models;
using MatriculaITM.Clases;
using System.Web.Http;

namespace MatriculaITM.Controllers
{
    [RoutePrefix("api/Matricula")]
    public class MatriculaController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public string Ingresar([FromBody] Matricula matricula)
        {
            ManejoMatricula manejador = new ManejoMatricula();
            return manejador.Ingresar(matricula);
        }
        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(string documento, string semestre)
        {
            ManejoMatricula manejo = new ManejoMatricula();
            var resultado = manejo.ConsultarPorDocumentoYSemestre(documento, semestre);

            if (resultado == null || resultado.Count == 0)
            {
                return NotFound();
            }

            return Ok(resultado);
        }
        [HttpGet]
        [Route("ConsultarPorDocumentoYSemestre")]
        public List<Matricula> ConsultarPorDocumentoYSemestre([FromUri] string documento, [FromUri] string semestre)
        {
            ManejoMatricula manejo = new ManejoMatricula();
            return manejo.ConsultarPorDocumentoYSemestre(documento, semestre);
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Matricula matricula)
        {
            ManejoMatricula manejo = new ManejoMatricula();
            return manejo.Actualizar(matricula);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            ManejoMatricula manejo = new ManejoMatricula();
            return manejo.Eliminar(id);
        }
    }
}