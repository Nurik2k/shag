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


// let checks = [{name:'milk',qnty:'2',priceFor1:'3.0'},{name:'bred',qnty:'3',priceFor1:'1.2'},{name:'butter',qnty:'1',priceFor1:'4.5'}];

// function show()
// {
//     for(let i=0;i<checks.length;i++)
//     {
//         console.log(`${checks[i].name}-${checks[i].qnty}-${checks[i].priceFor1}`);
//     }
// }

// show();

// function summ(arr)
// {
//     let s=0;
//     for(let i=0;i<arr.length;i++)
//     {
//         s+=parseInt(arr[i].qnty)*parseFloat(arr[i].priceFor1);
//     }
//     console.log(`общая сумма покупки ${s}`);
// }
// summ(checks);

// function mostExpensive(arr)
// {
//     let max=parseInt(arr[0].qnty)*parseFloat(arr[0].priceFor1);
//     let ind =0;
//     for(let i=1;i<arr.length;i++)
//     {
//         if(max<parseInt(arr[i].qnty)*parseFloat(arr[i].priceFor1))
//         {
//             max=parseInt(arr[i].qnty)*parseFloat(arr[i].priceFor1);
//             ind=i;
//         }
//     }
//     console.log(`самая дорогая покупка в чеке ${max}`);
//     console.log(`${checks[ind].name}-${checks[ind].qnty}-${checks[ind].priceFor1} = ${max}`);
// }
// mostExpensive(checks);

// function averagePrice(arr)
// {
//     let overall=0;
//     let overallQuantity = 0;
//     for(let i=0;i<arr.length;i++)
//     {
//         overall+=parseInt(arr[i].qnty)*parseFloat(arr[i].priceFor1);
//         overallQuantity+=parseInt(arr[i].qnty);
//     }
//     console.log(`средняя стоимость одного товара в чеке - ${overall/overallQuantity}`);
// }

// averagePrice(checks);
//_________________________________________________________________________________________


// let massv = [{name:'style1',fontSize:'120%'},{name:'style1',color:'red'},{name:'style1',textAlign:'center'},{name:'style1',underline:'1'}];

// let temp = 'HEHEHEHHEHEH';
// function showTextWithStyle(mass,txt)
// {
//     document.write(`<p style=" font-size: ${mass[0].fontSize}; text-align: ${mass[2].textAlign}; color: ${mass[1].color}; underline: ${mass[3].underline};">  ${txt} </p>`);
// }
// showTextWithStyle(massv,temp);
//____________________________________________________________________________________________


class Rooms
{
    constructor(numb,cpcty,fclty)
    {
        this.name=numb;
        this.cpcty=cpcty
        this.fclty=fclty;
    }
}

let masOfRooms = new Array();

function printRooms()
{
    console.log(masOfRooms.length);
    for(let i=0;i<masOfRooms.length;i++)
    {
        console.log(masOfRooms[i]);
    }
}

function showRoomsFclty(fclty001)
{
    for(let i=0;i<masOfRooms.length;i++)
    {
        if(masOfRooms[i].fclty===fclty001)
            console.log(masOfRooms[i]);
    }
}

class Group
{
    constructor(name,qtty,fclty)
    {
        this.name=name;
        this.qtty=qtty
        this.fclty=fclty;
    }
}

let sep2122 = new Group('sep2122',14,'sep');

function showRoomsForGroup(group)
{
    for(let i=0;i<masOfRooms.length;i++)
    {
        if(masOfRooms[i].cpcty>=group.qtty)
            console.log(masOfRooms[i]);
    }
}

function sortByCapty()
{
    masOfRooms.sort(function(a, b) {
        return a.cpcty - b.cpcty;
      });
}

function sortByAlpha()
{
    masOfRooms.sort(function(a, b) {
    var nameA=a.name.toLowerCase(), nameB=b.name.toLowerCase();
    if (nameA < nameB) return -1;//сортируем строки по возрастанию  
    if (nameA > nameB)  return 1;
    return 0; // Никакой сортировки
    });
}

let room223 = new Rooms('Aroom223',20,'sep');
let room220 = new Rooms('Broom220',10,'sep');
let room210 = new Rooms('Froom210',50,'gts');

masOfRooms.unshift(room210);
masOfRooms.unshift(room220);   
masOfRooms.unshift(room223);

printRooms();

showRoomsFclty('gts');

showRoomsForGroup(sep2122);

sortByCapty();

printRooms();

sortByAlpha();

printRooms();
