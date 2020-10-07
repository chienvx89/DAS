var CategoryConfig = {
    InitIndexGrid: function () {
        $("#index_gird").DataTable();
    },

    GetUsers: function () {
        let someData = "";
        let dataType = "html";
        let url = "/users/gets";
        let ssCallback = function (data) {
            $("#ContentArea").html(data)
        }
        CustAjaxCall("", someData, url, dataType, ssCallback);
    },
    DeleteUser: function () {
        $(".DeleteUser").click(function () {
            let userId = $(this).attr("data-id");
            CommonJs.ShowConfirmMsg('Bạn có chắc chắn muốn xóa người dùng này?'
                , 'Bạn không thể phục hồi dữ liệu đã xóa'
                , 'Xóa'
                , function () {
                    let someData = {};
                    let method = "POST";
                    let url = "/Users/Delete/" + userId;
                    let ssCallBack = function (res) {
                        if (typeof res === "object" && typeof res.type !== undefined) {
                            if (res.type === "Success") {
                                CommonJs.ShowNotifyMsg(SwalMsgType.success, res.message);
                                setTimeout(function () {
                                    window.location.reload();
                                }, 3000);
                            }
                            else if (res.Type === "Error")
                                CommonJs.ShowNotifyMsg(SwalMsgType.error, res.message);
                            else if (res.Type === "Warning")
                                CommonJs.ShowNotifyMsg(SwalMsgType.warning, res.message);
                        }
                    };
                    CommonJs.CustAjaxCall(someData, method, url, "json", ssCallBack, "");
                });
            return false;
        })
    },
};

var InitCategory = function () {
    //UsersConfig.DeleteUser();
    CategoryConfig.InitIndexGrid();
}