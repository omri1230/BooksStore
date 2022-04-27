var dataTable;

$(document).ready(function() {
    loadDataTable();
    textColor();
});


function loadDataTable() {
    dataTable = $('#dataTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%"},
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data)
                {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary rounded-3 mx-4"><i class="bi bi-pencil-square mx-1"></i>Edit</a>
                        </div>
                         <span class="btn-group" role="group">
                            <a class="btn btn-danger rounded-3" onClick="Delete('/Admin/Product/Delete/${data}')"><i class="bi bi-trash mx-1"></i>Delete</a>
                        </span>
                    `
                },
                "width": "20%"
            },

        ],
    });
}

function textColor() {
    $("#dataTable_length").css("color", "white");
    $("#dataTable_length select").css("color", "white");
    $("#dataTable_length option").delay(3000).css("background-color", "#230f34");
    $(".dataTables_filter").css("color", "white");
    $(".dataTables_filter input").css("color", "white");
    $("#dataTable_info").css("color", "white");
    $("#dataTable_previous").css("color", "white");
    $("#dataTable_paginate a").css("color", "white");
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#7066e0',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function(data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}




