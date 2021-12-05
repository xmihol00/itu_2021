
var selectedFilters = [];
var states = [];
var agendaIds = [];
var workflowModelsIds = [];

function setListView() {
    var listdiv = document.getElementById("listView");
    var tablediv = document.getElementById("tableView");

    listdiv.hidden = false;
    tablediv.hidden = true;
}
function setTableView() {
    var listdiv = document.getElementById("listView");
    var tablediv = document.getElementById("tableView");

    listdiv.hidden = true;
    tablediv.hidden = false;
}

function Filter(element = null, filer = null) {
    if (filer != null) {
        if (filer.classList.contains("selected-state-enum")) {
            filer.firstElementChild.remove();
            filer.classList.remove("selected-state-enum");
            var id;
            if (filer.id.includes("Model")) {
                id = filer.id.replace("Model", '');
                workflowModelsIds.splice(workflowModelsIds.indexOf(filer.id.replace("Model", ''), 1));
            } else if (filer.id.includes("Agenda")) {
                id = filer.id.replace("Agenda", '');
                agendaIds.splice(agendaIds.indexOf(filer.id.replace("Agenda", ''), 1));
            } else if (filer.id.includes("State")) {
                id = filer.id.replace("State", '');
                states.splice(states.indexOf(filer.id.replace("State", ''), 1));
            }
        }
        else {
            var id;
            if (filer.id.includes("Model")) {
                id = filer.id.replace("Model", '');
                workflowModelsIds.push(id);
            } else if (filer.id.includes("Agenda")) {
                id = filer.id.replace("Agenda", '');
                agendaIds.push(id);
            } else if (filer.id.includes("State")) {
                id = filer.id.replace("State", '');
                states.push(id);
            }
        }
    }


    $.ajax(
        {
            async: true,
            type: 'POST',
            url: filterURL,
            data: {
                SearchString: $("#SearchBar").val(),
                States: states,
                AgendaIds: agendaIds,
                WorkflowModelsIds: workflowModelsIds
            },
        }).done(function (result) {
            $("#FilterLists").html(result.filtersHTML);
            $("#Workflows").html(result.workflowsHTML);

        }).fail(function (result) {
        });

}

function showTaskDetail(taskId) {
    let info = document.getElementById("Detail" + taskId);
    if (info.hidden == false) {
        info.hidden = true;
    } else {
        info.hidden = false;

    }
}

function ShowModelDetail(element) {
    $.ajax(
        {
            async: true,
            type: "GET",
            url: "/Agenda/ModelDetail/" + element.id + "/" + (element.getAttribute("data-order") | 0),
        })
        .done(function (result) {
            document.getElementById("SvgDataId").innerHTML = result;
            document.getElementById("SvgDetailId").style.display = "block";
            document.addEventListener("click", HideModelDetail);
        })
        .fail(function () {
            ShowAlert("Detail modelu se nepodařilo zobrazit.", true);
        });
}

function HideModelDetail(event) {
    let modal = document.getElementById("SvgDetailId");
    if (event == null || modal == event.target) {
        modal.style.display = "none";
        document.removeEventListener("click", HideModelDetail);
    }
}

