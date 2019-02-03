console.log("Hello, World!");

// For Default home page
$("#aboutBody").hide();
$("#contactBody").hide();

$(document).ready(function() {
    $("#home").click(function() {
        $("#homeBody").show();
        $("#aboutBody").hide();
        $("#contactBody").hide();
    });

    $("#about").click(function() {
        $("#homeBody").hide();
        $("#aboutBody").show();
        $("#contactBody").hide();
    });

    $("#contact").click(function() {
        $("#homeBody").hide();
        $("#aboutBody").hide();
        $("#contactBody").show();
    });
});

// for User Login home page
$("#profileBody").hide();
$("#myLyricsBody").hide();
$(document).ready(function() {
    $("#userHome").click(function() {
        $("#userHomeBody").show();
        $("#profileBody").hide();
        $("#myLyricsBody").hide();
    });

    $("#profile").click(function() {
        $("#userHomeBody").hide();
        $("#profileBody").show();
        $("#myLyricsBody").hide();
    });

    $("#myLyrics").click(function() {
        $("#userHomeBody").hide();
        $("#profileBody").hide();
        $("#myLyricsBody").show();
    });
});

$(document).ready(function () {
function search() {
    // Declare variables 
    var input, filter, table, tr, td, i;
    input = document.getElementById("searchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("songTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// for song lyrics details from table

$('#lyricsDetailModal').on('show.bs.modal', function(e) {

    var _button = $(e.relatedTarget);

    // console.log(_button, _button.parents("tr"));
    var _row = _button.parents("tr");
    var _songName = _row.find("#tableSongName").text();
    var _songArtist = _row.find("#tableArtist").text();
    var _songLyrics = _row.find("#tableSongLyrics").text();
    // console.log(_invoiceAmt, _chequeAmt);

    $(this).find("#songName").html(_songName);
    $(this).find("#artist").html("by " + _songArtist);
    $(this).find("#songLyrics").html(_songLyrics);
});

//for editing

$('#lyricsEditModal').on('show.bs.modal', function(e) {

    var _button = $(e.relatedTarget);

    // console.log(_button, _button.parents("tr"));
    var _row = _button.parents("tr");
    var _songName = _row.find("#tableSongName").text();
    var _songArtist = _row.find("#tableArtist").text();
    var _songLyrics = _row.find("#tableSongLyrics").text();
    // console.log(_invoiceAmt, _chequeAmt);

    $(this).find("#songName").val(_songName);
    $(this).find("#songArtist").val(_songArtist);
    $(this).find("#lyrics").val(_songLyrics);
});

//for delete
$('#lyricsDeleteModal').on('show.bs.modal', function(e) {

    var _button = $(e.relatedTarget);

    // console.log(_button, _button.parents("tr"));
    var _row = _button.parents("tr");
    var _songName = _row.find("#tableSongName").text();
    // console.log(_invoiceAmt, _chequeAmt);

    $(this).find(".modal-title").html("Do you really want to delete " + _songName + "?");
  });
});