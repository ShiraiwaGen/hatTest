// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

import { Modal } from "../lib/bootstrap/dist/js/bootstrap.bundle";

// Write your JavaScript code.

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

function CrearBtnClick() {
    window.location.reload();
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