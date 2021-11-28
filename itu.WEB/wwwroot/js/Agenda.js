//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

function EditationStart() {
    let normals = document.getElementsByClassName("normal");
    for (let normal of normals) {
        normal.style.display = "none";
    }

    let edits = document.getElementsByClassName("edit");
    for (let edit of edits) {
        edit.style.display = "block";
    }
}

function EditAdmin() {
    document.getElementById("AdminId").style.display = "none";
    document.getElementById("AdminEditId").style.display = "flex";
}

function CancelAdmin() {
    document.getElementById("AdminId").style.display = "flex";
    document.getElementById("AdminEditId").style.display = "none";
}

function SaveAdmin() {
    let sel = document.getElementById("AdminSelect");
    let opt = sel.options[sel.selectedIndex];
    opt.selected = true;

    let dto = {};
    dto.AdminId = sel.value;
    dto.Id = AgendaId;
    
    $.ajax(
    {
        async: true,
        type: 'POST',
        url: "/Agenda/EditAdmin",
        data: dto
    })
    .done(function () 
    {
        document.getElementById("AdminName").innerText = opt.text;
        document.getElementById("AdminId").style.display = "flex";
        document.getElementById("AdminEditId").style.display = "none";
        ShowAlert("Administrátor agendy úspěšně změněn.");
    })
    .fail(function() 
    {
        ShowAlert("Administrátora agendy se nepodařilo změnit.", true);
    });
}

function DataEdit() {
    document.getElementById("DataId").style.display = "none";
    document.getElementById("DataEditId").style.display = "block";
    let des = document.getElementById("DescriptionEditId");
    des.style.minHeight = des.scrollHeight + "px";
}

function SaveData() {
    
    let dto = {};
    dto.Name = document.getElementById("NameEditId").value;
    dto.Description = document.getElementById("DescriptionEditId").value;
    dto.Id = AgendaId;

    let sel = document.getElementById("AdminSelect");
    let opt = sel.options[sel.selectedIndex];
    opt.selected = true;
    dto.AdminId = sel.value;
    
    $.ajax(
    {
        async: true,
        type: 'POST',
        url: "/Agenda/EditData",
        data: dto
    })
    .done(function () 
    {
        document.getElementById("NameId").innerText = dto.Name;
        document.getElementById("DescriptionId").innerText = dto.Description;
        document.getElementById("AdminId").innerText = opt.text;
        document.getElementById("DataId").style.display = "block";
        document.getElementById("DataEditId").style.display = "none";
        ShowAlert("Data úspěšně změněna.");
    })
    .fail(function() 
    {
        ShowAlert("Data se nepodařilo změnit.", true);
    });    
}

function CancelData() {
    document.getElementById("DataId").style.display = "block";
    document.getElementById("DataEditId").style.display = "none";
}

function MouseInRole(event) {
    for (let element of event.target.getElementsByClassName("vis-hidden")) {
        element.style.visibility = "visible";
    }
}

function MouseOutRole(event) {
    for (let element of event.target.getElementsByClassName("vis-hidden")) {
        element.style.visibility = "hidden";
    }
}

var MouseInRoleCB = MouseInRole;
var MouseOutRoleCB = MouseOutRole;

function AddNewRole(element) {
    element.style.display = "none";
    element.nextSibling.style.display = "block";
    element.nextSibling.nextSibling.style.display = "block";
    MouseInRoleCB = () => {};
    MouseOutRoleCB = () => {};
    let parent = element.parentNode.parentNode;
    const sel = CreteSelect(parent.getElementsByClassName("user"));
    parent.append(sel);
}

function RolesCancel(element) {
    element.style.display = "none";
    element.previousSibling.style.display = "block";
    element.nextSibling.style.display = "none";
    MouseInRoleCB = MouseInRole;
    MouseOutRoleCB = MouseOutRole;
    document.getElementById("GeneratedSelId").remove();
}

function CreteSelect(current) {
    const sel = document.createElement("select");
    sel.classList.add("mb-2");
    sel.classList.add("form-control");
    sel.id = "GeneratedSelId"

    let append = true;
    for (let pair of Users) {
        append = true;
        for (let node of current) {
            if (node.getAttribute("name") == pair.Id)
            {
                append = false;
                break;
            }
        }

        if (append) {
            const opt = document.createElement("option");
            opt.value = pair.Id;
            opt.innerText = pair.FullName;
            sel.appendChild(opt);
        }
    }

    return sel;
}

function AddRole(element) {
    let dto = {};
    dto.UserId = document.getElementById("GeneratedSelId").value;
    dto.AgendaId = AgendaId;
    dto.Type = element.id;
    
    $.ajax(
    {
        async: true,
        type: 'POST',
        url: "/Agenda/AddRole",
        data: dto
    })
    .done(function (result) 
    {
        document.getElementById("RolesId").innerHTML = result;
        MouseInRoleCB = MouseInRole;
        MouseOutRoleCB = MouseOutRole;
        ShowAlert("Role úspěšně přidána.");
    })
    .fail(function() 
    {
        ShowAlert("Roli se nepodařilo přidat.", true);
    });
}

function EditRole(element) {
    let dto = {};
    let sel = document.getElementById(element.name);
    dto.UserId = sel.value;
    dto.Id = sel.name;
    
    $.ajax(
    {
        async: true,
        type: 'POST',
        url: "/Agenda/EditRole",
        data: dto
    })
    .done(function (result) 
    {
        let roles = document.getElementById("RolesId");
        roles.innerHTML = result;
        MouseInRoleCB = MouseInRole;
        MouseOutRoleCB = MouseOutRole;
        ShowAlert("Role úspěšně přidána.");
        
        if (roles.getElementsByTagName("select").length == 0)
        {
            for (let ele of document.getElementById("WFModelsId").getElementsByTagName("button"))
            {
                ele.disabled = false;
                ele.title = null;
            }
        }
    })
    .fail(function() 
    {
        ShowAlert("Roli se nepodařilo přidat.", true);
    });
}

