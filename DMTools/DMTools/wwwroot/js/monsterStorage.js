function AddListToSessionStorage(monsters) {
    console.log("here");
    monsters = JSON.stringify(monsters);
    sessionStorage.removeItem('monsters');
    sessionStorage.setItem('monsters', monsters);
}

function GetMonsterList() {
    let monsters = sessionStorage.getItem('monsters');
    if (monsters !== null) {
        let temp = JSON.parse(monsters);
        return temp;
    }
}