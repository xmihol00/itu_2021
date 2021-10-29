
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
            EndDate = new Date(ed.innerHTML);
            ed.remove();
            let clk = document.getElementById("CLK");
            CountDown();

            document.getElementById("Card" + SelectedId).classList.remove("card-selected");
            document.getElementById("Select" + SelectedId).style.display = "none";
            document.getElementById("Unselect" + SelectedId).style.display = "block";

            SelectedId = element.id;
            document.getElementById("Card" + SelectedId).classList.add("card-selected");
            let select = document.getElementById("Select" + SelectedId);
            select.style.display = "block";
            select.appendChild(clk);
            document.getElementById("Unselect" + SelectedId).style.display = "none";
        })
        .fail(function (result)
        {
            //AlertAndReload(result);
        });
}

function CountDown()
{
    let timeLeft = (Date.parse(EndDate) - Date.parse(new Date)) / 1000 - 3600;
    let days = Math.floor(timeLeft / 86400); 
    let hours = Math.floor((timeLeft - days * 86400) / 3600);
    let minutes = Math.floor((timeLeft - days * 86400 - hours * 3600) / 60);
    let seconds = Math.floor(timeLeft - days * 86400 - hours * 3600 - minutes * 60);
    
    if (days < 10 && days >= 0)
    {
        days = "0" + days;
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

    let clk = document.getElementById("CLK");
    if (days < 0)
    {
        clk.style.color = "#cf0000"
    }
    else if (days < 3)
    {
        clk.style.color = "#fc6a00"
    }
    else
    {
        clk.style.color = "green"
    }

    document.getElementById("CDD").innerHTML = days + "<span class='clk-span-day'>dny</span>";
    document.getElementById("CDH").innerHTML = hours + "<span class='clk-span-hr'>hodiny</span>";
    document.getElementById("CDM").innerHTML = minutes + "<span class='clk-span-min'>minuty</span>";
    document.getElementById("CDS").innerHTML = seconds + "<span class='clk-span-sec'>sekundy</span>";
}

function FormatPriceDown(event, element)
{
    value = event.key;

    if (value == ',' || value == '.')
    {
        if (element.value.indexOf('.') != -1)
        {
            event.preventDefault();
        }
    }
    else if (value != "Backspace" && (value < '0' || value > '9') && value != "ArrowRight" && value != "ArrowLeft")
    {
        event.preventDefault();
    }
}

function FormatPriceInput(element)
{
    let last = element.value.slice(-1);
    element.value = element.value.replace(/,/g, '.');
    element.value = element.value.replace(/\s/g, '');
    values = element.value.split('.');
    values[0] = values[0].replace(/(?<!\..*)(\d)(?=(?:\d{3})+(?:\.|$))/g, "$1 ");

    if (values.length > 1)
    {
        element.value = values[0] + '.' + values[1].slice(0, 2);
        return;
    }

    element.value = values[0] + (last == '.' ? '.' : '');
}

function FileChosen(element)
{
    let fileName = element.value.split('\\').pop();
    document.getElementById("UpFile").innerText = fileName;
    document.getElementById("UpBtn").disabled = false;
}

function UploadFile()
{
    if (window.FormData == undefined)
    {
        return;
    }
    else 
    {
        let files = document.getElementById("Upload").files;
        let fileData = new FormData();
        fileData.append(files[0].name, files[0]);

        $.ajax({
            url: '/Task/Upload/1',
            type: 'POST',
            datatype: 'json',
            contentType: false,
            processData: false,
            async: true,
            data: fileData,
        })
        .done(function(result)
        {
            console.log(result);
        });
    }
}
