function solve(arr) {
    let result = [];

    for (let i = 0; i < arr.length - 2; i++) {

        let currentKVP = arr[i].split(' ');
        let currKey = currentKVP[0];
        let currValue = currentKVP[1];

        result[currKey] = currValue;
    }

    let neededKey = arr[arr.length - 2];

    if(neededKey in result) {
        console.log(result[neededKey]);
    }
    else {
        console.log('None');
    }
}