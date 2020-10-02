"use strict"
//todo js
const SwalMsgType = {
    success: 'success',
    error: 'error',
    warning: 'warning',
    info: 'info',
    question: 'question',
};

var CommonJs = {
    CustAjaxCall: function (someData, method, url, datatype, ssCallBack, errCallback) {
        $.ajax({
            data: someData,
            method: method,
            dataType: datatype,//'json'
            url: url//'/controller/action/'
        }).done(function (data) {
            // If successful
            if (typeof (ssCallBack) === "function")
                ssCallBack(data);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            // If fail
            alert(textStatus + ': ' + errorThrown);
            if (typeof (errCallback) === "function")
                errCallback();
        });
    },
    ShowModalExtra: function () {
        $("#modal-xl").modal('show');
    },

    ShowModalSm: function () {
        $("#modal-sm").modal('show');
    },
    //https://sweetalert2.github.io/
    ShowNotifyMsg: function (msgType, msgContent) {
        switch (msgType) {
            case 'success':
                Swal.fire({
                    icon: 'success',
                    position: 'top-center',
                    showConfirmButton: false,
                    title: msgContent,
                    showConfirmButton: false,
                    // timer: 1500
                });
                break;
            case 'error':
                Swal.fire({
                    icon: 'error',
                    position: 'top-center',
                    showConfirmButton: false,
                    title: msgContent,
                    showConfirmButton: false,
                    // timer: 1500
                });
                break;
            case 'warning':
                Swal.fire({
                    icon: 'warning',
                    position: 'top-center',
                    showConfirmButton: false,
                    title: msgContent,
                    showConfirmButton: false,
                    // timer: 1500
                });
                break;
            case 'info':
                Swal.fire({
                    icon: 'info',
                    position: 'top-center',
                    showConfirmButton: false,
                    title: msgContent,
                    showConfirmButton: false,
                    // timer: 1500
                });
                break;
            case 'question':
                Swal.fire({
                    icon: 'question',
                    position: 'top-center',
                    showConfirmButton: false,
                    title: msgContent,
                    showConfirmButton: false,
                    // timer: 1500
                });
                break;
            default:
                break
        };
        return false;
    },
    ShowConfirmMsg: function (title, text, textConfirmButtn, callbackFunc) {
        Swal.fire({
            title: title,
            text: text,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: textConfirmButtn,
        }).then((res) => {
            if (res.value) {
                if (typeof (callbackFunc) === "function") {
                    callbackFunc();
                }
            }
        })
    },
    QuickSubmitJS: function () {
        $(".QuickSubmitJS").click(function () {
            let self = $(this);
            let form = self.closest("form");
            let data = CommonJs.GetSerialize(form);
            let url = self.attr("data-url");
            let dataType = "json"
            let isReload = self.attr("isReloadAfterSubmit") !== "false";
            let ssCallBack = function (res) {
                if (typeof res === "object" && typeof res.type !== undefined) {
                    if (res.type === "Success") {
                        if (isReload) {
                            setTimeout(function () {
                                window.location.reload();
                            }, 3000);
                        }
                        CommonJs.ShowNotifyMsg(SwalMsgType.success, res.message);
                    }
                    else if (res.type === "Error")
                        CommonJs.ShowNotifyMsg(SwalMsgType.error, res.message);
                    else if (res.type === "Warning")
                        CommonJs.ShowNotifyMsg(SwalMsgType.warning, res.message);
                }
            }

            //todo : handle with errCallback
            let errCallback = function () {
                return false;
            }

            CommonJs.CustAjaxCall(data, "POST", url, dataType, ssCallBack, errCallback);
            return false;
        });
    },
    QuickSubmitHTML: function () {
        $(".QuickSubmitHtml").click(function () {
            let self = $(this);
            let form = self.closest("form");
            let data = form.serializeArray();
            let nOb = {};
            for (let i in data) {
                if (!nOb.hasOwnProperty(data[i].name))
                    nOb[data[i].name] = "";
                nOb[data[i].name].push(data[i].value);
            }

            let url = self.attr("data-url");
            let dataType = "html"
            let dataTarget = self.attr("data-target");
            let ssCallBack = function (res) {
                $(dataTarget).html(res);
            }

            //todo : handle with errCallback
            let errCallback = function () {
                return;
            }

            CommonJs.CustAjaxCall(data, url, dataType, ssCallBack, errCallback);
        });
    },
    GetSerialize: function (form) {
        let data = form.serializeArray();
        let rs = {};
        for (let i in data) {
            if (!rs.hasOwnProperty(data[i].name))
                rs[data[i].name] = [];
            rs[data[i].name].push(data[i].value);
        }

        for (let i in rs) {
            if (rs[i].length === 1) {
                rs[i] = rs[i].join(",");
            }
            else {
                rs[i] = JSON.stringify(rs[i]);
            }
        }

        return rs;
    },


    GetSerialize2: function (form) {
        var rs = {};
        var keys = {};
        form.find("input, select, textarea,button").each(function () {
            let el = $(this);
            let name = el.prop("name");
            if (typeof name !== "string") {
                return;
            }
            let tagName = el.prop("tagName").toLowerCase();
            let type = el.prop("type").toLowerCase();
            switch (type) {
                case "text": case "password": case "hidden": case "number":
                    if (!rs.hasOwnProperty(name)) {
                        rs[name] = [];
                    }
                    rs[name].push(el.val());
                    return;
                case "checkbox": case "radio":
                    if (!rs.hasOwnProperty(name)) {
                        rs[name] = [];
                    }
                    if (el.prop("checked")) {
                        rs[name].push(el.val());
                    }
                default:
                    return;
            }

        });

        for (let i in rs) {
            if (rs[i].length === 1) {
                rs[i] = rs[i].join(",");
            }
            else {
                rs[i] = JSON.stringify(rs[i]);
            }
        }

        return rs;
    },

    ClearFormSimple(form) {
        $(form).find("input, select, textarea,button").each(function () {
            let el = $(this);

        });
    }

}

var InitCommonJs = function () {
    CommonJs.ShowNotifyMsg();
    CommonJs.QuickSubmitJS();
}