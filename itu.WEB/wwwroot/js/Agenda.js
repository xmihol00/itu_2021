
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
}

function SaveData() {
    
    let dto = {};
    dto.Name = document.getElementById("NameEditId").value;
    dto.Description = document.getElementById("DescriptionEditId").value;
    dto.Id = AgendaId;
    
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

function RemoveRole(element) {
    $.ajax(
    {
        async: true,
        type: 'GET',
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
