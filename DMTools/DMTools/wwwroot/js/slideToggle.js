//$('#slide').on('click', function () { $('[name="hello"]').slideToggle(1000, 'swing') });

function RegisterSlide(ele) {
    $('#' + ele).on('click', function () {
        let parent = $(this).parent('div.margin-20');
        parent.slideToggle(500, 'swing', function () {
            parent.children('h1[name="nameTag"]').removeAttr('hidden');
        });
    });
}

function Slide(ele) {
    let parent = $(ele).parents('div.stat-block');
    if (parent.length === 0)
        parent = $(ele).parents().siblings('div.stat-block');

    let child = parent.siblings('div[name="nameTag"]');

    if (child.attr('hidden'))
        child.removeAttr('hidden');
    else
        child.attr('hidden', 'hidden');
    parent.slideToggle(200, 'swing');
}

function HideUpload(element) {
    let icon = $(element).children();
    if (icon !== null) {
        icon = icon[1];
        if ($(icon).hasClass("fa-chevron-up")) {
            $(icon).removeClass("fa-chevron-up");
            $(icon).addClass("fa-chevron-down");
            $(element).children()[0].textContent = "Show";
        }
        else {
            $(icon).removeClass("fa-chevron-down");
            $(icon).addClass("fa-chevron-up");
            $(element).children()[0].textContent = "Hide";
        }
    }
    $('#monsterUpload').slideToggle();
}