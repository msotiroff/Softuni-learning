function solve(arr) {
    let allObjects = [];

    for (let i = 0; i < arr.length; i++) {
        let currentObject = JSON.parse(arr[i]);

        allObjects.push(currentObject);
    }

    if (allObjects.length > 0) {
        for (object of allObjects) {
            console.log(`Name: ${object.name}`);
            console.log(`Age: ${object.age}`);
            console.log(`Date: ${object.date}`);
        }
    }
}

// solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}', '{"name":"Tosho","age":11,"date":"04/04/2005"}'])