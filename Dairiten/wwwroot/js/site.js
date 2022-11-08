// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { event } = require("jquery");

//import { Modal } from "../lib/bootstrap/dist/js/bootstrap.bundle";

// Write your JavaScript code.

/*商品区分ラジオボタン（申込入力画面）*/
function shohinKbnBtnClick() {
    let btnJutaku = document.getElementById("shohinKbnRadio1");
    let jutakuForm = document.getElementById("jutaku-form");
    let jigyoForm = document.getElementById("jigyo-form");
    let jutakuForm2 = document.getElementById("jutaku-form2");
    let jigyoForm2 = document.getElementById("jigyo-form2");
    if (btnJutaku.checked) {
        jigyoForm.style.display = "none";
        jigyoForm2.style.display = "none";
        jutakuForm.style.display = "";
        jutakuForm2.style.display = "";
    } else {
        jigyoForm.style.display = "";
        jigyoForm2.style.display = "";
        jutakuForm.style.display = "none";
        jutakuForm2.style.display = "none";
    }
}

/*(住宅用)契約者区分ラジオボタン（申込入力画面）*/
function keiyakushaKbnBtnClick() {
    let btnKojin = document.getElementById("keiyakushaKbnRadio1");
    let btnHojin = document.getElementById("keiyakushaKbnRadio2");
    let btnKojinJigyonushi = document.getElementById("keiyakushaKbnRadio3");
    let ju_KojinForm = document.getElementById("jutaku_kojin");
    let ju_HojinForm = document.getElementById("jutaku_hojin");
    let ju_Hojin2Form = document.getElementById("jutaku_hojin2");
    let ju_KojinJigyonushiForm = document.getElementById("jutaku_kojinjigyonushi");
    if (btnKojin.checked) {
        ju_KojinForm.style.display = "";
        ju_HojinForm.style.display = "none";
        ju_Hojin2Form.style.display = "none";
        ju_KojinJigyonushiForm.style.display = "none";
    }
    if (btnHojin.checked) {
        ju_KojinForm.style.display = "none";
        ju_HojinForm.style.display = "";
        ju_Hojin2Form.style.display = "";
        ju_KojinJigyonushiForm.style.display = "none";
    }
    if (btnKojinJigyonushi.checked) {
        ju_KojinForm.style.display = "none";
        ju_HojinForm.style.display = "none";
        ju_Hojin2Form.style.display = "";
        ju_KojinJigyonushiForm.style.display = "";
    }
}

/*(事業用)契約者区分ラジオボタン（申込入力画面）*/
function ji_keiyakushaKbnBtnClick() {
    let btnHojin = document.getElementById("ji_keiyakushaKbnRadio2");
    let btnKojinJigyonushi = document.getElementById("ji_keiyakushaKbnRadio3");
    let ji_HojinForm = document.getElementById("jigyo_hojin");
    let ji_KojinJigyonushiForm = document.getElementById("jigyo_kojinjigyonushi");
    if (btnHojin.checked) {
        ji_HojinForm.style.display = "";
        ji_KojinJigyonushiForm.style.display = "none";
    }
    if (btnKojinJigyonushi.checked) {
        ji_HojinForm.style.display = "none";
        ji_KojinJigyonushiForm.style.display = "";
    }
}

/*(住宅用)告知事項等ラジオボタン（申込入力画面）*/
function other_hokenBtnClick() {
    let btnNO = document.getElementById("other_hokenRadio1");
    let otherHokenForm = document.getElementById("other_hoken-form");
    if (btnNO.checked) {
        otherHokenForm.style.display = "none";
    } else {
        otherHokenForm.style.display = "";
    }
}

/*(事業用)告知事項等ラジオボタン（申込入力画面）*/
function ji_other_hokenBtnClick() {
    let btnNO = document.getElementById("ji_other_hokenRadio1");
    let otherHokenForm = document.getElementById("ji_other_hoken-form");
    if (btnNO.checked) {
        otherHokenForm.style.display = "none";
    } else {
        otherHokenForm.style.display = "";
    }
}

/* クリア処理1/3 */
function clearFormAll() {
    for (var i = 0; i < document.forms.length; ++i) {
        clearForm(document.forms[i]);
    }
}
/* クリア処理2/3 */
function clearForm(form) {
    for (var i = 0; i < form.elements.length; ++i) {
        clearElement(form.elements[i]);
    }
}
/* クリア処理3/3 */
function clearElement(element) {
    switch (element.type) {
        case "hidden":
        case "submit":
        case "reset":
        case "button":
        case "image":
            return;
        case "file":
            return;
        case "text":
        case "password":
        case "textarea":
        case "tel":
        case "date":
            element.value = "";
            return;
        case "checkbox":
        case "radio":
            element.checked = false;
            return;
        case "select-one":
        case "select-multiple":
            element.selectedIndex = 0;
            return;
        default:
    }
}

