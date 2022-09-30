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

