

$(document).ready(function () {
    $.getJSON("svc/productInfo.aspx")
        .done(function (product) {
            var $keys = Object.keys(product[0]);

            for (var i = 0; i < product.length; i++) {
                var $newRow = $('<TR/>', {
                    id: product[i][$keys[0]] + "row"
                })
                $('#tableBody').append($newRow)
                for (var j = 0; j < $keys.length; j++) {
                    $newRow.append($('<TD/>', {
                        text: product[i][$keys[j]],
                        id: product[i][$keys[0]] + $keys[j]
                    }));
                }
                var $newTD = $('<TD/>')
                $newRow.append($newTD)
                $newTD.append($('<button/>', {
                    text: 'Update Product',
                    onClick: 'UpdateProduct(' + product[i][$keys[0]] + ');',
                    style: "margin: 2px; width: 80%"
                }));
                $newTD.append($('<button/>', {
                    text: 'Remove Product',
                    style: "margin: 2px; width: 80%;",
                    onClick: 'RemoveProduct(' + product[i][$keys[0]] + ');'
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
    console.log($('#input0').val())
    $.getJSON("svc/productInfo.aspx?add=1&price=" + $('#input0').val() + "&stock=" + $('#input1').val() +
        "&shortDesc=" + $('#input2').val() + "&longDesc=" + $('#input3').val() +
        "&url=" + $('#input4').val() + "&vatTag=" + $('#input5').val()).done(function (data) {
            console.log(data);
            $.getJSON("svc/productInfo.aspx")
                .done(function (product) {
                    $('#tableBody').empty()
                    var $keys = Object.keys(product[0]);

                    for (var i = 0; i < product.length; i++) {
                        var $newRow = $('<TR/>', {
                            id: product[i][$keys[0]] + "row"
                        })
                        $('#tableBody').append($newRow)
                        for (var j = 0; j < $keys.length; j++) {
                            $newRow.append($('<TD/>', {
                                text: product[i][$keys[j]],
                                id: product[i][$keys[0]] + $keys[j]
                            }));
                        }
                        var $newTD = $('<TD/>')
                        $newRow.append($newTD)
                        $newTD.append($('<button/>', {
                            text: 'Update Product',
                            onClick: 'UpdateProduct(' + product[i][$keys[0]] + ');',
                            style: "margin: 2px; width: 80%"
                        }));
                        $newTD.append($('<button/>', {
                            text: 'Remove Product',
                            style: "margin: 2px; width: 80%;",
                            onClick: 'RemoveProduct(' + product[i][$keys[0]] + ');'
                        }));
                    }
                });
        })
};

function RemoveProduct(id) {
    $.getJSON("svc/productInfo.aspx?action=remove&removeid=" + id).done(function (data) {
        console.log(data);
        $.getJSON("svc/productInfo.aspx")
            .done(function (product) {
                $('#tableBody').empty()
                var $keys = Object.keys(product[0]);

                for (var i = 0; i < product.length; i++) {
                    var $newRow = $('<TR/>', {
                        id: product[i][$keys[0]] + "row"
                    })
                    $('#tableBody').append($newRow)
                    for (var j = 0; j < $keys.length; j++) {
                        $newRow.append($('<TD/>', {
                            text: product[i][$keys[j]],
                            id: product[i][$keys[0]] + $keys[j]
                        }));
                    }
                    var $newTD = $('<TD/>')
                    $newRow.append($newTD)
                    $newTD.append($('<button/>', {
                        text: 'Update Product',
                        onClick: 'UpdateProduct(' + product[i][$keys[0]] + ');',
                        style: "margin: 2px; width: 80%"
                    }));
                    $newTD.append($('<button/>', {
                        text: 'Remove Product',
                        style: "margin: 2px; width: 80%;",
                        onClick: 'RemoveProduct(' + product[i][$keys[0]] + ');'
                    }));
                }
            });
    })
}

function UpdateProduct(id) {
    var $id = $('#' + id + 'ProductID').text();
    var $price = (parseFloat($('#' + id + 'Price').text()) / 1.25);
    var $stock = $('#' + id + 'Stock').text();
    var $shortdesc = $('#' + id + 'ShortDescription').text();
    var $longdesc = $('#' + id + 'LongDescription').text();
    var $url = $('#' + id + 'URL').text();
    var $vat = $('#' + id + 'VatTag').text();

    var productArray = [];

    productArray.push($price);
    productArray.push($stock);
    productArray.push($shortdesc);
    productArray.push($longdesc);
    productArray.push($url);
    productArray.push($vat);
    
    $('#' + id + 'row').children().remove();
    var $newTD = $('<TD/>', {
        text: $id
    })
    $('#' + id + 'row').append($newTD)
    
    for (var i = 0; i < 6; i++) {
        var $newTD = $('<TD/>')
        $('#' + id + 'row').append($newTD);
        $newTD.append($('<input/>', {
            type: 'text',
            id: id + 'update' + i,
            style: 'width: 100%;',
            value: productArray[i]
        }))
    }
    var $newTD = $('<TD/>')
    $('#' + id + 'row').append($newTD)
    $newTD.append($('<button/>', {
        text: 'Update',
        onClick: 'UpdateOldProduct(' + $id + ');',
        style: 'margin: 2px; width: 80%'
    }))
}

function UpdateOldProduct(id) {
    var $id = id;
    var $price =        $('#' + id + 'update0').val()
    var $stock =        $('#' + id + 'update1').val()
    var $shortdesc =    $('#' + id + 'update2').val()
    var $longdesc =     $('#' + id + 'update3').val()
    var $url =          $('#' + id + 'update4').val()
    var $vat =          $('#' + id + 'update5').val()
    console.log($id + " " + $price + " " + $stock);

    $.getJSON("svc/productInfo.aspx?action=update&pid=" + $id + "&price=" + $price + "&stock=" + $stock +
        "&shortDesc=" + $shortdesc + "&longDesc=" + $longdesc +
        "&url=" + $url + "&vatTag=" + $vat).done(function (data) {
            console.log(data);
            $.getJSON("svc/productInfo.aspx")
                .done(function (product) {
                    $('#tableBody').empty()
                    var $keys = Object.keys(product[0]);

                    for (var i = 0; i < product.length; i++) {
                        var $newRow = $('<TR/>', {
                            id: product[i][$keys[0]] + "row"
                        })
                        $('#tableBody').append($newRow)
                        for (var j = 0; j < $keys.length; j++) {
                            $newRow.append($('<TD/>', {
                                text: product[i][$keys[j]],
                                id: product[i][$keys[0]] + $keys[j]
                            }));
                        }
                        var $newTD = $('<TD/>')
                        $newRow.append($newTD)
                        $newTD.append($('<button/>', {
                            text: 'Update Product',
                            onClick: 'UpdateProduct(' + product[i][$keys[0]] + ');',
                            style: "margin: 2px; width: 80%"
                        }));
                        $newTD.append($('<button/>', {
                            text: 'Remove Product',
                            style: "margin: 2px; width: 80%;",
                            onClick: 'RemoveProduct(' + product[i][$keys[0]] + ');'
                        }));
                    }
                });
        })
}



