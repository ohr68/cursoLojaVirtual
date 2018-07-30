$('#Cep').change(function (e) {
    //Evita post após a digitação
    e.preventDefault();

    $('#Endereco').val('');
    $('#Bairro').val('');
    $('#Cidade').val('');
    $('#Estado').val('');



    var cep = $('#Cep').val().replace("-", "");

    $.getJSON("https://www.republicavirtual.com.br/web_cep.php?cep=" + cep + "&formato=json", {}, function (data)
    {
        if (data.resultado_txt == "sucesso - cep único")
        {
            $('#Endereco').val(data.tipo_logradouro + ' ' + data.logradouro);
            $('#Bairro').val(data.bairro);
            $('#Cidade').val(data.cidade);
            $('#Estado').val(data.uf);

        }
    });
});