function solve(arr) {
    let lenghtOfArray = Number(arr[0]);
    let result = [];

    for (let i = 0; i < lenghtOfArray; i++) {
        result.push(0);
    }

    for (let i = 1; i < arr.length; i++) {

        let current = arr[i].split(' - ');
        let index = Number(current[0]);
        let value = Number(current[1]);
        
        result.splice(index, 1, value);
    }

    console.log(result.join('\n'));
}