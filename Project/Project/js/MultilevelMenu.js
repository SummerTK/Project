    $(function () {
        // 获取导航栏
        resizeBannerImage();
    })
        $(window).resize(function () {
        // 获取导航栏
        resizeBannerImage();
    });

        function resizeBannerImage() {
        $("#Testv").html("")
            var WideScreen = window.innerWidth * 80/100
            $(".menu").css("width", WideScreen);
            var masterul2Html = "";
            var c = 0;
            var DivScreen = 100;
            for (var i = 0; i < 20; i++) {
                if (DivScreen < WideScreen) {
                    var masterulHtml = "";
                    masterulHtml += '<li>'
                    masterulHtml += '<a href="#">栏目' + i + '</a>'
                    masterulHtml += '<ul>'
                    masterulHtml += '<li><a href="#">二级栏目</a ></li >'
                    masterulHtml += '<li><a href="#">二级栏目</a></li>'
                    masterulHtml += '<li><a href="#">二级栏目</a></li>'
                    masterulHtml += '<li><a href="#">二级栏目</a></li>'
                    masterulHtml += '</ul>'
                    masterulHtml += '</li>'
                    $("#Testv").append(masterulHtml)
                    DivScreen = DivScreen + $('#Testv>li').eq(i).width() + 30;
                    c = i + 1;
                } else {
                    if (c == i) {
        $("#Testv").append('<li><a href="#">栏目四</a><ul id="Testv2"></ul></li>')
    }
    masterul2Html += '<li>'
                    masterul2Html += '<a href="#">栏目' + i + '</a>'
                    masterul2Html += '<ul>'
                    masterul2Html += '<li><a href="#">二级栏目</a></li>'
                    masterul2Html += '<li><a href="#">二级栏目</a></li>'
                    masterul2Html += '<li><a href="#">二级栏目</a></li>'
                    masterul2Html += '<li><a href="#">二级栏目</a></li>'
                    masterul2Html += '</ul>'
                    masterul2Html += '</li>'
                }
            }
            if (masterul2Html != "") {
        $("#Testv2").append(masterul2Html)
    }
    }
