﻿function SetDeleteDialog(id, title) {
    document.getElementById("ModalBody").innerText = "确认要删除笔记 " + title + " 吗？";
    document.getElementById("DeleteNoteButton").innerHTML = "<a href=\"/Note/Remove/?id=" + id + "\" class=\"btn btn-danger text-white\">删除<\/a>";
}