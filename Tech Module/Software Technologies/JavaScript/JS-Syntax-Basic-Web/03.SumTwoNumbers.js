function sumTwoNumbers(arr) {
    let result = arr.map(Number).reduce((a, b) => a + b);

    console.log(result);
}