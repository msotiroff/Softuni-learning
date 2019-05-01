function sumsByTown(arr) {
    let townData = {};

    for (let i = 0; i < arr.length; i++) {

        let currentObject = JSON.parse(arr[i]);

        if (currentObject.town in townData) {
            townData[currentObject.town] += currentObject.income;
        }
        else {
            townData[currentObject.town] = currentObject.income;
        }
    }

    let allTowns = Object.keys(townData).sort();

    for (let i = 0; i < allTowns.length; i++) {

        console.log(`${allTowns[i]} -> ${townData[allTowns[i]]}`)
    }
}