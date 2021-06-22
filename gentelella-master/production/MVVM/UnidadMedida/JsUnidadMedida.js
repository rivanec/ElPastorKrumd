var tUnidadMedida;
$(document).ready(function () {
    jQuery.support.cors = true;

    $("#bLimpiar").on("click", function () {
        Limpiarfrm();
    });
    $("#bGuardar").on("click", function () {
        Guardarfrm();
    });

    tUnidadMedida = $('#tUnidadMedida').DataTable({
        //dom: 'lrtip',
        //searching: true,
        //lengthChange: false,
        //info: false,
        //select: false,
        //responsive: false,
        //pagingType: 'simple',
        //scrollY: "450px",
        //scrollCollapse: true,     

        columns: [


            {
                data: "Id", visible: false
                , render: function (data, type, row) {
                    var str = "<span><i class=' fa fa-phone'></i>";
                    if (row.IdSucursal > 0)
                        str += "<i style='margin-left:5px;' class='fa fa-arrow-circle-right'></i></span>";
                    else if (row.IdSucursal === 8)
                        str += "<i style='margin-left:5px;' class='fa fa-arrow-circle-left'></i></span>";
                    return str;
                }
            },
            {
                data: "UnidadMedida", title: "UnidadMedida"
            },
            {
                data: "Estatus", title: "Estatus", render: function (data, type, row) {
                    var strEstatus = "<button class='btn btn-danger' onclick='Eliminar(" + row.Id + ")' type='button'>Eliminar</button>";

                    return strEstatus;
                }
            }




        ],

        ajax: {

            url: "https://localhost:44376/" + "api/WaUnidadMedida",
            crossDomain: true,

            dataType: "json",
            dataSrc: ""
        }
    });


    $('#tUnidadMedida').on('click', 'tr', function () {
        var objUnidadMedida = tUnidadMedida.row(this).data();
        Cargafrm(objUnidadMedida);

    });
})


function Cargafrm(UnidadMedida) {
    $("#hId").val(UnidadMedida.Id);
    $("#txtUnidadMedida").val(UnidadMedida.UnidadMedida);
}

function Limpiarfrm() {
    $("#frmUnidadMedida")[0].reset();
    $("#hId").val(0);
}

function Guardarfrm() {
    $.post("https://localhost:44376/" + "api/WaUnidadMedida", $("#frmUnidadMedida").serialize(), function (data) {
        Limpiarfrm();
        tUnidadMedida.ajax.reload();
    })
}


function Eliminar(id) {
    $.SmartMessageBox({
        title: "Pastor Enchilado",
        content: "¿Deseas Eliminar el registro? </br> Da clic en si para confirmar",
        buttons: '[No][Si]'
    }, function (ButtonPressed) {
        if (ButtonPressed === "Si") {
            $.get("https://localhost:44376/" + "api/WaUnidadMedida/Eliminar?id=" + id, function (data) {
                Limpiarfrm();
                tUnidadMedida.ajax.reload();
                $.smallBox({
                    title: "Pastor Enchilado",
                    content: "Registro Eliminado",
                    color: "#3276B1",

                    icon: "fa fa-trash  swing animated",
                    timeout: 4000

                });
            })
        }
        if (ButtonPressed === "No") { }

    });




}

