// let array = ['1', '2', '3'];
// let newArray = [...array];
// console.log(array);
// newArray.push('4');
// console.log(array);
// console.log(newArray);


// let string = 'Моя строка';
// let newString = string;
// console.log(string);
// newString += 'не изменилась!';
// console.log(newString);

// let string = 'Сьешь еще этих мягких французских булок, да выпей чаю.';
// console.log(string.substring(5, 9));

// let string = 'Сьешь еще этих мягких французских булок, да выпей чаю.';
// console.log(string.split(' '));//из строки в массив

// let string = '      +7 (777) 777 - 77 - 77      ';
// let cleanString = string.trim();
// console.log(string);
// console.log(cleanString);


// let string1 = 'cьешь еще этих мягких французских булок, ';
// function upperFirst(str){
    
// console.log(`${ str.substring(0,1).toUpperCase()} ${str.substring(1)}`);
// }
// upperFirst(string1);

// let string = 'cьешь еще этих мягких французских булок';
// const glasnye = ['а', 'е', 'у', 'о', 'и', 'э', 'ы', 'ю', 'я'];
// function glasnyCount(){
//     let count = 0;
//     for(let i = 0; i < string.length; i++){
//         for(let j = 0; j < glasnye.length; j++) {
//             if(string[i] === glasnye[j]) {
//             count += 1;
//             }
//         }
//     }
//     console.log(count);
// }
// glasnyCount();


// let string = 'ТОЛЬКО СЕГОДНЯ! Распродажа! 2 по цене одного! Торопись!';
// const glasnye = ['100% бесплатно', 'увеличение продаж', 'только сегодня', 'не удаляйте', 'ххх'];
// function glasnyCount(str){
//     let result = false;
//     let temp = str.toLowerCase();
//     for(let i = 0; i < string.length; i++){
//             if(temp.indexOf(glasnye[i]) !== -1) {
//                 result = true;
//             }
//     }
//     console.log(result);
// }
// glasnyCount(string);//true


// let string = 'ТОЛЬКО СЕГОДНЯ! Распродажа! 2 по цене одного! Торопись!';
// function truncate(str, count){
//     if(str.length > count){
//         return `${str.substring(0, count -3)}...`
//     }
// }
// console.log(truncate('Hello, world!', 8));


let string = 'топот';
function polindrom(str){
    let left = [];
    let right = [];
    if(str.length % 2 !== 0){
        left = str.substring(0, (str.length - 1) / 2);
        right = str.substring((str.length + 1) / 2);
    }
    else{
        left = str.substring(0, (str.length) / 2);
        right = str.substring((str.length) / 2);
    }
    left = left.split('');
    left = right.split('');
    let count = 0;
    for(let i = 0; i <= left.length; i++){
        for(let j = 0; j <= right.length; j++){
            if(left[i] === right[j]){
                count += 1;
            }
        }
    }
    console.log(count);
    console.log(left);
    console.log(right);
    if(count === left.length){
        return true;
    }
    else{
        return false;
    }
}
console.log(polindrom(string));