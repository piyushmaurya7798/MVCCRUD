$(document).ready(function () {

})

//$('#btn').click(function () {
//alert('Clicked')
//})


$('#ButtonModal').click(function () {
    $('#exampleModal').modal('show')
})
$('#closebtn').click(function () {
    $('#exampleModal').modal('hide')
})



function clear() {
    $('#InName').val("");
    $('#InEmail').val("");
    $('#InSalary').val("")
}

$('#saveBtn').click(function () {

    var obj = {
        name: $('#InName').val(),
        email: $('#InEmail').val(),
        salary: $('#InSalary').val(),
    }
    console.log(obj);
    var obj2 = $('#myform').serialize();
    console.log(obj2);
    $.ajax({
        url: '/Ajax/AddEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj2,
        success: function () {
            alert('Good');
            $('#exampleModal').modal('hide');
            clear();
        },
        error: function () {
            alert('Not Good')
        }

    })
})