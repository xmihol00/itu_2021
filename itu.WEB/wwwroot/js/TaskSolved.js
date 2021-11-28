//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

var TaskId = null;

document.addEventListener("DOMContentLoaded", function()
{
    TaskId = document.getElementById("IdOfTaskId").value;
});

function ShowTask(element)
{    
    $.ajax(
    {
        async: true,
        type: 'GET',
        url: "/Task/DetailSolved/" + element.id,
    })
    .done(function (result) 
    {
        document.getElementById("DetailDiv").innerHTML = result;
        
        
        document.getElementById("Card" + TaskId).classList.remove("card-selected");
        document.getElementById("Select" + TaskId).style.display = "none";
        document.getElementById("Unselect" + TaskId).style.display = "block";
        TaskId = element.id;

        document.getElementById("Card" + TaskId).classList.add("card-selected");
        let select = document.getElementById("Select" + TaskId);
        select.style.display = "block";
        let ed = document.getElementById("EndDate");
        select.lastChild.innerText = ed.innerText;
        ed.remove();

        document.getElementById("Unselect" + TaskId).style.display = "none";
    })
    .fail(function() 
    {
        ShowAlert("Nepodařilo se otevřít řešení úkolu.", true);
    });
}
