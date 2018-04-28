$(function () {
    BootStrap_List();
});

function BootStrap_List() {
    $('#employeeTable').bootstrapTable('destroy');
    $('#employeeTable').bootstrapTable({
        //请求方法
        method: 'get',
        url: '/DataOpera/GetList',//请求数据的地址
        //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）     
        cache: false,
        //是否显示行间隔色
        striped: true,
        //是否显示分页（*）  
        pagination: true,
        //是否启用排序  
        sortable: true,
        //排序方式 
        sortOrder: "asc",
        dataType: "json",
        //可供选择的每页的行数（*）    
        pageList: [6, 20, 50, 100, 200, 500, 100, 2000, 5000, 10000],
        //每页的记录行数（*）   
        pageSize: 6,
        //初始化加载第一页，默认第一页
        pageNumber: 1,
        //是否显示搜索
        search: true,
        //分页方式：client客户端分页，server服务端分页（*）
        sidePagination: 'server',
        toolbar: "#toolbar",
        showHeader: true,
        showRefresh: true,
        showColumns: true,
        minimumCountColumns: 2,
        clickToSelect: true,
        showExport: true,
        //导出当前页
        exportDataType: 'basic',
        //导出所有
        //exportDataType: "all",
        exportTypes: ['json', 'xml', 'csv', 'txt', 'sql', 'excel'],
        //fixedColumns: true,
        //fixedNumber: 2,
        //exportTypes: ['txt', 'excel'],
        columns: [
            {
                field: 'id', align: 'center', valign: 'middle', checkbox: true,
            },
            { title: 'ID', field: 'UserID', align: 'center', valign: 'middle', sortable: true },//, sortable: true 
            { title: '名称', field: 'UserName', align: 'center', valign: 'middle' },
            { title: '密码', field: 'UserPwd', align: 'center', valign: 'middle' },
            { title: '手机', field: 'UserPhone', align: 'center', valign: 'middle' },
            { title: '邮箱', field: 'UserEmail', align: 'center', valign: 'middle' },
            { title: 'QQ', field: 'UserQQ', align: 'center', valign: 'middle' },//, visible: false
        ],
    });
}

///导入员工
function ImportEmployee() {
    var file = document.getElementById("EFile");
    // for IE, Opera, Safari, Chrome  
    if (file.outerHTML) {
        file.outerHTML = file.outerHTML;
    } else { // FF(包括3.5)  
        file.value = "";
    }
    $("#EFile").click();
};

///员工导入
function EUpload() {
    var fd = new FormData();
    fd.append("EFile", $("#EFile").get(0).files[0]);//上传的文件file
    $.ajax({
        url: "/DataOpera/EmployeeExcel",
        type: "POST",
        processData: false,
        contentType: false,
        data: fd,
        success: function (data) {
            if (data.state) {
                layer.msg(data.msg, { tiem: 500, icon: 1 });
            }
            else {
                layer.msg(data.msg, { tiem: 500, icon: 2 });
            }
        }
    })
}