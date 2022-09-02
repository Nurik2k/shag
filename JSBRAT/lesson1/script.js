function getRandomNum(){
    const rndInt = Math.floor(Math.random() * 100) + 1;
    return rndInt;
}

const arrayInt = [];


for(let i = 0; i < 10; i++){
    arrayInt.push(getRandomNum());
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

arrayMax(arrayInt);
printArray(arrayInt);
addArray(arrayInt, 5, 'Back');