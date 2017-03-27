$(document).ready(function () {
    $.getJSON("svc/productInfo.aspx")
        .done(function (product) {
            var $keys = Object.keys(product[0]);

            for (var i = 0; i < product.length; i++) {
                var $newRow = $('<TR/>')
                $('#tableBody').append($newRow)
                for (var j = 0; j < $keys.length; j++) {
                    console.log(product[i][$keys[j]])
                    $newRow.append($('<TD/>', {
                        text: product[i][$keys[j]]
                    }));
                }
                var $newTD = $('<TD/>')
                $newRow.append($newTD)
                $newTD.append($('<button/>', {
                    text: 'Update Product',
                    onClick: 'UpdateProduct(' + product[i][$keys[0]] + ')',
                    style: "margin: 2px; width: 80%"
                }));
                $newTD.append($('<button/>', {
                    text: 'Remove Product',
                    style: "margin: 2px; width: 80%;",
                    onClick: 'RemoveProduct(' + product[i][$keys[0]] + ')'
                }));
            }
    });
});

function AddProduct() {
    var $newRow = $('<TR/>')
    $('#tableBody').append($newRow)
    var $newTD = $('<TD/>')
    $newRow.append($newTD);
    for (var i = 0; i < 6; i++) {
        var $newTD = $('<TD/>')
        $newRow.append($newTD);
        $newTD.append($('<input/>', {
            type: 'text',
            id: 'input' + i,
            style: 'width: 100%;'
        }))
    }
    var $newTD = $('<TD/>')
    $newRow.append($newTD)
    $newTD.append($('<button/>', {
        text: 'Add',
        onClick: 'AddNewProduct();',
        style: 'margin: 2px; width: 80%'
    }))
};

function AddNewProduct() {
    console.log($('#input1').val())
    $.getJSON("svc/productInfo.aspx?price=" + $('#input1').val() + " ")

    //double price, int vattag, int stock, string shortdescription, string longdescription, string url
};