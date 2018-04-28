$(function () {
    //内置参数
    Built_inTable_List();
    //自定义参数
    CustomizeTable_List();
    //自定义框

})

function Built_inTable_List() {
    $('#Built_inTable').bootstrapTable('destroy');
    $("#Built_inTable").bootstrapTable({
        method: 'get',//数据请求方式
        url: '/Data/Built_inTableGetList',//请求数据的地址
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
        showHeader: true,
        showRefresh: true,
        showColumns: true,
        minimumCountColumns: 2,
        clickToSelect: true,
        showExport: true,
        //导出当前页
        exportDataType: 'basic',
        //导出所有
        //exportdatatype: "all",
        exporttypes: ['json', 'xml', 'csv', 'txt', 'sql', 'excel'],
        //queryParams: queryParams,
        columns: [
            {
                field: 'id', align: 'center', valign: 'middle', checkbox: true,
            },
            { title: '表名', field: '表名', align: 'center', valign: 'middle', sortable: true },
            { title: '字段序号', field: '字段序号', align: 'center', valign: 'middle' },//, visible: false
            { title: '字段名', field: '字段名', align: 'center', valign: 'middle' },
            { title: '标识', field: '标识', align: 'center', valign: 'middle' },
            { title: '主键', field: '主键', align: 'center', valign: 'middle' },
            { title: '类型', field: '类型', align: 'center', valign: 'middle' },
            { title: '占用字节数', field: '占用字节数', align: 'center', valign: 'middle' },
            { title: '长度', field: '长度', align: 'center', valign: 'middle' },
            { title: '小数位数', field: '小数位数', align: 'center', valign: 'middle' },
            { title: '允许空', field: '允许空', align: 'center', valign: 'middle' },
            { title: '默认值', field: '默认值', align: 'center', valign: 'middle' },
        ],
    });
}

function CustomizeTable_List() {
    $('#CustomizeTable').bootstrapTable('destroy');
    $("#CustomizeTable").bootstrapTable({
        method: 'get',//数据请求方式
        url: '/Data/CustomizeTableList',//请求数据的地址
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
        showHeader: true,
        showRefresh: true,
        showColumns: true,
        minimumCountColumns: 2,
        clickToSelect: true,
        showExport: true,
        //导出当前页
        exportDataType: 'basic',
        //导出所有
        //exportdatatype: "all",
        exporttypes: ['json', 'xml', 'csv', 'txt', 'sql', 'excel'],
        queryParams: queryParams,
        columns: [
            {
                field: 'id', align: 'center', valign: 'middle', checkbox: true,
            },
            { title: '表名', field: '表名', align: 'center', valign: 'middle', sortable: true },
            { title: '字段序号', field: '字段序号', align: 'center', valign: 'middle' },//, visible: false
            { title: '字段名', field: '字段名', align: 'center', valign: 'middle' },
            { title: '标识', field: '标识', align: 'center', valign: 'middle' },
            { title: '主键', field: '主键', align: 'center', valign: 'middle' },
            { title: '类型', field: '类型', align: 'center', valign: 'middle' },
            { title: '占用字节数', field: '占用字节数', align: 'center', valign: 'middle' },
            { title: '长度', field: '长度', align: 'center', valign: 'middle' },
            { title: '小数位数', field: '小数位数', align: 'center', valign: 'middle' },
            { title: '允许空', field: '允许空', align: 'center', valign: 'middle' },
            { title: '默认值', field: '默认值', align: 'center', valign: 'middle' },
        ],
    });
}

function queryParams(params) {
    return {
        search: params.search,
        limit: params.limit,
        offset: params.offset,
        order: params.order,
        a: 1,
        b: 2,
    };
}