function callAjax(urlService, param, callback, isAuthenticate, isLoading) {
    if (isAuthenticate === null) {
        isAuthenticate = 1;
    }
    if (isLoading === null) isLoading = 0;
    var headers = {};
    if (isAuthenticate === 1) {
        if (typeof currentJwt !== "undefined") {
            headers.Authorization = 'Bearer ' + currentJwt;
        }
        else {
            //window.location.href = "account/signin";
        }
    }

    if (isLoading === 1) {
        $('.loading-ajax').css('display', 'flex');
    }

    $.ajax({
        type: "POST",
        url: urlService,
        contentType: "application/json; charset=utf-8",
        data: param,
        dataType: "json",
        headers: headers,
        success: function (data) {
            callback(data);
            $('.loading-ajax').css('display', 'none');
        },
        failure: function (data) {
            $('.loading-ajax').css('display', 'none');
        },
        error: function (data) {
            $('.loading-ajax').css('display', 'none');
        }

    });
}

function LoadGridData(url, param, isAuthenticate, isLoading, fnCompleted) {
    if (isAuthenticate === null) isAuthenticate = 1;
    var headers = {};
    var Authorization = "";
    if (isLoading === null) isLoading = 0;
    if (isLoading === 1)
        $('.loading-grid').css('display', 'flex');
    if (isAuthenticate === 1) {
        var token = localStorage.getItem('tokenKey');
        if (token === null)
            window.location.href = "/Account/login";
        else {
            var obj = JSON.parse(token);
            if (token) {
                headers.Authorization = 'Bearer ' + obj.Token;
                Authorization = 'Bearer ' + obj.Token;
            }
        }
    }
    return {
        "type": "POST",
        "url": url,
        "contentType": 'application/json; charset=utf-8',
        "headers": headers,
        'beforeSend': function (request) {
            request.setRequestHeader("Authorization", Authorization);
        },
        "drawCallback": function (settings) {
            if (fnCompleted !== null) {
                fnCompleted(settings);
            }
        },
        "complete": function (json, type) {
            if (fnCompleted !== null) {
                fnCompleted(json.responseJSON);
            }
        },
        'data': function (data) {
            $('.loading-grid').css('display', 'none');
            if (param !== null)
                $.extend(data, param);
            return data = JSON.stringify(data);
        },
        'error': function (jqXHR, exception) {
            $('.loading-ajax').css('display', 'none');
            if (jqXHR.status === 401) {
                logout();
            }
        }
    };
}

function validateCookie() {
    var mCookie = getCookie('tokenKey');
    var mLocalStore = localStorage.getItem('tokenKey');
    if (mCookie.length < 1 && mLocalStore.length < 1) {
        return false;
    }
    if (mCookie !== mLocalStore) {
        return false;
    }
    return true;
}

function ValidateAccess(mCookie) {
    mCookie = JSON.parse(mCookie);
    var mParams = JSON.stringify({ ID: mCookie.ID, Email: mCookie.Email, UserName: mCookie.Username, Token: mCookie.Token, SessionSignIn: mCookie.SessionSignIn });
    var ValAccess = $.ajax({
        url: "/api/Ex/v2/identity/DetectIdentity",
        method: "POST",
        contentType: "application/json",
        data: mParams
    });
    return ValAccess;
}
$(function () {
    InitNoticeHub();
})

function InitNoticeHub() {
    var notehub = $.connection.notify;
    if (typeof notehub !== "undefined") {

        notehub.client.broadcastSpecify = function (data) {
            debugger;
            ReceiveNotifycation(data);
            console.log('notice specify', data);
        }

        $.connection.hub.qs = { 'access_token': currentJwt };
        $.connection.hub.start().done(function () {
            notehub.server.addConnection(currentClass, $.connection.hub.id);
        });
    }
}

String.format = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];

    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }
    return theString;
};

