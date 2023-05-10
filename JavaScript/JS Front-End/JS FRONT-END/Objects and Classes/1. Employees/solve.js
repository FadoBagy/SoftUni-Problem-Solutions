function solve_1(arr) {
    let employeeObjs = [];
    for (let i = 0; i < arr.length; i++) {
        let employeeObj = {
            Name: arr[i],
            PersonalNumber: arr[i].length
        };
        employeeObjs.push(employeeObj);
    }
    employeeObjs.forEach(employee => {
        console.log(`Name: ${employee.Name} -- Personal Number: ${employee.PersonalNumber}`);
    });
}
