$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});
$(document).ready(function () {
    $.getJSON("/svc/productInfo.aspx").done(function (product) {
        console.log(product);
        product.forEach(function (data) {
            var $myRow = $('<div/>', { class: 'container' })
            $('#Products').append($myRow)
            console.log(data);

            $($myRow).append($('<a/>', {
                href: '#',
                'data-toggle': "popover",
                title: data.ShortDescription,
                'data-content': data.LongDescription,
                text: data.ShortDescription,
                'data-trigger': "focus"
            }));
            $('[data-toggle="popover"]').popover();
        });
    });
});



  



