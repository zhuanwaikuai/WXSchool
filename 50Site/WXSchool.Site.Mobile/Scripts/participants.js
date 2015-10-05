/// <reference path="zepto.min.js" />
!(function (window, document)
{
    //下拉选择
    $(".select_opacity").on("change", function ()
    {
        var index = this.selectedIndex, $prve = $(this).prev();
        index == 0 ? $prve.addClass("red") : $prve.removeClass("red");
        $prve.text(this.options[index].text);
    });

    //输入框验证
    $(".input_verify").on("focus", function ()
    {
        var value = $(this).val().trim();
        if (value == $(this).attr("tip"))
        {
            $(this).val("").removeClass("red");
        }
    }).on("blur", function ()
    {
        var value = $(this).val().trim();
        $(this).val(value);
        //非空
        if (!value)
        {
            $(this).val($(this).attr("tip")).addClass("red");
            return;
        }
        //内容跟提示一样
        if (value == $(this).attr("tip"))
        {
            $(this).addClass("red");
            return;
        }
        $(this).removeClass("red");
    });

    //根据身份证来判断性别
    $("#icard").on("blur", function ()
    {
        var value = $(this).val().trim();
        if (value.length == 15 || value.length == 18)
        {
            var num = parseInt(value.substr(16, 1) || value.substr(13, 1), 10) || 1; console.log(num);
            var $radios = $(this).parent().parent().next().find(".radio");
            $radios.removeClass("radio_selected");
            $radios.eq(num % 2-1).addClass("radio_selected"); //奇数表示男性，偶数表示女性
        }
    });

    //单选
    $(".radio").on("click", function ()
    {
        var $radios = $(this).parent().find(".radio");
        $radios.removeClass("radio_selected");
        $(this).addClass("radio_selected");
    });

    //手机号验证
    $("#phone").off("blur").on("blur", function ()
    {
        var value = $(this).val().trim();
        $(this).val(value);
        //非空
        if (!value)
        {
            $(this).val($(this).attr("tip")).addClass("red");
            return;
        }
        //内容跟提示一样
        if (value == $(this).attr("tip"))
        {
            $(this).addClass("red");
            return;
        }
        //手机号不合法
        if (!(/1\d{10}/).test(value))
        {
            $(this).addClass("red");
            return;
        }
        $(this).removeClass("red");
    });





    //上一页
    $(".btn_cancel").on("click", function ()
    {
        history.back();
    });
    //确定
    $(".btn_ok").on("click", function () {
        if ($("span").hasClass("red")
                || $(".input_verify").hasClass("red")) {
            dialog.alert("操作失败", "请先完善人员信息！", "知道了");
            return;
        }

        var parId = $("#parId").val();
        var regId = $("#regId").val();
        var pName = $("#pName").val().replace($("#pName").attr("tip"), "");
        var icard = $("#icard").val().replace($("#icard").attr("tip"), "");
        var phone = $("#phone").val().replace($("#phone").attr("tip"), "");
        var sex = $(".radio_selected").attr("data-val");
        var group = $("#group").val();
        var group_id = $("#group option").not(function () { return !this.selected; }).attr("data-id");

        $.ajax({
            url: '../Participants/Edit',
            type: 'post',
            data: { ParId: parId, RegistrationId: regId, PName: pName, IDCardNo: icard, Gender: sex, Telephone: phone, GroupCode: group_id, GroupName: group },
            success: function (data) {
                if (data.ResultType == 200) {
                    location.href = '../Participants/Index?regId=' + regId;
                }
            }
        });
        //location.href = "apply_preview.html";
    });



    var $jp = $("<div></div>").height("20px").hide();
    $(".content").append($jp);
    $("input").on("focus", function () { $jp.show(); }).on("blur", function () { $jp.hide(); });
})(window, document);
