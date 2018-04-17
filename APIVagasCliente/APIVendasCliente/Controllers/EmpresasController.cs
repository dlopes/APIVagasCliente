using APIVendasCliente.Filters;
using APIVendasCliente.Models.Entities;
using APIVendasCliente.Models.Validation;
using APIVendasCliente.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIVendasCliente.Controllers
{
    public class EmpresasController : ApiController
    {
        private EmpresaValidator validador = new EmpresaValidator();

        // GET: api/Empresas
        public IEnumerable<Empresa> GetEmpresas()
        {
            EmpresaRepository empRepository = new EmpresaRepository();
            var empresas = empRepository.GetAll();

            return empresas;
        }

        // GET: api/Empresas/5
        public IHttpActionResult GetEmpresa(int id)
        {

             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");


             EmpresaRepository empRepository = new EmpresaRepository();

             Empresa empresa = empRepository.Get(id);
             if (empresa == null)
             {
                 return NotFound();
             }

             return Ok(empresa);
         }

        [Route("api/empresas/{id}/vagas")]
        public IHttpActionResult GetVagas(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            EmpresaRepository empRepository = new EmpresaRepository();

            Empresa empresa = empRepository.Get(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa.Vagas);
        }
        
        [Route("api/empresas/{id}/quantidade")]
        public IHttpActionResult GetEmpresaCount(int id)
        {

            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");


            EmpresaRepository empRepository = new EmpresaRepository();

            int empresaCount = empRepository.empresaCout(id);
            if (empresaCount == 0)
            {
                return NotFound();
            }

            return Ok(empresaCount);
        }

        // POST: api/Empresas
        [BasicAuhtentication]
         public IHttpActionResult PostEmpresa(Empresa empresa)
         {
             validador.ValidateAndThrow(empresa);

             EmpresaRepository empRepository = new EmpresaRepository();
             empRepository.Save(empresa);

             return CreatedAtRoute("DefaultApi", new { id = empresa.Id }, empresa);
         }

         // PUT: api/Empresas/5
         [BasicAuhtentication]
         public IHttpActionResult PutEmpresa(int id, Empresa empresa)
         {
             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");

             if (id != empresa.Id)
                 return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

             EmpresaRepository empRepository = new EmpresaRepository();
             if (empRepository.empresaCout(id) == 0)
                 return NotFound();

             validador.ValidateAndThrow(empresa);

             empRepository.Update(empresa);
             return StatusCode(HttpStatusCode.NoContent);
         }

         // DELETE: api/Empresas/5
         [BasicAuhtentication]
         public IHttpActionResult DeleteEmpresa(int id)
         {
             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");
             EmpresaRepository empRepository = new EmpresaRepository();
             Empresa empresa = empRepository.Get(id);

             if (empresa == null)
                 return NotFound();
             if (/*empRepository.vagaCount(id) > 0*/ empresa.Vagas.Count > 0)
                return Content(HttpStatusCode.Forbidden, "Essa empresa não pode ser excluída, pois há vagas ativas relacionadas a ela.");
            
            empRepository.Delete(empresa);

            return StatusCode(HttpStatusCode.NoContent);
         }
    }
}
