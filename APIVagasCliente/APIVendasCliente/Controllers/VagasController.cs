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
    public class VagasController : ApiController
    {
        private VagaValidator validador = new VagaValidator();

        // GET: api/Empresas
        public IEnumerable<Vaga> GetVagas()
        {
            VagasRepository vagaRepository = new VagasRepository();
            var vagas = vagaRepository.GetAll();

            return vagas;
        }

        // GET: api/Empresas/5
        public IHttpActionResult GetVaga(int id)
        {

             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");


            VagasRepository vagaRepository = new VagasRepository();

            Vaga vaga = vagaRepository.Get(id);
             if (vaga == null)
             {
                 return NotFound();
             }

             return Ok(vaga);
         }

        [Route("api/empresas/{id}/requisitos")]
        public IHttpActionResult GetRequisitos(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            VagasRepository vagaRepository = new VagasRepository();

            Vaga vaga = vagaRepository.Get(id);

            if (vaga == null)
            {
                return NotFound();
            }

            return Ok(vaga.Requisitos);
        }

        // POST: api/Empresas
        [BasicAuhtentication]
         public IHttpActionResult PostVaga(Vaga vaga)
         {
            validador.ValidateAndThrow(vaga);

            VagasRepository vagaRepository = new VagasRepository();
            vagaRepository.Save(vaga);

             return CreatedAtRoute("DefaultApi", new { id = vaga.Id }, vaga);
         }

         // PUT: api/Empresas/5
         [BasicAuhtentication]
         public IHttpActionResult PutVaga(int id, Vaga vaga)
         {
             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");

             if (id != vaga.Id)
                 return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            VagasRepository vagaRepository = new VagasRepository();
            if (vagaRepository.vagaCount(id) == 0)
                 return NotFound();

            validador.ValidateAndThrow(vaga);

            vagaRepository.Update(vaga);
             return StatusCode(HttpStatusCode.NoContent);
         }

         // DELETE: api/Empresas/5
         [BasicAuhtentication]
         public IHttpActionResult DeleteVaga(int id)
         {
             if (id <= 0)
                 return BadRequest("O id informado na URL deve ser maior que zero.");
            VagasRepository vagaRepository = new VagasRepository();
            Vaga vaga = vagaRepository.Get(id);

             if (vaga == null)
                 return NotFound();

            if (vagaRepository.vagaCount(id) > 0)
                 return Content(HttpStatusCode.Forbidden, "Essa vaga não pode ser excluída, pois há requesitos ativos relacionadas a ela.");

            vagaRepository.Delete(vaga);

            return StatusCode(HttpStatusCode.NoContent);
         }
    }
}
