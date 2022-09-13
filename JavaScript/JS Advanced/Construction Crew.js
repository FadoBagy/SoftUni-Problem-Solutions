function solve(worker) {
    if (worker.dizziness == true) {
        let requiredAmountWater = worker.weight * 0.1 * worker.experience;
        worker.levelOfHydrated += requiredAmountWater;
        worker.dizziness = false;
    }
    console.log(worker);
    return worker;
}