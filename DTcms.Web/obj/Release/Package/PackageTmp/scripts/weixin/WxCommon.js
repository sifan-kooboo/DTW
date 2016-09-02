/****当被分享或直接访问时处理。PC端不可访问。手机端会带上openid****/
//if (WxCommon.Utils.getCookie("wxid_bzw315") == null || WxCommon.Utils.getCookie("wxid_bzw315") == "") {
//    $.ajax({
//        type: "post",
//        dataType: "json",
//        timeout: 30000,
//        async: false,
//        cache: false,
//        url: "/WxOperaCommon/GetWxid",
//        data: { code: WxCommon.Utils.getQuery('code'), state: WxCommon.Utils.getQuery('state'), wxid: WxCommon.Utils.getQuery('openid') },
//        success: function (result) {
//            if (result != null && result.success) {
//                if (WxCommon.Utils.getCookie('wxid_subscribe') != '1') {
//                    //弹出关注
//                    //layer.msg('您还未关注');
//                }
//            } else if (!result.success && result.message == "tourl") {
//                location.href = result.data;
//            }
//        }
//    });
//}

/***************如上结束***************/
if (!window.WxCommon)
    WxCommon = new Object();
WxCommon.Common = {
    sharelink: '',
    shareimg: '',
    sharetitle: '',
    sharedesc: '',
    isCustomShare: true,
    IshideOptionMenu:false,//隐藏右上角菜单选项
    GetJsConfig: function () {
        $.ajax({
            type: "post",
            dataType: "json",
            timeout: 30000,
            async: true,
            cache: false,
            url:$("#hidajaxurl").val() + "?action=weixin_getconfig&accountId=1",
            success: function (result) {
                if (result != null) {
                    WxCommon.Common.RegJsConfig(result.appId, result.timestamp, result.nonceStr, result.signature);
                }
            }
        });
    }//GetJsConfig
    , RegJsConfig: function (appId, timestamp, nonceStr, signature) {//注册微信脚本
        wx.config({
            debug: false,
            appId: appId,
            timestamp: timestamp,
            nonceStr: nonceStr,
            signature: signature,
            jsApiList: [
              'checkJsApi',
              'onMenuShareTimeline',
              'onMenuShareAppMessage',
              'onMenuShareQQ',
              'onMenuShareWeibo',
              'onMenuShareQZone',
              'hideMenuItems',
              'showMenuItems',
              'hideAllNonBaseMenuItem',
              'showAllNonBaseMenuItem',
              'translateVoice',
              'startRecord',
              'stopRecord',
              'onVoiceRecordEnd',
              'playVoice',
              'onVoicePlayEnd',
              'pauseVoice',
              'stopVoice',
              'uploadVoice',
              'downloadVoice',
              'chooseImage',
              'previewImage',
              'uploadImage',
              'downloadImage',
              'getNetworkType',
              'openLocation',
              'getLocation',
              'hideOptionMenu',
              'showOptionMenu',
              'closeWindow',
              'scanQRCode',
              'chooseWXPay',
              'openProductSpecificView',
              'addCard',
              'chooseCard',
              'openCard'
            ]
        });
        WxCommon.Common.InitWxReady();
    }//RegJsConfig
        , InitWxReady: function () {
            if (WxCommon.Common.sharelink == '')
                WxCommon.Common.sharelink = "";
            if (WxCommon.Common.shareimg == '')
                WxCommon.Common.shareimg = "http://" + document.domain + "/Themes/Mobile/WxCommon/images/share.png";
            if (WxCommon.Common.sharetitle == '')
                WxCommon.Common.sharetitle = '保障网微信活动';
            if (WxCommon.Common.sharedesc == '')
                WxCommon.Common.sharedesc = '保障网微信活动';
            wx.ready(function () {
                //校验是否支持jsapi
                /*
                wx.checkJsApi({
                    jsApiList: [
                      'getNetworkType',
                      'onMenuShareAppMessage'
                    ],
                    success: function (res) {
                        layer.msg(JSON.stringify(res));
                    }
                });
                */
                //};
                if (WxCommon.Common.isCustomShare) {
                    wx.onMenuShareAppMessage({
                        title: WxCommon.Common.sharetitle,
                        desc: WxCommon.Common.sharedesc,
                        link: WxCommon.Common.sharelink,
                        imgUrl: WxCommon.Common.shareimg,
                        trigger: function (res) {
                            // 不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回
                            //layer.msg('用户点击发送给朋友' + $("#hidVoteId").val() + "-");
                            //return false;
                        },
                        success: function (res) {
                            //layer.msg('已分享');
                           
                        },
                        cancel: function (res) {
                            //layer.msg('已取消');
                        },
                        fail: function (res) {
                            //layer.msg(JSON.stringify(res));
                        }
                    });

                    wx.onMenuShareTimeline({
                        title: WxCommon.Common.sharetitle,
                        desc: WxCommon.Common.sharedesc,
                        link: WxCommon.Common.sharelink,
                        imgUrl: WxCommon.Common.shareimg,
                        trigger: function (res) {
                            // 不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回
                            //layer.msg('用户点击分享到朋友圈');
                        },
                        success: function (res) {
                            //layer.msg('已分享');
                           
                        },
                        cancel: function (res) {
                            //layer.msg('已取消');
                        },
                        fail: function (res) {
                            //layer.msg(JSON.stringify(res));
                        }
                    });

                    wx.onMenuShareQQ({
                        title: WxCommon.Common.sharetitle,
                        desc: WxCommon.Common.sharedesc,
                        link: WxCommon.Common.sharelink,
                        imgUrl: WxCommon.Common.shareimg,
                        trigger: function (res) {
                            //layer.msg('用户点击分享到QQ');
                        },
                        complete: function (res) {
                            //layer.msg(JSON.stringify(res));
                        },
                        success: function (res) {
                            //layer.msg('已分享');
                            
                        },
                        cancel: function (res) {
                            //layer.msg('已取消');
                        },
                        fail: function (res) {
                            //layer.msg(JSON.stringify(res));
                        }
                    });
                }
                if (WxCommon.Common.IshideOptionMenu)
                    wx.hideOptionMenu();
                else
                    wx.showOptionMenu();
                //批量隐藏菜单
                wx.hideMenuItems({
                    menuList: [
                        'menuItem:share:qq',//分享到QQ
                        'menuItem:share:weiboApp',//分享到Weibo
                        'menuItem:share:facebook',//分享到FB
                        'menuItem:share:QZone',//分享到 QQ 空间
                        'menuItem:originPage',//原网页
                        'menuItem:openWithSafari',//在Safari中打开
                       // 'menuItem:share:email',//邮件
                      'menuItem:readMode', // 阅读模式
                      'menuItem:openWithQQBrowser', // 在QQ浏览器中打开
                     // 'menuItem:copyUrl' // 复制链接
                    ],
                    success: function (res) {
                        //layer.msg('已隐藏“阅读模式”，“分享到朋友圈”，“复制链接”等按钮');
                    },
                    fail: function (res) {
                        //layer.msg(JSON.stringify(res));
                    }
                });
                
            });
            wx.error(function (res) {
                //layer.msg(res.errMsg);
            });
        }//InitWxReady
    , IsFollow: function () {//是否关注
        $.ajax({

        });
    }//IsFollow
}