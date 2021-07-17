function createCookie(cookieName, cookieValue, daysToExpire) {
    var date = new Date();
    date.setTime(date.getTime() + (daysToExpire * 24 * 60 * 60 * 1000));
    document.cookie = cookieName + "=" + cookieValue + "; expires=" + date.toGMTString()
}

function getCookie (name) {
    var match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'))
    if (match) return match[2]
}

class Areas {

}

class UtilsHttps {

    address = "https://localhost:44348/Areas/"

    mountDefaultContentType = function() {
        return "application/json; charset=utf-8"
    }

    mountBearerTokenRequisition = function(xhr) {
        xhr.setRequestHeader('Authorization', 'Bearer ' + getCookie("__jwt"))
    }
}

let utilsHttps = new UtilsHttps()

let areas = new Areas()
