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
for(let i; i < array.lenth; i++){
    if(array[i] % 2 === 0){
        result.push(array);
    }

}
printArray(result);
}


onlyEven(arrayInt);