
var Files = [];
var Dropped = false;
var EndDate = null;
var CountDownInterval = null;
var TaskId = null;
var LastEntered = null;

document.addEventListener("DOMContentLoaded", function()
{
    let ed = document.getElementById("EndDate");
    EndDate = new Date(ed.innerHTML);
    ed.remove();
    CountDown();
    CountDownInterval = setInterval(CountDown, 1000);
    
    TaskId = document.getElementsByTagName("form")[0].id;
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
        TaskId = document.getElementsByTagName("form")[0].id;
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
    let fileDiv = document.getElementById("NewFilesId");
    for (let i = 0; i < element.files.length; i++)
    {
        if (document.getElementById(element.files[i].name) == null)
        {
            Files.push(element.files[i]);
            fileDiv.appendChild(CreateFileNumberDiv(element.files[i].name), fileDiv);
        }
    }
    element.files = new DataTransfer().files;
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
        url: "/File/Upload/" + TaskId,
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
        document.getElementById("FilesId").innerHTML = result;
        element.parentNode.remove();
    });

    return false;
}

function CreateFileNumberDiv(fileName)
{
    const mainDiv = document.createElement("div");
    mainDiv.classList.add("new-file-div");
    mainDiv.classList.add("mb-2");

    const nameDiv = document.createElement("div");
    nameDiv.classList.add("task-headline");
    nameDiv.classList.add("file-name");

    const nameSpan = document.createElement("span");
    nameSpan.classList.add("center");
    nameSpan.innerText = fileName;

    nameDiv.appendChild(nameSpan);
    mainDiv.appendChild(nameDiv);

    const inputDiv = document.createElement("div");
    inputDiv.classList.add("input-group");
    inputDiv.classList.add("new-file-input");

    const prepDiv = document.createElement("div");
    prepDiv.classList.add("input-group-prepend");

    const label = document.createElement("label");
    label.classList.add("input-group-text");
    label.innerText = "Identifikátor";

    prepDiv.appendChild(label);
    inputDiv.appendChild(prepDiv);

    const input = document.createElement("input");
    input.type = "text";
    input.classList.add("form-control");

    inputDiv.appendChild(input);

    const btnDiv = document.createElement("div");
    btnDiv.classList.add("new-file-btns");
    
    const upBtn = document.createElement("button");
    upBtn.disabled = true;
    upBtn.classList.add("btn");
    upBtn.classList.add("btn-success");
    upBtn.classList.add("btn-sm");
    upBtn.innerText = "Nahrát";
    upBtn.type = "button";
    
    const upIcon = document.createElement("i");
    upIcon.classList.add("fas");
    upIcon.classList.add("fa-upload");
    upIcon.classList.add("ml-2");
    
    const delBtn = document.createElement("button");
    delBtn.classList.add("btn");
    delBtn.classList.add("btn-danger");
    delBtn.classList.add("btn-sm");
    delBtn.innerText = "Zrušit";
    
    const crossIcon = document.createElement("i")
    crossIcon.classList.add("fas");
    crossIcon.classList.add("fa-times");
    crossIcon.classList.add("ml-2");
    
    upBtn.appendChild(upIcon);
    delBtn.appendChild(crossIcon);
    btnDiv.appendChild(upBtn);
    btnDiv.appendChild(delBtn);
    mainDiv.appendChild(inputDiv);
    mainDiv.appendChild(btnDiv);
    
    inputDiv.id = fileName;
    delBtn.onclick = () => newFileRemoved(inputDiv);
    upBtn.onclick = () => UploadFile(inputDiv);
    input.oninput = () => BtnChangeState(input, upBtn);

    return mainDiv;
}

