$(function() {
    $.cookie("username", "Seisenbay Nurzhan");
    console.log($.cookie());

    function countSinging(){
        const visit = $.cookie('visit');
        if(visit){
            $.cookie('visit', parseInt(visit) + 1);
        }
        else{
            $.cookie('visit', 1);
        }
        return $.cookie('visit');
    }
    $('.counterJs').html(countSinging());

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
    let posts = [];
    function getPost() {
        $.get(`https://dummyjson.com/posts?limit=3`, function(response) {  
            posts = response.posts;
            aCreate();
        });
    }
    getPost();
    let angryMan = 'images/AngryMan.gif'
    
    let photos = [];
   function getPhoto() {
        for(let i = 0; i < 2; i++){
            photos.push(`https://picsum.photos/id/${i}/500/500`);
        }
        photos.push(angryMan);
    }

    getPhoto();
    function createPosts(title, body, photo) {
        return `
        <div class="row featurette">
        <div class="col-md-7">
            <h2 class="featurette-heading">${title}</h2>
            <p class="lead">${body}</p>
        </div>
        <div class="col-md-5">
            <img class="lazy" data-original="${photo}" width="500" height="500">
        </div>
        </div>

        <hr class="featurette-divider">
    `
    }
    function createPosts2(){
       for(let i = 0; i < posts.length; i++){
        
        $('#posts').append(createPosts(posts[i].title, posts[i].body, photos[i]));
       }

       $("img.lazy").lazyload();
    }
    
    function aCreate(){       
        createPosts2();
    }
    

    




});

