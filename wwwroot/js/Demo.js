$(document).ready(function () {
    GetEmp();
})

//$('#btn').click(function () {
//alert('Clicked')
//})


$('#ButtonModal').click(function () {
    $('#exampleModal').modal('show')
    $('#hide').css("display", "none");
})
$('#closebtn').click(function () {
    $('#exampleModal').modal('hide');
    clear();
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
            GetEmp();
        },
        error: function () {
            alert('Not Good')
        }

    })
})


function deleteemp(id)
{
    if (confirm("Are you sure you want to delete"))
    {
        $.ajax({
            url: '/Ajax/DelEmp?Id=' + id,
            success: function () {
                alert('Emp Deleted');
                GetEmp();
            },
            error: function () {
                alert('Not Successfull');
            }
        })
    }

}

function EditEmp(id)
{
    $('#exampleModal').modal('show');
    $('#UpdateBtn').css("display","block");
    $('#saveBtn').css("display","none");
    $('#hide').css("display","block");
    
    $.ajax({
        url: '/Ajax/EditEmp?Id=' + id,
        success: function (result) {
            
            $("#InName").val(result.name);
            $("#ID").val(result.id);
            $("#InEmail").val(result.email);
            $("#InSalary").val(result.salary);

        },
        error: function () {
            alert('Not Successfull');
        }
    })
        
}

function GetEmp()
{
    $.ajax({
        url: '/Ajax/GetEmp',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (result) {
            obj = '';

            $.each(result, function (index, item) {
                obj += "<tr>"
                obj += "<td>" + item.id + "</td>"
                obj += "<td>" + item.name + "</td>"
                obj += "<td>" + item.email + "</td>"
                obj += "<td>" + item.salary + "</td>"
                obj += "<td><input type='button' class='btn btn-danger' onclick='deleteemp("+item.id+")' value='Delete'></input></td>"
                obj += "<td><input type='button' class='btn btn-secondary' onclick='EditEmp("+item.id+")' value='Edit'></input></td>"
                obj += "</tr>"
            });
            $("#tablebody").html(obj);
        },
        error: function () {
            alert('Not Good')
        }
    })
}



$('#UpdateBtn').click(function () {

    var obj2 = $('#myform').serialize();
    console.log(obj2);
    $.ajax({
        url: '/Ajax/updateEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        data: obj2,
        success: function () {
            alert('Good');
            $('#exampleModal').modal('hide');
            clear();
            GetEmp();
        },
        error: function () {
            alert('Not Good');
            clear();
        }

    })
})


$('#searchBtn').click(function () {
    var sdata=$('searchdata').val();
    $.ajax({
        url: '/Ajax/Index?data=' + sdata,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8',
        success: function () {
          
            //GetEmp();
        },
        error: function () {
            alert('Not Good');
            clear();
        }

    }) 
})