function newFileRemoved(element)
{
    Files = Files.filter(x => x.name != element.id);
    element.parentNode.remove();
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

function DeleteFile(id)
{
    $.ajax({
        url: "/File/Delete/" + id,
        type: "POST",
        async: true,
    })
    .done(function(result)
    {
        document.getElementById("FilesId").innerHTML = result;
    });

    return false;
}

function FileDragged(event)
{
    let element = event.target;
    event.dataTransfer.setData("Id", element.id);

    let oldTopPos = element.getBoundingClientRect().top;

    for (let item of document.getElementsByClassName("hidden-version"))
    {
        item.style.display = "flex";
    }

    for (let item of document.getElementsByClassName("file-version"))
    {
        item.style.borderColor = "var(--color-prio-urgent)";
    }

    let newTopPos = element.getBoundingClientRect().top + window.scrollY;
    window.scroll(window.scrollX, newTopPos - oldTopPos);
}

function FileDropped(event)
{
    Dropped = true;
    let target = event.target;
    while(target.getAttribute("data-version") == undefined)
    {
        target = target.parentNode;
    }

    event.preventDefault();
    
    $.ajax({
        url: "/File/ChangeVersion",
        type: "POST",
        async: true,
        data: { FileId: event.dataTransfer.getData("Id"), Version: target.getAttribute("data-version") }
    })
    .done(function(result)
    {
        document.getElementById("FilesId").innerHTML = result;
    }); 
}

function DragOver(event)
{
    event.preventDefault();
}

function DragEnded()
{
    setTimeout(function() 
    {
        if (!Dropped)
        {
            for (let item of document.getElementsByClassName("hidden-version"))
            {
                item.style.display = "none";
            }

            for (let item of document.getElementsByClassName("file-version"))
            {
                item.style.borderColor = "black";
            }
        }
        Dropped = false;
    }, 0);
}

function DragEntered(element)
{
    if (LastEntered != null)
    {
        LastEntered.style.borderColor = "var(--color-prio-urgent)";
    }
    LastEntered = element;
    element.style.borderColor = "green";
}

function DragLeave(element, event)
{
    let rect = element.getBoundingClientRect();
    if (rect.top > event.clientY || rect.bottom < event.clientY || rect.right < event.clientX || rect.left > event.clientX)
    {
        element.style.borderColor = "var(--color-prio-urgent)";
    }
}

function Save(address)
{
    let dto = {}
    dto.Note = document.getElementById("NoteId").value;
    dto.Id = document.getElementsByTagName("form")[0].id;
    
    if (address == "AssignmentSave")
    {
        let price = document.getElementById("PriceId");
        dto.PriceGues = price.value.replace(/\s/g,'');
        dto.Currency = document.getElementById("CurrencyId").value;
        dto.Benefit = document.getElementById("BenefitId").value;
    }
    else if (address == "AcceptationSave")
    {
        dto.Reason = document.getElementById("ReasonId").value;
        dto.Accepted = document.getElementById("AcceptId").checked;
    }
    else if (address == "EstimateSave")
    {
        dto.EstimatePrice = document.getElementById("EstimatePriceId").value;
        dto.MaxPrice = document.getElementById("MacPriceId").value;
    }
    else if (address == "AssessmentSave")
    {
        dto.Conclusion = document.getElementById("ConclusionId").value;
    }

    $.ajax(
    {
        async: true,
        type: 'POST',
        url: "/Task/" + address,
        data: dto
    })
    .done(function (result) 
    {
        console.log("recieved");
        document.getElementById("DetailDiv").innerHTML = result;
    })
    .fail(function (result)
    {
        //AlertAndReload(result);
    });
}

function Solve(type)
{
    let form = document.getElementsByTagName("form")[0];

    if (type == "Assignment")
    {
        let price = document.getElementById("PriceId");
        price.value = price.value.replace(/\s/g,'');
    }
    
    form.submit();
}

function Accept()
{
    document.getElementById("ReasonLabelId").innerText = "Důvod přijetí";
}

function Deny()
{
    document.getElementById("ReasonLabelId").innerText = "Důvod odmítnutí";
}
