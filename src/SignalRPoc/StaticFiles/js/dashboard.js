
"use strict";
    
var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:5001/dashboardHub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();


connection.on('AtualizarDashboardCliente', function (dashboardData) {

    // metodo chamado pela instancia do hub

    if(dashboardData) {

        console.log(dashboardData);

        //var jsonData = JSON.parse(dashboardData);
        var jsonData = dashboardData;
        
        var divIndices = document.getElementById("areaIndices");
        
        divIndices.innerHTML = '';

        console.log(jsonData);

        jsonData.forEach(element => {

            var indice = document.createElement("p");
            indice.innerHTML = `<strong>Id</strong>: ${element.id} 
                - <strong>Indice:</strong> ${element.nome} 
                - <strong>Valor:</strong> ${element.valor} 
                - <strong>Acumulado %:</strong> ${element.acumulado}`;

            divIndices.appendChild(indice);
        });
    }
});

connection.start()
    .then(function () {
        console.log('Iniciada conexão com hub');
        // connection.invoke("ObterDadosDashboard");
    }).catch(function (err) {
        return console.error('Erro ==> ' + err.toString());
    });

var atualizarDashboard = () => {

    var parametro = {
        id: 1,
        nome: "Teste"
    };

    // chama metodo no hub
    connection.invoke("AtualizarDashboard", parametro)
        .catch(function (err) {
            console.log('erro ao invocar metodo hub');
            return console.error(err.toString());
        });

    // connection.invoke("SendMessage", user, message).catch(function (err) {
    //         return console.error(err.toString());
    //     });
};


document.getElementById("btnAtualizar").addEventListener("click", function (event) {
    //var user = document.getElementById("userInput").value;
    //var message = document.getElementById("messageInput").value;

    atualizarDashboard();

    event.preventDefault();
});
  
