

function LoginInCheck(evt) {
    if (evt.keyCode == 13) {
        var nUserID = $('#txtUserName').val();
        var nUserPas = $('#txtPassword').val();
        if (nUserID == '' || nUserPas == '') {
            $('#lError').html(LoginInputAlert); //請輸入賬號和密碼
            return false;
        }
        setTimeout('__doPostBack(\'LoginIn\',\'\')', 0);
    }
}
function CALogin() { //證書登錄

    var info;
    if (typeof (Signer) == "object") {
        //info = Signer.SignIn(SignInNew3);
        try {

            var IsVersion = Signer.CheckVersion("1,0,1");
            if (IsVersion == null) { return; }
            if (IsVersion < 1) {
                if (IsVersion == "-1") {
                    if (confirm("你還未安裝'SignGadget'軟件包，確認要安裝嗎?\r\n 請安裝后刷新該頁面！")) {
                        // $('#SignInstall').click();
                        window.location.href = "http://10.162.197.5/crm/Gonggao/SysNewsDetail.aspx?PKID=140226095611";
                    }
                }
                if (IsVersion == "0") {
                    if (confirm("偵測到'SignGadget'軟件包有新版本，確認要更新嗎?\r\n請更新后刷新該頁面！")) {
                        window.location.href = "http://10.162.197.5/crm/Gonggao/SysNewsDetail.aspx?PKID=140226095611";

                        // $('#SignInstall').click();
                    }
                }
            }
            else {
                try {
                    info = Signer.SignInNew3("", "FOXCONN CA");
                    if (info == null) { return; } 		//沒有選擇憑證
                    if (info == "Error") { return; } //憑證沒用通過FoxconnCA驗證
                    var o = new Object();
                    var datas = info.split('^');
                    for (var i = 0; i < datas.length; i++) {
                        if (datas[i].indexOf('CN=') >= 0) { o.CertName = datas[i].substring(datas[i].indexOf('CN=') + 3); } 				//憑證用戶名
                        if (datas[i].indexOf('E=') >= 0) {
                            o.Email = datas[i].substring(datas[i].indexOf('E=') + 2); 				//憑證用戶Email
                        }
                        // if (datas[i].indexOf('SN=') >= 0) { o.SerialNumber = datas[i].substring(datas[i].indexOf('SN=') + 3); } 			//憑證編號
                        //if (datas[i].indexOf('EffectiveDate=') >= 0) { o.EffectiveDate = datas[i].substring(datas[i].indexOf('EffectiveDate=') + 14); } //發放日期
                        //if (datas[i].indexOf('ExpirationDate=') >= 0) { o.ExpirationDate = datas[i].substring(datas[i].indexOf('ExpirationDate=') + 15); } //有效期到
                        //if (datas[i].indexOf('Thumbprint=') >= 0) { o.Thumbprint = datas[i].substring(datas[i].indexOf('Thumbprint=') + 11); } 	//憑證指紋
                        //if (datas[i].indexOf('PublicKey=') >= 0) { o.PublicKey = datas[i].substring(datas[i].indexOf('PublicKey=') + 10); } 		//憑證公鑰
                    }
                    $('#HidUsername').val(o.CertName);
                    $('#HidEmail').val(o.Email);
                    document.getElementById("Button1").click();
                }
                catch (e) {
                }
            }
        } catch (e) {
            if (confirm("你還未安裝'SignGadget'軟件包，確認要安裝嗎?\r\n請更新后刷新該頁面！")) {
                // $('#SignInstall').click();
                window.location.href = "http://10.162.197.5/crm/Gonggao/SysNewsDetail.aspx?PKID=140226095611";
            }
        }
    }
}

function eSignTest() {
    var info;
    if (typeof (Signer) == "object") {
        //        var date1 = new Date();
        //        var result = Signer.SignFile("merge.pdf^merge2.pdf", "Signature1", "NNR1400043", "0");
        //        var date2 = new Date();
        //        var haomiao = date2.getTime() - date1.getTime();
        //        alert(haomiao);

        try {
            var date3 = new Date();

            //            var result = Signer.SignByName("merge.pdf,merge2.pdf,merge3.pdf", "Signature1,Signature1,Signature1", "NNFileManage\\NNR\\NNR1400043", "")
            var result = Signer.SignByName("ExpenseTemplate6.pdf", "form1[0].pagejj[0].Table1[0].Row21[0].sign1[0]", "JJEEAFile", "")

            if (result == "true") {
                var info2 = Signer.SignSuccessfulList;
                info2.split(",")

                var ResultList = info2.split(";");
                var ReturnFile = [];
                for (var i = 0; i < ResultList.length - 1; i++) {
                    var mFileInfo = ResultList[i].split(",");
                    ReturnFile.push(mFileInfo[2]);
                }
                var allFileName = ReturnFile.join("^");
                alert(allFileName);

                //修改數據庫中該文件名
            }

            // var result = Signer.SignByName("merge.pdf^merge2.pdf", "Signature1", "NNR", "")
            //  var result = Signer.SignByName("bigMerge.pdf,bigMerge2.pdf,bigMerge3.pdf,bigMerge4.pdf,bigMerge5.pdf,bigMerge6.pdf", "Signature1,Signature1,Signature1,Signature1,Signature1,Signature1", "NNR\\NNR1400043", "0", "")
            // var result = Signer.SignByName("merge.pdf,merge2.pdf", "Signature1,Signature1", "NNR\\NNR1400043", "")


        } catch (e) {
            alert(e);
        }
    }
}