/* DataTables */
//$.extend($.fn.dataTable.defaults, {
//    // 日本語化
//    language: {
//        url: "http://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Japanese.json"
//    }
//});
$("#mytable").DataTable({    
    lengthMenu: [10, 20, 30, 40, 50, 100],    // 件数切替の値を10～50の10刻みにする
    displayLength: 20,  // 件数のデフォルトの値を20にする
    //scrollX: true,
    //scrollY: 200,
    //columnDefs: [
    //    { targets: 0, visible: false },
    //    { targets: 1, width: 100 }
    //]);
    processing: true,
    language: {
        "processing": "処理中...",
        "lengthMenu": "_MENU_ 件表示",
        "zeroRecords": "データはありません。",
        "info": " _TOTAL_ 件中 _START_ - _END_ 件目",
        "infoEmpty": " 0 件中 0 - 0 件目",
        "infoFiltered": "（全 _MAX_ 件より抽出）",
        "infoPostFix": "",
        "search": "検索:",
        "url": "",
        "paginate": {
            "first": "<<",
            "previous": "前",
            "next": "次",
            "last": ">>"
        }
    },
    //"columns": [//列の幅を変更する
    //    { "width": "10%" },//1列目
    //    { "width": "70%" },//2列目
    //],
    fixedHeader: true,//テーブルヘッダーを固定
    stateSave: true,//保持機能を有効にする
    searching: true, // falseにすると独自の検索も反映されない
    bProcessing: true,//ソート処理などの処理中を表すインジケータの表示有無
    //scrollY: false,//Y方向（縦方向）スクロール
    //ordering: false, //並び替え許可
    //dom: "<'row'<'col-sm-6'l><'col-sm-6 right'i>>" +
    //    "<'row'<'col-sm-12'tr>>" +
    //    "<'row'<'col-sm-12'p>>",
});

/*全角→半角（カタカナ）*/
function toHankakuKana(elm, id) {
    var beforeStr = new Array('ァ', 'ィ', 'ゥ', 'ェ', 'ォ', 'ャ', 'ュ', 'ョ', 'ッ', 'ー', 'ヴ', 'ガ', 'ギ', 'グ', 'ゲ', 'ゴ', 'ザ', 'ジ', 'ズ', 'ゼ', 'ゾ', 'ダ', 'ヂ', 'ヅ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ', 'ア', 'イ', 'ウ', 'エ', 'オ', 'カ', 'キ', 'ク', 'ケ', 'コ', 'サ', 'シ', 'ス', 'セ', 'ソ', 'タ', 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ', 'ハ', 'ヒ', 'フ', 'ヘ', 'ホ', 'マ', 'ミ', 'ム', 'メ', 'モ', 'ヤ', 'ユ', 'ヨ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ワ', 'ヲ', 'ン');
    var afterStr = new Array('ｧ', 'ｨ', 'ｩ', 'ｪ', 'ｫ', 'ｬ', 'ｭ', 'ｮ', 'ｯ', 'ｰ', 'ｳﾞ', 'ｶﾞ', 'ｷﾞ', 'ｸﾞ', 'ｹﾞ', 'ｺﾞ', 'ｻﾞ', 'ｼﾞ', 'ｽﾞ', 'ｾﾞ', 'ｿﾞ', 'ﾀﾞ', 'ﾁﾞ', 'ﾂﾞ', 'ﾃﾞ', 'ﾄﾞ', 'ﾊﾞ', 'ﾋﾞ', 'ﾌﾞ', 'ﾍﾞ', 'ﾎﾞ', 'ﾊﾟ', 'ﾋﾟ', 'ﾌﾟ', 'ﾍﾟ', 'ﾎﾟ', 'ｱ', 'ｲ', 'ｳ', 'ｴ', 'ｵ', 'ｶ', 'ｷ', 'ｸ', 'ｹ', 'ｺ', 'ｻ', 'ｼ', 'ｽ', 'ｾ', 'ｿ', 'ﾀ', 'ﾁ', 'ﾂ', 'ﾃ', 'ﾄ', 'ﾅ', 'ﾆ', 'ﾇ', 'ﾈ', 'ﾉ', 'ﾊ', 'ﾋ', 'ﾌ', 'ﾍ', 'ﾎ', 'ﾏ', 'ﾐ', 'ﾑ', 'ﾒ', 'ﾓ', 'ﾔ', 'ﾕ', 'ﾖ', 'ﾗ', 'ﾘ', 'ﾙ', 'ﾚ', 'ﾛ', 'ﾜ', 'ｦ', 'ﾝ');
    var fullStr = elm.value;
    for (var i = 0; i < beforeStr.length; i++) {
        fullStr = fullStr.replace(new RegExp(beforeStr[i], 'g'), afterStr[i]);
    }
    document.getElementById(id).value = fullStr;
} 

/*保証人区分「その他」選択時（申込入力画面）*/
function hoshonin_kbnChange() {
    let txtHoshonin = document.getElementById("hoshonin_kbn_other");
    var selected = $("#hoshonin_kbn").children("option:selected");
    if (selected.text() == 'その他') {
        txtHoshonin.disabled = false;
    } else {
        txtHoshonin.disabled = true;
    }
}

/*(住宅用契約者)法人形態プルダウン選択時（申込入力画面）*/
function hojinkeitaiChange() {
    let btnHojinkeitai_mae = document.getElementById("hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("hojinkeitai_other");
    var selected = $("#hojinkeitai").children("option:selected");
    if (selected.text() == '') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.disabled = false;
    } else if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
    } else if (selected.text() != '') {
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
        } else if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_ushiro.value = selected.text();
        }
    }
}

