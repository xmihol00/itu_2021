
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
        })
        .fail(function (result)
        {
            //AlertAndReload(result);
        });
}