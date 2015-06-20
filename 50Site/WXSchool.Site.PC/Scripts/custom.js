//分页
var pageIndex = 1;
var bindClick = function () {
    $(".paginate_button").click(function () {
        var index = $(this).attr("tabindex");
        if (index == "+1") {
            pageIndex = pageIndex + 1;
        } else if (index == "-1") {
            pageIndex = pageIndex - 1;
        } else {
            pageIndex = parseInt(index);
        }

        doQuery();
    });
};

var refreshPagerInfo = function (total) {
    $.ajax({
        url: getRootPath()+'/Pager/OutputHtml',
        type: 'get',
        data: { currentPageIndex: pageIndex, totalItemCount: total },
        success: function (data) {
            $(".panel-footer").empty();
            $(".panel-footer").html(data);

            bindClick();
        }
    });
};

//js获取项目根路径，如： http://localhost:8083/uimcardprj
function getRootPath() {
    //获取当前网址，如： http://localhost:8083/uimcardprj/share/meun.jsp
    var curWwwPath = window.document.location.href;
    //获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
    var pathName = window.document.location.pathname;
    var pos = curWwwPath.indexOf(pathName);
    //获取主机地址，如： http://localhost:8083
    var localhostPaht = curWwwPath.substring(0, pos);
    //获取带"/"的项目名，如：/uimcardprj
    //var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
    //return (localhostPaht + projectName);
    return (localhostPaht);
}

jQuery(window).load(function () {

    // Page Preloader
    jQuery('#status').fadeOut();
    jQuery('#preloader').delay(350).fadeOut(function () {
        jQuery('body').delay(350).css({ 'overflow': 'visible' });
    });
});

jQuery(document).ready(function () {

    // Toggle Left Menu
    jQuery('.nav-parent > a').click(function () {

        var parent = jQuery(this).parent();
        var sub = parent.find('> ul');

        // Dropdown works only when leftpanel is not collapsed
        if (!jQuery('body').hasClass('leftpanel-collapsed')) {
            if (sub.is(':visible')) {
                sub.slideUp(200, function () {
                    parent.removeClass('nav-active');
                    jQuery('.mainpanel').css({ height: '' });
                    adjustmainpanelheight();
                });
            } else {
                closeVisibleSubMenu();
                parent.addClass('nav-active');
                sub.slideDown(200, function () {
                    adjustmainpanelheight();
                });
            }
        }
        return false;
    });

    function closeVisibleSubMenu() {
        jQuery('.nav-parent').each(function () {
            var t = jQuery(this);
            if (t.hasClass('nav-active')) {
                t.find('> ul').slideUp(200, function () {
                    t.removeClass('nav-active');
                });
            }
        });
    }

    function adjustmainpanelheight() {
        // Adjust mainpanel height
        var docHeight = jQuery(document).height();
        if (docHeight > jQuery('.mainpanel').height())
            jQuery('.mainpanel').height(docHeight);
    }

    // Close Button in Panels
    jQuery('.panel .panel-close').click(function () {
        jQuery(this).closest('.panel').fadeOut(200);
        return false;
    });

    // Minimize Button in Panels
    jQuery('.minimize').click(function () {
        var t = jQuery(this);
        var p = t.closest('.panel');
        if (!jQuery(this).hasClass('maximize')) {
            p.find('.panel-body, .panel-footer').slideUp(200);
            t.addClass('maximize');
            t.html('&plus;');
        } else {
            p.find('.panel-body, .panel-footer').slideDown(200);
            t.removeClass('maximize');
            t.html('&minus;');
        }
        return false;
    });


    // Add class everytime a mouse pointer hover over it
    jQuery('.nav-bracket > li').hover(function () {
        jQuery(this).addClass('nav-hover');
    }, function () {
        jQuery(this).removeClass('nav-hover');
    });


    // Menu Toggle
    jQuery('.menutoggle').click(function () {

        var body = jQuery('body');
        var bodypos = body.css('position');

        if (bodypos != 'relative') {

            if (!body.hasClass('leftpanel-collapsed')) {
                body.addClass('leftpanel-collapsed');
                jQuery('.nav-bracket ul').attr('style', '');

                jQuery(this).addClass('menu-collapsed');

            } else {
                body.removeClass('leftpanel-collapsed chat-view');
                jQuery('.nav-bracket li.active ul').css({ display: 'block' });

                jQuery(this).removeClass('menu-collapsed');

            }
        } else {

            if (body.hasClass('leftpanel-show'))
                body.removeClass('leftpanel-show');
            else
                body.addClass('leftpanel-show');

            adjustmainpanelheight();
        }

    });

    jQuery(window).resize(function () {

        if (jQuery('body').css('position') == 'relative') {

            jQuery('body').removeClass('leftpanel-collapsed chat-view');

        } else {

            jQuery('body').removeClass('chat-relative-view');
            jQuery('body').css({ left: '', marginRight: '' });
        }

    });

    //自定义
    var path = window.location.pathname;
    $('.nav-bracket > li').each(function () {
        //var url = $(this).find("a").attr("href").replace("../", "");
        var func = $(this).attr("data-func").toLowerCase();
        path = path + "/index";
        if (path.toLowerCase().indexOf(func) >= 0) {
            $(this).addClass("active");
            var iclass = $(this).find("a > i").attr("class");
            $(".pageheader").find("i").addClass(iclass);
        }
    });
    if (jQuery("#myForm").length > 0) {
        jQuery("#myForm").validate({
            highlight: function (element) {
                jQuery(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            },
            success: function (element) {
                jQuery(element).closest('.form-group').removeClass('has-error').find(".error").remove();
            }
        });
    }
    //返回
    $("#goback").click(function () {
        history.go(-1);
    });
    //修改密码
    $("#btnChangePwd").click(function () {
        var pwd = $("#txtOldPwd").val();
        if (pwd == "") {
            alert("请输入原密码");
            return;
        }
        var newPwd = $("#txtNewPwd").val();
        if (newPwd == "") {
            alert("请输入新密码");
            return;
        }
        if ($("#txtCompPwd").val() == "") {
            alert("请输入确认密码");
            return;
        }
        if (newPwd != $("#txtCompPwd").val()) {
            alert("新密码两次输入不一致");
            return;
        }

        $.ajax({
            url: '../account/ChangePassword',
            type: 'post',
            data: { pwd: pwd, newPwd: newPwd },
            success: function (data) {
                alert(data.Message);
            },
            error: function (e) {
                alert("系统繁忙，请稍后再试！");
            },
            complete: function () {
            }
        });
    });


});