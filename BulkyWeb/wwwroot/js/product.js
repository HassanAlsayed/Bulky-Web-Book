﻿
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/product/GetAll' },
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'isbn', "width": "10%", },
            { data: 'listPrice', "width": "10%" },
            { data: 'author', "width": "10%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class=" btn-group" role="group">
        <a href="/admin/product/UpdateProduct?id=${data}" class="btn btn-primary "> <i class="bi bi-pencil-square"></i> Edit</a>
        <a onclick="Delete('/admin/product/DeleteProduct?id=${data}')" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
    </div>`;
                },
                "width": "20%"
            }

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
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}


        