function headerAPI(idx) {
    var headers = $('.primary');
    _.each(headers, function (item, index) {
        if (index === idx) {
            $(_.first($(item).children())).attr("class", "firstLevel active");
        } else {
            $(_.first($(item).children())).attr("class", "firstLevel");
        }
    });
}
