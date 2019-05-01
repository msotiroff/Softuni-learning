function solve(arr) {
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        let commands = arr[i].split(' ');
        let currentCommand = commands[0];
        let currentElement = commands[1];

        if (currentCommand === 'add') {
            result.push(currentElement);
        }
        else if(currentCommand === 'remove') {
            result.splice(currentElement, 1);
        }
    }

    console.log(result.join('\n'));
}