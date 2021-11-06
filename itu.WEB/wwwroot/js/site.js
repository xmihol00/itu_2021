
var Timeout = null;
var Interval = null;
var SignalConnection = new signalR.HubConnectionBuilder().configureLogging(signalR.LogLevel.None).withUrl("/hub").build();

SignalConnection.on("NewTask", function()
{
    console.log("new task");
});

SignalConnection.start();

function ShowAlert(message, error = false) 
{
    let alertDiv = document.getElementById("AlertId");
    alertDiv.style.display = "block";
    alertDiv.style.opacity = "1";
    
    let alert = alertDiv.firstChild;
    alert.firstChild.innerText = message;

    if (Timeout != null)
    {
        clearTimeout(Timeout);
        clearInterval(Interval);
        Timeout = null;
    }
    
    if (error) 
    {
        alert.classList.remove("alert-success");
        alert.classList.add("alert-danger");
    } 
    else 
    {
        alert.classList.add("alert-success");
        alert.classList.remove("alert-danger");
    }

    Timeout = setTimeout(() => HideStart(alertDiv), 1000);
}

function HideStart(element)
{
    Interval = setInterval(() => { element.style.opacity -= 0.01; }, 30);
    Timeout = setTimeout(HideAlert, 3000);
}

function HideAlert()
{
    let alert = document.getElementById("AlertId");
    alert.style.display = "none";

    clearTimeout(Timeout);
    clearInterval(Interval);
    Timeout = null;
}
