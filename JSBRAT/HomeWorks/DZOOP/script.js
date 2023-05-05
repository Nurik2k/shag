// function pow(x, n){
//     if(n === 1){
//         return x;
//     }
//     else{
//         return x * pow(x, n - 1);
//     }
// }
// let num1 = prompt("Введите число: ");
// let num2 = prompt("Введите степень: ");
// alert(pow(num1, num2));
//_____________________________________________

// function findMaxDel(num1, num2){
//     return !num2 ? num1 : findMaxDel(num2, num1 % num2);
// }
// let number1 = prompt("Введите первое число: ");
//  let number2 = prompt("Введите второе число: ");
//  alert(findMaxDel(number1, number2));
//_____________________________________________

// let num = prompt("Введите числа: ");
// let findMaxNum = (num = 0, greatest = 0) => {
//  if(num){
//  const max = Math.max(num % 10, greatest);
//  return findMaxNum(Math.floor(num / 10), max);
//  };
//  return greatest;
// };

// alert(`Максимальная цифра: ${findMaxNum(num)}`); 
//___________________________________________________

// function isPrime(num, div = 3){
//     if(num === 2) return true;
//     if(num < 2 || num % 2 === 0)  return false;
//     if(div * div > num) return true;
//     if(num % div === 0) return false;
//     return isPrime(num, div + 2);
// }
// console.log(isPrime(1)); //-> false
// console.log(isPrime(2)); //-> true
// console.log(isPrime(3)); //-> true
// console.log(isPrime(4)); //-> false
//___________________________________________________
//5 не понял)
//___________________________________________________
function fib(n) {
    return n <= 1 ? n : fib(n - 1) + fib(n - 2);
  }
  let num = parseInt(prompt("Введите число: "));
  alert(fib(num));