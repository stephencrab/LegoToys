var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            url: '/Admin/Product/GetAll',
            dataSrc: 'data'
        },
        columns: [
            { data: 'title', width: '15%' },
            { data: 'isbn', width: '15%' },
            { data: 'price', width: '15%' },
            { data: 'manufacturer', width: '15%' },
            { data: 'category.name', width: '15%' },
            {
                data: 'id',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a class="btn btn-primary mx-2" href="/Admin/Product/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
                            <a class="btn btn-danger mx-2" onClick="Delete('/Admin/Product/Delete/${data}');"><i class="bi bi-trash3"></i></a>
                        </div>
                    `
                },
                width: '15%'
            },
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}