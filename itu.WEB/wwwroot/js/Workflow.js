// Uchovava udaje o filterch
var selectedFilters = [];
var taskNames = [];
var agendaNames = [];
var workflowModelsNames = [];

/**
 * @brief Funnkce provadejici filtrovani na zaklade aktualniho obsahu pole s id 'SearchBar' a vybranych filtru v seznamu 'FilterTypesEnum.Selected' ze souboru '_FilterLists.cshtml'.
 * @param {Null} element Dummy, aby parametry funkce odpovidaly strukture callbacku pro @ref SearchSuggestionPicker.
 * @param {Element} filer Nove pridany/odebrany filter se seznamu filtru, nebo null pokud je funkce vyvolana jinym zpusobem nez pridanim filteru.
 */
function Filter(element = null, filer = null) {
    selectedValues = [];

    $("#" + selectedFilters + "List li").each(function () // pro kazdy prvke listu/seznamu vybranych filteru
    {                                                       // (id je sestaveno na zaklade hodnoty v enum, samotny list je vytvoren v souboru '_FilterLists.cshtml')
        selectedValues.push($(this).val());
    })

    if (filer !== null) // jen pokud se jedna o pridani/odebrani filteru
    {
        if (filer.id.includes("Model")) {
            workflowModelsNames.push(filer.getAttribute("value"));
        } else if (filer.id.includes("Agenda")) {
            agendaNames.push(filer.getAttribute("value"));
        } else if (filer.id.includes("Task")) {
            taskNames.push(filer.getAttribute("value"));
        }

    }
    let states = [];
    [].forEach.call(document.getElementsByClassName("selected-state-enum"), function (state) {
        states.push(state.getAttribute("data-value"));
    });

    // POST dotaz na server
    $.ajax(
        {
            async: true,
            type: 'POST',
            url: filterURL,
            data: {
                SearchString: $("#SearchBar").val(),
                TaskNames: taskNames,
                AgendaNames: agendaNames,
                WorkflowModelsNames: workflowModelsNames
            }, // vytvoreni DTO objektu, ktery server prijme
        }).done(function (result) {
            // updatovani stranky s vysledkem ze serveru
            console.log("hi");
            console.log(result);
            $("#FilterLists").html(result.filtersHTML);
            $("#Workflows").html(result.workflowsHTML);

        }).fail(function (result) {
            console.log(result);
        });

}