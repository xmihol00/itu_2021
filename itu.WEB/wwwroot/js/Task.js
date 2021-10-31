
var DefaultHeight = 0;
var Files = [];

document.addEventListener("DOMContentLoaded", function()
{
    CountDown();
    CountDownInterval = setInterval(CountDown, 1000);
    DefaultHeight = document.getElementById("UpFile").scrollHeight + 2;
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
    let fileDiv = element.parentNode;
    for (let i = 0; i < element.files.length; i++)
    {
        if (document.getElementById(element.files[i].name) == null)
        {
            Files.push(element.files[i]);
            fileDiv.parentNode.insertBefore(CreateFileNumberDiv(element.files[i].name), fileDiv);
        }
    }
}

function UpdateFileSpan()
{
    let fileSpan = document.getElementById("UpFile");
    if (Files.length == 0)
    {
        fileSpan.style.height = DefaultHeight + "px";
        fileSpan.innerText = "";
        return;
    }
    fileSpan.innerText = Files[0].name;
    
    for (let i = 1; i < Files.length; i++)
    {
        fileSpan.innerText += ", " + Files[i].name;
    }
    
    fileSpan.style.height = (fileSpan.scrollHeight > DefaultHeight ? (fileSpan.scrollHeight + 10) : DefaultHeight) + "px";
}

function UploadFile(element)
{
    let upload = Files.find(x => x.name = element.id);    
    let fileData = new FormData();
    fileData.append(element.childNodes[1].value, upload);

    $.ajax({
        url: "/Task/Upload/" + TaskId,
        type: "POST",
        datatype: "json",
        contentType: false,
        processData: false,
        async: true,
        data: fileData,
    })
    .done(function(result)
    {
        Files = Files.filter(x => x.name != element.id);
        element.remove();
    });
}

function CreateFileNumberDiv(fileName)
{
    const inputDiv = document.createElement("div");
    inputDiv.classList.add("input-group");
    inputDiv.classList.add("mb-2");

    const prepDiv = document.createElement("div");
    prepDiv.classList.add("input-group-prepend");

    const label = document.createElement("label");
    label.classList.add("input-group-text");
    label.classList.add("task-prep-wdth");
    label.innerText = fileName;

    prepDiv.appendChild(label);
    inputDiv.appendChild(prepDiv);

    const input = document.createElement("input");
    input.type = "text";
    input.classList.add("form-control");

    inputDiv.appendChild(input);

    const appDiv = document.createElement("div");
    appDiv.classList.add("input-group-append");
    
    const upBtn = document.createElement("button");
    upBtn.disabled = true;
    upBtn.classList.add("btn");
    upBtn.classList.add("btn-success");
    upBtn.innerText = "Nahrát";
    
    const upIcon = document.createElement("i");
    upIcon.classList.add("fas");
    upIcon.classList.add("fa-upload");
    upIcon.classList.add("ml-2");
    
    const delBtn = document.createElement("button");
    delBtn.classList.add("btn");
    delBtn.classList.add("btn-danger");
    
    const crossIcon = document.createElement("i")
    crossIcon.classList.add("fas");
    crossIcon.classList.add("fa-times");
    crossIcon.classList.add("ml-1");
    crossIcon.classList.add("mr-1");
    
    upBtn.appendChild(upIcon);
    delBtn.appendChild(crossIcon);
    appDiv.appendChild(upBtn);
    appDiv.appendChild(delBtn);
    inputDiv.appendChild(appDiv);
    
    inputDiv.id = fileName;
    delBtn.onclick = () => newFileRemoved(inputDiv);
    upBtn.onclick = () => UploadFile(inputDiv);
    input.oninput = () => BtnChangeState(input, upBtn);

    return inputDiv;
}

function newFileRemoved(element)
{
    Files = Files.filter(x => x.name != element.id);
    element.remove();
}

function BtnChangeState(input, button)
{
    if (input.value && input.value.trim())
    {
        button.disabled = false;
    }
    else
    {
        button.disabled = true;
    }
}
