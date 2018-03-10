﻿var giftNS = giftNS || {};
giftNS.builGift = function (data) {
    try {
        var giftUl = $('#giftItem ul');

        for (var item in data) {
            var liElement = $('<li></li>');
            var elementLabel = $('<span></span>');
            elementLabel.text(item + ': ');

            var elementValue = $('<span></span>');
            elementValue.text(data[item]);

            liElement.append(elementLabel);
            liElement.append(elementValue);
            giftUl.append(liElement);
        }
        $('#beerGift article:first-of-type header').show();
        $('#beerGift #gift').hide();
    } catch (e) {

    } 
    
}

$(document).ready(function () {
    var giftHeader = $('#beerGift article:first-of-type header');
    giftHeader.hide();

    $('#gift').click(function () {
        var profile = {
            CustomerCategory: 'gold',
            BuyingStyle: 'same',
            InvoiceAverage: 'high'
        };

        var crud = new crudNs.crud('http://localhost:11390/api/gift', 'post', profile);

        crud.sendRequest(function (data) {
            giftNS.builGift(data);

        });
    });
   
});