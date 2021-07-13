using Central.Log.API.Help.Validation;
using CentraLog.ApplicationCore.Entities;
using CentraLog.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Central.Log.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogAplicacaoController : ControllerBase
    {
        private readonly ILogService _logService;
        public LogAplicacaoController(ILogService logService)
        {
            this._logService = logService;
        }

        [HttpGet("getlogs")]
        public IEnumerable<LogAplicacaoEntity> Get()
        {
            var result = _logService.GetAll();
            return result;
        }

        /// <summary>
        /// Metodo com finalidade de inserir log no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("addlogaplicacao")]
        public async Task<ActionResult<dynamic>> Post(LogAplicacaoEntity entity)
        {
            //validando entity
            var validator = new LogManagerValidator();
            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                var addAsync = await _logService.AddLogAsync(entity);
                if (addAsync == null)
                    return BadRequest("Não foi possivel inserir registro no banco");
                return Ok(string.Concat("Log salvo com sucesso:",
                    JsonConvert.SerializeObject(entity)));
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(results.Errors));
            }
        }

        [HttpGet("getlogbyId/id")]
        public IEnumerable<LogAplicacaoEntity> Find(long id)
        {
            var result = _logService.Find(x => x.IdCentralLog == id);
            return result;
        }
    }
}
