var dtable;
$(document).ready(function () {
    dtable = $('#tasksTable').DataTable({

        "ajax": { "url": "/Tasks/AllTasks" },
        "columns": [
            { "data": "id" },
            { "data": "title" },
            { "data": "description" },
            { "data": "status" },
            { "data": "createdAt" },
            { "data": "dueDate" },

        ],
        "render": function (data)
        {
            return `<a href="/Tasks/CreateUpdate?id=${data}"><i class="bi bi-pencil-square"></i></a>
                        <a onclick=RemoveTask("/Products/Delete/${data}")><i class="bi bi-trash"></i></a>`
        }
    });
});
