function printLines(arr) {
    let allLines = arr;

    for (let i = 0; i < allLines.length; i++) {
        let currentLine = allLines[i];
        if (currentLine != "Stop"){
            console.log(currentLine);
        }
        else {
            break;
        }
    }
}