
var Timeout = null;
var Interval = null;
var SignalConnection = new signalR.HubConnectionBuilder().configureLogging(signalR.LogLevel.None).withUrl("/hub").build();

SignalConnection.on("NewTask", function(result)
{
    let count = document.getElementById("TaskCountId");
    count.innerText = parseInt(count.innerText) + 1;
    let alertDiv = document.getElementById("TaskAlertId");
    let tmp = document.createElement("div");
    tmp.innerHTML = result;
    console.log(tmp.firstChild);
    alertDiv.appendChild(tmp.firstChild);
    alertDiv.style.display = "block";
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

function TaskAlertClose(id)
{
    let alertDiv = document.getElementById("TaskAlertId");
    document.getElementById("Alert" + id).remove();
    if (alertDiv.childNodes.length == 0)
    {
        alertDiv.style.display = "none";
    }
}

