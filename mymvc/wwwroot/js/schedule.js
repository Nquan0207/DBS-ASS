var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $.ajax({
        url: '/admin/schedule/getall',
        type: 'GET',
        success: function (response) {
            if (!response.data) {
                console.error('Error: No data found in the response');
                toastr.error('Failed to load data.');
                return;
            }

            var isAdmin = response.isAdmin;

            dataTable = $('#tblSchedule').DataTable({
                "data": response.data,
                "columns": [
                    { data: 'course.courseName', "width": "25%" },
                    { data: 'course.credit', "width": "10%" },
                    { data: 'time', "width": "10%" },
                    { data: 'date', "width": "15%" },
                    { data: 'location', "width": "15%" },
                    {
                        data: 'scheduleId',
                        "render": function (data) {
                            let buttons = `<div class="w-75 btn-group" role="group">
                                <a href="/admin/schedule/upsert?id=${data}" class="btn btn-primary mx-2">
                                    <i class="bi bi-pencil-square"></i> Edit</a>`;

                            if (isAdmin) {
                                buttons += `<a onClick=Delete('/admin/schedule/delete/${data}') class="btn btn-danger mx-2">
                                    <i class="bi bi-trash-fill"></i> Delete</a>`;
                            }

                            buttons += `</div>`;
                            return buttons;
                        },
                        "width": "25%"
                    }
                ]
            });
        },
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
                        dataTable.ajax.reload(); // Reload table without resetting paging
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr) {
                    console.error("Error:", xhr.responseText);
                    toastr.error("An unexpected error occurred.");
                }
            });
        }
    });
}
