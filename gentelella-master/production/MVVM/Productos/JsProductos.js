var tProductos;
$(document).ready(function () {
    jQuery.support.cors = true;
    CargaCategorias();


    $('.js-example-basic-single').select2({
        ajax: {
            url: 'https://localhost:44376/api/WaIngredientes/Filter',
            dataType: 'json',
            data: function (params) {
                var query = {
                    filter: params.term
                }


                // Query parameters will be ?search=[term]&type=public
                return query;
            }
            ,
            results: function (data, page) {

                return {

                    results: data
                };
            },
            // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
        }
    });
    $('.select2.select2-container.select2-container--default').css('width', '100%')


    //});

    //$('.js-example-basic-single').select2();
    //$('.select2.select2-container.select2-container--default').css('width', '100%')

    //$('.js-example-basic-single').select2({
    //    ajax: {
    //        url: 'https://ad.s-s.mx/ApiLegalAdmin/api/WaCat_TbLedesTarea/GetLedesTarea',
    //        dataType: 'json',
    //        data: function (params) {
    //            var query = {
    //                term: params.term,
    //                Cliente: 4207,
    //                Asunto: 8833
    //            }


    //            // Query parameters will be ?search=[term]&type=public
    //            return query;
    //        }
    //        ,
    //        processResults: function (data) {
    //            // Transforms the top-level key of the response object from 'items' to 'results'
    //            return {
    //                results: data.items
    //            };
    //        }
    //        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
    //    }
    //});
    //$('.select2.select2-container.select2-container--default').css('width', '100%')


    $("#bLimpiar").on("click", function () {
        Limpiarfrm();
    });
    $("#bGuardar").on("click", function () {
        Guardarfrm();
    });

    tProductos = $('#tProductos').DataTable({
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
                data: "Producto", title: "Producto"
            },
            {
                data: "Categoria", title: "Categoria"
            },
            {
                data: "Precio", title: "Precio"
            },
            {
                data: "Estatus", title: "Estatus", render: function (data, type, row) {
                    var strEstatus = "<button class='btn btn-danger' onclick='Eliminar(" + row.Id + ")' type='button'>Eliminar</button>";

                    return strEstatus;
                }
            }




        ],

        ajax: {

            url: "https://localhost:44376/" + "api/WaProductos",
            crossDomain: true,

            dataType: "json",
            dataSrc: ""
        }
    });



    tIngredientes = $('#tIngredientes').DataTable({
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
                data: "Ingrediente", title: "Ingrediente"
            },
            {
                data: "UnidadMedida", title: "Unidad de Medida"
            },
            {
                data: "Cantidad", title: "Cantidad"
            },
            {
                data: "Estatus", title: "Estatus", render: function (data, type, row) {
                    var strEstatus = "<button class='btn btn-danger' onclick='Eliminar(" + row.Id + ")' type='button'>Eliminar</button>";

                    return strEstatus;
                }
            }




        ],

        ajax: {

            url: "https://localhost:44376/" + "api/WaIngredientes",
            crossDomain: true,

            dataType: "json",
            dataSrc: ""
        }
    });


    $('#tProductos').on('click', 'tr', function () {
        var objProducto = tProductos.row(this).data();
        console.log(objProducto)
        Cargafrm(objProducto);

    });
})


function Cargafrm(Producto) {
    $("#txtId").val(Producto.Id);
    $("#txtProducto").val(Producto.Producto);
    $("#sCategoriaId").val(Producto.CategoriaId);
    $("#txtPrecio").val(Producto.Precio);
}

function Limpiarfrm() {
    $("#frmProducto")[0].reset();
    $("#hId").val(0);
}

function Guardarfrm() {
    $.post("https://localhost:44376/" + "api/WaProductos", $("#frmProducto").serialize(), function (data) {
        Limpiarfrm();
        tProductos.ajax.reload();
    })
}


function Eliminar(id) {
    $.SmartMessageBox({
        title: "Pastor Enchilado",
        content: "¿Deseas Eliminar el registro? </br> Da clic en si para confirmar",
        buttons: '[No][Si]'
    }, function (ButtonPressed) {
        if (ButtonPressed === "Si") {
            $.get("https://localhost:44376/" + "api/WaProductos/Eliminar?id=" + id, function (data) {
                Limpiarfrm();
                tProductos.ajax.reload();
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
function CargaCategorias() {
    $.get("https://localhost:44376/" + "api/WaCategorias", function (data) {
        var stringCategorias = "";
        for (var i = 0; i < data.length; i++) {
            stringCategorias += "<option selected value=" + data[i].Id + ">" + data[i].Categoria + "</option>";
        }
        $("#sCategoriaId").html(stringCategorias);
    });
}


function log(message) {
    $("<div>").text(message).prependTo("#log");
    $("#log").scrollTop(0);
}

