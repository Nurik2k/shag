$(function(){ 
    //console.log("AJAX PROJECT"); 
    $.get("https://dummyjson.com/products/?limit=12", function(response){ 
        $.each(response.products, function( index, value ){ 
        $('.products').append(createItem(value)); 
        }); 
         
    }) 
    .fail(function(){ 
        alert("error"); 
    }); 
 
    let timeout = null; 
    const $searchInput = $('#search'); 
 
    $searchInput.on('keyup', function() { 
 
      if(timeout !== null){ 
        clearTimeout(timeout); 
      } 
       
      timeout = setTimeout(() => { 
        let searchText = $(this).val(); 
        if(searchText.length >= 3) { 
          getElements(searchText); 
        } 
      }, 2000); 
      }); 
 
      
      /*$('#findbutton').click(function(){ 
        console.log(this); 
      });*/ 
 
      function getElements(fraza){ 
        $.get("https://dummyjson.com/products/?limit=12", function(response){ 
        let seacrhArray = response.products; 
        let list = seacrhArray.filter(function(item){ 
          return item.title.toLowerCase().indexOf(fraza.toLowerCase()) >= 0 
        }) 
        $('.products').html('');
        // 
        $.each(list, function( index, value ){ 
          $('.products').append(createItem(value)); 
          }); 
        
 
        
         
    }) 
    .fail(function(){ 
      alert("error"); 
  }); 
      } 
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