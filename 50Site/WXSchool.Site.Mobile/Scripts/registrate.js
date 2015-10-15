/// <reference path="zepto.min.js" />
!(function (window, document) {
    //下拉选择
    $(".select_opacity").on("change", function () {
        var index = this.selectedIndex, $prve = $(this).prev();
        index == 0 ? $prve.addClass("red") : $prve.removeClass("red");
        $prve.text(this.options[index].value);
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

    //单选
    $(".radio").on("click", function () {
        var $radios = $(this).parent().find(".radio");
        $radios.removeClass("radio_selected");
        $(this).addClass("radio_selected");
        $(this).parent().attr("data-type", $(this).index());
    });

    //减 和 加
    $(".sub_num,.add_num").on("tap", function () {
        var $parent = $(this).parent(),
            min = parseInt($parent.attr("data-min"), 10),
            max = parseInt($parent.attr("data-max"), 10),
            num = parseInt($parent.attr("data-num"), 10),
            isSub = $(this).hasClass("sub_num");
        isSub ? num-- : num++;
        num = num < min ? min : num > max ? max : num;
        $parent.attr("data-num", num).find(".num").html(num);

        //num == min ? $parent.find(".sub_num").addClass("red") : $parent.find(".sub_num").removeClass("red");
        //num == max ? $parent.find(".add_num").addClass("red") : $parent.find(".add_num").removeClass("red");
    });



    //选择公司地区
    $("#city").on("click", function () {
        $(".page").hide();
        $(".page_2").show();
    });

    var addData = { proId: "", proName: "", cityID: "", cityName: "", areaId: "", areaName: "" };//存储公司的地址
    window.data = addData;

    //选择省份
    $(".first_box").html(getList(0)).delegate("p", "click", function () {
        $(this).parent().find("p").removeClass("selected");
        $(this).addClass("selected");

        var id = $(this).attr("data-id");
        $(".second_box").html(getList(id)).show();
        $(".third_box").hide();

        addData = {};
        addData.proId = id;
        addData.proName = $(this).text();
    });
    //选择城市
    $(".second_box").delegate("p", "click", function () {
        $(this).parent().find("p").removeClass("selected");
        $(this).addClass("selected");

        var id = $(this).attr("data-id");
        $(".third_box").html(getList(id)).show();

        addData.cityID = id;
        addData.cityName = $(this).text();
    });
    //选择地区
    $(".third_box").delegate("p", "click", function () {
        addData.areaId = $(this).attr("data-id");
        addData.areaName = $(this).text();

        $("#city").val(addData.proName + " " + addData.cityName + " " + addData.areaName).removeClass("red");
        $(".page").hide();
        $(".page_1").show();
    });


    //是否预定酒店
    $(".select_hotel .radio").on("click", function () {
        if ($(this).index() == 0)//预订酒店
        {
            $(".hotel_info").show();
            $(".no_tips").hide();
            if ($("#hotel").val() == '请选择酒店') {
                $("#hotel_span").addClass("red");
            }
        }
        else {
            $(".hotel_info").hide();
            $(".no_tips").show();
            $("#hotel_span").removeClass("red");
            $("#hotel_num").removeClass("red");
        }
    });

    //var maxHotelNum = 4;
    //酒店数量
    //$("#hotel_num").on("input", function () {
    //    var num = parseInt($(this).val(), 10) || 1;
    //    if (num > maxHotelNum) { num = maxHotelNum; }
    //    $(this).val(num);
    //});

    //提交
    $(".btn_zc").on("click", function () {
        if ($("span").hasClass("red")
                || $(".input_verify").hasClass("red")) {
            dialog.alert("操作失败", "请先完善报名信息！", "知道了");
            return;
        }

        var regId = $("#regId").val();
        //地址
        var address = $("#city").val().replace($("#city").attr("tip"), "");//addData
        //单位
        var company = $("#company").val().replace($("#company").attr("tip"), "");
        //参会人数
        var participant = parseInt($("#participant").attr("data-num"), 10) || 0;
        //是否选择酒店
        var selectHotel = parseInt($("#select_hotel").attr("data-type"), 10) || 0;// 0:选择 1:不选择
        //酒店
        var hotel = $("#hotel").val();
        var hotel_id = $("#hotel option").not(function() { return !this.selected; }).attr("data-id");
        //酒店数量
        var hotel_num = parseInt($("#hotel_num").attr("data-num"), 10) || 0;
        //天数
        var days = parseInt($("#days").attr("data-num"), 10) || 0;
        //9日晚是否留下用餐
        var dining = 1;//parseInt($("#dining").attr("data-type"), 10) || 0;// 0:选择 1:不选择
        //组别
        var group = $("#group").val();
        var group_id = $("#group option").not(function () { return !this.selected; }).attr("data-id");

        if (group_id == "3" && hotel_id!="9") {
            dialog.alert("操作失败", "只能选择派克快捷酒店！", "知道了");
            return;
        }

        //debugger;
        $.ajax({
            url: '../Meeting/Registrate',
            type: 'post',
            data: { RegId: regId, ProvinceCode: addData.proId, ProvinceName: addData.proName, CityCode: addData.cityID, CityName: addData.cityName, CountyCode: addData.areaId, CountyName: addData.areaName, OrganizationName: company, Participants: participant, IsBooking: selectHotel, HotelId: hotel_id, HotelName: hotel, BookedRooms: hotel_num, LodgingDays: days, HaveMeals: dining, GroupCode: group_id, GroupName: group },
            success: function (data) {
                if (data.ResultType == 200) {
                    location.href = '../Participants/Index?regId=' + data.AppendData;
                } else {
                    dialog.alert("操作失败", data.Message, "知道了");
                }
            }
        });
    });


    //列表
    function getList(id) {
        var h = [];
        citys.forEach(function (n) {
            if (n[2].toString() === id.toString()) {
                h.push('<p data-id="' + n[0] + '">' + n[1] + '</p>');
            }
        });
        return h.join("");
    }

    var $jp = $("<div></div>").height("20px").hide();
    $(".content").append($jp);
    $("input").on("focus", function () { $jp.show(); }).on("blur", function () { $jp.hide(); });
})(window, document);
