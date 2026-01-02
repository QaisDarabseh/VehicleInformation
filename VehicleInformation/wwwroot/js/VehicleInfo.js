$(document).ready(function () {

    // Select2
    $('#makeSelect').select2({
        placeholder: 'Select or search a car make',
        allowClear: true,
        width: '100%'
    });

    // DataTable
    const modelsTable = $('#modelsTable').DataTable({
        pageLength: 10,
        lengthChange: true,
        searching: false,
        ordering: true,
        language: {
            emptyTable: "No models found"
        }
    });

    // Search button
    $('#VehicleSearch').on('click', function () {
        GetVehicleTypes();
        GetVehicleModels();
    });

    function GetVehicleTypes() {
        const makeId = $('#makeSelect').val();
        const container = $('#VehicleTypes');
        container.empty();

        if (!makeId) {
            container.html('<span class="text-muted">Please select a car make</span>');
            return;
        }

        $.get('/Home/GetVehicleTypes', { makeId }, function (data) {
            if (data.length === 0) {
                container.html('<span class="text-muted">No vehicle types found</span>');
                return;
            }

            data.forEach(type => {
                container.append(`
                    <span class="badge bg-success px-3 py-2">
                        ${type.vehicleTypeName}
                    </span>
                `);
            });
        });
    }

    function GetVehicleModels() {
        const makeId = $('#makeSelect').val();
        const year = parseInt($('#yearInput').val());

        if (!makeId || !year) return;

        if (year < 1980 || year > new Date().getFullYear()) {
            alert('Please enter a valid year');
            return;
        }

        $.get('/Home/GetModels', { makeId, year }, function (data) {
            modelsTable.clear();

            data.forEach(model => {
                modelsTable.row.add([
                    model.Make_Name,
                    model.Model_Name
                ]);
            });

            modelsTable.draw();
        });
    }
});
