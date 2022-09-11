// function equals(num1, num2){
// if(num1 > num2){
//     alert('1');
// }
// else if(num1 < num2){
//     alert('-1');
// }
// else if(num1 === num2){
//     alert('0');
// }
// }
// let number1 = prompt("Введите первое число: ");
// let number2 = prompt("Введите второе число: ");
// equals(number1, number2);
// _____________________________________________________
// function Factorial(x) {
//     let F = 1;
//     if(x <= 0)
//         return 1;
//     if(x > 0)
//     {
//         for(let i = 1; i <= x; i++)
//             F = F * i;
//     }
//     return F;
// }
// let number = prompt("Введите число: ");
// alert(Factorial(number));
// _____________________________________________________

// function nez(numb1, numb2, numb3){
// alert(`${numb1}${numb2}${numb3}`);
// }
// let number1 = prompt("Введите первое число: ");
// let number2 = prompt("Введите второе число: ");
// let number3 = prompt("Введите третье число: ");
// nez(number1, number2, number3);
// _____________________________________________________

// function figura(num1, num2 = num1){
// if(num1 >= 0 && num2 >= 0){
//     return num1 * num2;
// }
// else{
//     return "Не вводите отрицательные числа!";
// }
// }
// alert(figura(5, 4));
// alert(figura(4));
// _____________________________________________________

// function soverCh(num){
//     let sum = 0;
//     for(let i = 1; i < num; i++){
//         if (num % i === 0) {
//             sum += i;
//         }
//     }
//     if(sum === num){
//         return "Совершенное число!";
//     }
//     else{
//     return "Не совершенное число!";
//     }
// };
// let number1 = parseInt(prompt("Введите число: "));
// alert(soverCh(number1));
// _____________________________________________________

// function soverCh(num){
//     let sum = 0;
        
//     for(let i = 1; i < num; i++) {
//         if (num % i === 0) {
//             sum += i; 
//         }
//     } 
    
//     if (sum === num) {
//         return true;
//     }
    
//     return false; 
// };
// function range (min, max) {
//     let perfectNumbers = '';
//     for (min; min <= max; min++) {
//         if (soverCh(min)) {
//             perfectNumbers = perfectNumbers + min.toString() + ' ';
//         }
//     }

//     if (perfectNumbers !== '') {
//         return perfectNumbers;
//     }

//     return false;
// };

// console.log(range (3, 15000));   
// _____________________________________________________

// let time_ = {
//     h: 5,
//     s: 7
// };
// function dTime(num){
//     if(!isNaN(num)){
//         return num > 9 ? num : '0' + num;
//     }
// }
// function timeStr(obj){
//     return [ 
//     (dTime(obj.h) || '00'), 
//     (dTime(obj.m) || '00'), 
//     (dTime(obj.s) || '00'), 
//     ].join(":");
// }

// time_ = {
//     h: prompt("Введите часы: "),
//     m: prompt("Введите минуты: "),
//     s: prompt("Введите секунды: ")
// }
// alert(timeStr(time_));
// _____________________________________________________

// function timeInSeconds(h, m = 0, s = 0){
//     h *= 3600;
//     m *= 60;
//     let result = h + m + s;
//     return result;
// }

//     let hours = parseInt(prompt("Введите часы: "));
//      let min = parseInt(prompt("Введите минуты: "));
//      let sec =parseInt(prompt("Введите секунды: "));
// alert(`Время в секндах: ${timeInSeconds(hours, min, sec)}`);
// _____________________________________________________________

// let time = (num) => {
//     let hFloat = num / 3600;
//     let hours = Math.floor(hFloat);
//     let min = Math.floor((hFloat - hours) * 60);
//     let sec = num -((min * 60) + (hours * 3600));
//     function zero (num){
//         return num > 9 ? num : `0${num}`;
//     }
//     return `${zero(hours)}:${zero(min)}:${zero(sec)}`;
// }
// let seconds = prompt("Введите секунды: ");
// alert(time(seconds));
// _____________________________________________________________

//10 Не понял