
document.addEventListener("DOMContentLoaded", function()
{
    CountDown();
    CountDownInterval = setInterval(CountDown, 1000);
});

function SolveTask(element)
{    
    $.ajax(
        {
            async: true,
            type: 'GET',
            url: "/Task/Detail/" + element.id,
        })
        .done(function (result) 
        {
            document.getElementById("DetailDiv").innerHTML = result;
            
            let ed = document.getElementById("EndDate");
            EndDate = new Date(ed.innerText);
            ed.remove();
            CountDown();

            document.getElementById("Card" + SelectedId).classList.remove("card-selected");
            document.getElementById("Select" + SelectedId).style.display = "none";
            document.getElementById("Unselect" + SelectedId).style.display = "block";

            SelectedId = element.id;
            document.getElementById("Card" + SelectedId).classList.add("card-selected");
            document.getElementById("Select" + SelectedId).style.display = "block";
            document.getElementById("Unselect" + SelectedId).style.display = "none";
        })
        .fail(function (result)
        {
            //AlertAndReload(result);
        });
}

function CountDown()
{
    let timeLeft = (Date.parse(EndDate) - Date.parse(new Date)) / 1000;
    let days = Math.floor(timeLeft / 86400); 
    let hours = Math.floor((timeLeft - days * 86400) / 3600);
    let minutes = Math.floor((timeLeft - days * 86400 - hours * 3600) / 60);
    let seconds = Math.floor(timeLeft - days * 86400 - hours * 3600 - minutes * 60);

    if (days == 1)
    {
        days += " den";
    }
    else if (days == 2 || days == 3 || days == 4)
    {
        days += " dny";
    }
    else
    {
        days += " dnů"
    }
    if (hours < 10) 
    { 
        hours = "0" + hours; 
    }
    if (minutes < 10) 
    { 
        minutes = "0" + minutes; 
    }
    if (seconds < 10) 
    { 
        seconds = "0" + seconds; 
    }

    if (days == 0)
    {
        document.getElementById("CDD").innerText = "";
    }
    else
    {
        document.getElementById("CDD").innerText = days;
    }
    document.getElementById("CDH").innerText = hours;
    document.getElementById("CDM").innerText = minutes;
    document.getElementById("CDS").innerText = seconds;
}
