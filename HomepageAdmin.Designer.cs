
@{
    ViewBag.Title = "Homepage Admin";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Homepage Admin</title>
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/util.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Content/themes/base/main.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
    <link href="~/Content/themes/base/jquery-ui.min.css" rel="stylesheet" />
    <script src="~/Scripts/bootstrap.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
    <link href="~/Content/themes/base/jquery-ui.min.css" rel="stylesheet" />
</head>
<body>
    <div style="width:90%; margin:0 auto">
        <a class="popup btn btn-primary" href="/Admin/Save/0" style="margin-bottom:20px; margin-top:20px;">Add New Profile</a>
        <table id="myDatatable">
            <thead>
                <tr>
                    <th style="text-align:center">Company</th>
                    <th style="text-align:center">Nama</th>
                    <th style="text-align:center">Jabatan</th>
                    <th style="text-align:center">Tanggal Lahir (yyyy/mm/dd/)</th>
                    <th style="text-align:center">Usia</th>
                    <th style="text-align:center">Tanggal Masuk (yyyy/mm/dd/)</th>
                    <th style="text-align:center">Masa Kerja (Tahun)</th>
                    <th style="text-align:center">Golongan</th>
                    <th style="text-align:center">Tanggal Golongan</th>
                    <th style="text-align:center">Edit</th>
                    <th style="text-align:center">Delete</th>
                </tr>
            </thead>
        </table>
    </div>

    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/jquery-ui-1.12.1.min.js"></script>
    <script>
        $(document).ready(function () {
            var oTable = $('#myDatatable').dataTable({
                "ajax": {
                    "url": '/admin/GetMember',
                    "type": "get",
                    "datatype": "json"
                },
                "columns": [
                    { "data": "company", "autoWidth": true },
                    { "data": "nama", "autoWidth": true },
                    { "data": "jabatan", "autoWidth": true },
                    { "data": "tgl_lahir", "autoWidth": true },
                    { "data": "usia", "autoWidth": true },
                    { "data": "tgl_masuk", "autoWidth": true },
                    { "data": "masa_kerja", "autoWidth": true },
                    { "data": "gol", "autoWidth": true },
                    { "data": "tgl_gol", "autoWidth": true },
                    {
                        "data": "member_id", "width": "50px", "render": function (data) {
                            return '<a class="popup" href="/Admin/Save/' + data + '">Edit</a>';
                        }
                    },
                    {
                        "data": "member_id", "width": "50px", "render": function (data) {
                            return '<a class="popup" href="/Admin/Delete/' + data + '">Delete</a>';
                        }
                    }
                ],
                'createdRow': function (row, data, dataIndex) {
                    $(row).attr('class', 'isi');
                    $(row).attr('data-id', data.member_id);
                }
            })
            
            $("#myDatatable").on("click", ".isi", function () {
                var id = ($(this).data('id'));
                window.open('http://localhost:54060/Admin/ProfileAdmin?id=' + id, '_self');
            });
        })//ini benar
    </script>
</body>
</html>
