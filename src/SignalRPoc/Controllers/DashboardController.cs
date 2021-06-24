using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPoc.Hubs;
using SignalRPoc.Models;

namespace SignalRPoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IHubContext<DashboardHub> _dashboardHub;

        public DashboardController(IHubContext<DashboardHub> dashboardHub)
        {
            _dashboardHub = dashboardHub;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var indices = ObterIndices();

            var indicesJson = System.Text.Json.JsonSerializer.Serialize(indices);

            // envia dados para o metodo no cliente
            await _dashboardHub.Clients.All.SendAsync("AtualizarDashboardCliente", indices, CancellationToken.None);

            return Ok();
        }

        private List<Indice> ObterIndices()
        {
            return new List<Indice>
            {
                new Indice {
                    Id = Guid.NewGuid(), Nome = "IGP-M", Valor = 12.64m, Acumulado = 1.5m
                },
                new Indice {
                    Id = Guid.NewGuid(), Nome = "SELIC", Valor = 4.75m, Acumulado = 2.2m
                },
                new Indice {
                    Id = Guid.NewGuid(), Nome = "INPC", Valor = 10.22m, Acumulado = 3.7m
                },
                new Indice {
                    Id = Guid.NewGuid(), Nome = "IPCA", Valor = 8.72m, Acumulado = 2.5m
                },
                new Indice {
                    Id = Guid.NewGuid(), Nome = "PIB", Valor = 5.83m, Acumulado = 0.5m
                },
                new Indice {
                    Id = Guid.NewGuid(), Nome = "TR", Valor = 4.31m, Acumulado = 1.8m
                }
            };
        }
    }
}