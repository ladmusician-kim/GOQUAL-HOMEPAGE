var windowHeight = $(window).height();
var windowWidth = $(window).width();
$(".goqual_container").css("min-height", windowHeight - 220);

var lang = $("#Lang").val();
var ko_menu = $('.goqual_lang_ko');
var eng_menu = $('.goqual_lang_eng');

if (lang == 0) {
    if (ko_menu) {
        ko_menu.addClass('active');
    }
} else {
    if (eng_menu) {
        eng_menu.addClass('active');
    }
}