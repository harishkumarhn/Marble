<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="CustomReportAdd.aspx.cs" Inherits="Marble.WebReports.CustomReportAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hide_column {
            display: none;
        }

        textarea.form-control {
            height: auto !important;
        }
    </style>
    <script src="Content/DataTables/media/js/jquery.dataTables.js"></script>
    <%--    <link href="Content/DataTables/media/css/dataTables.bootstrap4.css" rel="stylesheet" />
    <link href="Content/DataTables/media/css/dataTables.material.css" rel="stylesheet" />--%>
    <link href="Content/DataTables/media/css/jquery.dataTables.min.css" rel="stylesheet" />
    <input type="hidden" value="0" class="hdnAddMode" />
    <div>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#reportbody" aria-controls="reportbody" role="tab" data-toggle="tab" id="reports" data-mode="1">Reports</a></li>
            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab" id="addReport" data-mode="2">ADD Report</a></li>
            <%--<li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Edit Report</a></li>--%>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="reportbody">
                <div class="dtDiv">
                    <table id="example" class="display" width="100%"></table>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="profile">
                <div class="col-md-6">
                    <input type="hidden" class="form-control" id="rid" value="">
                    <div class="form-group">
                        <label for="reportname">Report Name</label>
                        <input type="text" class="form-control" id="reportname">
                    </div>
                    <div class="form-group">
                        <label for="reportgroup">Report Group</label>
                        <input type="text" class="form-control" id="reportgroup">
                    </div>
                    <div class="form-group">
                        <label for="query">Query</label>
                        <textarea class="form-control" id="query" rows="7"> </textarea>
                    </div>
                    <div class="form-group">
                        <label for="outputFormat">Output Format</label>
                        <select class="form-control" id="outputFormat">
                            <option>PDF</option>
                            <option>EXCEL</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <input type="checkbox" name="Active" value="Active" class="isActive">
                        <%--  <label for="vehicle1"> I have a bike</label><br>--%>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btnSave">Save</button>
                    </div>
                </div>

            </div>
            <div role="tabpanel" class="tab-pane" id="messages">.CCC..</div>

        </div>

    </div>




    <script type="text/javascript">
        $(document).on("click", "#reports,#addReport", function (e) {
            switch ($(this).data("mode")) {
                case 1:
                    //$("#addReport").toggleClass("hide");
                    $(".hdnAddMode").val("1")
                    $("#addReport").text("ADD Report");
                    break;
                case 2:
                    $(".hdnAddMode").val("1")
                    break;
            }

        });

        function ClearForm() {
            $("#reportname").val("");
            $("#outputFormat").val("");
            $("#query").val("");
            $("#reportgroup").val("");
            $(".isActive").prop("checked", false);
            $("#rid").val("");

        }
        $(document).on("click", ".btnSave", function (e) {
            e.preventDefault();

            if (!Validate()) {
                return;
            }

            var report = {};
            report.ReportName = $("#reportname").val();
            report.OutputFormat = $("#outputFormat").val();
            report.DBQuery = $("#query").val();
            report.ReportGroup = $("#reportgroup").val();
            report.IsActive = $(".isActive").prop("checked");
            if ($(".hdnAddMode").val() == "2") {
                report.Id = $("#rid").val();
            }

            var jrep = JSON.stringify(report);
            //console.log(JSON.stringify(report));
            $.ajax({
                type: "POST",
                //data: {jsonData: "ssss" },
                data:
                    JSON.stringify({ jsonData: jrep })
                ,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                // contentype: "application/json; charset=utf-8",
                //contentType: "text/plain",
                url: "/Ajax/WebApp.aspx/SaveReport",
                //data: { str: text},
                //dataType:"json",
                success: function (data) {
                    console.log(JSON.stringify(data));
                    if (data.d.Result == 0) {
                        alertify.error(data.d.Message);
                    }
                    else {
                        alertify.success(data.d.Message);
                        ClearForm()
                        $("#reports").trigger("click");
                        loadData();
                    }
                },
                error: function (response) {
                    debugger
                    alert(response);
                }
            });
            //}
        });

        function Validate() {
            var valid = true;
            alertify.set('notifier', 'position', 'top-right');

            if ($("#reportname").val().trim() == "") {

                alertify.error("Report Name is Required");
                valid = false;

            }
            else if ($("#outputFormat").val() == "") {

                alertify.error("Output format is Required");
                valid = false;
            }
            else if ($("#query").val().trim() == "") {
                alertify.error("Query is Required");
                valid = false;

            }
            else if ($("#reportgroup").val().trim() == "") {
                alertify.error("Report group is Required");
                valid = false;

            }
            return valid;
        }

        $(document).on("click", ".lnkEdit", function (e) {

            debugger
            var id = $(this).closest("tr").find("td:first").text();
            $.ajax({
                type: "POST",
                // data: {jsonData: "ssss" },
                data:
                    JSON.stringify({ id: id })
                ,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                // contentype: "application/json; charset=utf-8",
                //contentType: "text/plain",
                url: "/Ajax/WebApp.aspx/EditReport",
                //data: { str: text},
                //dataType:"json",
                success: function (data) {
                    var dt = JSON.parse(data.d);

                    //console.log(JSON.stringify(data));
                    $("#reportname").val(dt.ReportName)
                    $("#outputFormat").val(dt.OutputFormat);
                    $("#query").val(dt.DBQuery)
                    $("#reportgroup").val(dt.ReportGroup);
                    $(".isActive").prop("checked", dt.IsActive);
                    $("#rid").val(dt.Id);


                    $("#addReport").text("Edit Report");
                    $("#addReport").trigger("click");
                    $(".hdnAddMode").val("2")


                },
                error: function (response) {
                    debugger
                    alert(response);
                }
            });

            //switch ($(this).data("mode") ) {
            //    case "1":
            //        //$("#addReport").toggleClass("hide");
            //        $("#addReport").val("1")
            //         $("#addReport").text("ADD Report");
            //        break;
            //    case "2":
            //        break;
            //}

        });
        function loadData() {

            if ($.fn.dataTable.isDataTable('#example')) {
                $('#example').DataTable().destroy();
            }
            $.ajax({
                type: "POST",
                //data: JSON.stringify({ name: $('#name').val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                // contentype: "application/json; charset=utf-8",
                //contentType: "text/plain",
                url: "/Ajax/WebApp.aspx/GetAllReports1",
                //data: { str: text},
                //dataType:"json",
                success: function (data) {

                    var jsonString = JSON.parse(data.d)
                    //console.log(JSON.stringify(data));
                    // alert(JSON.stringify(data));
                    $('#example').DataTable({
                        data: jsonString,
                        //scrollY: '50vh',
                         scrollY:        "500px",
                        scrollX: true,
                        fixedColumns: true,
                        scrollCollapse: true,
                        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                        columns: [

                            { title: "Id" },
                            { title: "Report Name" },
                            { title: "ReportKey" },
                            { title: "IsCustomReport" },
                            { title: "Output Format" },
                            { title: "Query" },
                            { title: "Report Group" },
                            { title: "Active" },
                            {
                                "render": function (data, type, row, meta) {
                                    return '<a href="#" class="lnkEdit">Edit</a>';
                                }

                            }

                        ],
                        "columnDefs": [
                            {
                                "type": "int",  className: "hide_column", "targets": [0],
                                "visible": true,
                            },
                            { "type": "string" ,width: 140,"targets": [1]},
                            { "type": "string", className: "hide_column", "targets": [2] },
                            { "type": "string", className: "hide_column", "targets": [3] },
                            { "type": "string" ,width: 150,"targets": [4]},
                            { "type": "string",   "targets": [5], className: "textwrap1", },
                            { "type": "string",width: 150,  "targets": [6]},
                            { "type": "string" }, { "type": "string" }
                        ]
                         
                    });
                },
                error: function (response) {
                    //debugger
                    //alert(response);
                }
            });


        }

        $(document).ready(function (e) {
            loadData();
        })
        function OnSuccess(response) {
            alert(response.d);
        }

    </script>
</asp:Content>
