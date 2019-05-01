function solve(arr) {

    function TryParseInt(str, defaultValue) {
        var retValue = defaultValue;
        if(str !== null){
                if (!isNaN(str)) {
                    retValue = parseInt(str);
                }

        }
        return retValue;
    }

    let currentObj = {};

    for (let i = 0; i < arr.length; i++) {
        let currentProp = arr[i].split(' -> ');
        let property = currentProp[0];
        let value = TryParseInt(currentProp[1], currentProp[1]);


        currentObj[property] = value;
    }

    console.log(JSON.stringify(currentObj));
}

// solve(['name -> Angel','surname -> Georgiev','age -> 20','grade -> 6.00','date -> 23/05/1995'])