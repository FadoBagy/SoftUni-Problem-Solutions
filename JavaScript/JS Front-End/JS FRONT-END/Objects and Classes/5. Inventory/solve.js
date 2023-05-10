function sovle_5(arr) {
    let heroObjs = [];
    for (let i = 0; i < arr.length; i++) {
        let heroParts = arr[i].split(' / ');
        heroObjs.push({
            Hero: heroParts[0],
            Level: heroParts[1],
            Items: heroParts[2].split(', ')
        });
    }
    heroObjs.sort((a, b) => a.Level - b.Level).forEach(hero => {
        console.log('Hero: ' + hero.Hero);
        console.log('level => ' + hero.Level);
        console.log('items => ' + hero.Items.join(', '));
    });
}
