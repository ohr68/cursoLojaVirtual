$('#Cep').change(function (e) {
    //Evita post após a digitação
    e.preventDefault();

    $('#Endereco').val('');
    $('#Bairro').val('');
    $('#Cidade').val('');
    $('#Estado').val('');



    var cep = $('#Cep').val().replace("-", "");

    $.getJSON("https://www.republicavirtual.com.br/web_cep.php?cep=" + cep + "&formato=json", {}, function (data) {
        if (data.resultado_txt == "sucesso - cep único") {
            $('#Endereco').val(data.tipo_logradouro + ' ' + data.logradouro);
            $('#Bairro').val(data.bairro);
            $('#Cidade').val(data.cidade);
            $('#Estado').val(data.uf);

        }
    });
});


$(function () {
    //Abrir o modal
    $(".btn-xs").click(function(e) {
        e.preventDefault();

        var id = this.id;
        var nome = this.name;

        $("#deleteModal .modal-body input[type=hidden]").val(id);

        $("#deleteModal .modal-body span").text(nome);

        $("#deleteModal").modal('show');

        $("#deleteModal .modal-footer button").click(function (e) {
            //Prevenir o comportamento padrão do botão
            e.preventDefault();

            var url = "/Administrativo/Produto/Excluir/";
            var id = $(".modal-body input[type=hidden]").val();

            var rowNo = "#row-" + id;

            if ($('#deleteModal .modal-header span').find())
            {
                $('#deleteModal .modal-header span').remove();
            }

            $.ajax({
                url: url,
                type: 'POST',
                datatype: 'json',
                data: {
                    produtoId: id
                },beforeSend: function () {
                    var loading = "<span><em>Excluindo</em>&nbsp;<i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></span>";
                    $('#deleteModal .modal-header h4').after(loading);
                },
                success: function (data) {

                    $('#deleteModal').modal('hide');

                    $(rowNo).animate({ opacity: 0.0 }, 400, function () {
                        $(rowNo).remove();
                    });

                },
                complete: function (data) {
                    $("#divExcluir").empty();
                    $("#divExcluir").addClass("alert alert-success");
                    $("#divExcluir").html(data.responseText);
                    $('#deleteModal .modal-header span').remove();
                }

        });
        });
    });
});