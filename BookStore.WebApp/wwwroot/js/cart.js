var CartController = function () {
    this.initialize = function () {
        loadData();

        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            updateCart(id, quantity);
        });
        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0);
        });
    }

    function updateCart(id, quantity) {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "POST",
            url: "/" + culture + '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    function loadData() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                if (res.length === 0) {
                    $('#tbl_cart').hide();
                }
                var html = '';
                var total = 0;
                if (culture=="vi") { var cultureType = 'vi-VN'; var currencyType = "VND"; }
                else { var cultureType = 'en-US'; var currencyType = "USD"; }
            
                var formatter = new Intl.NumberFormat(cultureType, {
                    style: 'currency',
                    currency: currencyType,
                });

                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;
                    total = total + amount;
                    html += "<tr>"
                        + "<td> <div style=\"text-align:center;\" class=\"media\" > <div class=\"d-flex\"> <img style=\"text-align:center;width: 100px; height:auto;\" src=\"" + $('#hidBaseAddress').val() + item.showDefaultImage + "\" alt=\"\"/></div > <div class=\"media-body\"><p style=\"font-size:20px\">"+item.name+"</p></div> </div></td>"

                        + "<td style=\"font-size:20px;text-align:center;\">" + formatter.format(item.price) + "</td>"

                        + "<td><div  style=\"text-align:center;\"  class=\"input-append\"><input class=\"span1 form-control\" style=\"display:inline; margin-right:20px; width:50px; height: 38px;\" placeholder=\"1\" id=\"txt_quantity_" + item.productId + "\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\">"
                        + "<button style=\"margin-right:20px;\" class=\"btn btn-minus\" data-id=\"" + item.productId + "\" type =\"button\"> <i class=\"icon-minus\">–</i></button>"
                        + "<button style=\"margin-right:20px;\" class=\"btn btn-plus\" type=\"button\" data-id=\"" + item.productId + "\"><i class=\"icon-plus\">+</i></button>"
                        + "<button style=\"margin-right:20px;\" class=\"btn btn-danger btn-remove\" type=\"button\" data-id=\"" + item.productId + "\"><i class=\"icon-remove icon-white\">Delete</i></button>"
                        + "</div>"
                        + "</td>"
                        + "<td style=\"font-size:20px;text-align:center;\">" + formatter.format(amount) + "</td>"
                        + "</tr>";
                        
                });
                $('#cart_body').html(html);
                $('#lbl_number_of_items').text(res.length);
                $('#lbl_total').text(formatter.format(total));
            }
        });
    }
}