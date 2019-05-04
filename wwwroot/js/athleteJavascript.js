
function populateNewAuthleteModal() {
    var design = `
                    <div class="panel panel-default">
                        <div class="panel-heading">Name</div>
                        <div class="panel-body">
                            <select id="athlete">
                                <option>Select</option>
                            </select>
                        </div>
                      </div>
                      <div class="panel panel-default">
                            <div class="panel-heading">Distance</div>
                            <div class="panel-body"><input id="result" type="number" required /></div>
                     </div>

					 <div>
							<input  onclick="return saveAthlete()" type="button" value="Save">
					 </div>

`;

    $("#modalBody").append(design);
    $("#modalBody").css("display", "block");
    getAthlete();
}


function getAthlete() {
    $.ajax({
        type: "GET",
        url: '/Athelet/GetAthelet',
        contentType: "application/json; charset=utf-8",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (data) {
        for (var i = 0; i < data.length; i++) {
            $("#athlete").append(`<option value=${data[i].userId}>${data[i].userName}</option>`);
        }
    })
}


function saveAthlete() {
    var userId = $("#athlete").val();
    var testId = $("#testId").val();
    var result = $("#result").val();

    if (userId == "select") {
        alert("Please Provide Athlete");
        return false;
    }

    if (result == "") {
        alert("Please Provide distance");
        return false;
    }


    $.ajax({
        type: "POST",
        data: JSON.stringify({ UserId: userId, TestId: testId, Result: result }),
        url: '/Athelet/InsertAthleteInTest',
        contentType: "application/json; charset=utf-8",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (data) {
        window.location.href = window.location.href;
    })
}


function updateAthlete(userId) {
    var userId = userId;
    var testId = $("#testId").val();
    var result = $("#result").val();

    $.ajax({
        type: "POST",
        data: JSON.stringify({ UserId: userId, TestId: testId, Result: result }),
        url: '/Athelet/UpdateAthleteInTest',
        contentType: "application/json; charset=utf-8",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (data) {
        window.location.href = window.location.href;
    })


}


function deleteAthlete(userId) {
    var userId = userId;
    var testId = $("#testId").val();

    $.ajax({
        type: "POST",
        data: JSON.stringify({ UserId: userId, TestId: testId }),
        url: '/Athelet/InActiveAthleteInTest',
        contentType: "application/json; charset=utf-8",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json"
    }).done(function (data) {
        window.location.href = window.location.href;
    })


}


function populateEditModal(userId,userName,result) {
    var design = `
                    <div class="panel panel-default">
                        <div class="panel-heading">Name</div>
                        <div class="panel-body">
                             <div class="panel-heading">${userName}</div>
                        </div>
                      </div>
                      <div class="panel panel-default">
                            <div class="panel-heading">Distance</div>
                            <div class="panel-body"><input id="result" type="number" value="${result}" /></div>
                     </div>

					 <div>
							<input  onclick="return updateAthlete(${userId})" type="button" value="Save">
					 </div>



					 <div>
							<input type="button" value="Delete Athlete From Test" onclick="ConfirmDelete(${userId})">
					 </div>

`;

    $("#modalBody").append(design);
    $("#modalBody").css("display", "block");

}



function ConfirmDelete(userId) {
    var x = confirm("Are you sure you want to delete?");
    if (x) {
        deleteAthlete(userId)
        return true;
    }
    else {
        return false;
    }
      
}