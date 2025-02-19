var dtable;

    dtable = $('#test').DataTable({

        "ajax": { "url": "/Accounts/GetAllUsers" },
        "columns": [
            { "data": "id" },
            { "data": "username" },
            { "data": "email" }
            { "data": "passwordhash" },
        ],
    });

