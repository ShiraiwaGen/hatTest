// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//import { Modal } from "../lib/bootstrap/dist/js/bootstrap.bundle";

// Write your JavaScript code.

/*商品選択ラジオボタン（申込入力画面）*/
function shohinKbnBtnClick() {
    let btnJutaku = document.getElementById("shohinKbnRadio1");
    let jutakuForm = document.getElementById("jutaku-form");
    let jigyoForm = document.getElementById("jigyo-form");
    if (btnJutaku.checked) {
        jigyoForm.style.display = "none";
        jutakuForm.style.display = "";
    } else {
        jigyoForm.style.display = "";
        jutakuForm.style.display = "none";
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
    // 件数切替の値を10～50の10刻みにする
    lengthMenu: [10, 20, 30, 40, 50, 100],
    // 件数のデフォルトの値を50にする
    displayLength: 50,
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
});

/*全角→半角（カタカナ）*/
function toFullZenkana(elm, id) {
    var beforeStr = new Array('ァ', 'ィ', 'ゥ', 'ェ', 'ォ', 'ャ', 'ュ', 'ョ', 'ッ', 'ー', 'ヴ', 'ガ', 'ギ', 'グ', 'ゲ', 'ゴ', 'ザ', 'ジ', 'ズ', 'ゼ', 'ゾ', 'ダ', 'ヂ', 'ヅ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ', 'ア', 'イ', 'ウ', 'エ', 'オ', 'カ', 'キ', 'ク', 'ケ', 'コ', 'サ', 'シ', 'ス', 'セ', 'ソ', 'タ', 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ', 'ハ', 'ヒ', 'フ', 'ヘ', 'ホ', 'マ', 'ミ', 'ム', 'メ', 'モ', 'ヤ', 'ユ', 'ヨ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ワ', 'ヲ', 'ン');
    var afterStr = new Array('ｧ', 'ｨ', 'ｩ', 'ｪ', 'ｫ', 'ｬ', 'ｭ', 'ｮ', 'ｯ', 'ｰ', 'ｳﾞ', 'ｶﾞ', 'ｷﾞ', 'ｸﾞ', 'ｹﾞ', 'ｺﾞ', 'ｻﾞ', 'ｼﾞ', 'ｽﾞ', 'ｾﾞ', 'ｿﾞ', 'ﾀﾞ', 'ﾁﾞ', 'ﾂﾞ', 'ﾃﾞ', 'ﾄﾞ', 'ﾊﾞ', 'ﾋﾞ', 'ﾌﾞ', 'ﾍﾞ', 'ﾎﾞ', 'ﾊﾟ', 'ﾋﾟ', 'ﾌﾟ', 'ﾍﾟ', 'ﾎﾟ', 'ｱ', 'ｲ', 'ｳ', 'ｴ', 'ｵ', 'ｶ', 'ｷ', 'ｸ', 'ｹ', 'ｺ', 'ｻ', 'ｼ', 'ｽ', 'ｾ', 'ｿ', 'ﾀ', 'ﾁ', 'ﾂ', 'ﾃ', 'ﾄ', 'ﾅ', 'ﾆ', 'ﾇ', 'ﾈ', 'ﾉ', 'ﾊ', 'ﾋ', 'ﾌ', 'ﾍ', 'ﾎ', 'ﾏ', 'ﾐ', 'ﾑ', 'ﾒ', 'ﾓ', 'ﾔ', 'ﾕ', 'ﾖ', 'ﾗ', 'ﾘ', 'ﾙ', 'ﾚ', 'ﾛ', 'ﾜ', 'ｦ', 'ﾝ');
    var fullStr = elm.value;
    for (var i = 0; i < beforeStr.length; i++) {
        fullStr = fullStr.replace(new RegExp(beforeStr[i], 'g'), afterStr[i]);
    }
    document.getElementById(id).value = fullStr;
} 
