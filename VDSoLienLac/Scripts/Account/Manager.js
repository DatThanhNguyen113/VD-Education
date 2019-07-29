$(document).ready(function () {
    GetNotice();
    CheckSignInUser();
    GetUserInfo();
    DisplaySidebarActive();
    /// <summary>
    /// Hiệu ứng thu nhỏ và mở rộng khi bấm nút Sidebar
    /// </summary>
    /// <returns></returns>
    $('#sidebarCollapse').on('click', function () {
        $(this).toggleClass('active');
        $('#sidebar').toggleClass('active');
    });
});

function DisplaySidebarActive() {
    var NavbarUrl = (window.location.href).split('/');
    var ViewUrl = NavbarUrl[4];
    var ControllerUrl = NavbarUrl[3];
    var ActiveUrl = String.format(`/{0}/{1}`, ControllerUrl, ViewUrl);
    if (ActiveUrl !== "/") {
        $(`.list-unstyled li a[href="` + ActiveUrl + `"]`).addClass("active");
    } else {
        $(`.list-unstyled li a[href=""]`).addClass("active");
    }
}

$(window).on('load', function () {
    /// <summary>
    /// Hiệu ứng mở cửa khi đăng nhập thành công
    /// </summary>
    /// <returns></returns>
    setTimeout(function () {
        $('body').addClass('loaded');
    }, 200);
});

/// <summary>
/// Kiểm tra xác thực chuỗi Jwt khi đăng nhập
/// </summary>
/// <returns></returns>
function CheckSignInUser() {
    if (currentJwt === undefined || currentJwt === null || currentJwt === "") {
        window.location.href = "/Account/SignIn";
    }
}

/// <summary>
/// Lấy danh sách thông tin user
/// </summary>
/// <returns></returns>
function GetUserInfo() {
    var UrlService = "/api/accountservice/userinfo";
    var Params = JSON.stringify({
        'role_id': currentRole
    });
    callAjax(UrlService, Params, function (data) {
        if (parseInt(data.result) > 0) {
            var item = data.response_data[0];
            var UserFullName = String.format(`{0} {1}`, item.first_name, item.last_name);
            var UserGenderName = "";
            $('#first-name').html(item.first_name);
            $('#UserFirstName').val(item.first_name);
            $('#last-name').html(item.last_name);
            $('#UserLastName').val(item.last_name);
            $('#user-role').html(item.role);
            $('#UserCenter-Name').html(UserFullName);
            $('#UserDisplayBirthday').html(dateFormat(item.birth_date, "dd/mm/yyyy"));
            switch (item.gender_id) {
                case 0:
                    UserGenderName = "Nữ";
                    break;
                case 1:
                    UserGenderName = "Nam";
                    break;
                default:
                    UserGenderName = "Khác";
            }
            $('#UserDisplayGender').html(UserGenderName);
            $('#UserDisplayEmail').html(LimitStringLength(item.email, 10));
            $('#UserEmail').val(item.email);
            $('#UserDisplayAddress').html(LimitStringLength(item.address, 10));
            $('#UserAddress').val(item.address);
            $('#UserDisplayPhone').html(item.phone_number);
            $('#UserPhone').val(item.phone_number);
            $('#UserDisplayID').html(item.id_card_number);
            $('#UserNumberCard').val(item.id_card_number);
        }
    }, 1);
}

/// <summary>
/// Nhận danh sách thông báo
/// </summary>
/// <returns></returns>
function ReceiveNotifycation(NotifycationModel) {
    switch (NotifycationModel.type) {
        case 0:
            var NotificationTypeTitle = String.format(`
                                <a class="dropdown-item d-flex align-items-center" href="{0}">
                                <div class="mr-3">
                                    <div class="icon-circle bg-primary">
                                        <i class="fas fa-file-alt text-white"></i>
                                    </div>
                                </div>
                                <div>
                                    <div class="small text-gray-500">{1}</div>
                                    <span style="font-weight:500; line-height:normal">{2}</span>
                                </div>
                                 </a>
                                  `, NotifycationModel.path
                , NotifycationModel.create_date
                , NotifycationModel.subject);
            $('#Notification_ct').append(NotificationTypeTitle);
            break;
        case 1:
            var NotificationTypeManual = String.format(`<a class="dropdown-item d-flex align-items-center" href="{0}">
                                <div class="mr-3">
                                    <div class="icon-circle bg-warning">
                                        <i class="fas fa-exclamation-triangle text-white"></i>
                                    </div>
                                </div>
                                <div>
                                    <div class="small text-gray-500">{1}</div>
                                    <span style="font-weight:500; line-height:normal">{2}</span>
                                </div>
                            </a>`, NotifycationModel.path
                , NotifycationModel.create_date
                , NotifycationModel.subject);
            $('#Notification_cp').append(NotificationTypeManual);
            break;
        default:
            break;
    }
}

function GetNotice() {
    var Url = "/api/subject/getNotice";
    callAjax(Url, null, function (data) {
        var NotificationBell = "";
        var NotificationMail = "";
        if (parseInt(data.result) > 0) {
            for (var i = 0; i < data.response_data.length; i++) {             
                if (data.response_data[i].type === 0) {
                    NotificationBell += String.format(`<a class="dropdown-item d-flex align-items-center" href="{0}">
                                <div class="mr-3">
                                    <div class="icon-circle bg-primary">
                                        <i class="fas fa-file-alt text-white"></i>
                                    </div>
                                </div>
                                <div>
                                    <div class="small text-gray-500">{1}</div>
                                    <span style="font-weight:500; line-height:normal">{2}</span>
                                </div>
                                 </a>`, "/Home/PageTruant", dateFormat(data.response_data[i].create_date, "dd/mm/yyyy"), LimitStringLength(data.response_data[i].subject,35));
                } else if (data.response_data[i].type === 1) {
                    NotificationMail += String.format(`<a class="dropdown-item d-flex align-items-center" onclick="SetValueNotification({3});" href="{0}">
                                <div class="mr-3">
                                    <div class="icon-circle bg-primary">
                                        <i class="fas fa-file-alt text-white"></i>
                                    </div>
                                </div>
                                <div>
                                    <div class="small text-gray-500">{1}</div>
                                    <span style="font-weight:500; line-height:normal">{2}</span>
                                </div>
                                 </a>`, "/Home/ReceiveNotification", dateFormat(data.response_data[i].create_date,"dd/mm/yyyy"), LimitStringLength(data.response_data[i].subject, 35), data.response_data[i].id);
                }
            }
            $('#Notification_ct').html(NotificationBell);
            $('#Notifycation_cp').html(NotificationMail);
        }
    }, 1);
}

function SetValueNotification(params) {
    localStorage.setItem("TokenNotification", params);
}