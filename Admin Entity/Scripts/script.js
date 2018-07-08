var loginuser='';
var loginpass='';
//var credential='';











$(function(){

  $('#admin_details').hide();
  $('#adminEdit').hide();

$('#admindetail').hide();
$('#admindel').hide();
$('#createadmin').hide();


$(document).on('click', '#signinbutton', function(){
  //var credential = btoa('Admin3:1122');
   $.ajax({
      url: 'http://localhost:55910/api/logins',
      
      method:'GET',
      headers: {
        Authorization: 'Basic' + credential
      },
      complete: function(xmlhttp){
        alert(xmlhttp.status);
        if(xmlhttp.status==200)
        {
          alert("in");
         //ndow.location.href = 'http://localhost/Admin Entity';
        }
        else
        {
          alert("out");
          $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }
    });

  
 });







    $("#navicon").click(function(){
       var n = $(".naviconholder").css("padding-left");
       if(n=="50px"){
         $(".naviconholder").css("padding-left", "210px");
         $(".navbar").css("visibility", "visible");
         $(".mainbody").css("margin-left", "300px");
       }

       else{
         $(".naviconholder").css("padding-left", "50px");
         $(".navbar").css("visibility", "hidden");
         $("mainbody").css("margin-left", "200px");
       }
    });  

  var globalId=0;
  var loadAdmins = function(){
    $.ajax({
      url: 'http://localhost:55910/api/admins',
   

      complete: function(xmlhttp){
        if(xmlhttp.status == 200)
        {
          
          var adminList = xmlhttp.responseJSON;
          var outputStr = '';
          for(var i = 0; i < adminList.length; i++)
          {
            outputStr += '<tr id="tdedit"  value="'+adminList[i].id+'"><td>' + adminList[i].username + '</td><td>' + adminList[i].fullName + '</td><td>'+ adminList[i].email+'</td><td><button type="button" class="mybtn" id = '+adminList[i].id+'   style="color: black; background-color: skyblue;"     >EDIT</button></td><td><button type="button" class="delete" id = '+adminList[i].id+'   style="color: white; background-color: red;"   >DELETE</button></td><td><button type="button" class="detail" id = '+adminList[i].id+'   style="color: white; background-color: green;"   >DETAIL</button></td></tr>';
           
          }

          $('#admin_list tbody').html(outputStr);
          $('#admin_details').show();
        }
        else
        {
          $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }
    });
  }
  $('#admin_profile').click(loadAdmins);


//edit

  $(document).on('click', '.mybtn', function(){
  var ids = $(this).attr('id') ;
  globalId=$(this).attr('id') ;;
$.ajax({
      url: 'http://localhost:55910/api/admins/'+ids,
      method: 'GET',
      header: 'Content-Type: application/json',
      complete: function(xmlhttp){
        if(xmlhttp.status == 200)
        {
          $('#admin_details').hide();
          var admin = xmlhttp.responseJSON;
          $('#adminId').html(admin.id);
          $('#ausername').val(admin.username)
          $('#afullName').val(admin.fullName)
          $('#aemail').val(admin.email)
          $('#apassword').val(admin.password)
          $('#adminEdit').show();
        }
        else
        {
          alert("Not");
          $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }

    });
});


// del

$(document).on('click', '.delete', function(){
  var ids = $(this).attr('id') ;
  globalId=$(this).attr('id') ;;
$.ajax({
      url: 'http://localhost:55910/api/admins/'+ids,
      method: 'GET',
      header: 'Content-Type: application/json',
      complete: function(xmlhttp){
        if(xmlhttp.status == "200")
        {

           alert(globalId);
          var admin = xmlhttp.responseJSON;
          $('#admin_details').hide();
            // localStorage.setItem("adminId",admin.id);
          $('#ddminId').html(admin.id);
          $('#dusername').html(admin.username);
          $('#dfullName').html(admin.fullName);
          $('#demail').html(admin.email);
          $('#dpassword').html(admin.password);
          $('#admindel').show();
        }
        else
        {
          alert("Not");
          $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }

    });
});


 $('#dyes').click(function(){

/// cal
$.ajax({
      url: 'http://localhost:55910/api/admins/'+globalId,
      method:'DELETE',
      header: 'Content-Type: application/json',
      complete: function(xmlhttp){

        //alert(xmlhttp.status);
        if(xmlhttp.status == "204")
        {

           alert("Successfully Deleted");
           
         // $('#msgi').html("");
         location.reload();
        }
        else
        {

          alert(xmlhttp.status +xmlhttp.statusText);
         
        }
      }


});



     

 });


 $('#dno').click(function(){

location.reload();

 });
 $('#sbutton').click(function(){


var x = $('#scr').val();
$.ajax({
      url: 'http://localhost:55910/api/admins/searchbyadmin/'+x,
      method:'GET',
      header: 'Content-Type: application/json',
     

      

      complete: function(xmlhttp){
      var xxx = xmlhttp.responseJSON;
        //alert(xmlhttp.status);


var outputStrp='';



        if(xmlhttp.status == "200")
        {

           alert("User Found");



         for(var i = 0; i < xxx.length; i++)
          {
            outputStrp += '<tr id="tdedit"  value="'+xxx[i].id+'"><td>' + xxx[i].username + '</td><td>' + xxx[i].fullName + '</td><td>'+ xxx[i].email+'</td><td><button type="button" class="mybtn" id = '+xxx[i].id+'   style="color: black; background-color: skyblue;"     >EDIT</button></td><td><button type="button" class="delete" id = '+xxx[i].id+'   style="color: white; background-color: red;"   >DELETE</button></td><td><button type="button" class="detail" id = '+xxx[i].id+'   style="color: white; background-color: green;"   >DETAIL</button></td></tr>';
           
          }

          $('#admin_list tbody').html(outputStrp);
          $('#admin_details').show();




           
           
         // $('#msgi').html("");
         
        }
        else
        {

          alert(xmlhttp.status +xmlhttp.statusText);
         
        }






      }
    });// write seach code here



});




 $('#createbutton').click(function(){
    $('#admin_details').hide();

     $('#createadmin').show();









 });







//det



$(document).on('click', '.detail', function(){
  var ids = $(this).attr('id') ;
  globalId=$(this).attr('id') ;;
$.ajax({

      url: 'http://localhost:55910/api/admins/'+ids,
      method: 'GET',
      header: 'Content-Type: application/json',
      complete: function(xmlhttp){
        if(xmlhttp.status == "200")
        {

           alert(globalId);
          var admin = xmlhttp.responseJSON;
          $('#admin_details').hide();
            // localStorage.setItem("adminId",admin.id);
          $('#bdminId').html(admin.id);
          $('#busername').html(admin.username);
          $('#bfullName').html(admin.fullName);
          $('#bemail').html(admin.email);
          $('#bpassword').html(admin.password);
          $('#admindetail').show();
        }
        else
        {
          alert("Not");
          $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
        }
      }

    });
});
 
 $('#bdminSave').click(function(){

location.reload();

 });


$('#credminSave').click(function(){
 // alert(globalId);
    $.ajax({
      url: 'http://localhost:55910/api/admins',
      method:'POST',
      header: 'Content-Type: application/json',
      data: {
        username: $('#creusername').val(),
        fullName: $('#crefullName').val(),
        email: $('#creemail').val(),
        password: $('#crepassword').val(),
      },
      

      

      complete: function(xmlhttp){

        //alert(xmlhttp.status);
        if(xmlhttp.status == "201")
        {

           alert("Successfully Created");
           
         // $('#msgi').html("");
         location.reload();
        }
        else
        {

          alert(xmlhttp.status +xmlhttp.statusText);
         
        }






      }
    });


 });



  $('#adminSave').click(function(){
 // alert(globalId);
    $.ajax({
      url: 'http://localhost:55910/api/admins/'+globalId,
      method:'PUT',
      header: 'Content-Type: application/json',
      data: {
        username: $('#ausername').val(),
        fullName: $('#afullName').val(),
        email: $('#aemail').val(),
        password: $('#apassword').val(),
      },
      

      

      complete: function(xmlhttp){

        //alert(xmlhttp.status);
        if(xmlhttp.status == "200")
        {

           alert("Successfully Updated");
           
         // $('#msgi').html("");
         location.reload();
        }
        else
        {

          alert(xmlhttp.status +xmlhttp.statusText);
         
        }

      }
    });


    
  });


});
    





 



