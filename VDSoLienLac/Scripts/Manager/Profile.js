$(document).ready(function () {
    $("#frmUserPassword").validate({
        rules: {
            Password: {
                required: true,
                maxlength: 16,
                minlength: 6
            },
            NewPass: {
                required: true,
                maxlength: 16,
                minlength: 6
            },
            ConfirmPass: {
                required: true,
                maxlength: 16,
                minlength: 6,
                equalTo: "#new-password"
            }
        },
        messages: {
            Password: {
                required: '<i class="fas fa-exclamation-circle"></i> Vui lòng nhập vào mật khẩu hiện tại.',
                maxlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.',
                minlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.'
            },
            NewPass: {
                required: '<i class="fas fa-exclamation-circle"></i> Vui lòng nhập vào mật khẩu mới',
                maxlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.',
                minlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.'
            },
            ConfirmPass: {
                required: '<i class="fas fa-exclamation-circle"></i> Hãy nhập lại mật khẩu mới',
                maxlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.',
                minlength: '<i class="fas fa-exclamation-circle"></i> Mật khẩu phải bao gồm 6 đến 16 kí tự.'
            }
        }
    });

    $("#frmUserProfile").validate({
        rules: {
            UserFirstName: {
                required: true
            },
            UserLastName: {
                required: true
            },
            UserEmail: {
                required: true,
                email: true
            },
            UserBirthday: {
                required: true
            },
            UserAddress: {
                required: true
            },
            UserPhone: {
                required: true
            },
            UserNumberCard: {
                required: true
            }
        },
        messages: {
            UserFirstName: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            },
            UserLastName: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            },
            UserEmail: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.',
                email: '<i class="fas fa-exclamation-circle"></i> Bạn phải cung cấp một định dạng email.'
            },
            UserBirthday: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            },
            UserAddress: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            },
            UserPhone: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            },
            UserNumberCard: {
                required: '<i class="fas fa-exclamation-circle"></i> Đây là thông tin bắt buộc không được để trống.'
            }
        }
    });
});

$('#btnUpdateUser').on('click', function () {
    if ($('#frmUserProfile').valid()) {
        var Url = "/api/accountservice/userupdate";
        var Role = currentRole;
        var FirstName = $('#UserFirstName').val();
        var LastName = $('#UserLastName').val();
        var Email = $('#UserEmail').val();
        var Birthday = $('#UserBirthday').val();
        var Gender = $('input[name=Gender]:checked').val();
        var Address = $('#UserAddress').val();
        var Phone = $('#UserPhone').val();
        var UserNumberCard = $('#UserNumberCard').val();
        var Params = JSON.stringify({
            "role_id": Role,
            "first_name": FirstName,
            "last_name": LastName,
            "email": Email,
            "birth_date": Birthday,
            "gender_id": Gender,
            "address": Address,
            "phone_number": Phone,
            "id_card_number": UserNumberCard
        });
        callAjax(Url, Params, function (data) {
            if (parseInt(data.result) === 1) {
                $('#success').html("Thay đổi thông tin thành công...!");
                $('#modalSuccess').modal("show");
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            } else {
                $('#error').html("Thay đổi thông tin thất bại, vui lòng thử lại...!");
                $('#modalError').modal("show");
                setTimeout(function () {
                    $('#modalError').modal("hide");
                }, 2000);
            }
        }, 1);
    }
});

$('#btnLogin').on('click', function () {
    if ($('#frmUserPassword').valid()) {
        var Url = "/api/accountservice/changepassword";
        var CurrentPassword = $('#old-password').val();
        var NewPassword = $('#new-password').val();
        var Params = JSON.stringify({
            "password": CurrentPassword,
            "new_pass": NewPassword
        });
        callAjax(Url, Params, function (data) {
            if (parseInt(data.result) === 1) {
                $('#success').html("Thay đổi mật khẩu thành công...!");
                $('#modalSuccess').modal("show");
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            } else {
                $('#error').html("Thay đổi thất bại, vui lòng thử lại...!");
                $('#modalError').modal("show");
                setTimeout(function () {
                    $('#modalError').modal("hide");
                }, 2000);
            }
        }, 1);
    }
});



