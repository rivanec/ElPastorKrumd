
$(document).ready(function () {
    localStorage.removeItem('Fecha');
    //$("#bspinr").hide();
    jQuery.support.cors = true;
    $("#bspinr").click(function (e) {
        //$("#bspinr").show();

        //$("#blogin").removeClass("btn btn-primary btn-block btn-flat");

        e.preventDefault(); //Cancelar sin detener el resto del funcionamiento.

        $.post("https://localhost:44376/Token", $("#flogin").serialize(), function (data) { //Envio de datos al servidor

            localStorage.setItem('tokenKey', JSON.stringify(data)); //crea ítems dentro del almacenamiento local
            window.location.href = "/production/index.html"; //ubicación del documento 

        }).fail(function (e) {
            alert("Usuario / Contraseña Invalido");  //Error en el usuario y/o cobtraseña
            //$("#bspinr").hide();

        });


    });

    var data = JSON.parse(localStorage.getItem('tokenKey'));



    if (data !== null) {


        window.location.href = "../../Views/Login/Index.html";
    }
    $("#contra").click(function (e) {
        e.preventDefault();
        window.location = configUrl.url("Views/Account/Register.html"); //.pathname = "Views/Account/Register.html";
    });
    $("#regi").click(function (e) {
        window.location = configUrl.url("Views/Account/Register.html");

        e.preventDefault();

    });


});