function RemoveRole(element) {
    $.ajax(
    {
        async: true,
        type: "GET",
        url: "/Agenda/RemoveRole/" + element.id,
    })
    .done(function (result) 
    {
        document.getElementById("RolesId").innerHTML = result;
        MouseInRoleCB = MouseInRole;
        MouseOutRoleCB = MouseOutRole;
        ShowAlert("Role úspěšně odebrána.");
    })
    .fail(function() 
    {
        ShowAlert("Roli se nepodařilo odebrat.", true);
    });
}

function ShowCrateModal() {
    document.getElementById("CreateAgendaId").style.display = "block";
    document.addEventListener("click", HideCreateModal);
}

function HideCreateModal(event) {
    let modal = document.getElementById("CreateAgendaId");
    if (event == null || modal == event.target)
    {
        modal.style.display = "none";
        document.removeEventListener("click", HideCreateModal);
    }
}

function ShowAddModel() {
    $.ajax(
    {
        async: true,
        type: "GET",
        url: "/Agenda/NewModels/" + AgendaId,
    })
    .done(function (result) 
    {
        document.getElementById("AddModalDataId").innerHTML = result;
        document.getElementById("AddModelId").style.display = "block";
        document.addEventListener("click", HideAddModel);
    })
    .fail(function() 
    {
        ShowAlert("Nepodařilo se získat modely pro přidání.", true);
    });
}

function HideAddModel(event) {
    let modal = document.getElementById("AddModelId");
    if (event == null || modal == event.target)
    {
        modal.style.display = "none";
        document.removeEventListener("click", HideAddModel);
    }
}

function AddModel(element) {
    let dto = {};
    dto.AgendaId = AgendaId;
    dto.ModelId = element.id;
    
    $.ajax(
    {
        async: true,
        type: "POST",
        url: "/Agenda/AddModel/" + AgendaId,
        data: dto
    })
    .done(function () 
    {
        window.location = "/Agenda/Detail/" + AgendaId;
    })
    .fail(function() 
    {
        ShowAlert("Model workflow se nepodařilo přidat.", true);
    });
}


function ShowRunWF(element) {
    document.getElementById("AddWorkflowId").style.display = "block";
    document.addEventListener("click", HideAddWF);
    document.getElementById("ModelInputId").value = element.id;
}

function HideAddWF(event) {
    let modal = document.getElementById("AddWorkflowId");
    if (event == null || modal == event.target)
    {
        modal.style.display = "none";
        document.removeEventListener("click", HideAddWF);
    }
}

function ShowModelDetail(element) {
    $.ajax(
    {
        async: true,
        type: "GET",
        url: "/Agenda/ModelDetail/" + element.id,
    })
    .done(function (result) 
    {
        document.getElementById("SvgDataId").innerHTML = result;
        document.getElementById("SvgDetailId").style.display = "block";
        document.addEventListener("click", HideModelDetail);        
    })
    .fail(function() 
    {
        ShowAlert("Detail modelu se nepodařilo zobrazit.", true);
    });
}

function HideModelDetail(event) {
    let modal = document.getElementById("SvgDetailId");
    if (event == null || modal == event.target)
    {
        modal.style.display = "none";
        document.removeEventListener("click", HideModelDetail);
    }
}

function RemoveModel(element) {
    $.ajax(
    {
        async: true,
        type: "GET",
        url: "/Agenda/RemoveModel/" + element.id + "/" + AgendaId,
    })
    .done(function() 
    {
        element.parentNode.parentNode.parentNode.parentNode.remove();
        ShowAlert("Model workflow úspěšně odebrán.");
    })
    .fail(function() 
    {
        ShowAlert("Model workflow se nepodařilo odebrat.", true);
    });    
}

function RunWorkflowCheck() {
    let name = document.getElementById("RunNameId");
    let desc = document.getElementById("RunDescId");
    let dis = false;
    
    if (!name.value || !name.value.trim()) {
        name.parentNode.firstChild.firstChild.classList.add("comp-bckg");
        dis = true;
    }
    else {
        name.parentNode.firstChild.firstChild.classList.remove("comp-bckg");
    }

    if (!desc.value || !desc.value.trim()) {
        desc.parentNode.firstChild.firstChild.classList.add("comp-bckg");
        dis = true;
    }
    else {
        desc.parentNode.firstChild.firstChild.classList.remove("comp-bckg");
    }

    document.getElementById("RunWFBtnId").disabled = dis;
}

function CreateAgendaCheck() {
    let name = document.getElementById("AgendaNameId");
    let desc = document.getElementById("AgendaDescId");
    let dis = false;
    
    if (!name.value || !name.value.trim()) {
        name.parentNode.firstChild.firstChild.classList.add("comp-bckg");
        dis = true;
    }
    else {
        name.parentNode.firstChild.firstChild.classList.remove("comp-bckg");
    }

    if (!desc.value || !desc.value.trim()) {
        desc.parentNode.firstChild.firstChild.classList.add("comp-bckg");
        dis = true;
    }
    else {
        desc.parentNode.firstChild.firstChild.classList.remove("comp-bckg");
    }

    document.getElementById("CreateBtnId").disabled = dis;
}
