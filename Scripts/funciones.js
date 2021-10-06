x = $(document);
x.ready(start);

function start() {
    x = $("#prueba");
    x.click(prueba);

    $('#IdProvincia').change(function () {
        if ($('#IdProvincia').val() != undefined) {

            var IdProvincia = $('#IdProvincia').val();
            $("#IdCorregimiento").empty();
            CallGetDistrito(IdProvincia);
        }
    });

    $('#IdDistrito').change(function () {
        if ($('#IdDistrito').val() != undefined) {
            var IdDistrito = $('#IdDistrito').val();
            CallGetCorregimiento(IdDistrito);
        }
    });

    x = $("#guardar-ajax");
    x.click(GuardarAjax);
}

function prueba() {
    alert("Mapeado");
}



function GuardarAjax() {
    var IdCliente = $("IdCliente").val();
    var Nombre = $("#Nombre").val();
    var Apellido = $("#Apellido").val();
    var Sexo = $("#Sexo").val();
    var IdProvincia = $("#IdProvincia").val();
    var IdDistrito = $("#IdDistrito").val();
    var IdCorregimiento = $("#IdCorregimiento").val();

    var data = {
        IdCliente: IdCliente,
        Nombre: Nombre,
        Apellido: Apellido,
        Sexo: Sexo,
        IdProvincia: IdProvincia,
        IdDistrito: IdDistrito,
        IdCorregimiento: IdCorregimiento
    };

    $.ajax({
        url: "../Clientes/GuardarAjax",
        type: "post",
        cache: false,
        data: data,
        async: false,
        success: function (msj) {
            if (msj.success == "1") {
                $('IdCliente').val(msj.IdCliente)
                alert("Alerta Guardar Ajax");
                
            } else if(msj.success == "2") {
                alert("Registro Actualizado");
            }
        },
        error: function (msj) {
            alert("Error en el Llamado de AJAX");
        }
    });
}


function CallGetDistrito(IdProvincia) {

    var Param = { IdProvincia: IdProvincia };
    $.ajax({
        url:"../Clientes/CallGetDistritoByID",
        type: "post",
        cache: false,
        data: Param,
        async: false,
        success: function (response) {
            $("#IdDistrito").empty();
            $("#IdDistrito").html(response);
        },
        error: function (response) {
            ManejaErroresAJAXSession(response);
        }
    });
}

function CallGetDistritoSuc(IdProvincia) {

    var Param = { IdProvincia: IdProvincia };
    $.ajax({
        url: "../Clientes/CallGetDistritoByID",
        type: "post",
        cache: false,
        data: Param,
        async: false,
        success: function (response) {
            $("#IdDistritoSuc").empty();
            $("#IdDistritoSuc").html(response);
        },
        error: function (response) {
            ManejaErroresAJAXSession(response);
        }
    });
}



function CallGetCorregimientoSuc(IdDistrito) {

    var Param = { IdDistrito: IdDistrito };
    $.ajax({
        url: "../Clientes/CallGetCorregimientoByID",
        type: "post",
        cache: false,
        data: Param,
        async: false,
        success: function (response) {
            $("#IdCorregimientoSuc").empty();
            $("#IdCorregimientoSuc").html(response);
        },
        error: function (response) {
            ManejaErroresAJAXSession(response);
        }
    });

}



function CallGetCorregimiento(IdDistrito) {

    var Param = { IdDistrito: IdDistrito };
    $.ajax({
        url:"../Clientes/CallGetCorregimientoByID",
        type: "post",
        cache: false,
        data: Param,
        async: false,
        success: function (response) {
            $("#IdCorregimiento").empty();
            $("#IdCorregimiento").html(response);
        },
        error: function (response) {
            ManejaErroresAJAXSession(response);
        }
    });
}


function dropdown_provedores_practicantes(tSolicitud, tpersonal) {

    if (tSolicitud === '3' && tpersonal !== '') {

        CargarDrpPersonal(tpersonal);
    }
    else
        if (tSolicitud === '1') {

            imput();
        }
}

function CargarDrpPersonal(tpersonal) {
    var Param = {
        IdTipoPersonal: tpersonal
    };
    $.ajax({
        url:'../Clientes/GetListaPersonal/',
        type: 'get',
        data: Param,
        success: function (response) {

            $("#IdEmpleado").replaceWith(dropdown(response));

            $('#IdEmpleado').change(function () {

                var IdEmpTotalControl = $("#IdEmpleado").val();

                getPersonal(IdEmpTotalControl);
            });
        }
    });

}


function changeall() {

    if ($("#IdSucursal").val() == undefined) {
        $("#IdCorregimientoSuc").empty();
        $("#IdDistritoSuc").empty();
    }

    $('#IdProvinciaSuc').change(function () {
        if ($('#IdProvinciaSuc').val() != undefined) {
            var IdProvincia = $('#IdProvinciaSuc').val();
            $("#IdCorregimientoSuc").empty();
            CallGetDistritoSuc(IdProvincia);
        }
    });

    $('#IdDistritoSuc').change(function () {
        if ($('#IdDistritoSuc').val() != undefined) {
            var IdDistrito = $('#IdDistritoSuc').val();
            CallGetCorregimientoSuc(IdDistrito);

        }
    });
}

$('.sidebar-toggle-btn').pushMenu(options)
$('[data-toggle="pushmenu"]').pushMenu('toggle')
