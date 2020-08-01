$("#simpleSelect2").select2({
    placeholder: "Select a Static Value",
    theme: "bootstrap4",
    allowClear: true
});

$("#ajaxSelect2").select2({
    placeholder: "Select a Value from API Data",
    theme: "bootstrap4",
    allowClear: true,
    ajax: {
        url: "/api/customer/search",
        contentType: "application/json; charset=utf-8",
        data: function (params) {
            var query =
            {
                term: params.term,
            };
            return query;
        },
        processResults: function (result) {
            return {
                results: $.map(result, function (item) {
                    return {
                        id: item.id,
                        text: item.firstName + ' ' + item.lastName,
                        city: item.city
                    };
                }),
            };
        }
    }
});

$("#ajaxMultiSelect2").select2({
    placeholder: "Select Multiple Value from API Data",
    theme: "bootstrap4",
    allowClear: true,
    ajax: {
        url: "/api/customer/search",
        contentType: "application/json; charset=utf-8",
        data: function (params) {
            var query =
            {
                term: params.term,
            };
            return query;
        },
        processResults: function (result) {
            return {
                results: $.map(result, function (item) {
                    return {
                        id: item.id,
                        text: item.firstName + ' ' + item.lastName,
                        city: item.city
                    };
                }),
            };
        }
    }
});

$("#ajaxMultiSelect2HTML").select2({
    placeholder: "HTML Content with Image",
    theme: "bootstrap4",
    allowClear: true,
    ajax: {
        url: "/api/customer/search",
        contentType: "application/json; charset=utf-8",
        data: function (params) {
            var query =
            {
                term: params.term,
            };
            return query;
        },
        processResults: function (result) {
            return {
                results: $.map(result, function (item) {
                    return {
                        id: item.id,
                        text: item.firstName + ' ' + item.lastName,
                        html: '<div style="display:flex;"><div><img src="data:image/png;base64, ' + item.photo + '" alt="" style="height:70px;width:70px;object-fit:cover;" class="img-rounded img-responsive" /></div><div style="padding:10px" ><div style="font-size: 1.2em">' + item.firstName + ' ' + item.lastName + '</div><div>from <b>' + item.city + '</b></div></div></div >',
                    };
                }),
            };
        }
    },

    templateResult: template,
    escapeMarkup: function (m) {
        return m;
    }
});

function template(data) {
    return data.html;
};

document.getElementById('submitButton').addEventListener('click', function () {
    let result;
    result = $("#ajaxMultiSelect2HTML").select2("data")[0];
    var id = result.id;
    alert("Select Id is " + id);
});