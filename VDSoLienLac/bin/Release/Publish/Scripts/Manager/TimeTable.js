var CalendarTitle, Calendar, CalendarStart, CalendarEnd;
var CurrentDate = new Date().toJSON().slice(0, 10);
var TableTimeValue = [];
var Url = "/api/subject/gettimetablebystudent";
callAjax(Url, null, function (data) {
    if (data.result > 0) {
        for (var i = 0; i < data.response_data.length; i++) {
            Calendar = dateFormat(data.response_data[i].date, "yyyy-mm-dd");
            CalendarTitle = String.format(`Môn: {0}
                                           Phòng: {1}
                                           Giáo Viên: {2}
                                           Tiết: {3}
                                           `,data.response_data[i].subject_name
                                            ,data.response_data[i].room
                                            ,data.response_data[i].teacher_name
                                            ,data.response_data[i].lesson_number);
            switch (data.response_data[i].session) {
                case "Sáng":
                    CalendarStart = String.format(`{0}T{1}`, Calendar, "07:30:00");
                    CalendarEnd = String.format(`{0}T{1}`, Calendar, "11:30:00");
                    break;
                case "Chiều":
                    CalendarStart = String.format(`{0}T{1}`, Calendar, "13:30:00");
                    CalendarEnd = String.format(`{0}T{1}`, Calendar, "17:30:00");
                    break;
                default:
            }
            TableTimeValue.push({ "title": CalendarTitle, "start": CalendarStart, "end": CalendarEnd });
        }

        var calendarEl = document.getElementById('calendar');
        var calendar = new FullCalendar.Calendar(calendarEl, {
            plugins: ['list'],
            timeZone: 'Asia/Ho_Chi_Minh',
            locale: 'vn',
            header: {
                left: 'prev,next',
                center: 'title',
                right: 'listDay,listWeek'
            },
            views: {
                listDay: { buttonText: 'Ngày' },
                listWeek: { buttonText: 'Tuần' }
            },     
            defaultView: 'listWeek',
            defaultDate: CurrentDate,

            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: TableTimeValue
        });
        calendar.render();
    }
}, 1);



function weeksBetween(d1, d2) {
    return Math.round((d2 - d1) / (7 * 24 * 60 * 60 * 1000));
}