function copyToClipboard(obj) {
    var copyText = document.getElementById(obj);
    copyText.select();
    document.execCommand("Copy");
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function copyToClickBoard(el) {
    // resolve the element
    el = document.getElementById(el);

    // handle iOS as a special case
    if (navigator.userAgent.match(/ipad|ipod|iphone/i)) {

        // save current contentEditable/readOnly status
        var editable = el.contentEditable;
        var readOnly = el.readOnly;

        // convert to editable with readonly to stop iOS keyboard opening
        el.contentEditable = true;
        el.readOnly = true;

        // create a selectable range
        var range = document.createRange();
        range.selectNodeContents(el);

        // select the range
        var selection = window.getSelection();
        selection.removeAllRanges();
        selection.addRange(range);
        el.setSelectionRange(0, 999999);

        // restore contentEditable/readOnly to original state
        el.contentEditable = editable;
        el.readOnly = readOnly;
    }
    else {
        el.select();
    }

    // execute copy command
    document.execCommand('copy');
}

function deleteCookie() {
    setCookie("tokenKey", -1, -1000);
}
function removeCookies() {
    var res = document.cookie;
    var multiple = res.split(";");
    for (var i = 0; i < multiple.length; i++) {
        var key = multiple[i].split("=");
        document.cookie = key[0] + " =; expires = Thu, 01 Jan 1970 00:00:00 UTC";
    }
}

/*This is the time format function in the form dd: MM: yyyy: HH: mm: ss TT
 Start Script
*/
var dateFormat = function () {
    var token = /d{1,4}|m{1,4}|yy(?:yy)?|([HhMsTt])\1?|[LloSZ]|"[^"]*"|'[^']*'/g,
        timezone = /\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,
        timezoneClip = /[^-+\dA-Z]/g,
        pad = function (val, len) {
            val = String(val);
            len = len || 2;
            while (val.length < len) val = "0" + val;
            return val;
        };

    return function (date, mask, utc) {
        var dF = dateFormat;

        if (arguments.length === 1 && Object.prototype.toString.call(date) === "[object String]" && !/\d/.test(date)) {
            mask = date;
            date = undefined;
        }

        date = date ? new Date(date) : new Date;
        if (isNaN(date)) throw SyntaxError("invalid date");

        mask = String(dF.masks[mask] || mask || dF.masks["default"]);

        if (mask.slice(0, 4) === "UTC:") {
            mask = mask.slice(4);
            utc = true;
        }

        var _ = utc ? "getUTC" : "get",
            d = date[_ + "Date"](),
            D = date[_ + "Day"](),
            m = date[_ + "Month"](),
            y = date[_ + "FullYear"](),
            H = date[_ + "Hours"](),
            M = date[_ + "Minutes"](),
            s = date[_ + "Seconds"](),
            L = date[_ + "Milliseconds"](),
            o = utc ? 0 : date.getTimezoneOffset(),
            flags = {
                d: d,
                dd: pad(d),
                ddd: dF.i18n.dayNames[D],
                dddd: dF.i18n.dayNames[D + 7],
                m: m + 1,
                mm: pad(m + 1),
                mmm: dF.i18n.monthNames[m],
                mmmm: dF.i18n.monthNames[m + 12],
                yy: String(y).slice(2),
                yyyy: y,
                h: H % 12 || 12,
                hh: pad(H % 12 || 12),
                H: H,
                HH: pad(H),
                M: M,
                MM: pad(M),
                s: s,
                ss: pad(s),
                l: pad(L, 3),
                L: pad(L > 99 ? Math.round(L / 10) : L),
                t: H < 12 ? "a" : "p",
                tt: H < 12 ? "am" : "pm",
                T: H < 12 ? "A" : "P",
                TT: H < 12 ? "AM" : "PM",
                Z: utc ? "UTC" : (String(date).match(timezone) || [""]).pop().replace(timezoneClip, ""),
                o: (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60) * 100 + Math.abs(o) % 60, 4),
                S: ["th", "st", "nd", "rd"][d % 10 > 3 ? 0 : (d % 100 - d % 10 !== 10) * d % 10]
            };

        return mask.replace(token, function ($0) {
            return $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
        });
    };
}();

dateFormat.masks = {
    "default": "ddd mmm dd yyyy HH:MM:ss",
    shortDate: "m/d/yy",
    mediumDate: "mmm d, yyyy",
    longDate: "mmmm d, yyyy",
    fullDate: "dddd, mmmm d, yyyy",
    shortTime: "h:MM TT",
    mediumTime: "h:MM:ss TT",
    longTime: "h:MM:ss TT Z",
    isoDate: "yyyy-mm-dd",
    isoTime: "HH:MM:ss",
    shortIsoTime: "HH:MM",
    isoDateTime: "yyyy-mm-dd'T'HH:MM:ss",
    isoUtcDateTime: "UTC:yyyy-mm-dd'T'HH:MM:ss'Z'"
};

dateFormat.i18n = {
    dayNames: [
        "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
        "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
    ],
    monthNames: [
        "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
        "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
    ]
};

Date.prototype.format = function (mask, utc) {
    return dateFormat(this, mask, utc);
};
/// <summary>
/// Kiểm tra và đặt giới hạn cho chuỗi
/// </summary>
/// <returns>Số lượng chuỗi nhiều hơn giới hạn sẽ chuyễn thành "..."</returns>
function LimitStringLength(Value, Limit) {
    var dots = "...";
    if (Value.length > Limit) {
        Value = Value.substring(0, Limit) + dots;
    }
    return Value;
}

function UIForMobile() {
    var width = 986;
    var WindowWidth = 0;
    $(window).on('resize', function () {
        WindowWidth = $(window).width();
        if (WindowWidth < width) {
            this.window.location.href = "/Account/DownloadForMobile";
        } else {
            this.window.location.href = "/Account/SignIn";
        }
        console.log(WindowWidth);
    });
}