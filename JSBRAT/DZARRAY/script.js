// let ProductList = [5];
// let j = 0;

// class Product {
//     constructor(name, count, ammount=false) {
//       this.name = name;
//       this.count = count;
//       this.ammount = ammount;
//     }
// }

// function compare( a, b ) {
//     if ( a.ammount < b.ammount ){
//       return -1;
//     }
//     if ( a.ammount > b.ammount ){
//       return 1;
//     }
//     return 0;
// }

// function showProductList(){
//   ProductList.sort((a, b) => {
//     return a.ammount - b.ammount;
//   });
//   ProductList.forEach((e) => {
//     console.log(`${e.name} | count: ${e.count} | ammount: ${e.ammount}`);
//   });
// }

// function buyProduct(obj) {
//   obj.ammount = true;
// }

// function createProduct(name, count) {
//   let obj = new Product();
//   obj.name = name;
//   obj.count = count;
//   ProductList[j] = obj; j++;
// }

// function buyProductUi(obj) {
//   ProductList.forEach((e) => {
//     if(e.name == obj){
//       buyProduct(e);
//     }
//   });
// }

// function createProductUi(){
//   let a = prompt("write product name");
//   let b = prompt("write product count");
//   createProduct(a, b);
// }

// for(let i = 0; i < 2; i++){
//   createProductUi();
// }

// showProductList(ProductList);
// let a = prompt("write what is boughta");
// buyProductUi(a);
// showProductList(ProductList);
//__________________________________________________________

$('#print_check').click(function() {
    let arr = [{
        name: 'Apple',
        bill: parseInt('230')
    }, {
        name: 'Potato',
        bill: parseInt('80')
    }, {
        name: 'Banana',
        bill: parseInt('50')
    }, ];
    
        
  GetCheck(arr);
});


  function GetCheck(arr){

    document.write('<ol start="1">');
    arr.forEach(ar => {
        document.write(<li> <span style="color: red;">${ar.name}</span> ${ar.bill} tenge.</li>);
    });
    document.write('<ol>'); 
    AllCountPrice(arr);
  }
  function AllCountPrice(arr){
    let sum = 0;
    for(let i = 0; i<arr.lenght; i++){
        sum += arr.bill[i++];
    }
    document.write(sum);
}


