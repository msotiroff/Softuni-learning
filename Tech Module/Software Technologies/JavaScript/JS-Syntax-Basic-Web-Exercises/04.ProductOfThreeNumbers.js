function product(arr) {
    let numbers = arr.map(Number);
    let countOfNegatives = 0;
    for (let i = 0; i < numbers.length; i++) {
         if (numbers[i] < 0) {
             countOfNegatives++;
         }
    }
    
    if (countOfNegatives % 2 !== 0) {
        return "Negative";
    }
    return "Positive"
}