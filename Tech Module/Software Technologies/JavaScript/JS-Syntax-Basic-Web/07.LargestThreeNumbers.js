function largestThreeNumbers(arr) {
    let numbers = arr.map(Number).sort((a, b) => b - a);

    for (let i = 0; i < Math.min(numbers.length, 3); i++) {
        console.log(numbers[i]);
    }
}