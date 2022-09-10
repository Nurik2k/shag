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
// __________________________________________________________________________________________________
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
// ________________________________________________________
// let numbers = (prompt("Введите 10 чисел: "));
// let = chet = 0, nechet = 0, nul = 0;
// for(let i = 0; i < numbers; i++){
//     if(numbers[i] % 2 === 0 && numbers[i] > 0){
//         chet++;
//     }
//     else if(numbers[i] % 2 === 1){
//         nechet++;
//     }
//     else if(numbers[i] === '0'){
//         nul++;
//     }
// }
// alert(`Четных: ${chet}
// Нечетных: ${nechet}
// Нулей: ${nul}`);

// while (true) {
//     const num1 = +prompt('Введите первое число');
//     const num2 = +prompt('Введите второе число');
//     const op = prompt('Выберете знак |-|+|/|*|');
//     const action = {
//       '+': () => num1 + num2,
//       '-': () => num1 - num2,
//       '/': () => num1 / num2,
//       '*': () => num1 * num2
//     }[op];
//     if (action) alert(action());

//     if (!confirm('Хотите ли вы решить еще один пример?')) break;
//   }
// ______________________________________________________________________


// let number = prompt('Введите число: ');
// let step = +prompt('На сколько сдвинуть: ');
// arr = number.split('');
// for(let i = 0; i < step; i++) {
//   arr.push(arr.shift());
// }
// alert(arr.join());
// ________________________________________________________

// const days = ['Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суббота', 'Воскресенье'];
// let temp = 0;
// while (confirm(`${days[temp]}. Хотите увидеть следующий день?`)) {
//   temp = (temp + 1) % days.length;
// }
//________________________________________________________________________

// tables = [];
// for(let i = 2; i <= 9; i++){
//     tables.push(`Таблица умножения ${i}:\n`);
// for(let j = 2; j <= 10; j++){
// tables.push(`${i} * ${j} = ${i * j} \n`);
// }
// }  
// console.log(tables.join(''));
//________________________________________________________________________

//10 задание не понял!
