$(document).ready(function () {
        localStorage.removeItem('Fecha');
        //$("#bspinr").hide();
        jQuery.support.cors = true;
        $("#bspinr").click(function (e) {
            //$("#bspinr").show();

            //$("#blogin").removeClass("btn btn-primary btn-block btn-flat");

            e.preventDefault();

            $.post("https://localhost:44376/Token", $("#flogin").serialize(), function (data) {

                localStorage.setItem('tokenKey', JSON.stringify(data));

                window.location.href = "/production/index.html";

            }).fail(function (e) {
                alert("Usuario / Contraseña Invalido");
                //$("#bspinr").hide();

            });


        });

        var data = JSON.parse(localStorage.getItem('tokenKey'));



        if (data !== null) {


            window.location.href = "/production/index.html";
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