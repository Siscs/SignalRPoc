
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRPoc.Hubs
{
    public class DashboardHub: Hub
    {
        public Task AtualizarDashboard(ParametroCliente parametro)
        {
            //await Clients.All.SendAsync("MetodoCliente", indicesJson, CancellationToken.None);

            return Task.CompletedTask;
            
        }

    }

    public class ParametroCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
