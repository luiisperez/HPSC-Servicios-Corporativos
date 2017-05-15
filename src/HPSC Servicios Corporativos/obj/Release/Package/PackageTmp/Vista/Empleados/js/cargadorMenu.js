jQuery(document).ready(function () {

    // Empleados
    $("#visualizarempleados").click(function (e) {
        e.preventDefault();
        var url = '/Vista/Empleados/gestion-empleados/visualizarempleados';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenedor").empty();
                    $("#contenedor").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });


});