/*(住宅用契約者)法人形態その他入力時（申込入力画面）*/
function hojinkeitai_otherChange() {
    let btnHojinkeitai_mae = document.getElementById("hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("hojinkeitai_other");
    if (btnHojinkeitai_mae.checked) {
        txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
    } else if (btnHojinkeitai_ushiro.checked) {
        txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
    }
}

/*(住宅用契約者)法人形態位置ラジオボタン（申込入力画面）*/
function hojinkeitai_ichiBtnClick() {
    let btnHojinkeitai_mae = document.getElementById("hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("hojinkeitai_other");
    var selected = $("#hojinkeitai").children("option:selected");
    if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
    } else if (selected.text() != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = selected.text();
        }
    } else if (txtHojinkeitai_other.value != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
        }
    }
}

/*(事業用契約者)法人形態プルダウン選択時（申込入力画面）*/
function ji_k_hojinkeitaiChange() {
    let btnHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_k_hojinkeitai_other");
    var selected = $("#ji_k_hojinkeitai").children("option:selected");
    if (selected.text() == '') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.disabled = false;
    } else if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
    } else if (selected.text() != '') {
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
        } else if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_ushiro.value = selected.text();
        }
    }
}

/*(事業用契約者)法人形態その他入力時（申込入力画面）*/
function ji_k_hojinkeitai_otherChange() {
    let btnHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_k_hojinkeitai_other");
    if (btnHojinkeitai_mae.checked) {
        txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
    } else if (btnHojinkeitai_ushiro.checked) {
        txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
    }
}

/*(事業用契約者)法人形態位置ラジオボタン（申込入力画面）*/
function ji_k_hojinkeitai_ichiBtnClick() {
    let btnHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_k_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_k_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_k_hojinkeitai_other");
    var selected = $("#ji_k_hojinkeitai").children("option:selected");
    if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
    } else if (selected.text() != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = selected.text();
        }
    } else if (txtHojinkeitai_other.value != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
        }
    }
}

/*(事業用被保険者)法人形態プルダウン選択時（申込入力画面）*/
function ji_h_hojinkeitaiChange() {
    let btnHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_h_hojinkeitai_other");
    var selected = $("#ji_h_hojinkeitai").children("option:selected");
    if (selected.text() == '') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.disabled = false;
    } else if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
    } else if (selected.text() != '') {
        txtHojinkeitai_other.value = '';
        txtHojinkeitai_other.disabled = true;
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
        } else if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_ushiro.value = selected.text();
        }
    }
}

/*(事業用被保険者)法人形態その他入力時（申込入力画面）*/
function ji_h_hojinkeitai_otherChange() {
    let btnHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_h_hojinkeitai_other");
    if (btnHojinkeitai_mae.checked) {
        txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
    } else if (btnHojinkeitai_ushiro.checked) {
        txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
    }
}

/*(事業用被保険者)法人形態位置ラジオボタン（申込入力画面）*/
function ji_h_hojinkeitai_ichiBtnClick() {
    let btnHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_ichiRadio1");
    let btnHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ichiRadio2");
    let txtHojinkeitai_mae = document.getElementById("ji_h_hojinkeitai_mae");
    let txtHojinkeitai_ushiro = document.getElementById("ji_h_hojinkeitai_ushiro");
    let txtHojinkeitai_other = document.getElementById("ji_h_hojinkeitai_other");
    var selected = $("#ji_h_hojinkeitai").children("option:selected");
    if (selected.text() == 'なし') {
        txtHojinkeitai_mae.value = '';
        txtHojinkeitai_ushiro.value = '';
    } else if (selected.text() != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = selected.text();
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = selected.text();
        }
    } else if (txtHojinkeitai_other.value != '') {
        if (btnHojinkeitai_mae.checked) {
            txtHojinkeitai_mae.value = txtHojinkeitai_other.value;
            txtHojinkeitai_ushiro.value = '';
        } if (btnHojinkeitai_ushiro.checked) {
            txtHojinkeitai_mae.value = '';
            txtHojinkeitai_ushiro.value = txtHojinkeitai_other.value;
        }
    }
}

/*(事業用)被保険者区分ラジオボタン（申込入力画面）*/
function ji_hihokenshaBtnClick() {
    let btnHojin = document.getElementById("ji_hihokensha_kbnRadio1");
    let btnKojinJigyonushi = document.getElementById("ji_hihokensha_kbnRadio2");
    let ji_h_HojinForm = document.getElementById("ji_h_hojin");
    let ji_h_KojinjigyonushiForm = document.getElementById("ji_h_kojinjigyonushi");
    if (btnHojin.checked) {
        ji_h_HojinForm.style.display = "";
        ji_h_KojinjigyonushiForm.style.display = "none";
    }
    if (btnKojinJigyonushi.checked) {
        ji_h_HojinForm.style.display = "none";
        ji_h_KojinjigyonushiForm.style.display = "";
    }
}

