// const str1 = "s12";
// function findStrok(str){
//     const sumNumbers = str.match(/\d+/g).join('').length;
//     const sumLetters = str.match(/[a-z]/gi).join('').length;
//     console.log(sumNumbers, sumLetters);
// }
// findStrok(str1);
//_____________________________________________________________

let num = prompt("Введите число: ");
function textToNumber(number) {
    let first = ['Один', 'Два', 'Три', 'Четыре', 'Пять', 'Шесть', 'Семь', 'Восемь', 'Девять'];
    let second = ['Десять', 'Одинадцать', 'Двенадцать', 'Тринадцать', 'Четырнадцать', 'Пятнадцать', 'Шестнадцать', 'Семьнадцать', 'Восемьнадцать', 'Девяднадцать', 'Двадвать'];
    let third = ['Двадцать', 'Тридцать', 'Сорок', 'Пятьдесят', 'Шестьдесят', 'Семьдесят', 'Восемьдесят', 'Девяносто'];
    if (number > 0 && number <= 9) {
      return first[number - 1];
    }
    if(number >= 10 && number <= 20){
        return second[number - 10];
    }
    if(number >= 20 && number <= 99){
        let str = `${number}`;
        str = str.split('');
        let firstNum = str[0];
        let secondNum = str[1];
        return `${third[firstNum - 2]} ${first[secondNum - 1]}`;
    }
}
alert(textToNumber(num));