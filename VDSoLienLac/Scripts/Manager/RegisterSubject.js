$(document).ready(function () {
    GetOpenSubject();
    GetClockSubject();
    var headers = {};
    headers.Authorization = 'Bearer ' + currentJwt;

    $('#ListLockSubject').DataTable({
        ajax: {
            url: '/api/subject/getregistedsubject',
            method: 'POST',
            headers: headers,
            dataSrc: 'response_data'
        },
        columns: [
            { data: 'Code' },
            { data: 'Name' },
            { data: 'TheoryCredit' },
            { data: 'PracticeCredit' },
            { data: 'TotalCredits' },
            { data: 'TeacherName' }
        ]
    });
});

/// <summary>
/// Lấy danh sách các môn học mà sinh viên có thể đăng ký
/// </summary>
/// <returns></returns>
function GetOpenSubject() {
    var Url = "/api/subject/getsubjectregister";
    callAjax(Url, null, function (data) {
        var Subject = "";
        for (var i = 0; i < data.response_data.length; i++) {
            Subject += String.format(`
                <tr>
                <td>{0}</td>
                <td>{1}</td>
                <td>{2}</td>
                <td>{3}</td>
                <td>{4}</td>
                <td>{5}</td>
                <td class="text-center"><button class="btn" onclick="RegisterSubject({6});">
                <svg width="25" height="25" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
                <polygon style="fill:#FFFFFF;" points="478.609,144.696 478.609,111.304 411.826,111.304 411.826,144.696 378.435,144.696 378.435,0 378.435,0 378.435,0 0,0 0,0 0,0 0,512 378.435,512 378.435,311.652 411.826,311.652 411.826,278.261 445.217,278.261 445.217,244.87 478.609,244.87 478.609,211.478 512,211.478 512,144.696 "></polygon>
                <polygon style="fill:#FFDAAA;" points="478.609,144.696 478.609,111.304 411.826,111.304 411.826,144.696 378.435,144.696 378.435,178.087 345.043,178.087 345.043,211.478 311.652,211.478 311.652,244.87 278.261,244.87 278.261,278.261 244.87,278.261 244.87,311.652 211.478,311.652 211.478,345.043 178.087,345.043 178.087,445.217 278.261,445.217 278.261,411.826 311.652,411.826 311.652,378.435 345.043,378.435 345.043,345.043 378.435,345.043 378.435,311.652 411.826,311.652 411.826,278.261 445.217,278.261 445.217,244.87 478.609,244.87 478.609,211.478 512,211.478 512,144.696 "></polygon>
                <polygon style="fill:#FF9811;" points="478.609,144.696 478.609,111.304 411.826,111.304 411.826,144.696 378.435,144.696 378.435,178.087 345.043,178.087 345.043,211.478 311.652,211.478 311.652,244.87 278.261,244.87 278.261,278.261 244.87,278.261 244.87,311.652 211.478,311.652 211.478,345.043 244.87,345.043 244.87,378.435 278.261,378.435 278.261,411.826 311.652,411.826 311.652,378.435 345.043,378.435 345.043,345.043 378.435,345.043 378.435,311.652 411.826,311.652 411.826,278.261 445.217,278.261 445.217,244.87 478.609,244.87 478.609,211.478 512,211.478 512,144.696 "></polygon>
                <polygon style="fill:#FFFFFF;" points="478.609,144.696 478.609,111.304 411.826,111.304 411.826,178.087 445.217,178.087 445.217,211.478 512,211.478 512,144.696 "></polygon>
                <polygon points="378.435,311.652 345.043,311.652 345.043,345.043 311.652,345.043 311.652,378.435 345.043,378.435 345.043,478.609 33.391,478.609 33.391,33.391 345.043,33.391 345.043,211.478 311.652,211.478 311.652,244.87 345.043,244.87 345.043,211.478 378.435,211.478 378.435,211.478 378.435,211.478 378.435,178.087 411.826,178.087 411.826,144.696 378.435,144.696 378.435,0 378.435,0 378.435,0 0,0 0,0 0,0 0,512 378.435,512 378.435,311.652 "></polygon>
                <rect x="77.913" y="77.913" width="222.609" height="33.391"></rect>
                <rect x="77.913" y="155.826" width="222.609" height="33.391"></rect>
                <rect x="378.435" y="278.261" width="33.391" height="33.391"></rect>
                <rect x="411.826" y="244.87" width="33.391" height="33.391"></rect>
                <rect x="445.217" y="211.478" width="33.391" height="33.391"></rect>
                <rect x="478.609" y="144.696" width="33.391" height="66.783"></rect>
                <rect x="211.478" y="311.652" width="33.391" height="33.391"></rect>
                <rect x="244.87" y="278.261" width="33.391" height="33.391"></rect>
                <rect x="278.261" y="244.87" width="33.391" height="33.391"></rect>
                <rect x="411.826" y="111.304" width="66.783" height="33.391"></rect>
                <polygon points="178.087,411.826 77.913,411.826 77.913,445.217 278.261,445.217 278.261,411.826 311.652,411.826 311.652,378.435 278.261,378.435 278.261,411.826 211.478,411.826 211.478,345.043 178.087,345.043 "></polygon>
                </svg>
                </button></td>
                </tr>`, data.response_data[i].code, data.response_data[i].name, data.response_data[i].theory_credit, data.response_data[i].practice_credit, data.response_data[i].total_credits, data.response_data[i].teacher_name, data.response_data[i].master_timetable_id);
        }

        $('#ListOpenSubject tbody').html(Subject);
    }, 1);
}

function RegisterSubject(params) {
    var Url = "/api/subject/registsubject";
    var Params = JSON.stringify({
        "master_timetable_id": params
    });

    callAjax(Url, Params, function (data) {
        if (parseInt(data.result) === 1) {
            $('#success').html("Đăng ký môn học thành công...!");
            $('#modalSuccess').modal("show");
            setTimeout(function () {
                window.location.reload();
            }, 3000);
        } else {
            $('#error').html("Đăng ký thất bại, vui lòng thử lại...!");
            $('#modalError').modal("show");
            setTimeout(function () {
                $('#modalError').modal("hide");
            }, 2000);
        }
    }, 1);
}

function GetClockSubject() {
    var Url = "/api/subject/getregistedsubject";
    callAjax(Url, null, function () {

    }, 1);
}