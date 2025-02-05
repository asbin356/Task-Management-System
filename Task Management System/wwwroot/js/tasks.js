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
    });
});
