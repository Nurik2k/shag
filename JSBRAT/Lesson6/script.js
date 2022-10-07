$(function(){ 
    //console.log("AJAX PROJECT"); 
    $.get("https://dummyjson.com/products/?limit=10", function(response){ 
        $.each(response.products, function( index, value ){ 
        $('.products').append(createItem(value)); 
        }); 
         
    }) 
    .fail(function(){ 
        alert("error"); 
    }); 

let timeout = null;
const $searchInput = $('#search');

$searchInput.on('keyup', function(){
    let that = this;
    if(timeout !== null){
        clearTimeout(timeout);
    }
    timeout = setTimeout(() => {
        let searchText = $(this).val();
        if(searchText.length > 3){
            console.log($(this).val());
        }
    }, 2000);
});

    $('#search').on('input',function(){
        let searchtext = $(this).val();
        if(searchtext.length > 3){
        
        }
    });
}); 
 
function createItem(params){ 
    return ` 
    <div class = "col-3"> 
    <div class="card"> 
    <img src="${params.images[0]}" class="card-img-top" alt="${params.title}"> 
    <div class="rating>${params.rating}</div> 
    <div class="card-body"> 
      <h5 class="card-title">${params.title}</h5> 
      <p class="card-text">${params.description}</p> 
      <a href="#" class="btn btn-primary">Купить за ${params.price}</a> 
    </div> 
    </div> 
  </div>` 
}