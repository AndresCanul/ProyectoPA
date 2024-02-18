function ConsultarNombre() {

    let identification = $("#Identificacion").val();

    $.ajax({
        url: "https://apis.gometa.org/cedulas/" + identification,
        method: "GET",
        datatype: "json",
        success: function (response)
        {
            $("#Nombre").val(response.nombre);
        },
        error: function (response)
        {

        }
    })
}