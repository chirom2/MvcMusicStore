$("#searchButton").click(function() {
    //callSearhAction("Rock");
    console.log($("#searchString").val());
    callSearhAction($("#searchField").val());

});


function callSearhAction(searchString) {
    console.log("entry");
   
    //$.post('http://localhost:52687/search/displayresult', { searchString: searchString },
    //            function (result) {
    //                $("#resultSearch").html(result);
    //            }, function (xhr, status, error) {
    //                console.log("error " + error);
    //            });//Bon passage de param mais pas d'affichage

    $.ajax({
        type: "POST",
        url: "http://localhost:52687/search/displayresult",
        data: { searchString: ''+searchString+'' },
        success: function(result) {
            $("#resultSearch").html(result);
        },
        error: function(xhr, status, error) {
            console.log("error " + error);
        }
    });

}