/// <reference path="zepto.min.js" />
!(function (window) {
    var document = window.document;

    //下拉选择
    $(".select_opacity").on("change", function () {
        var index = this.selectedIndex, $prve = $(this).prev();
        index == 0 ? $prve.addClass("red") : $prve.removeClass("red");
        $prve.text(this.options[index].text);
    });

    //输入框验证
    $(".input_verify").on("focus", function () {
        var value = $(this).val().trim();
        if (value == $(this).attr("tip")) {
            $(this).val("").removeClass("red");
        }
    }).on("blur", function () {
        var value = $(this).val().trim();
        $(this).val(value);
        //非空
        if (!value) {
            $(this).val($(this).attr("tip")).addClass("red");
            return;
        }
        //内容跟提示一样
        if (value == $(this).attr("tip")) {
            $(this).addClass("red");
            return;
        }
        $(this).removeClass("red");
    });

    //手机号验证
    $("#phone").off("blur").on("blur", function () {
        var value = $(this).val().trim();
        $(this).val(value);
        //非空
        if (!value) {
            $(this).val($(this).attr("tip")).addClass("red");
            return;
        }
        //内容跟提示一样
        if (value == $(this).attr("tip")) {
            $(this).addClass("red");
            return;
        }
        //手机号不合法
        if (isNaN(value)) {
            $(this).addClass("red");
            return;
        }
        $(this).removeClass("red");
    });


    //提交
    $(".btn_submit").on("click", function () {
        if ($("span").hasClass("red")
            || $(".input_verify").hasClass("red")) {
            dialog.alert("提交失败", "请先完善信息！", "知道了");
            return;
        }
        //页面的提交业务
        doSubmit();
    });
    
})(window);
