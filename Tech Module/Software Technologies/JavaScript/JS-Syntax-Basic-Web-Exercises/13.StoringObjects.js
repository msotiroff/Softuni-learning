function solve(arr) {
    function Student(name, age, grade) {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }

    let allStudents = [];

    for (let i = 0; i < arr.length; i++) {
        let currentStudentData = arr[i].split(' -> ');

        let currentStudent = new Student(
            currentStudentData[0],
            currentStudentData[1],
            currentStudentData[2]
        )

        allStudents.push(currentStudent);
    }
    
    for (let student of allStudents) {
        console.log(`Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Grade: ${student.grade}`);
    }
}
// solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90'])