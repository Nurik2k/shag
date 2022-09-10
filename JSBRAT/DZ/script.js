// let number1 = parseInt(prompt("Введите первое число: "));
// let number2 = parseInt(prompt("Введите второе число: "));
// let result= 0;
// if(number1 < number2){
//     while(number1 <= number2){
//         result += number1;
//         number1++;
//     }
// }
// else{
//     while(number1 >= number2){
//         result += number2;
//         number2++;
//     }
// }
// console.log(`Сумма всех чисел: ${result}`);
//________________________________________________________________________

// function nod  (num1, num2) {
//     if (num2 !== 0) {
//       const result = num1 % num2;
//       return nod(num2, result);
//     }
//     return num1;
//   };
  

//   let number1 = prompt('Введите первое число');
//   let number2 = prompt('Введите второе число');
//   alert('НОД чисел ' + number1 + ' и ' + number2 + ' будет: ' + nod(number1, number2));
//________________________________________________________________________________________

// let number = parseInt(prompt('Введите число'));
// let del = [];
// for(let i = 0; i < number; i++){
//     if(number % i === 0){
//         del.push(i);
//     }
// }
// alert(del);

// function count(num) {
//     let d;
//     for(let i = 0; num > 1; i++) {
//        num /= 10;
//        d = i + 1; 
//     }
//     return d;
//  }
//  let cl = console.log;//Прикольно :)
// number = prompt("Введите число: ");
// cl(count(number));

let numbers = (prompt("Введите 10 чисел: "));
let = chet = 0, nechet = 0, nul = 0;
for(let i = 0; i < numbers; i++){
    if(numbers[i] % 2 === 0 && numbers[i] > 0){
        chet++;
    }
    else if(numbers[i] % 2 === 1){
        nechet++;
    }
    else if(numbers[i] === '0'){
        nul++;
    }
}
alert(`Четных: ${chet}
Нечетных: ${nechet}
Нулей: ${nul}`);