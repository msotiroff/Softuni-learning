function solve(arr) {
    let result = {};

    for (let i = 0; i < arr.length - 2; i++) {

        let currentKVP = arr[i].split(' ');
        let currKey = currentKVP[0];
        let currValue = currentKVP[1];

        let currentObject = {"key":currKey,"value":currValue};

        if (currentObject.key in result) {
            result[currKey].push(currValue)
        }
        else {
            result[currKey] = new Array(currValue);
        }
    }
    let allKeys = Object.keys(result);
    let neededKey = arr[arr.length - 2];

    for (let i = 0; i < allKeys.length; i++) {
        if (neededKey === allKeys[i]){
            console.log(result[neededKey].join('\n'));
            break;
        }
        if (i == allKeys.length - 1) {
            console.log('None');
        }
    }
}