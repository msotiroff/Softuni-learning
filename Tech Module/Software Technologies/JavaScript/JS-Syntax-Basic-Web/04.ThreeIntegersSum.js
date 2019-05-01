function threeIntegersSum(arr) {
    let numbers = arr[0].split(' ').map(Number);

    let num1 = numbers[0];
    let num2 = numbers[1];
    let num3 = numbers[2];

    if (num1 === num2 + num3){
        console.log(`${Math.min(num2, num3)} + ${Math.max(num2, num3)} = ${num1}`)
    }
    else if (num2 === num1 + num3){
        console.log(`${Math.min(num1, num3)} + ${Math.max(num1, num3)} = ${num2}`)
    }
    else if(num3 === num2 + num1){
        console.log(`${Math.min(num2, num1)} + ${Math.max(num2, num1)} = ${num3}`)
    }
    else {
        console.log("No")
    }
}