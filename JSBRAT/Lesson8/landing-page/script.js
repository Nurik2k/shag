$(function() {
    function getImage() {
        $.get(`https://picsum.photos/v2/list?page=1&limit=3`, function(response) {  
            //console.log( response.download_url)
            let items = response;

            $.each(items, function(index, value) {
               $('#items1').append(createItem(value));
            }) 
        });
    }
    getImage();
    function createItem(params) {
        return `
        <div class="col-lg-4">
        <div class="rounded"><img src="${params.download_url}" /> </div>
        <h2>${params.author}</h2>
      </div>
       `
    }
    
});

