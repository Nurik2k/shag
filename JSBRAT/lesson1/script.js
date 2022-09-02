function getRandomNum(){
    const rndInt = Math.floor(Math.random() * 100) + 1;
    return rndInt;
}

const arrayInt = [];
const array2 = [];

for(let i = 0; i < 10; i++){
    arrayInt.push(getRandomNum());
}
for(let i = 0; i < 5; i++){
    array2.push(getRandomNum());
}

function printArray(array){
    console.log(array);
}

function onlyEven(array){
const result = [];
for(let i; i < array.length; i++){
    if(array[i] % 2 === 0){
        result.push(array);
    }

}
printArray(result);
}

function arraySum(array){
    let sum = 0;
    for(let i = 0; i < array.length; i++){
        sum += array[i];
    }
    console.log(sum);
}

function arrayMax(array){
    const result = [...array];
    result.sort(function(a, b){
        return a - b;
    });
    console.log(result.pop());
}

function addArray(array, index , item){
    const result = [...array];
    result.splice(index, 0, item);
    console.log(result);
}

function deleteItem(pos, array){
    const result = [...array];
    result.splice(pos, 1);
    console.log(result);
}

const arrayOne = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
const arrayTwo = [1, 2, 3, 4, 5];

function concatUniq(array1, array2){
    //const result = [...new Set([...array1, ...array2])];
const result = array1.concat(array2);
const uniq = [...new Set(result)];
console.log(result);
}

function concatDouble(array1, array2){
    const result = array1.filter(function(item){
        return array2.indexOf(item) > -1;
    })
    console.log(result);
}
function Uniq(array1, array2){
    const result = array1.filter(function(item){
        return array2.indexOf(item) === -1
    })
    console.log(result);
}

const fruits = ['ананас', 'яблоко', 'персик', 'банан', 'груша' ];
const fruitsSort = fruits.sort();

console.log(fruits);
document.write('<ul>');
for(let i = 0; i < fruitsSort.length; i++){
    document.write('<li>');
    document.write(fruitsSort[i]);
    document.write('</li>');
}
document.write('</ul>');